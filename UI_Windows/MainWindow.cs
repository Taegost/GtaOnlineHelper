using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using UI_Windows.Controls;

namespace UI_Windows
{
    public partial class MainWindow : Form
    {
        private List<Control_Template> toolList = new List<Control_Template>(); // List of controls
        public string SaveDirectory { get; private set; }
        public MainWindow()
        {
            InitializeComponent();

            SaveDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), System.AppDomain.CurrentDomain.FriendlyName);
#if DEBUG
            SaveDirectory = Path.Combine(SaveDirectory, "Debug");
#endif
            // Add tools to the panel
            AddTool(new Control_AntiCheat(SaveDirectory));
            AddTool(new CTL_VehicleCargo(SaveDirectory));

            foreach (UserControl tool in toolList) { pnl_Main.Controls.Add(tool); }
        }

        private void AddTool(Control_Template newControl)
        {
            toolList.Add(newControl);
        } // method AddTool

        private void ShowTool(string toolName)
        {
            foreach (Control_Template tool in toolList)
            {
                tool.Visible = tool.ToolName == toolName;
            }
        } // method ShowTool

        private void btn_AntiCheat_Click(object sender, EventArgs e)
        {
            ShowTool("Anti-Cheat");
        } // btn_AntiCheat_Click

        private void btn_VehicleCargo_Click(object sender, EventArgs e)
        {
            ShowTool("Vehicle Cargo");
        }
    } // class MainWindow
} // namespace
