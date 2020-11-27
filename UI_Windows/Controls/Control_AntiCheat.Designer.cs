namespace UI_Windows
{
    partial class Control_AntiCheat
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_EnableFirewall = new System.Windows.Forms.Button();
            this.btn_DisableFirewall = new System.Windows.Forms.Button();
            this.btn_NewLobby = new System.Windows.Forms.Button();
            this.txt_NewLobbyStatus = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_EnableFirewall
            // 
            this.btn_EnableFirewall.Location = new System.Drawing.Point(14, 12);
            this.btn_EnableFirewall.Name = "btn_EnableFirewall";
            this.btn_EnableFirewall.Size = new System.Drawing.Size(108, 23);
            this.btn_EnableFirewall.TabIndex = 0;
            this.btn_EnableFirewall.Text = "Enable Firewall";
            this.btn_EnableFirewall.UseVisualStyleBackColor = true;
            // 
            // btn_DisableFirewall
            // 
            this.btn_DisableFirewall.Location = new System.Drawing.Point(14, 42);
            this.btn_DisableFirewall.Name = "btn_DisableFirewall";
            this.btn_DisableFirewall.Size = new System.Drawing.Size(108, 23);
            this.btn_DisableFirewall.TabIndex = 1;
            this.btn_DisableFirewall.Text = "Disable Firewall";
            this.btn_DisableFirewall.UseVisualStyleBackColor = true;
            // 
            // btn_NewLobby
            // 
            this.btn_NewLobby.Location = new System.Drawing.Point(14, 72);
            this.btn_NewLobby.Name = "btn_NewLobby";
            this.btn_NewLobby.Size = new System.Drawing.Size(108, 23);
            this.btn_NewLobby.TabIndex = 2;
            this.btn_NewLobby.Text = "New Lobby";
            this.btn_NewLobby.UseVisualStyleBackColor = true;
            this.btn_NewLobby.Click += new System.EventHandler(this.btn_NewLobby_Click);
            // 
            // txt_NewLobbyStatus
            // 
            this.txt_NewLobbyStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_NewLobbyStatus.Location = new System.Drawing.Point(129, 71);
            this.txt_NewLobbyStatus.Name = "txt_NewLobbyStatus";
            this.txt_NewLobbyStatus.ReadOnly = true;
            this.txt_NewLobbyStatus.Size = new System.Drawing.Size(293, 23);
            this.txt_NewLobbyStatus.TabIndex = 3;
            // 
            // Control_AntiCheat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txt_NewLobbyStatus);
            this.Controls.Add(this.btn_NewLobby);
            this.Controls.Add(this.btn_DisableFirewall);
            this.Controls.Add(this.btn_EnableFirewall);
            this.Name = "Control_AntiCheat";
            this.Size = new System.Drawing.Size(422, 150);
            this.Load += new System.EventHandler(this.Control_AntiCheat_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_EnableFirewall;
        private System.Windows.Forms.Button btn_DisableFirewall;
        private System.Windows.Forms.Button btn_NewLobby;
        private System.Windows.Forms.TextBox txt_NewLobbyStatus;
    }
}
