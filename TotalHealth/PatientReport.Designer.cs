namespace TotalHealth
{
    partial class PatientReport
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTherapistType = new System.Windows.Forms.Label();
            this.lblPatientReport = new System.Windows.Forms.Label();
            this.dgvPatientCharges = new System.Windows.Forms.DataGridView();
            this.lstTherapistType = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatientCharges)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTherapistType
            // 
            this.lblTherapistType.AutoSize = true;
            this.lblTherapistType.Font = new System.Drawing.Font("Georgia", 6.792453F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTherapistType.Location = new System.Drawing.Point(65, 84);
            this.lblTherapistType.Name = "lblTherapistType";
            this.lblTherapistType.Size = new System.Drawing.Size(80, 13);
            this.lblTherapistType.TabIndex = 1;
            this.lblTherapistType.Text = "Therapist Type";
            // 
            // lblPatientReport
            // 
            this.lblPatientReport.AutoSize = true;
            this.lblPatientReport.Font = new System.Drawing.Font("Georgia", 14.26415F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPatientReport.Location = new System.Drawing.Point(63, 30);
            this.lblPatientReport.Name = "lblPatientReport";
            this.lblPatientReport.Size = new System.Drawing.Size(398, 25);
            this.lblPatientReport.TabIndex = 2;
            this.lblPatientReport.Text = "Patient Charges Report by Therapist Type";
            // 
            // dgvPatientCharges
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvPatientCharges.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPatientCharges.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPatientCharges.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPatientCharges.Location = new System.Drawing.Point(59, 181);
            this.dgvPatientCharges.Name = "dgvPatientCharges";
            this.dgvPatientCharges.Size = new System.Drawing.Size(821, 316);
            this.dgvPatientCharges.TabIndex = 3;
            // 
            // lstTherapistType
            // 
            this.lstTherapistType.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lstTherapistType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstTherapistType.Font = new System.Drawing.Font("Georgia", 8.830189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstTherapistType.FormattingEnabled = true;
            this.lstTherapistType.ItemHeight = 16;
            this.lstTherapistType.Location = new System.Drawing.Point(188, 84);
            this.lstTherapistType.Name = "lstTherapistType";
            this.lstTherapistType.Size = new System.Drawing.Size(290, 80);
            this.lstTherapistType.TabIndex = 4;
            this.lstTherapistType.SelectedIndexChanged += new System.EventHandler(this.lstTherapistType_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::TotalHealth.Properties.Resources.Family_Health_Small;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(582, -8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(153, 183);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // PatientReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(934, 509);
            this.Controls.Add(this.lstTherapistType);
            this.Controls.Add(this.dgvPatientCharges);
            this.Controls.Add(this.lblPatientReport);
            this.Controls.Add(this.lblTherapistType);
            this.Controls.Add(this.pictureBox1);
            this.Name = "PatientReport";
            this.Text = "Patient Report";
            this.Load += new System.EventHandler(this.PatientReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatientCharges)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTherapistType;
        private System.Windows.Forms.Label lblPatientReport;
        private System.Windows.Forms.DataGridView dgvPatientCharges;
        private System.Windows.Forms.ListBox lstTherapistType;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}