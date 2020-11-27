
namespace UI_Windows.Controls
{
    partial class CTL_VehicleCargo
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
            this.lst_CurrentVehicles = new System.Windows.Forms.ListBox();
            this.lbl_CurrentVehicles = new System.Windows.Forms.Label();
            this.btn_AddVehicle = new System.Windows.Forms.Button();
            this.btn_RemoveVehicle = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lst_CompleteCollections = new System.Windows.Forms.ListBox();
            this.lst_TopRange = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lst_MidRange = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lst_StandardRange = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lst_CurrentVehicles
            // 
            this.lst_CurrentVehicles.FormattingEnabled = true;
            this.lst_CurrentVehicles.ItemHeight = 15;
            this.lst_CurrentVehicles.Location = new System.Drawing.Point(18, 40);
            this.lst_CurrentVehicles.Name = "lst_CurrentVehicles";
            this.lst_CurrentVehicles.Size = new System.Drawing.Size(120, 349);
            this.lst_CurrentVehicles.Sorted = true;
            this.lst_CurrentVehicles.TabIndex = 0;
            // 
            // lbl_CurrentVehicles
            // 
            this.lbl_CurrentVehicles.AutoSize = true;
            this.lbl_CurrentVehicles.Location = new System.Drawing.Point(18, 19);
            this.lbl_CurrentVehicles.Name = "lbl_CurrentVehicles";
            this.lbl_CurrentVehicles.Size = new System.Drawing.Size(92, 15);
            this.lbl_CurrentVehicles.TabIndex = 1;
            this.lbl_CurrentVehicles.Text = "Current Vehicles";
            // 
            // btn_AddVehicle
            // 
            this.btn_AddVehicle.Location = new System.Drawing.Point(145, 68);
            this.btn_AddVehicle.Name = "btn_AddVehicle";
            this.btn_AddVehicle.Size = new System.Drawing.Size(75, 23);
            this.btn_AddVehicle.TabIndex = 2;
            this.btn_AddVehicle.Text = "Add";
            this.btn_AddVehicle.UseVisualStyleBackColor = true;
            this.btn_AddVehicle.Click += new System.EventHandler(this.btn_AddVehicle_Click);
            // 
            // btn_RemoveVehicle
            // 
            this.btn_RemoveVehicle.Enabled = false;
            this.btn_RemoveVehicle.Location = new System.Drawing.Point(145, 98);
            this.btn_RemoveVehicle.Name = "btn_RemoveVehicle";
            this.btn_RemoveVehicle.Size = new System.Drawing.Size(75, 23);
            this.btn_RemoveVehicle.TabIndex = 3;
            this.btn_RemoveVehicle.Text = "Remove";
            this.btn_RemoveVehicle.UseVisualStyleBackColor = true;
            this.btn_RemoveVehicle.Click += new System.EventHandler(this.btn_RemoveVehicle_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(225, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Complete Collections";
            // 
            // lst_CompleteCollections
            // 
            this.lst_CompleteCollections.FormattingEnabled = true;
            this.lst_CompleteCollections.ItemHeight = 15;
            this.lst_CompleteCollections.Location = new System.Drawing.Point(226, 40);
            this.lst_CompleteCollections.Name = "lst_CompleteCollections";
            this.lst_CompleteCollections.Size = new System.Drawing.Size(120, 274);
            this.lst_CompleteCollections.Sorted = true;
            this.lst_CompleteCollections.TabIndex = 5;
            // 
            // lst_TopRange
            // 
            this.lst_TopRange.FormattingEnabled = true;
            this.lst_TopRange.ItemHeight = 15;
            this.lst_TopRange.Location = new System.Drawing.Point(353, 40);
            this.lst_TopRange.Name = "lst_TopRange";
            this.lst_TopRange.Size = new System.Drawing.Size(120, 94);
            this.lst_TopRange.Sorted = true;
            this.lst_TopRange.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(371, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Mid Range";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(371, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Top Range";
            // 
            // lst_MidRange
            // 
            this.lst_MidRange.FormattingEnabled = true;
            this.lst_MidRange.ItemHeight = 15;
            this.lst_MidRange.Location = new System.Drawing.Point(353, 159);
            this.lst_MidRange.Name = "lst_MidRange";
            this.lst_MidRange.Size = new System.Drawing.Size(120, 94);
            this.lst_MidRange.Sorted = true;
            this.lst_MidRange.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(353, 260);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Standard Range";
            // 
            // lst_StandardRange
            // 
            this.lst_StandardRange.FormattingEnabled = true;
            this.lst_StandardRange.ItemHeight = 15;
            this.lst_StandardRange.Location = new System.Drawing.Point(353, 278);
            this.lst_StandardRange.Name = "lst_StandardRange";
            this.lst_StandardRange.Size = new System.Drawing.Size(120, 94);
            this.lst_StandardRange.Sorted = true;
            this.lst_StandardRange.TabIndex = 11;
            // 
            // CTL_VehicleCargo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lst_StandardRange);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lst_MidRange);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lst_TopRange);
            this.Controls.Add(this.lst_CompleteCollections);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_RemoveVehicle);
            this.Controls.Add(this.btn_AddVehicle);
            this.Controls.Add(this.lbl_CurrentVehicles);
            this.Controls.Add(this.lst_CurrentVehicles);
            this.Name = "CTL_VehicleCargo";
            this.Size = new System.Drawing.Size(558, 395);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lst_CurrentVehicles;
        private System.Windows.Forms.Label lbl_CurrentVehicles;
        private System.Windows.Forms.Button btn_AddVehicle;
        private System.Windows.Forms.Button btn_RemoveVehicle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lst_CompleteCollections;
        private System.Windows.Forms.ListBox lst_TopRange;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lst_MidRange;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lst_StandardRange;
    }
}
