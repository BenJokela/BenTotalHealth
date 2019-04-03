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
    public partial class Practitioner : Form
    {
        private Main myParent;

        public Practitioner(Main p)
        {
            myParent = p;
            InitializeComponent();
        }

        int currentRecord = 0;
        DataTable dtPractitioners = new DataTable();
        bool addMode = false;

        private void Practitioner_Load(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM TherapistType";

            DataTable dtType = GetData(sql);

            DataRow row = dtType.NewRow();
            row["TherapistTypeID"] = DBNull.Value;
            row["Name"] = "--------";
            dtType.Rows.InsertAt(row, 0);


            cboType.DataSource = dtType;
            cboType.DisplayMember = "Name";
            cboType.ValueMember = "TherapistTypeID";

            currentRecord = 0;
            FillTherapists();
        }

        private void FillTherapists()
        {
            string sql = "SELECT * FROM Therapist ORDER BY LastName";
            dtPractitioners = GetData(sql);
            ReadyMode();
        }
        private void ReadyMode()
        {
            PopulateForm();
            myParent.tss2.Text = "Ready";
            ToggleButtonState(false);
            addMode = false;
        }
        private void EditMode()
        {
            myParent.tss2.Text = "Practitioner edit in progress...";
            ToggleButtonState(true);
            addMode = false;
        }
        private void AddMode()
        {
            myParent.tss2.Text = "add new practitioner record in progress...";
            ToggleButtonState(true);
            addMode = true;
            ClearForm();
            myParent.tss1.Text = $"Record {dtPractitioners.Rows.Count + 1} of {dtPractitioners.Rows.Count + 1}";
        }
        private void ToggleButtonState(bool state)
        {
            btnAdd.Enabled = !state;
            btnDelete.Enabled = !state;
            btnSave.Enabled = state;
            btnCancel.Enabled = state;
            btnFirst.Enabled = !state;
            btnNext.Enabled = !state;
            btnPrevious.Enabled = !state;
            btnLast.Enabled = !state;
        }
        private void ClearForm()
        {
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            cboType.SelectedIndex = 0;
            txtHourly.Text = string.Empty;
            txtPremium.Text = string.Empty;
        }

        private void PopulateForm()
        {
            txtFirstName.Text = dtPractitioners.Rows[currentRecord]["FirstName"].ToString();
            txtLastName.Text = dtPractitioners.Rows[currentRecord]["LastName"].ToString();
            cboType.SelectedValue = dtPractitioners.Rows[currentRecord]["TherapistType"];
            decimal hourlyRate = Convert.ToDecimal(dtPractitioners.Rows[currentRecord]["HourlyRate"]);
            txtHourly.Text = hourlyRate.ToString("0.00");
            decimal premiumRate = Convert.ToDecimal(dtPractitioners.Rows[currentRecord]["PremiumAddOnCost"]);
            txtPremium.Text = premiumRate.ToString("0.00");

            myParent.tss1.Text = $"Record {currentRecord + 1} of {dtPractitioners.Rows.Count}";
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

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentRecord < dtPractitioners.Rows.Count - 1)
            {
                currentRecord++;
                PopulateForm();
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentRecord > 0)
            {
                currentRecord--;
                PopulateForm();
            }

        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            if (currentRecord > 0)
            {
                currentRecord = 0;
                PopulateForm();
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            if (currentRecord != dtPractitioners.Rows.Count - 1)
            {
                currentRecord = dtPractitioners.Rows.Count - 1;
                PopulateForm();
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddMode();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            ReadyMode();

        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsClean())
                {
                    string firstName = FixApostrophe(txtFirstName.Text.Trim());
                    string lastName = FixApostrophe(txtLastName.Text.Trim());
                    int type = 0;
                    if (cboType.SelectedIndex != 0)
                    { type = Convert.ToInt16(cboType.SelectedValue); }
                    else
                    {
                        MessageBox.Show("Please select a Therapist Type.");
                        cboType.Focus();
                        return;
                    }
                    decimal hourly = Convert.ToDecimal(txtHourly.Text.Trim());
                    decimal premium = Convert.ToDecimal(txtPremium.Text.Trim());
                    string sql = string.Empty;
                    if (addMode)
                    {
                        sql = $"INSERT INTO Therapist VALUES ('{firstName}', '{lastName}', " +
                            $"{type}, {hourly}, {premium})";
                        int rowsAffected = SendData(sql);
                        if (rowsAffected == 1)
                        {
                            MessageBox.Show($"Record for {firstName} {lastName} was successfully added");
                            FillTherapists();
                        }
                    }
                    else
                    {
                        sql = $"UPDATE Therapist SET FirstName = '{firstName}', LastName = '{lastName}', " +
                            $"TherapistType = {type}, HourlyRate = {hourly}, PremiumAddOnCost = {premium} " +
                            $"WHERE TherapistId={dtPractitioners.Rows[currentRecord]["TherapistId"]}";
                        int rowsAffected = SendData(sql);
                        if (rowsAffected == 1)
                        {
                            MessageBox.Show($"Record for {firstName} {lastName} was successfully updated");
                            FillTherapists();
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show(sqlEx.Message, sqlEx.GetType().ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void txtFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!addMode) { EditMode(); }

        }

        private void cboType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!addMode) { EditMode(); }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string sql = $"SELECT COUNT (*) FROM Appointment WHERE TherapistID = {dtPractitioners.Rows[currentRecord]["TherapistId"]}";
            int appointmentCount = Convert.ToInt16(GetScalarValue(sql));
            if (appointmentCount <= 0)
            {
                MessageBox.Show("You may not delete this record as this practitioner has appointments booked.");
                ReadyMode();
            }
            else
            {

                DialogResult result = MessageBox.Show("Are you sure you want to permanently delete this record?", "Exit?",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    ReadyMode();
                }
                else if (result == DialogResult.Yes)
                {
                    sql = $"DELETE FROM Therapist WHERE TherapistId={dtPractitioners.Rows[currentRecord]["TherapistId"]}";
                    int rowsAffected = SendData(sql);
                    if (rowsAffected == 1)
                    {
                        MessageBox.Show("Record successfully deleted");
                        FillTherapists();
                    }
                }
            }

        }
        #region Validation
        private string FixApostrophe(string str)
        {
            return str.Replace("'", "''");
        }
        private void TextBoxValidating(object sender, CancelEventArgs e)
        {
            Control ctl = (Control)sender;
            string msg = string.Empty;
            e.Cancel = false;
            if (ctl.Text == string.Empty)
            {
                ctl.Focus();
                e.Cancel = true;
                if (ctl.Name == "txtFirstName")
                {
                    msg = "Please enter a first name.";
                }
                else if (ctl.Name == "txtLastName")
                {
                    msg = "Please enter a last name.";
                }
                else if (ctl.Name == "txtHourly")
                {
                    msg = "Please enter an hourly rate.";
                }
                else if (ctl.Name == "txtPremium")
                {
                    msg = "Please enter a premium add-on rate.";
                }
            }
            if (ctl.Name == "txtHourly")
            {
                if (!decimal.TryParse(txtHourly.Text.Trim(), out decimal hourly) || hourly == 0m) 
                {
                    e.Cancel = true;
                    msg = "Please enter a valid number for hourly rate.";
                    ctl.Focus();
                }
            }
            else if (ctl.Name == "txtPremium")
            {
                if (!decimal.TryParse(txtPremium.Text.Trim(), out decimal premium)|| premium==0m)
                {
                    e.Cancel = true;
                    msg = "Please enter a valid number for premium add-on rate.";
                    ctl.Focus();
                }
            }
            errorProvider1.SetError(ctl, msg);

        }
        private void cboType_Validating(object sender, CancelEventArgs e)
        {
            Control ctl = (Control)sender;
            string msg = string.Empty;
            e.Cancel = false;
            if(cboType.SelectedIndex == 0)
            {
                msg = "Please select a practitioner type.";
                e.Cancel = true;
                cboType.Focus();
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
        #endregion

        private void Practitioner_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }
    }
}
