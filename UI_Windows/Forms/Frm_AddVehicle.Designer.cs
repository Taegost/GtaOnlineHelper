
namespace UI_Windows.Forms
{
    partial class Frm_AddVehicle
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
            this.lst_VehicleNames = new System.Windows.Forms.ListBox();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.lst_Plates = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lst_VehicleNames
            // 
            this.lst_VehicleNames.FormattingEnabled = true;
            this.lst_VehicleNames.ItemHeight = 15;
            this.lst_VehicleNames.Location = new System.Drawing.Point(13, 13);
            this.lst_VehicleNames.Name = "lst_VehicleNames";
            this.lst_VehicleNames.Size = new System.Drawing.Size(120, 379);
            this.lst_VehicleNames.TabIndex = 0;
            this.lst_VehicleNames.SelectedIndexChanged += new System.EventHandler(this.lst_VehicleNames_SelectedIndexChanged);
            // 
            // btn_Add
            // 
            this.btn_Add.Enabled = false;
            this.btn_Add.Location = new System.Drawing.Point(13, 415);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(75, 23);
            this.btn_Add.TabIndex = 1;
            this.btn_Add.Text = "Add";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(111, 415);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 2;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // lst_Plates
            // 
            this.lst_Plates.FormattingEnabled = true;
            this.lst_Plates.ItemHeight = 15;
            this.lst_Plates.Location = new System.Drawing.Point(139, 12);
            this.lst_Plates.Name = "lst_Plates";
            this.lst_Plates.Size = new System.Drawing.Size(76, 49);
            this.lst_Plates.TabIndex = 3;
            this.lst_Plates.SelectedIndexChanged += new System.EventHandler(this.lst_Plates_SelectedIndexChanged);
            // 
            // Frm_AddVehicle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 450);
            this.Controls.Add(this.lst_Plates);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.lst_VehicleNames);
            this.Name = "Frm_AddVehicle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Frm_AddVehicle";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lst_VehicleNames;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.ListBox lst_Plates;
    }
}