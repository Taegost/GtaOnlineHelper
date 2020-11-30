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

        }

        private void AddTool(Control_Template newControl)
        {
            toolList.Add(newControl);

            // Creates and adds the buttons for the tool
            int buttonHeight = 23;
            int buttonWidth = 94;
            int buttonPadding = (pnl_Navigation.Width - buttonWidth) / 2;
            Button newButton = new Button();
            newButton.Text = newControl.ToolName;
            newButton.Size = new Size(buttonWidth, buttonHeight);
            newButton.Location = new Point(0, ((toolList.Count - 1) * buttonHeight));
            newButton.BackColor = Color.Gainsboro;
            newButton.TextAlign = ContentAlignment.MiddleCenter;
            newButton.Visible = true;
            newButton.Left = buttonPadding;
            pnl_Navigation.Controls.Add(newButton);

            pnl_Main.Controls.Add(newControl);

            newButton.Click += new EventHandler(ToolButtonClicked);
        } // method AddTool

        private void ToolButtonClicked(object sender, EventArgs e)
        {
            foreach (Control_Template tool in toolList)
            {
                tool.Visible = tool.ToolName == (sender as Button).Text;
            }
        } // method ToolButtonClicked
    } // class MainWindow
} // namespace
