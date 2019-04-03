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
        DateTime start = new DateTime();
        DateTime end = new DateTime();

        decimal total = 0m;

        private void Appointment_Load(object sender, EventArgs e)
        {
            myParent.tss1.Text = string.Empty;
            myParent.tss2.Text = string.Empty;

            FillTimeDropdowns();
            FillPatientMenu();
            FillTherapistMenu();
            dtpFrom.CustomFormat = "MMMM dd";
        }
        private void FillTherapistMenu()
        {
            string sql = "Select TherapistID, LastName + ', ' + FirstName AS TherapistName FROM Therapist";
            DataTable dtTherapists = GetData(sql);
            cboPractitioner.DataSource = dtTherapists;
            cboPractitioner.DisplayMember = "TherapistName";
            cboPractitioner.ValueMember = "TherapistID";

        }

        private void FillPatientMenu()
        {
            string sql = "Select PatientNumber, LastName + ', ' + FirstName AS PatientName FROM Patient";
            DataTable dtPatients = GetData(sql);
            cboPatient.DataSource = dtPatients;
            cboPatient.DisplayMember = "PatientName";
            cboPatient.ValueMember = "PatientNumber";

        }
        private void FillTimeDropdowns()
        {
            cboStartTime.Items.AddRange(new string[] { "9:00", "9:30", "10:00", "10:30", "11:00", "11:30",
                "13:00", "13:30", "14:00", "14:30", "15:00", "15:30", "16:00", "16:30" });
            //cboEndTime.Items.AddRange(new string[] { "9:30", "10:00", "10:30", "11:00", "11:30", "12:00",
            //    "13:30", "14:00", "14:30", "15:00", "15:30", "16:00", "16:30", "17:00" });
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





        private void btnCalculateCharge_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                int therapistID = Convert.ToInt16(cboPractitioner.SelectedValue);
                string patientNumber = cboPatient.SelectedValue.ToString();

                string sql = $"SELECT HourlyRate FROM Therapist WHERE TherapistId = {therapistID}";

                decimal rate = Convert.ToDecimal(GetScalarValue(sql));

                string date = dtpFrom.Value.ToShortDateString();
                string startDateTime = date + " " + cboStartTime.SelectedItem.ToString();
                string endDateTime = date + " " + cboEndTime.SelectedItem.ToString();
                start = Convert.ToDateTime(startDateTime);
                end = Convert.ToDateTime(endDateTime);
                TimeSpan hours = end - start;
                decimal length = Convert.ToDecimal(hours.TotalHours);
                decimal premiumAdd = 0m;

                if (chkPremium.Checked)
                {
                    sql = $"SELECT PremiumAddOnCost FROM Therapist WHERE TherapistId = {therapistID}";
                    premiumAdd = Convert.ToDecimal(GetScalarValue(sql));
                }
                //check if patient has loyalty status
                sql = $"SELECT LoyaltyDiscount FROM Patient WHERE PatientNumber = '{patientNumber}'";
                bool loyalty = (bool)GetScalarValue(sql);
                if (loyalty) { premiumAdd *= .65m; }

                total = (rate * length) + premiumAdd;

                lblTotalCharge.Text = total.ToString("c");

            }
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            //check if patient has 2 or more future appts with other therapists.
            string sql = $"SELECT COUNT (DISTINCT TherapistID) FROM Appointment WHERE EXISTS" +
                $"(SELECT * FROM Appointment WHERE PatientNumber =  '{cboPatient.SelectedValue}' AND StartDate > GETDATE() " +
                $"AND TherapistID <> {Convert.ToInt16(cboPractitioner.SelectedValue)})";
            int therapistCount = Convert.ToInt16(GetScalarValue(sql));
            //if patient has 2 or less appointments, book appointment
            if (therapistCount < 2)
            {
                if (total == 0m)
                {
                    MessageBox.Show("You must calculate the charge first.");
                }

                else
                {
                    string patientNumber = cboPatient.SelectedValue.ToString();
                    int therapistID = Convert.ToInt16(cboPractitioner.SelectedValue);
                    int premium = chkPremium.Checked ? 1 : 0;

                    sql = $"INSERT INTO Appointment VALUES ('{start}', '{end}', {therapistID}, " +
                        $"'{patientNumber}', {premium}, {total})";
                    int rowsAffected = SendData(sql);
                    if (rowsAffected == 1)
                    {
                        MessageBox.Show("Appointment has been successfully booked.");
                    }
                    sql = $"SELECT LoyaltyDiscount FROM Patient WHERE PatientNumber = '{patientNumber}'";
                    bool loyalty = (bool)GetScalarValue(sql);
                    if (!loyalty)
                    {
                        sql = $"SELECT COUNT(*) FROM Appointment WHERE PatientNumber = '{patientNumber}'";
                        int aptCount = Convert.ToInt16(GetScalarValue(sql));
                        if (aptCount >= 3)
                        {
                            sql = $"UPDATE Patient SET LoyaltyDiscount = 1 WHERE PatientNumber = '{patientNumber}'";
                            SendData(sql);
                        }
                    }
                }

            }
            //if patient has more than two appointments
            else if (therapistCount >= 2)
            {
                MessageBox.Show("A patient cannot book more than 2 appointments with any practioner");
            }

        }



        private void cboStartTime_SelectionChangeCommitted(object sender, EventArgs e)
        {

            //string[] test = new string[] { "10:30", "11:00", "11:30", "12:00" };
            //test[cboStartTime/.index][test.Length]
            cboEndTime.Text = string.Empty;
            if (cboStartTime.SelectedItem.ToString() == "9:00")
            {
                cboEndTime.Items.Clear();
                cboEndTime.Items.AddRange(new string[] { "9:30", "10:00", "10:30", "11:00", "11:30", "12:00" });
            }
            else if (cboStartTime.SelectedItem.ToString() == "9:30")
            {
                cboEndTime.Items.Clear();
                cboEndTime.Items.AddRange(new string[] { "10:00", "10:30", "11:00", "11:30", "12:00" });
            }
            else if (cboStartTime.SelectedItem.ToString() == "10:00")
            {
                cboEndTime.Items.Clear();
                cboEndTime.Items.AddRange(new string[] { "10:30", "11:00", "11:30", "12:00" });
            }
            else if (cboStartTime.SelectedItem.ToString() == "10:30")
            {
                cboEndTime.Items.Clear();
                cboEndTime.Items.AddRange(new string[] { "11:00", "11:30", "12:00" });
            }
            else if (cboStartTime.SelectedItem.ToString() == "11:00")
            {
                cboEndTime.Items.Clear();
                cboEndTime.Items.AddRange(new string[] { "11:30", "12:00" });
            }
            else if (cboStartTime.SelectedItem.ToString() == "11:30")
            {
                cboEndTime.Items.Clear();
                cboEndTime.Items.Add("12:00");
            }
            else if (cboStartTime.SelectedItem.ToString() == "13:00")
            {
                cboEndTime.Items.Clear();
                cboEndTime.Items.AddRange(new string[] { "13:30", "14:00", "14:30", "15:00", "15:30", "16:00", "16:30", "17:00" });
            }
            else if (cboStartTime.SelectedItem.ToString() == "13:30")
            {
                cboEndTime.Items.Clear();
                cboEndTime.Items.AddRange(new string[] { "14:00", "14:30", "15:00", "15:30", "16:00", "16:30", "17:00" });
            }
            else if (cboStartTime.SelectedItem.ToString() == "14:00")
            {
                cboEndTime.Items.Clear();
                cboEndTime.Items.AddRange(new string[] { "14:30", "15:00", "15:30", "16:00", "16:30", "17:00" });
            }
            else if (cboStartTime.SelectedItem.ToString() == "14:30")
            {
                cboEndTime.Items.Clear();
                cboEndTime.Items.AddRange(new string[] { "15:00", "15:30", "16:00", "16:30", "17:00" });
            }
            else if (cboStartTime.SelectedItem.ToString() == "15:00")
            {
                cboEndTime.Items.Clear();
                cboEndTime.Items.AddRange(new string[] { "15:30", "16:00", "16:30", "17:00" });
            }
            else if (cboStartTime.SelectedItem.ToString() == "15:30")
            {
                cboEndTime.Items.Clear();
                cboEndTime.Items.AddRange(new string[] { "16:00", "16:30", "17:00" });
            }
            else if (cboStartTime.SelectedItem.ToString() == "16:00")
            {
                cboEndTime.Items.Clear();
                cboEndTime.Items.AddRange(new string[] { "16:30", "17:00" });
            }
            else if (cboStartTime.SelectedItem.ToString() == "16:30")
            {
                cboEndTime.Items.Clear();
                cboEndTime.Items.Add("17:00");
            }

        }


        private void ComboBoxValidating(object sender, CancelEventArgs e)
        {
            Control ctl = (Control)sender;
            string msg = string.Empty;
            e.Cancel = false;
            if (ctl == cboStartTime)
            {
                if (cboStartTime.SelectedIndex == -1)
                {
                    e.Cancel = true;
                    msg = "Please select a start time.";
                    ctl.Focus();
                }
            }
            if (ctl == cboEndTime)
            {
                if (cboEndTime.SelectedIndex == -1)
                {
                    e.Cancel = true;
                    msg = "Please select an end time.";
                    ctl.Focus();
                }
            }
            errorProvider1.SetError(ctl, msg);

        }

        private bool IsClean()
        {
            foreach (Control ctl in groupBox1.Controls)
            {
                if (errorProvider1.GetError(ctl) != string.Empty)
                {
                    return false;
                }
            }
            return true;
        }

        private void Appointment_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

            lblTotalCharge.Text = string.Empty;
            cboStartTime.SelectedIndex = 0;
            cboEndTime.Items.Clear();
            cboPatient.SelectedIndex = 0;
            cboPractitioner.SelectedIndex = 0;
        }
    }
}
