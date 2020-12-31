using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GTA_Online_Helper.Shared;

namespace GTAOnlineHelper.Controls
{
    public partial class Ctl_Business : UserControl
    {
        private Business CurrentBusiness { get; set; }

        public event EventHandler DataChanged;

        protected virtual void OnDataChanged()
        {
            EventHandler handler = DataChanged;
            handler?.Invoke(this, new EventArgs());
        } // event OnDataChanged

        public Ctl_Business()
        {
            InitializeComponent();
        } // constructor

        public Ctl_Business(Business business)
        {
            InitializeComponent();
            CurrentBusiness = business;
            LoadBusinessData();
        } // constructor

        private void LoadBusinessData()
        {
            lbl_Name.Text = CurrentBusiness.Name;
            foreach (BusinessUpgrade upgrade in CurrentBusiness.Upgrades) { AddCheckBoxesForUpgrades(upgrade); }
            UpdateBusinessData();
        } // method LoadBusinessData

        private void UpdateBusinessData()
        {
            txt_LocalTwo.Text = CurrentBusiness.GetTwoVehicleLocalThresholdValue().ToString();
            txt_LocalThree.Text = CurrentBusiness.GetThreeVehicleLocalThresholdValue().ToString();
            txt_LocalFour.Text = CurrentBusiness.GetFourVehicleLocalThresholdValue().ToString();
            txt_LosSantosTwo.Text = CurrentBusiness.GetTwoVehicleLosSantosThresholdValue().ToString();
            txt_LosSantosThree.Text = CurrentBusiness.GetThreeVehicleLosSantosThresholdValue().ToString();
            txt_LosSantosFour.Text = CurrentBusiness.GetFourVehicleLosSantosThresholdValue().ToString();
            txt_DailyUpkeep.Text = CurrentBusiness.CurrentDailyUpkeep.ToString();
        }

        private void AddCheckBoxesForUpgrades(BusinessUpgrade upgrade)
        {
            CheckBox newCheckBox = new CheckBox
            {
                Text = upgrade.Name,
                Margin = new Padding(-3, -3, -3, -3),
                Checked = upgrade.Active
            };
            pnl_Upgrades.Controls.Add(newCheckBox);
            newCheckBox.CheckedChanged += new EventHandler(CheckBoxToggled);
        } // AddCheckBoxesForUpgrades

        private void CheckBoxToggled(object sender, EventArgs e)
        {
            foreach (BusinessUpgrade upgrade in CurrentBusiness.Upgrades)
            {
                if (upgrade.Name == (sender as CheckBox).Text) { upgrade.Active = (sender as CheckBox).Checked; }
            }
            UpdateBusinessData();
            OnDataChanged();
        } // method ToolButtonClicked
    } // class Ctl_Business
}
