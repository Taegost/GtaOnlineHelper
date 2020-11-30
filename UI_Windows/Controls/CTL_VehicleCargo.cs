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

        private void AddVehicleToList(Vc_Vehicle newVehicle)
        {
            currentVehicles.Add(newVehicle);
            lst_CurrentVehicles.Items.Add(newVehicle.GetNameAndPlate());
            SaveVehicleList();
            UpdateInterface();
        } // method AddVehicleToList

        private void RemoveVehicleFromList(Vc_Vehicle vehicleToRemove)
        {
            // This is a little hacky for now because currentVehicles.Remove isn't working when passing in vehicleToRemove, even if it's identical
            foreach (Vc_Vehicle vehicle in currentVehicles)
            {
                if (vehicle.GetNameAndPlate().Equals(vehicleToRemove.GetNameAndPlate()))
                {
                    currentVehicles.Remove(vehicle);
                    break;
                } // if (vehicle.GetNameAndPlate().Equals(vehicleToRemove.GetNameAndPlate()))
            } // foreach (Vc_Vehicle vehicle in currentVehicles)
            lst_CurrentVehicles.Items.Remove(vehicleToRemove.GetNameAndPlate());
            SaveVehicleList();
            UpdateInterface();
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
            lst_CompleteCollections.Items.Clear();
            Vc_Vehicles fullVehicleList = new Vc_Vehicles();
            if (completedCollections.Count > 0)
            {
                foreach (string collection in completedCollections) 
                {
                    string collectionString = $"{collection} - {fullVehicleList.GetNumberOfDriversByCollection(collection)}";
                    if (!lst_CompleteCollections.Items.Contains(collectionString)) { lst_CompleteCollections.Items.Add(collectionString); } }
            }

            // Updates vehicles by range that aren't in a collection
            lst_TopRange.Items.Clear();
            lst_MidRange.Items.Clear();
            lst_StandardRange.Items.Clear();
            foreach (Vc_Vehicle vehicle in currentVehicles)
            {
                if (vehicle.InCollection()) { continue; }
                    switch (vehicle.Range)
                {
                    case "Top":
                        if (!lst_TopRange.Items.Contains(vehicle.GetNameAndPlate())) { lst_TopRange.Items.Add(vehicle.GetNameAndPlate()); }
                        break;
                    case "Mid":
                        if (!lst_MidRange.Items.Contains(vehicle.GetNameAndPlate())) { lst_MidRange.Items.Add(vehicle.GetNameAndPlate()); }
                        break;
                    case "Standard":
                        if (!lst_StandardRange.Items.Contains(vehicle.GetNameAndPlate())) { lst_StandardRange.Items.Add(vehicle.GetNameAndPlate()); }
                        break;
                    case "Default":
                        throw new ArgumentException($"The range {vehicle.Range} for vehicle {vehicle.GetNameAndPlate()} is not valid");
                } // switch (vehicle.Range)
            } // foreach (Vc_Vehicle vehicle in currentVehicles)

            int totalWarehouseSlots = 40;
            int warehouseFillPercentage = (int)(Math.Ceiling((double)currentVehicles.Count / totalWarehouseSlots * 100));
            lbl_VehicleCount.Text = $"{currentVehicles.Count}/{totalWarehouseSlots}  {warehouseFillPercentage}% full";
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
            if (lst_CurrentVehicles.SelectedItems.Count > 0)
            {
                Vc_Vehicles fullVehicleList = new Vc_Vehicles();
                List<Vc_Vehicle> vehiclesToRemove = new List<Vc_Vehicle>();

                foreach (string selectedItem in lst_CurrentVehicles.SelectedItems)
                {
                    string[] vehicleParts = selectedItem.Split(" - ");
                    vehiclesToRemove.Add(fullVehicleList.GetVehicleByNameAndPlate(vehicleParts[0], vehicleParts[1]));
                } // foreach (string selectedItem in lst_CurrentVehicles.SelectedItems)

                string vehiclesToRemoveVerification = "";
                foreach (Vc_Vehicle vehicle in vehiclesToRemove) { vehiclesToRemoveVerification += $"\n{vehicle.GetNameAndPlate()}"; }
                DialogResult dialogResult = MessageBox.Show($"Are you sure you want to remove the following vehicle(s)?\n{vehiclesToRemoveVerification}", "Remove vehicle?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes) { foreach (Vc_Vehicle vehicle in vehiclesToRemove) { RemoveVehicleFromList(vehicle); } }
                UpdateInterface();
            } // if (lst_CurrentVehicles.SelectedItems.Count > 0)
        } // event btn_RemoveVehicle_Click
    } // class CTL_VehicleCargo
}
