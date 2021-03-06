﻿namespace TotalHealth
{
    partial class Main
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tss1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tss2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.appointmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.patientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.practitionerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.patientChargesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.patientReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new MdiTabControl.TabControl();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbAppointment = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.tsbPatient = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbPractitioner = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tss1,
            this.tss2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 635);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(952, 24);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tss1
            // 
            this.tss1.Name = "tss1";
            this.tss1.Size = new System.Drawing.Size(139, 19);
            this.tss1.Text = "toolStripStatusLabel1";
            // 
            // tss2
            // 
            this.tss2.Name = "tss2";
            this.tss2.Size = new System.Drawing.Size(139, 19);
            this.tss2.Text = "toolStripStatusLabel2";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Georgia", 8.830189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainToolStripMenuItem,
            this.reportToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(952, 25);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mainToolStripMenuItem
            // 
            this.mainToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.appointmentToolStripMenuItem,
            this.patientToolStripMenuItem,
            this.practitionerToolStripMenuItem});
            this.mainToolStripMenuItem.Name = "mainToolStripMenuItem";
            this.mainToolStripMenuItem.Size = new System.Drawing.Size(52, 21);
            this.mainToolStripMenuItem.Text = "&Main";
            // 
            // appointmentToolStripMenuItem
            // 
            this.appointmentToolStripMenuItem.Name = "appointmentToolStripMenuItem";
            this.appointmentToolStripMenuItem.Size = new System.Drawing.Size(194, 24);
            this.appointmentToolStripMenuItem.Text = "&Appointment";
            this.appointmentToolStripMenuItem.Click += new System.EventHandler(this.appointmentToolStripMenuItem_Click);
            // 
            // patientToolStripMenuItem
            // 
            this.patientToolStripMenuItem.Name = "patientToolStripMenuItem";
            this.patientToolStripMenuItem.Size = new System.Drawing.Size(194, 24);
            this.patientToolStripMenuItem.Text = "&Patient";
            this.patientToolStripMenuItem.Click += new System.EventHandler(this.patientToolStripMenuItem_Click);
            // 
            // practitionerToolStripMenuItem
            // 
            this.practitionerToolStripMenuItem.Name = "practitionerToolStripMenuItem";
            this.practitionerToolStripMenuItem.Size = new System.Drawing.Size(194, 24);
            this.practitionerToolStripMenuItem.Text = "Prac&titioner";
            this.practitionerToolStripMenuItem.Click += new System.EventHandler(this.practitionerToolStripMenuItem_Click);
            // 
            // reportToolStripMenuItem
            // 
            this.reportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.patientChargesToolStripMenuItem,
            this.patientReportToolStripMenuItem});
            this.reportToolStripMenuItem.Name = "reportToolStripMenuItem";
            this.reportToolStripMenuItem.Size = new System.Drawing.Size(64, 21);
            this.reportToolStripMenuItem.Text = "&Report";
            // 
            // patientChargesToolStripMenuItem
            // 
            this.patientChargesToolStripMenuItem.Name = "patientChargesToolStripMenuItem";
            this.patientChargesToolStripMenuItem.Size = new System.Drawing.Size(260, 24);
            this.patientChargesToolStripMenuItem.Text = "Appointments by &Date Range";
            this.patientChargesToolStripMenuItem.Click += new System.EventHandler(this.patientChargesToolStripMenuItem_Click);
            // 
            // patientReportToolStripMenuItem
            // 
            this.patientReportToolStripMenuItem.Name = "patientReportToolStripMenuItem";
            this.patientReportToolStripMenuItem.Size = new System.Drawing.Size(260, 24);
            this.patientReportToolStripMenuItem.Text = "Pa&tient Report";
            this.patientReportToolStripMenuItem.Click += new System.EventHandler(this.patientReportToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl1.Location = new System.Drawing.Point(0, 85);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.MenuRenderer = null;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Size = new System.Drawing.Size(952, 550);
            this.tabControl1.TabCloseButtonImage = null;
            this.tabControl1.TabCloseButtonImageDisabled = null;
            this.tabControl1.TabCloseButtonImageHot = null;
            this.tabControl1.TabIndex = 3;
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 61);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAppointment,
            this.toolStripSeparator3,
            this.toolStripButton1,
            this.tsbPatient,
            this.toolStripSeparator1,
            this.tsbPractitioner,
            this.toolStripSeparator2,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(952, 61);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbAppointment
            // 
            this.tsbAppointment.AutoSize = false;
            this.tsbAppointment.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAppointment.Image = global::TotalHealth.Properties.Resources.iconfinder_appointment_new_23189;
            this.tsbAppointment.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAppointment.Name = "tsbAppointment";
            this.tsbAppointment.Size = new System.Drawing.Size(47, 47);
            this.tsbAppointment.Text = "toolStripButton1";
            this.tsbAppointment.ToolTipText = "Add new appointment";
            this.tsbAppointment.Click += new System.EventHandler(this.appointmentToolStripMenuItem_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::TotalHealth.Properties.Resources.PatientReport;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripButton1.Size = new System.Drawing.Size(44, 58);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.ToolTipText = "Patient Report";
            this.toolStripButton1.Click += new System.EventHandler(this.patientReportToolStripMenuItem_Click);
            // 
            // tsbPatient
            // 
            this.tsbPatient.AutoSize = false;
            this.tsbPatient.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPatient.Image = global::TotalHealth.Properties.Resources.iconfinder_8_375259;
            this.tsbPatient.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPatient.Name = "tsbPatient";
            this.tsbPatient.Size = new System.Drawing.Size(47, 47);
            this.tsbPatient.Text = "toolStripButton2";
            this.tsbPatient.ToolTipText = "Patient";
            this.tsbPatient.Click += new System.EventHandler(this.patientToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 61);
            // 
            // tsbPractitioner
            // 
            this.tsbPractitioner.AutoSize = false;
            this.tsbPractitioner.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPractitioner.Image = global::TotalHealth.Properties.Resources.iconfinder_9_375256;
            this.tsbPractitioner.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPractitioner.Name = "tsbPractitioner";
            this.tsbPractitioner.Size = new System.Drawing.Size(47, 47);
            this.tsbPractitioner.Text = "toolStripButton3";
            this.tsbPractitioner.ToolTipText = "Practitioner";
            this.tsbPractitioner.Click += new System.EventHandler(this.practitionerToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 61);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::TotalHealth.Properties.Resources.AppointmentReport;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(44, 58);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.ToolTipText = "Appointment Report";
            this.toolStripButton2.Click += new System.EventHandler(this.patientChargesToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 659);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Georgia", 6.792453F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Main";
            this.Text = "Total Health";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mainToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem appointmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem patientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem practitionerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem patientChargesToolStripMenuItem;
        private MdiTabControl.TabControl tabControl1;
        internal System.Windows.Forms.StatusStrip statusStrip1;
        internal System.Windows.Forms.ToolStripStatusLabel tss1;
        internal System.Windows.Forms.ToolStripStatusLabel tss2;
        private System.Windows.Forms.ToolStripMenuItem patientReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton tsbAppointment;
        private System.Windows.Forms.ToolStripButton tsbPractitioner;
        private System.Windows.Forms.ToolStripButton tsbPatient;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}

