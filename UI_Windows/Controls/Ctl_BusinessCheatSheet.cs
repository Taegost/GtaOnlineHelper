using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using UI_Windows.Controls;

namespace UI_Windows.Controls
{
    public partial class Ctl_BusinessCheatSheet : Control_Template
    {
        public Ctl_BusinessCheatSheet(string saveDirectory) : base(saveDirectory)
        {
            InitializeComponent();

            ToolName = "Business CheatSheet";

            SaveFile = Path.Combine(SaveDirectory, "CurrentBusinessSetup.json");
        }
    } // class Ctl_BusinessCheatSheet
}
