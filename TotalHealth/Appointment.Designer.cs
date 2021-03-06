﻿namespace TotalHealth
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
            this.components = new System.ComponentModel.Container();
            this.cboPatient = new System.Windows.Forms.ComboBox();
            this.cboPractitioner = new System.Windows.Forms.ComboBox();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblAppointmentHeading = new System.Windows.Forms.Label();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.lblPatient = new System.Windows.Forms.Label();
            this.lblPractitioner = new System.Windows.Forms.Label();
            this.btnBook = new System.Windows.Forms.Button();
            this.chkPremium = new System.Windows.Forms.CheckBox();
            this.lblTotalCharge = new System.Windows.Forms.Label();
            this.btnCalculateCharge = new System.Windows.Forms.Button();
            this.cboStartTime = new System.Windows.Forms.ComboBox();
            this.cboEndTime = new System.Windows.Forms.ComboBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cboPatient
            // 
            this.cboPatient.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.22642F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPatient.FormattingEnabled = true;
            this.cboPatient.Location = new System.Drawing.Point(45, 119);
            this.cboPatient.Name = "cboPatient";
            this.cboPatient.Size = new System.Drawing.Size(173, 30);
            this.cboPatient.TabIndex = 0;
            // 
            // cboPractitioner
            // 
            this.cboPractitioner.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.22642F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPractitioner.FormattingEnabled = true;
            this.cboPractitioner.Location = new System.Drawing.Point(256, 119);
            this.cboPractitioner.Name = "cboPractitioner";
            this.cboPractitioner.Size = new System.Drawing.Size(170, 30);
            this.cboPractitioner.TabIndex = 1;
            this.cboPractitioner.SelectedIndexChanged += new System.EventHandler(this.cboPractitioner_SelectedIndexChanged);
            // 
            // dtpFrom
            // 
            this.dtpFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.22642F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(45, 229);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(173, 28);
            this.dtpFrom.TabIndex = 2;
            // 
            // lblAppointmentHeading
            // 
            this.lblAppointmentHeading.AutoSize = true;
            this.lblAppointmentHeading.Font = new System.Drawing.Font("Georgia", 18.33962F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppointmentHeading.Location = new System.Drawing.Point(84, 23);
            this.lblAppointmentHeading.Name = "lblAppointmentHeading";
            this.lblAppointmentHeading.Size = new System.Drawing.Size(321, 31);
            this.lblAppointmentHeading.TabIndex = 4;
            this.lblAppointmentHeading.Text = "Schedule an appointment";
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.22642F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndTime.Location = new System.Drawing.Point(239, 285);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(48, 24);
            this.lblEndTime.TabIndex = 5;
            this.lblEndTime.Text = "end:";
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.22642F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartTime.Location = new System.Drawing.Point(239, 229);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(48, 24);
            this.lblStartTime.TabIndex = 6;
            this.lblStartTime.Text = "start:";
            // 
            // lblPatient
            // 
            this.lblPatient.AutoSize = true;
            this.lblPatient.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.22642F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPatient.Location = new System.Drawing.Point(41, 92);
            this.lblPatient.Name = "lblPatient";
            this.lblPatient.Size = new System.Drawing.Size(66, 24);
            this.lblPatient.TabIndex = 7;
            this.lblPatient.Text = "Patient";
            // 
            // lblPractitioner
            // 
            this.lblPractitioner.AutoSize = true;
            this.lblPractitioner.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.22642F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPractitioner.Location = new System.Drawing.Point(253, 92);
            this.lblPractitioner.Name = "lblPractitioner";
            this.lblPractitioner.Size = new System.Drawing.Size(103, 24);
            this.lblPractitioner.TabIndex = 8;
            this.lblPractitioner.Text = "Practitioner";
            // 
            // btnBook
            // 
            this.btnBook.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.22642F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBook.Location = new System.Drawing.Point(434, 355);
            this.btnBook.Name = "btnBook";
            this.btnBook.Size = new System.Drawing.Size(146, 37);
            this.btnBook.TabIndex = 9;
            this.btnBook.Text = "Book it!";
            this.btnBook.UseVisualStyleBackColor = false;
            this.btnBook.Click += new System.EventHandler(this.btnBook_Click);
            // 
            // chkPremium
            // 
            this.chkPremium.AutoSize = true;
            this.chkPremium.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.22642F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPremium.Location = new System.Drawing.Point(133, 355);
            this.chkPremium.Name = "chkPremium";
            this.chkPremium.Size = new System.Drawing.Size(234, 28);
            this.chkPremium.TabIndex = 12;
            this.chkPremium.Text = "premium add-on service";
            this.chkPremium.UseVisualStyleBackColor = true;
            // 
            // lblTotalCharge
            // 
            this.lblTotalCharge.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblTotalCharge.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotalCharge.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.22642F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCharge.Location = new System.Drawing.Point(243, 420);
            this.lblTotalCharge.Name = "lblTotalCharge";
            this.lblTotalCharge.Size = new System.Drawing.Size(146, 37);
            this.lblTotalCharge.TabIndex = 13;
            // 
            // btnCalculateCharge
            // 
            this.btnCalculateCharge.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnCalculateCharge.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.22642F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalculateCharge.Location = new System.Drawing.Point(45, 404);
            this.btnCalculateCharge.Name = "btnCalculateCharge";
            this.btnCalculateCharge.Size = new System.Drawing.Size(146, 57);
            this.btnCalculateCharge.TabIndex = 14;
            this.btnCalculateCharge.Text = "Calculate Charge";
            this.btnCalculateCharge.UseVisualStyleBackColor = false;
            this.btnCalculateCharge.Click += new System.EventHandler(this.btnCalculateCharge_Click);
            // 
            // cboStartTime
            // 
            this.cboStartTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.22642F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboStartTime.FormattingEnabled = true;
            this.cboStartTime.Location = new System.Drawing.Point(13, 19);
            this.cboStartTime.Name = "cboStartTime";
            this.cboStartTime.Size = new System.Drawing.Size(121, 30);
            this.cboStartTime.TabIndex = 15;
            this.cboStartTime.SelectionChangeCommitted += new System.EventHandler(this.cboStartTime_SelectionChangeCommitted);
            this.cboStartTime.Validating += new System.ComponentModel.CancelEventHandler(this.ComboBoxValidating);
            // 
            // cboEndTime
            // 
            this.cboEndTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.22642F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEndTime.FormattingEnabled = true;
            this.cboEndTime.Location = new System.Drawing.Point(12, 71);
            this.cboEndTime.Name = "cboEndTime";
            this.cboEndTime.Size = new System.Drawing.Size(121, 30);
            this.cboEndTime.TabIndex = 16;
            this.cboEndTime.Validating += new System.ComponentModel.CancelEventHandler(this.ComboBoxValidating);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.22642F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(86, 200);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(51, 24);
            this.lblDate.TabIndex = 17;
            this.lblDate.Text = "date:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.cboStartTime);
            this.groupBox1.Controls.Add(this.cboEndTime);
            this.groupBox1.Location = new System.Drawing.Point(293, 214);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(147, 130);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.22642F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(434, 420);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(146, 37);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::TotalHealth.Properties.Resources.Family_Health_Small;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(565, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(293, 353);
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // Appointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(934, 509);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.btnCalculateCharge);
            this.Controls.Add(this.lblTotalCharge);
            this.Controls.Add(this.chkPremium);
            this.Controls.Add(this.btnBook);
            this.Controls.Add(this.lblPractitioner);
            this.Controls.Add(this.lblPatient);
            this.Controls.Add(this.lblStartTime);
            this.Controls.Add(this.lblEndTime);
            this.Controls.Add(this.lblAppointmentHeading);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.cboPractitioner);
            this.Controls.Add(this.cboPatient);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.Name = "Appointment";
            this.Text = "Appointment";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Appointment_FormClosing);
            this.Load += new System.EventHandler(this.Appointment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboPatient;
        private System.Windows.Forms.ComboBox cboPractitioner;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblAppointmentHeading;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.Label lblPatient;
        private System.Windows.Forms.Label lblPractitioner;
        private System.Windows.Forms.Button btnBook;
        private System.Windows.Forms.CheckBox chkPremium;
        private System.Windows.Forms.Label lblTotalCharge;
        private System.Windows.Forms.Button btnCalculateCharge;
        private System.Windows.Forms.ComboBox cboStartTime;
        private System.Windows.Forms.ComboBox cboEndTime;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}