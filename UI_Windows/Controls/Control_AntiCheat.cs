using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using UI_Windows.Controls;
using System.Diagnostics;
using System.Threading;
using System.Runtime.InteropServices;

namespace UI_Windows
{
    public partial class Control_AntiCheat : Control_Template
    {
        private bool newLobbyInUse = false;
        private string gtaProcessName = "gta5";

        public Control_AntiCheat(string saveDirectory) : base(saveDirectory)
        {
            InitializeComponent();
            ToolName = "Anti-Cheat";
        } // constructor

        #region "Private Methods"

        private delegate void UpdateNewLobbyStatusDelegate(string newStatus);
        private void UpdateNewLobbyStatus(string newStatus)
        {
            if (txt_NewLobbyStatus.InvokeRequired)
                txt_NewLobbyStatus.Invoke(new UpdateNewLobbyStatusDelegate(UpdateNewLobbyStatus), newStatus); 
            else
                if (!string.IsNullOrEmpty(newStatus)) { txt_NewLobbyStatus.Text = newStatus; }
        } // method UpdateNewLobbyStatus

        private void GetNewLobby()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Embedded", "bin", "pssuspend64.exe");
            if (File.Exists(filePath))
            {
                newLobbyInUse = true;
                UpdateNewLobbyStatus("Getting a new lobby, please wait");

                ProcessStartInfo gtaProcess = new ProcessStartInfo();
                gtaProcess.CreateNoWindow = true;
                gtaProcess.UseShellExecute = false;
                gtaProcess.FileName = filePath;
                gtaProcess.WindowStyle = ProcessWindowStyle.Hidden;
                gtaProcess.Arguments = gtaProcessName;
                gtaProcess.Verb = "runas";

                try
                {
                    Process.Start(gtaProcess);
                    Thread.Sleep(10000);
                    gtaProcess.Arguments = $"-r {gtaProcessName}";
                    Process.Start(gtaProcess);
                    UpdateNewLobbyStatus("New lobby complete, please check in game");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                { newLobbyInUse = false; }
            } // if (File.Exists(filePath))
        } // method GetNewLobby

        #endregion // Private Methods

        #region "Interface Methods"

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

        private void Control_AntiCheat_Load(object sender, EventArgs e)
        {

            // Give the button the flat style and make it
            // display the UAC shield.
            const Int32 BCM_SETSHIELD = 0x160C;
            btn_NewLobby.FlatStyle = System.Windows.Forms.FlatStyle.System;
            SendMessage(btn_NewLobby.Handle, BCM_SETSHIELD, 0, 1);
        } // Control_AntiCheat_Load

        private void btn_NewLobby_Click(object sender, EventArgs e)
        {
            if (newLobbyInUse)
                MessageBox.Show("New lobby is currently working, please be patient"); 
            else
            {
                Process[] processName = Process.GetProcessesByName(gtaProcessName);
                if (processName.Length == 0)
                {
                    string msg = "GTA5 is not currently running!";
                    UpdateNewLobbyStatus(msg);
                    MessageBox.Show(msg);
                }
                else
                {
                    Thread workerThread = new Thread(GetNewLobby);
                    workerThread.Start();
                }
            } // if (newLobbyInUse)
        } // method btn_NewLobby_Click

        #endregion // Interface Methods

    } // class Control_AntiCheat
} // namespace
