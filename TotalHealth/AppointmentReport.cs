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
    public partial class AppointmentReport : Form
    {
        public AppointmentReport()
        {
            InitializeComponent();
        }
        private Main myParent;
        public AppointmentReport(Main p)
        {
            InitializeComponent();
            myParent = p;
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


        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            DateTime dateFrom = dtpFrom.Value;
            DateTime dateTo = dtpTo.Value.AddDays(1);

            string sql = $"SELECT P.FirstName, P.LastName, T.FirstName, T.LastName, A.TotalCharge, P.LoyaltyDiscount FROM Patient P" +
                                   $" JOIN Appointment A ON P.PatientNumber = A.PatientNumber JOIN Therapist T ON " +
                                   $"T.TherapistID = A.TherapistID WHERE A.StartDate BETWEEN '{dateFrom}' AND '{dateTo}'";

            if (chkLoyalty.Checked == true)
            {
                sql = sql + $" AND P.LoyaltyDiscount = '{chkLoyalty.Checked}'";
            }

            DataTable dtAppointments = GetData(sql);
            dgvAppointments.DataSource = dtAppointments;

            dgvAppointments.AutoResizeColumns();
            dgvAppointments.ReadOnly = true;
            dgvAppointments.Columns[0].HeaderCell.Value = "Patient First Name";
            dgvAppointments.Columns[1].HeaderCell.Value = "Patient Last Name";
            dgvAppointments.Columns[2].HeaderCell.Value = "Therapist First Name";
            dgvAppointments.Columns[3].HeaderCell.Value = "Therapist Last Name";
            dgvAppointments.Columns[4].HeaderCell.Value = "Total Charge";
            dgvAppointments.Columns[4].DefaultCellStyle.Format = "c";
        }
    }
}
