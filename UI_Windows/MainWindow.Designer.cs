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
            this.sts_Bottom = new System.Windows.Forms.StatusStrip();
            this.pnl_Main = new System.Windows.Forms.Panel();
            this.pnl_Navigation = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // mnu_Top
            // 
            this.mnu_Top.Location = new System.Drawing.Point(0, 0);
            this.mnu_Top.Name = "mnu_Top";
            this.mnu_Top.Size = new System.Drawing.Size(936, 24);
            this.mnu_Top.TabIndex = 0;
            // 
            // sts_Bottom
            // 
            this.sts_Bottom.Location = new System.Drawing.Point(0, 491);
            this.sts_Bottom.Name = "sts_Bottom";
            this.sts_Bottom.Size = new System.Drawing.Size(936, 22);
            this.sts_Bottom.TabIndex = 2;
            // 
            // pnl_Main
            // 
            this.pnl_Main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_Main.Location = new System.Drawing.Point(131, 28);
            this.pnl_Main.Name = "pnl_Main";
            this.pnl_Main.Size = new System.Drawing.Size(805, 460);
            this.pnl_Main.TabIndex = 3;
            // 
            // pnl_Navigation
            // 
            this.pnl_Navigation.Location = new System.Drawing.Point(0, 27);
            this.pnl_Navigation.Name = "pnl_Navigation";
            this.pnl_Navigation.Size = new System.Drawing.Size(125, 398);
            this.pnl_Navigation.TabIndex = 4;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 513);
            this.Controls.Add(this.pnl_Navigation);
            this.Controls.Add(this.pnl_Main);
            this.Controls.Add(this.sts_Bottom);
            this.Controls.Add(this.mnu_Top);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GTA Online Helper";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnu_Top;
        private System.Windows.Forms.StatusStrip sts_Bottom;
        private System.Windows.Forms.Panel pnl_Main;
        private System.Windows.Forms.Panel pnl_Navigation;
    }
}