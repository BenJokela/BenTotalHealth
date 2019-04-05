using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TotalHealth
{
    public partial class Main : Form
    {
        private Patient frmPatient;
        private Practitioner frmPractitioner;
        private Appointment frmAppointment;
        private AppointmentReport frmAppointmentReport;
        private PatientReport frmPatientReport;
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //Splash mySplash = new Splash();
            //Login myLogin = new Login();
            //mySplash.ShowDialog();

            //if (mySplash.DialogResult != DialogResult.OK)
            //{
            //    this.Close();
            //}
            //else
            //{
            //    myLogin.ShowDialog();
            //}
            //if (myLogin.DialogResult != DialogResult.OK)
            //{
            //    this.Close();
            //}
            //tss1.Text = string.Empty;
            //tss2.Text = "Ready";
        }

        private void patientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmPatient == null || frmPatient.IsDisposed)
            {
                frmPatient = new Patient(this);

            }
            if (tabControl1.Contains(frmPatient))
            {
                tabControl1.TabPages[frmPatient].Select();
            }
            else
            {
                tabControl1.TabPages.Add(frmPatient);
            }

        }

        private void appointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmAppointment == null || frmAppointment.IsDisposed)
            {

                frmAppointment = new Appointment(this);
            }
            if (tabControl1.Contains(frmAppointment))
            {
                tabControl1.TabPages[frmAppointment].Select();
            }
            else
            {
                tabControl1.TabPages.Add(frmAppointment);
            }



        }

        private void practitionerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmPractitioner == null || frmPractitioner.IsDisposed)
            {

                frmPractitioner = new Practitioner(this);
            }
            if (tabControl1.Contains(frmPractitioner))
            {
                tabControl1.TabPages[frmPractitioner].Select();
            }
            else
            {
                tabControl1.TabPages.Add(frmPractitioner);
            }
        }

        private void patientChargesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmAppointmentReport == null || frmAppointmentReport.IsDisposed)
            {

                frmAppointmentReport = new AppointmentReport(this);
            }
            if (tabControl1.Contains(frmAppointmentReport))
            {
                tabControl1.TabPages[frmAppointmentReport].Select();
            }
            else
            {
                tabControl1.TabPages.Add(frmAppointmentReport);
            }


        }

        private void patientReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmPatientReport == null || frmPatientReport.IsDisposed)
            {

                frmPatientReport = new PatientReport(this);
            }
            if (tabControl1.Contains(frmPatientReport))
            {
                tabControl1.TabPages[frmPatientReport].Select();
            }
            else
            {
                tabControl1.TabPages.Add(frmPatientReport);
            }

        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }
    }
}
