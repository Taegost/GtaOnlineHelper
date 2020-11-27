namespace UI_Windows
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mnu_Top = new System.Windows.Forms.MenuStrip();
            this.grp_Tools = new System.Windows.Forms.GroupBox();
            this.btn_AntiCheat = new System.Windows.Forms.Button();
            this.btn_VehicleCargo = new System.Windows.Forms.Button();
            this.sts_Bottom = new System.Windows.Forms.StatusStrip();
            this.pnl_Main = new System.Windows.Forms.Panel();
            this.grp_Tools.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnu_Top
            // 
            this.mnu_Top.Location = new System.Drawing.Point(0, 0);
            this.mnu_Top.Name = "mnu_Top";
            this.mnu_Top.Size = new System.Drawing.Size(800, 24);
            this.mnu_Top.TabIndex = 0;
            // 
            // grp_Tools
            // 
            this.grp_Tools.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grp_Tools.AutoSize = true;
            this.grp_Tools.Controls.Add(this.btn_AntiCheat);
            this.grp_Tools.Controls.Add(this.btn_VehicleCargo);
            this.grp_Tools.Location = new System.Drawing.Point(13, 28);
            this.grp_Tools.Name = "grp_Tools";
            this.grp_Tools.Size = new System.Drawing.Size(111, 397);
            this.grp_Tools.TabIndex = 1;
            this.grp_Tools.TabStop = false;
            this.grp_Tools.Text = "Tools";
            // 
            // btn_AntiCheat
            // 
            this.btn_AntiCheat.Location = new System.Drawing.Point(6, 22);
            this.btn_AntiCheat.Name = "btn_AntiCheat";
            this.btn_AntiCheat.Size = new System.Drawing.Size(93, 23);
            this.btn_AntiCheat.TabIndex = 1;
            this.btn_AntiCheat.Text = "Anti-Cheat";
            this.btn_AntiCheat.UseVisualStyleBackColor = true;
            this.btn_AntiCheat.Click += new System.EventHandler(this.btn_AntiCheat_Click);
            // 
            // btn_VehicleCargo
            // 
            this.btn_VehicleCargo.Location = new System.Drawing.Point(6, 51);
            this.btn_VehicleCargo.Name = "btn_VehicleCargo";
            this.btn_VehicleCargo.Size = new System.Drawing.Size(94, 23);
            this.btn_VehicleCargo.TabIndex = 0;
            this.btn_VehicleCargo.Text = "Vehicle Cargo";
            this.btn_VehicleCargo.UseVisualStyleBackColor = true;
            this.btn_VehicleCargo.Click += new System.EventHandler(this.btn_VehicleCargo_Click);
            // 
            // sts_Bottom
            // 
            this.sts_Bottom.Location = new System.Drawing.Point(0, 428);
            this.sts_Bottom.Name = "sts_Bottom";
            this.sts_Bottom.Size = new System.Drawing.Size(800, 22);
            this.sts_Bottom.TabIndex = 2;
            // 
            // pnl_Main
            // 
            this.pnl_Main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_Main.Location = new System.Drawing.Point(131, 28);
            this.pnl_Main.Name = "pnl_Main";
            this.pnl_Main.Size = new System.Drawing.Size(669, 397);
            this.pnl_Main.TabIndex = 3;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnl_Main);
            this.Controls.Add(this.sts_Bottom);
            this.Controls.Add(this.grp_Tools);
            this.Controls.Add(this.mnu_Top);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GTA Online Helper";
            this.grp_Tools.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnu_Top;
        private System.Windows.Forms.GroupBox grp_Tools;
        private System.Windows.Forms.StatusStrip sts_Bottom;
        private System.Windows.Forms.Button btn_VehicleCargo;
        private System.Windows.Forms.Button btn_AntiCheat;
        private System.Windows.Forms.Panel pnl_Main;
    }
}