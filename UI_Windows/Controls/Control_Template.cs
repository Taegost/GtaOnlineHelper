using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace UI_Windows.Controls
{
    public partial class Control_Template : UserControl
    {
        public string ToolName { get; protected set; }
        public string SaveDirectory { get; protected set; }

        public Control_Template()
        {
            InitializeComponent();
        }

        public Control_Template(string saveDirectory)
        {
            InitializeComponent();
            Visible = false;
            SaveDirectory = saveDirectory;
        } // constructor
    } // class Control_Template
}
