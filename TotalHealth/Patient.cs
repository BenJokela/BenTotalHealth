using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TotalHealth
{
    public partial class Patient : Form
    {
        private Main myParent;
        Int64 phoneNum;
        DataTable dtPatient = new DataTable();
        bool addMode = false;
        public Patient(Main p)
        {
            InitializeComponent();
            myParent = p;
        }
        private void Patient_Load(object sender, EventArgs e)
        {
            FillProvinces();
            FillSearchBy();
            ReadyMode();

            DataTable dtLastNames = GetData($"SELECT PatientNumber, LastName FROM Patient");

            cboLastNames.DataSource = dtLastNames;
            cboLastNames.DisplayMember = "LastName";
            cboLastNames.ValueMember = "PatientNumber";

        }
        private void ReadyMode()
        {
            myParent.tss2.Text = "Ready";
            ToggleButtonState(false);
            addMode = false;
            grpPatientInfo.Enabled = false;
        }
        private void EditMode()
        {
            myParent.tss2.Text = "edit in progress...";
            ToggleButtonState(true);
            addMode = false;
            grpPatientInfo.Enabled = true;
            txtPatientNumber.ReadOnly = true;
        }
        private void AddMode()
        {
            myParent.tss2.Text = "add new record in progress...";
            ToggleButtonState(true);
            addMode = true;
            ClearForm();
            grpPatientInfo.Enabled = true;
            txtPatientNumber.ReadOnly = false;
            GenerateRandomPatientNumber();

        }
        private void GenerateRandomPatientNumber()
        {
            string firstFourLetters = RandomLettersGenerator();
            string lastSixNumbers = RandomNumbersGenerator();
            txtPatientNumber.Text = firstFourLetters + lastSixNumbers;
        }
        private string RandomLettersGenerator()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var stringChars = new char[4];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            return finalString;
        }
        private string RandomNumbersGenerator()
        {
            var chars = "1234567890";
            var stringChars = new char[6];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            return finalString;
        }
        private void ClearForm()
        {
            txtPatientNumber.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPhone.Text = string.Empty;
            cboProv.SelectedItem = "NB";
            txtPostCode.Text = string.Empty;
            chkLoyalty.Checked = false;
        }

        private void ToggleButtonState(bool state)
        {
            btnCancel.Enabled = state;
            btnSave.Enabled = state;
            btnNew.Enabled = !state;
            btnEdit.Enabled = !state;
            grpSearch.Enabled = !state;
        }
        private void FillProvinces()
        {
            cboProv.Items.Add("AB");
            cboProv.Items.Add("BC");
            cboProv.Items.Add("MB");
            cboProv.Items.Add("NB");
            cboProv.Items.Add("NL");
            cboProv.Items.Add("NS");
            cboProv.Items.Add("NT");
            cboProv.Items.Add("NU");
            cboProv.Items.Add("ON");
            cboProv.Items.Add("PE");
            cboProv.Items.Add("QC");
            cboProv.Items.Add("SK");
            cboProv.Items.Add("YT");
        }
        private void FillSearchBy()
        {
            cboSearchBy.Items.Add("FirstName");
            cboSearchBy.Items.Add("LastName");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cboSearchBy.SelectedIndex == -1)
            {
                MessageBox.Show("You must select FirstName or LastName to search");
                cboSearchBy.Focus();
            }
            else
            {
                string searchBy = cboSearchBy.SelectedItem.ToString();
                string searchObject = txtSearch.Text.ToString();
                if (searchObject != string.Empty)
                {
                    string sql = $"SELECT * FROM Patient WHERE {searchBy} = '{searchObject}'";
                    dtPatient = GetData(sql);
                    if(dtPatient.Rows.Count == 0)
                    {
                        MessageBox.Show("No results found for that name.");
                        txtSearch.Focus();
                        txtSearch.SelectAll();
                    }
                    else { PopulateForm(); }
                }
                else
                {
                    MessageBox.Show("You must enter something to search for");
                    txtSearch.Focus();
                }
            }
        }
        private void PopulateForm()
        {
            txtPatientNumber.Text = dtPatient.Rows[0]["PatientNumber"].ToString();
            txtFirstName.Text = dtPatient.Rows[0]["FirstName"].ToString();
            txtLastName.Text = dtPatient.Rows[0]["LastName"].ToString();
            txtAddress.Text = dtPatient.Rows[0]["StreetAddress"].ToString();
            txtCity.Text = dtPatient.Rows[0]["City"].ToString();
            cboProv.SelectedItem = dtPatient.Rows[0]["Province"].ToString();
            txtPostCode.Text = dtPatient.Rows[0]["PostalCode"].ToString();
            Int64 phone = Convert.ToInt64(dtPatient.Rows[0]["Phone"]);
            string phoneDisplay = phone.ToString();
            phoneDisplay = phoneDisplay.Substring(0, 3) + "-" + phoneDisplay.Substring(3, 3) + "-" + phoneDisplay.Substring(6, 4);
            txtPhone.Text = phoneDisplay;
            txtEmail.Text = dtPatient.Rows[0]["Email"].ToString();
            chkLoyalty.Checked = (bool)dtPatient.Rows[0]["LoyaltyDiscount"];
            ReadyMode();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsClean())
                {
                    string sql;
                    string patientNumber = txtPatientNumber.Text;
                    string firstName = txtFirstName.Text.Trim();
                    string lastName = txtLastName.Text.Trim();
                    string address = txtAddress.Text.Trim();
                    string city = txtCity.Text.Trim();

                    string phone = txtPhone.Text.Trim(); //already validated elsewhere
                    string areaCode = phone.Substring(0, 3);
                    string next3 = phone.Substring(4, 3);
                    string last4 = phone.Substring(8, 4);
                    phone = areaCode + next3 + last4;
                    Int64.TryParse(phone, out phoneNum);

                    string province = cboProv.SelectedItem.ToString();

                    string postCode = txtPostCode.Text.ToUpper().Trim();
                    if (postCode.Length == 6)
                    {
                        postCode = postCode.Substring(0, 3) + " " + postCode.Substring(3, 3);
                    }
                    string email = txtEmail.Text.Trim();
                    //loyalty discount
                    //int countAppts = Convert.ToInt16(GetScalarValue($"SELECT COUNT(*) FROM Appointment WHERE PatientNumber = {patientNumber}"));

                    int loyaltyStatus = chkLoyalty.Checked ? 1 : 0;
                    if (addMode)
                    {
                        sql = $"INSERT INTO Patient VALUES ('{patientNumber}', '{firstName}', '{lastName}', '{address}', '{city}', " +
                            $"'{province}', '{postCode}', {phoneNum}, '{email}', {loyaltyStatus})";
                    }
                    else //Edit Mode
                    {
                        sql = $"UPDATE Patient SET FirstName = '{firstName}', LastName = '{lastName}', StreetAddress = '{address}', " +
                            $"City = '{city}', Province = '{province}', PostalCode = '{postCode}', Phone = {phoneNum}, Email = '{email}', " +
                            $"LoyaltyDiscount = {loyaltyStatus} WHERE PatientNumber = '{patientNumber}'";
                    }
                    int rowsAffected = SendData(sql);
                    if (rowsAffected == 1)
                    {
                        MessageBox.Show($"The record for {firstName} {lastName} has been succesfully updated.");
                    }
                    else { MessageBox.Show("Something went wrong."); }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
            ReadyMode();


        }
        #region Validation

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    var domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                MessageBox.Show(e.Message, e.GetType().ToString());
                return false;
            }
            catch (ArgumentException e)
            {
                MessageBox.Show(e.Message, e.GetType().ToString());

                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
        private bool IsPostalCode(string postalCode)
        {

            //Canadian Postal Code in the format of "M3A 1A5"
            string pattern = "^[ABCEGHJ-NPRSTVXY]{1}[0-9]{1}[ABCEGHJ-NPRSTV-Z]{1}[ ]?[0-9]{1}[ABCEGHJ-NPRSTV-Z]{1}[0-9]{1}$";

            Regex reg = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);

            if (!(reg.IsMatch(postalCode))) { return false; }
            else { return true; }
        }
        private void TextBoxValidating(object sender, CancelEventArgs e)
        {
            Control ctl = (Control)sender;
            string msg = string.Empty;
            e.Cancel = false;
            if (ctl.Text == string.Empty)
            {
                e.Cancel = true;
                if (ctl.Name == "txtFirstName")
                {
                    msg = "Please enter a first name";
                }
                //else if (ctl.Name == "txtPatientNumber")
                //{
                //    msg = "Please enter a patient number.";
                //}
                else if (ctl.Name == "txtLastName")
                {
                    msg = "Please enter a last name";
                }
                else if (ctl.Name == "txtAddress")
                {
                    msg = "Please enter an address";
                }
                else if (ctl.Name == "txtCity")
                {
                    msg = "Please enter a city";
                }
                else if (ctl.Name == "txtPostCode")
                {
                    msg = "Please enter a postal code";
                }
            }
            //NOT NECESSARY ANYMORE AS PATIENT NUMBER IS RANDOMLY GENERATED.

            //if (ctl.Name == "txtPatientNumber")
            //{
            //    string patientNumber = txtPatientNumber.Text;
            //    if (patientNumber.Length != 10)
            //    {
            //        e.Cancel = true;
            //        msg = "patientNumber must be exactly 10 characters.";
            //        txtPatientNumber.Focus();
            //    }
            //    string firstFour = patientNumber.Substring(0, 4);
            //    string lastSix = patientNumber.Substring(4, 6);
            //    if (!int.TryParse(lastSix, out int x) || (int.TryParse(firstFour, out int y)))
            //    {
            //        e.Cancel = true;
            //        msg = "patientNumber must be in this format: xxxx######";
            //    }
            //}
            if (ctl.Name == "txtPhone")
            {
                string phone = txtPhone.Text.Trim();
                if (phone.Length != 12)
                {
                    e.Cancel = true;
                    msg = "Please enter phone number in correct format: ###-###-####";
                }
                else
                {
                    string areaCode = phone.Substring(0, 3);
                    string next3 = phone.Substring(4, 3);
                    string last4 = phone.Substring(8, 4);
                    phone = areaCode + next3 + last4;

                    if (!Int64.TryParse(phone, out phoneNum))
                    {
                        e.Cancel = true;
                        msg = "Please enter a valid phone number";
                    }
                }
            }
            if (ctl.Name == "txtPostCode")
            {
                if (!IsPostalCode(txtPostCode.Text.ToString()))
                {
                    e.Cancel = true;
                    msg = "Please enter a valid postal code.";
                }
            }
            if (ctl.Name == "txtEmail")
            {
                if (!IsValidEmail(txtEmail.Text.ToString()))
                {
                    e.Cancel = true;
                    msg = "Please enter a valid email address.";
                }
            }

            if (ctl == cboProv)
            {
                if (cboProv.SelectedIndex == -1)
                {
                    e.Cancel = true;
                    msg = "Please select a province";
                }
            }

            errorProvider1.SetError(ctl, msg);
        }


        private bool IsClean()
        {
            foreach (Control ctl in grpPatientInfo.Controls)
            {
                if (errorProvider1.GetError(ctl) != string.Empty)
                {
                    return false;
                }
            }
            return true;
        }

        #endregion

        #region Database Communication
        private object GetScalarValue(string sql)
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.cnnString);
            object retVal;
            using (conn)
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                retVal = cmd.ExecuteNonQuery();
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

        private void Patient_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }
        #endregion


        private void btnNew_Click(object sender, EventArgs e)
        {
            AddMode();
        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {
            if (!addMode)
            {
                EditMode();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ReadyMode();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditMode();
        }


        private void cboLastNames_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dtPatient = GetData($"SELECT * FROM Patient WHERE PatientNumber = '{cboLastNames.SelectedValue}'");
            PopulateForm();
            ReadyMode();

        }
    }
}
