using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using GTA_Online_Helper;
using Newtonsoft.Json;
using UI_Windows.Forms;

namespace UI_Windows.Controls
{
    public partial class CTL_VehicleCargo : Control_Template
    {
        private List<Vc_Vehicle> currentVehicles = new List<Vc_Vehicle>();
        
        private string SAVEFILE = "";
        public CTL_VehicleCargo(string saveDirectory) : base(saveDirectory)
        {
            InitializeComponent();
            ToolName = "Vehicle Cargo";
            
            SAVEFILE = Path.Combine(SaveDirectory, "CurrentVehicles.json");
            LoadVehicleList();
        } // constructor

        private Vc_Vehicle GetCurrentlySelectedVehicle()
        {
            Vc_Vehicle returnValue = null;
            if (!(lst_CurrentVehicles.SelectedIndex == -1))
            {
                foreach (Vc_Vehicle vehicle in currentVehicles)
                {
                    if (lst_CurrentVehicles.SelectedItem.ToString() == ($"{vehicle.Name} - {vehicle.Plate}")) { returnValue = vehicle; }
                }
            }
            return returnValue;
        } // method GetCurrentlySelectedVehicle

        private void AddVehicleToList(Vc_Vehicle newVehicle)
        {
            currentVehicles.Add(newVehicle);
            lst_CurrentVehicles.Items.Add($"{newVehicle.Name} - {newVehicle.Plate}");
            SaveVehicleList();
        } // method AddVehicleToList

        private void RemoveVehicleFromList(Vc_Vehicle removeVehicle)
        {
            if (!(lst_CurrentVehicles.SelectedIndex == -1))
            {
                Vc_Vehicle vehicleToRemove = GetCurrentlySelectedVehicle();

                currentVehicles.Remove(vehicleToRemove);
                lst_CurrentVehicles.Items.RemoveAt(lst_CurrentVehicles.SelectedIndex);
                SaveVehicleList();
            }
        } // method RemoveVehicleFromList

        private void SaveVehicleList()
        {
            if (!(Directory.Exists(SaveDirectory))) { Directory.CreateDirectory(SaveDirectory); }   
            using ( StreamWriter writer = new StreamWriter(SAVEFILE) )
            {
                string json = JsonConvert.SerializeObject(currentVehicles, Formatting.Indented);
                writer.Write(json);
            }
        } // method SaveVehicleList

        private void LoadVehicleList()
        {
            if (File.Exists(SAVEFILE))
            {
                List<Vc_Vehicle> loadedVehicles = null;
                using (StreamReader reader = new StreamReader(SAVEFILE))
                {
                        loadedVehicles = JsonConvert.DeserializeObject<List<Vc_Vehicle>>(reader.ReadToEnd());
                }
                if (!(loadedVehicles == null) && (loadedVehicles.Count > 0))
                {
                    foreach (Vc_Vehicle vehicle in loadedVehicles)
                    {
                        AddVehicleToList(vehicle);
                    }
                    UpdateInterface();
                }
            } // if (File.Exists(SAVEFILE))
        } // method LoadVehicleList

        private void UpdateInterface()
        {
            btn_RemoveVehicle.Enabled = (lst_CurrentVehicles.Items.Count > 0);

            // Updates completed collections
            List<string> completedCollections = new Vc_Vehicles().GetCompletedCollectionsFromList(currentVehicles);
            if (completedCollections.Count > 0)
            {
                foreach (string collection in completedCollections) { if (!lst_CompleteCollections.Items.Contains(collection)) { lst_CompleteCollections.Items.Add(collection); } }
            }
            else { lst_CompleteCollections.Items.Clear(); }

            // Updates vehicles by range that aren't in a collection
            foreach (Vc_Vehicle vehicle in currentVehicles)
            {
                switch (vehicle.Range)
                {
                    case "Top":
                        if ((!vehicle.InCollection()) && (!lst_TopRange.Items.Contains(vehicle.GetNameAndPlate()))) { lst_TopRange.Items.Add(vehicle.GetNameAndPlate()); }
                        break;
                    case "Mid":
                        if ((!vehicle.InCollection()) && (!lst_MidRange.Items.Contains(vehicle.GetNameAndPlate()))) { lst_MidRange.Items.Add(vehicle.GetNameAndPlate()); }
                        break;
                    case "Standard":
                        if ((!vehicle.InCollection()) && (!lst_StandardRange.Items.Contains(vehicle.GetNameAndPlate()))) { lst_StandardRange.Items.Add(vehicle.GetNameAndPlate()); }
                        break;
                    case "Default":
                        throw new ArgumentException($"The range {vehicle.Range} for vehicle {vehicle.GetNameAndPlate()} is not valid");
                } // switch (vehicle.Range)
            }
        } // method UpdateInterface

        private void btn_AddVehicle_Click(object sender, EventArgs e)
        {
            Frm_AddVehicle addVehicleForm = new Frm_AddVehicle();
            addVehicleForm.ShowDialog();
            if (addVehicleForm.VehicleAdded) 
            { AddVehicleToList(addVehicleForm.SelectedVehicle); }
            UpdateInterface();
        } // event btn_AddVehicle_Click

        private void btn_RemoveVehicle_Click(object sender, EventArgs e)
        {
            if (!(lst_CurrentVehicles.SelectedIndex == -1))
            {
                Vc_Vehicle selectedVehicle = GetCurrentlySelectedVehicle();
                DialogResult dialogResult = MessageBox.Show($"Are you sure you want to remove {selectedVehicle.Name} - {selectedVehicle.Plate}?", "Remove vehicle?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes) { RemoveVehicleFromList(selectedVehicle); }
            }
            UpdateInterface();
        } // event btn_RemoveVehicle_Click
    } // class CTL_VehicleCargo
}
