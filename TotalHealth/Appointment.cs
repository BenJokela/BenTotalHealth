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
    public partial class Appointment : Form
    {
        private Main myParent;
        public Appointment(Main p)
        {
            InitializeComponent();
            myParent = p;
        }
        decimal total = 0m;

        private void Appointment_Load(object sender, EventArgs e)
        {
            string sql = "Select PatientNumber, LastName + ', ' + FirstName AS PatientName FROM Patient";
            DataTable dtPatients = GetData(sql);
            cboPatient.DataSource = dtPatients;
            cboPatient.DisplayMember = "PatientName";
            cboPatient.ValueMember = "PatientNumber";
            sql = "Select TherapistID, LastName + ', ' + FirstName AS TherapistName FROM Therapist";
            DataTable dtTherapists = GetData(sql);
            cboPractitioner.DataSource = dtTherapists;
            cboPractitioner.DisplayMember = "TherapistName";
            cboPractitioner.ValueMember = "TherapistID";

        }

        private object GetScalarValue(string sql)
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.cnnString);
            object retVal;
            using (conn)
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                retVal = cmd.ExecuteScalar();
                conn.Close();
            }

            return retVal;


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
        private int SendData(string sql)
        {
            int rowsAffected;
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.cnnString);
            using (conn)
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                rowsAffected = cmd.ExecuteNonQuery();
            }
            return rowsAffected;
        }




        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            if(total == 0m)
            {
                MessageBox.Show("You must calculate the charge first.");
            }
            else
            {
                DateTime startDate = dtpFrom.Value;
                DateTime endDate = dtpTo.Value;
                string patientNumber = cboPatient.SelectedValue.ToString();
                int therapistID = Convert.ToInt16(cboPractitioner.SelectedValue);
                int premium = chkPremium.Checked ? 1 : 0;


                string sql = $"INSERT INTO Appointment VALUES ('{startDate}', '{endDate}', {therapistID}, " +
                    $"'{patientNumber}', {premium}, {total})";
                int rowsAffected = SendData(sql);
                if (rowsAffected == 1)
                {
                    MessageBox.Show("Appointment has been successfully booked."); 
                }
            }

        }

        private void btnCalculateCharge_Click(object sender, EventArgs e)
        {
            int therapistID = Convert.ToInt16(cboPractitioner.SelectedValue);

            string sql = $"SELECT HourlyRate FROM Therapist WHERE TherapistId = {therapistID}";
            decimal rate = Convert.ToDecimal(GetScalarValue(sql));
            decimal premiumAdd = 0;
            if (chkPremium.Checked){

                sql = $"SELECT PremiumAddOnCost FROM Therapist WHERE TherapistId = {therapistID}";
                premiumAdd = Convert.ToDecimal(GetScalarValue(sql));
                }
            total = rate + premiumAdd;

            lblTotalCharge.Text = total.ToString("c");
        }
    }
}
