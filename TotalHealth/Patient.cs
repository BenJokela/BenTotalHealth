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
            myParent.tss1.Text = string.Empty;
            FillProvinces();
            FillSearchBy();
            ReadyMode();
            btnDelete.Enabled = false;
        }
        #region startup
        private void FillLastNames()
        {
            DataTable dtLastNames = GetData($"SELECT PatientNumber, LastName FROM Patient ORDER BY LastName");
            cboLastNames.DataSource = dtLastNames;
            cboLastNames.DisplayMember = "LastName";
            cboLastNames.ValueMember = "PatientNumber";
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
        #endregion

        #region modes and form
        private void ReadyMode()
        {
            myParent.tss2.Text = "Ready";
            ToggleButtonState(false);
            if (txtFirstName.Text == string.Empty){btnDelete.Enabled = false;}
            else { btnDelete.Enabled = true; }
            addMode = false;
            grpPatientInfo.Enabled = false;
            grpSearch.Enabled = true;
            FillLastNames();
        }
        private void EditMode()
        {
            myParent.tss2.Text = "Patient edit in progress...";
            ToggleButtonState(true);
            addMode = false;
            grpPatientInfo.Enabled = true;
            txtPatientNumber.ReadOnly = true;
        }
        private void AddMode()
        {
            myParent.tss2.Text = "Add new patient record in progress...";
            ToggleButtonState(true);
            btnDelete.Enabled = false;
            addMode = true;
            ClearForm();
            grpPatientInfo.Enabled = true;
            txtPatientNumber.ReadOnly = true;
            GenerateRandomPatientNumber();
        }
        private void ToggleButtonState(bool state)
        {
            btnCancel.Enabled = state;
            btnSave.Enabled = state;
            btnNew.Enabled = !state;
            btnEdit.Enabled = !state;
            grpSearch.Enabled = !state;
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

        #endregion

        #region RandomPatientNumber

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
        #endregion

        #region button clicks and actions
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
                    if (dtPatient.Rows.Count == 0)
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateChildren(ValidationConstraints.Enabled))
                {
                    string sql;
                    string patientNumber = txtPatientNumber.Text;
                    string firstName = FixApostrophe(txtFirstName.Text.Trim());
                    string lastName = FixApostrophe(txtLastName.Text.Trim());
                    string address = FixApostrophe(txtAddress.Text.Trim());
                    string city = FixApostrophe(txtCity.Text.Trim());

                    string phone = txtPhone.Text.Trim(); //already validated elsewhere
                    string areaCode = phone.Substring(0, 3);
                    string next3 = phone.Substring(4, 3);
                    string last4 = phone.Substring(8, 4);
                    phone = areaCode + next3 + last4;
                    Int64.TryParse(phone, out phoneNum);

                    string province = cboProv.SelectedItem.ToString();

                    string postCode = txtPostCode.Text.ToUpper().Trim();//already validated elsewhere
                    if (postCode.Length == 6)
                    {
                        postCode = postCode.Substring(0, 3) + " " + postCode.Substring(3, 3);
                    }
                    string email = txtEmail.Text.Trim();//already validated elsewhere
                    //loyalty discount
                    //int countAppts = Convert.ToInt16(GetScalarValue($"SELECT COUNT(*) FROM Appointment WHERE PatientNumber = {patientNumber}"));

                    int loyaltyStatus = chkLoyalty.Checked ? 1 : 0;
                    if (addMode)
                    {

                        sql = $"IF NOT EXISTS (SELECT PatientNumber FROM Patient WHERE PatientNumber = '{patientNumber}') BEGIN" +
                            $" INSERT INTO Patient (PatientNumber, FirstName, LastName, StreetAddress, City, Province, PostalCode, Phone, Email, LoyaltyDiscount) " +
                            $"VALUES ('{patientNumber}', '{firstName}', '{lastName}', '{address}', '{city}', " +
                            $"'{province}', '{postCode}', {phoneNum}, '{email}', {loyaltyStatus}) END";
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
                        ReadyMode();
                    }
                    else { MessageBox.Show("Something went wrong. Try a Different Patient Number"); }

                }
                else
                {
                    MessageBox.Show("Please fix all errors before saving.");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
            ReadyMode();


        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string patientNumber = dtPatient.Rows[0]["PatientNumber"].ToString();
            string sql = $"SELECT COUNT(*) FROM Appointment WHERE PatientNumber = '{patientNumber}'";
            int aptCount = Convert.ToInt16(GetScalarValue(sql));
            if (aptCount > 0)
            {
                MessageBox.Show("You may not delete this record as this patient has appointments booked.");
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
                    sql = $"DELETE FROM Patient WHERE PatientNumber = '{patientNumber}'";
                    int rowsAffected = SendData(sql);
                    if (rowsAffected == 1)
                    {
                        MessageBox.Show("Record successfully deleted");
                        ReadyMode();
                    }
                }
            }
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            AddMode();
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            foreach (Control ctl in grpPatientInfo.Controls)
            {
                errorProvider1.SetError(ctl, string.Empty);
            }
            errorProvider1.Clear();
            if (addMode)
            {
                ClearForm();
                ReadyMode();
            }
            else
                ReadyMode();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditMode();
        }
        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {
            if (!addMode)
            {
                EditMode();
            }
        }

        private void cboLastNames_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dtPatient = GetData($"SELECT * FROM Patient WHERE PatientNumber = '{cboLastNames.SelectedValue}'");
            PopulateForm();
            ReadyMode();
        }
        #endregion

        #region Validation

        private string FixApostrophe(string str)
        {
            return str.Replace("'", "''");
        }


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
                //ctl.Focus();
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
                    //ctl.Focus();
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
                        //ctl.Focus();
                    }
                }
            }
            if (ctl.Name == "txtPostCode")
            {
                if (!IsPostalCode(txtPostCode.Text.ToString()))
                {
                    e.Cancel = true;
                    msg = "Please enter a valid postal code.";
                    //ctl.Focus();
                }
            }
            if (ctl.Name == "txtEmail")
            {
                if (!IsValidEmail(txtEmail.Text.ToString()))
                {
                    e.Cancel = true;
                    msg = "Please enter a valid email address.";
                    //ctl.Focus();
                }
            }

            if (ctl == cboProv)
            {
                if (cboProv.SelectedIndex == -1)
                {
                    e.Cancel = true;
                    msg = "Please select a province";
                    //ctl.Focus();
                }
            }
            errorProvider1.SetError(ctl, msg);
        }


        //private bool IsClean()
        //{
        //    foreach (Control ctl in grpPatientInfo.Controls)
        //    {
        //        if (errorProvider1.GetError(ctl) != string.Empty)
        //        {
        //            return false;
        //        }
        //    }
        //    return true;
        //}

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

        private void Patient_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }
        #endregion



    }
}
