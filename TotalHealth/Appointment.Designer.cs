namespace TotalHealth
{
    partial class Appointment
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
            this.cboPatient = new System.Windows.Forms.ComboBox();
            this.cboPractitioner = new System.Windows.Forms.ComboBox();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lblAppointmentHeading = new System.Windows.Forms.Label();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.lblPatient = new System.Windows.Forms.Label();
            this.lblPractitioner = new System.Windows.Forms.Label();
            this.btnBook = new System.Windows.Forms.Button();
            this.chkPremium = new System.Windows.Forms.CheckBox();
            this.lblTotalCharge = new System.Windows.Forms.Label();
            this.btnCalculateCharge = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cboPatient
            // 
            this.cboPatient.FormattingEnabled = true;
            this.cboPatient.Location = new System.Drawing.Point(87, 143);
            this.cboPatient.Name = "cboPatient";
            this.cboPatient.Size = new System.Drawing.Size(121, 21);
            this.cboPatient.TabIndex = 0;
            // 
            // cboPractitioner
            // 
            this.cboPractitioner.FormattingEnabled = true;
            this.cboPractitioner.Location = new System.Drawing.Point(305, 143);
            this.cboPractitioner.Name = "cboPractitioner";
            this.cboPractitioner.Size = new System.Drawing.Size(121, 21);
            this.cboPractitioner.TabIndex = 1;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Location = new System.Drawing.Point(87, 227);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(200, 20);
            this.dtpFrom.TabIndex = 2;
            // 
            // dtpTo
            // 
            this.dtpTo.Location = new System.Drawing.Point(87, 287);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(200, 20);
            this.dtpTo.TabIndex = 3;
            // 
            // lblAppointmentHeading
            // 
            this.lblAppointmentHeading.AutoSize = true;
            this.lblAppointmentHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.33962F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppointmentHeading.Location = new System.Drawing.Point(84, 23);
            this.lblAppointmentHeading.Name = "lblAppointmentHeading";
            this.lblAppointmentHeading.Size = new System.Drawing.Size(320, 31);
            this.lblAppointmentHeading.TabIndex = 4;
            this.lblAppointmentHeading.Text = "Schedule an appointment";
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(87, 269);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(58, 15);
            this.lblEndDate.TabIndex = 5;
            this.lblEndDate.Text = "end date:";
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(87, 209);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(60, 15);
            this.lblStartDate.TabIndex = 6;
            this.lblStartDate.Text = "start date:";
            this.lblStartDate.Click += new System.EventHandler(this.label3_Click);
            // 
            // lblPatient
            // 
            this.lblPatient.AutoSize = true;
            this.lblPatient.Location = new System.Drawing.Point(84, 125);
            this.lblPatient.Name = "lblPatient";
            this.lblPatient.Size = new System.Drawing.Size(45, 15);
            this.lblPatient.TabIndex = 7;
            this.lblPatient.Text = "Patient";
            // 
            // lblPractitioner
            // 
            this.lblPractitioner.AutoSize = true;
            this.lblPractitioner.Location = new System.Drawing.Point(302, 125);
            this.lblPractitioner.Name = "lblPractitioner";
            this.lblPractitioner.Size = new System.Drawing.Size(69, 15);
            this.lblPractitioner.TabIndex = 8;
            this.lblPractitioner.Text = "Practitioner";
            // 
            // btnBook
            // 
            this.btnBook.Location = new System.Drawing.Point(660, 371);
            this.btnBook.Name = "btnBook";
            this.btnBook.Size = new System.Drawing.Size(118, 37);
            this.btnBook.TabIndex = 9;
            this.btnBook.Text = "Book it!";
            this.btnBook.UseVisualStyleBackColor = true;
            this.btnBook.Click += new System.EventHandler(this.btnBook_Click);
            // 
            // chkPremium
            // 
            this.chkPremium.AutoSize = true;
            this.chkPremium.Location = new System.Drawing.Point(332, 253);
            this.chkPremium.Name = "chkPremium";
            this.chkPremium.Size = new System.Drawing.Size(159, 19);
            this.chkPremium.TabIndex = 12;
            this.chkPremium.Text = "premium add-on service";
            this.chkPremium.UseVisualStyleBackColor = true;
            // 
            // lblTotalCharge
            // 
            this.lblTotalCharge.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotalCharge.Location = new System.Drawing.Point(608, 292);
            this.lblTotalCharge.Name = "lblTotalCharge";
            this.lblTotalCharge.Size = new System.Drawing.Size(146, 35);
            this.lblTotalCharge.TabIndex = 13;
            // 
            // btnCalculateCharge
            // 
            this.btnCalculateCharge.Location = new System.Drawing.Point(608, 249);
            this.btnCalculateCharge.Name = "btnCalculateCharge";
            this.btnCalculateCharge.Size = new System.Drawing.Size(146, 23);
            this.btnCalculateCharge.TabIndex = 14;
            this.btnCalculateCharge.Text = "Calculate Charge";
            this.btnCalculateCharge.UseVisualStyleBackColor = true;
            this.btnCalculateCharge.Click += new System.EventHandler(this.btnCalculateCharge_Click);
            // 
            // Appointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCalculateCharge);
            this.Controls.Add(this.lblTotalCharge);
            this.Controls.Add(this.chkPremium);
            this.Controls.Add(this.btnBook);
            this.Controls.Add(this.lblPractitioner);
            this.Controls.Add(this.lblPatient);
            this.Controls.Add(this.lblStartDate);
            this.Controls.Add(this.lblEndDate);
            this.Controls.Add(this.lblAppointmentHeading);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.cboPractitioner);
            this.Controls.Add(this.cboPatient);
            this.Name = "Appointment";
            this.Text = "Appointment";
            this.Load += new System.EventHandler(this.Appointment_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboPatient;
        private System.Windows.Forms.ComboBox cboPractitioner;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label lblAppointmentHeading;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Label lblPatient;
        private System.Windows.Forms.Label lblPractitioner;
        private System.Windows.Forms.Button btnBook;
        private System.Windows.Forms.CheckBox chkPremium;
        private System.Windows.Forms.Label lblTotalCharge;
        private System.Windows.Forms.Button btnCalculateCharge;
    }
}