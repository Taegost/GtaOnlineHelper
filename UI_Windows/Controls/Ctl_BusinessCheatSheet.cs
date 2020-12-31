using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using UI_Windows.Controls;
using GTA_Online_Helper.Shared;
using Newtonsoft.Json;
using GTAOnlineHelper.Controls;

namespace UI_Windows.Controls
{
    public partial class Ctl_BusinessCheatSheet : Control_Template
    {
        private List<Business> BusinessList { get; set; }

        public Ctl_BusinessCheatSheet(string saveDirectory) : base(saveDirectory)
        {
            InitializeComponent();
            Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ToolName = "Business CheatSheet";
            SaveFile = Path.Combine(SaveDirectory, "CurrentBusinesses.json");
            LoadBusinessData();
        } // constructor

        private void LoadBusinessData()
        {
            if (File.Exists(SaveFile))
            {
                using (StreamReader reader = new StreamReader(SaveFile))
                {
                    BusinessList = JsonConvert.DeserializeObject<List<Business>>(reader.ReadToEnd());
                }
            } // if (File.Exists(SaveFile))
            
            if ((BusinessList == null) || (BusinessList.Count == 0)) { BusinessList = new Businesses().FullBusinessList; }
            foreach (Business business in BusinessList)
            {
                Ctl_Business businessControl = new Ctl_Business(business);
                pnl_Main.Controls.Add(businessControl);
                businessControl.DataChanged += DataChangedHandler;
            }
        } // method LoadBusinessData

        private void SaveBusinessData()
        {
            if (!(Directory.Exists(SaveDirectory))) { Directory.CreateDirectory(SaveDirectory); }
            using (StreamWriter writer = new StreamWriter(SaveFile))
            {
                string json = JsonConvert.SerializeObject(BusinessList, Formatting.Indented);
                writer.Write(json);
            }
        } // SaveBusinessData

        private void DataChangedHandler(object sender, EventArgs e)
        {
            SaveBusinessData();
        } // event handler DataChangedHandler

    } // class Ctl_BusinessCheatSheet
}
