using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TotalHealth
{
    public partial class PatientReport : Form
    {
        public PatientReport()
        {
            InitializeComponent();
        }
        private Main myParent;
        public PatientReport(Main p)
        {
            InitializeComponent();
            myParent = p;
        }


        private void PatientReport_Load(object sender, EventArgs e)
        {
            LoadListbox();
        }

        private void LoadListbox()
        {
            string sql = "SELECT * FROM TherapistType";
            DataTable dt = GetData(sql);

            lstTherapistType.ValueMember = "TherapistTypeId";
            lstTherapistType.DisplayMember = "Name";
            lstTherapistType.DataSource = dt;
        }
        private DataTable GetData(string sqlStatement)
        {
            SqlConnection conn = new SqlConnection
            (Properties.Settings.Default.cnnString);

            DataTable dt = new DataTable();
            using (conn)
            {
                SqlCommand cmd = new SqlCommand(sqlStatement, conn);
                using (cmd)
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }



        private void lstTherapistType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstTherapistType.SelectedIndex != -1)
            {
                string sql = $"SELECT P.PatientNumber, P.FirstName, P.LastName, SUM(TotalCharge) AS TotalCharges " +
                    $"FROM Patient P JOIN Appointment A ON P.PatientNumber = A.PatientNumber JOIN Therapist T ON A.TherapistID = T.TherapistID " +
                    $"WHERE T.TherapistType = {lstTherapistType.SelectedValue} GROUP BY P.PatientNumber, P.LastName, P.FirstName;";

                DataTable dtPatientCharges = GetData(sql);

                dgvPatientCharges.DataSource = dtPatientCharges;

                dgvPatientCharges.AutoResizeColumns();
                dgvPatientCharges.ReadOnly = true;
                dgvPatientCharges.Columns[0].HeaderCell.Value = "Patient Number";
                dgvPatientCharges.Columns[1].HeaderCell.Value = "Patient First Name";
                dgvPatientCharges.Columns[2].HeaderCell.Value = "Patient Last Name";
                dgvPatientCharges.Columns[3].DefaultCellStyle.Format = "c";

            }

        }
    }
}