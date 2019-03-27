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
            this.cboTherapistType = new System.Windows.Forms.ComboBox();
            this.lblTherapistType = new System.Windows.Forms.Label();
            this.lblPatientReport = new System.Windows.Forms.Label();
            this.dgvPatientCharges = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatientCharges)).BeginInit();
            this.SuspendLayout();
            // 
            // cboTherapistType
            // 
            this.cboTherapistType.FormattingEnabled = true;
            this.cboTherapistType.Location = new System.Drawing.Point(210, 92);
            this.cboTherapistType.Name = "cboTherapistType";
            this.cboTherapistType.Size = new System.Drawing.Size(165, 21);
            this.cboTherapistType.TabIndex = 0;
            this.cboTherapistType.SelectionChangeCommitted += new System.EventHandler(this.cboTherapistType_SelectionChangeCommitted);
            // 
            // lblTherapistType
            // 
            this.lblTherapistType.AutoSize = true;
            this.lblTherapistType.Location = new System.Drawing.Point(102, 95);
            this.lblTherapistType.Name = "lblTherapistType";
            this.lblTherapistType.Size = new System.Drawing.Size(87, 15);
            this.lblTherapistType.TabIndex = 1;
            this.lblTherapistType.Text = "Therapist Type";
            // 
            // lblPatientReport
            // 
            this.lblPatientReport.AutoSize = true;
            this.lblPatientReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.26415F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPatientReport.Location = new System.Drawing.Point(135, 36);
            this.lblPatientReport.Name = "lblPatientReport";
            this.lblPatientReport.Size = new System.Drawing.Size(415, 25);
            this.lblPatientReport.TabIndex = 2;
            this.lblPatientReport.Text = "Patient Charges Report by Therapist Type";
            // 
            // dgvPatientCharges
            // 
            this.dgvPatientCharges.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPatientCharges.Location = new System.Drawing.Point(58, 143);
            this.dgvPatientCharges.Name = "dgvPatientCharges";
            this.dgvPatientCharges.Size = new System.Drawing.Size(683, 295);
            this.dgvPatientCharges.TabIndex = 3;
            // 
            // PatientReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvPatientCharges);
            this.Controls.Add(this.lblPatientReport);
            this.Controls.Add(this.lblTherapistType);
            this.Controls.Add(this.cboTherapistType);
            this.Name = "PatientReport";
            this.Text = "PatientReport";
            this.Load += new System.EventHandler(this.PatientReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatientCharges)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboTherapistType;
        private System.Windows.Forms.Label lblTherapistType;
        private System.Windows.Forms.Label lblPatientReport;
        private System.Windows.Forms.DataGridView dgvPatientCharges;
    }
}