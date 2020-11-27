using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GTA_Online_Helper;

namespace UI_Windows.Forms
{
    public partial class Frm_AddVehicle : Form
    {
        private Vc_Vehicles vehicleList = new Vc_Vehicles();
        public Vc_Vehicle SelectedVehicle { get; set; }
        public bool VehicleAdded { get; set; }
        public Frm_AddVehicle()
        {
            InitializeComponent();

            foreach (string vehicle in (vehicleList.GetUniqueVehicleNames()))
            {
                lst_VehicleNames.Items.Add(vehicle);
            }

        } // constructor

        private void btn_Add_Click(object sender, EventArgs e)
        {
            SelectedVehicle = vehicleList.GetVehicleByNameAndPlate(lst_VehicleNames.SelectedItem.ToString(), lst_Plates.SelectedItem.ToString());
            VehicleAdded = true;
            this.Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            VehicleAdded = false;
            this.Close();
        }

        private void lst_VehicleNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> plates = vehicleList.GetPlatesForVehicle(lst_VehicleNames.SelectedItem.ToString());
            lst_Plates.Items.Clear();
            // lst_Plates_SelectedIndexChanged isn't being fired when lst_Plates.ClearSelected() is called, so I've put the code to disable the button here as well.
            lst_Plates.ClearSelected(); 
            btn_Add.Enabled = !(lst_Plates.SelectedIndex <= -1);
            foreach (string plate in plates) { lst_Plates.Items.Add(plate); }
        }

        private void lst_Plates_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_Add.Enabled = !(lst_Plates.SelectedIndex <= -1);
        }
    } // class Frm_AddVehicle
}
