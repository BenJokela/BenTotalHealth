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

            sql = "SELECT * FROM Therapist ORDER BY LastName";

            dtPractitioners = GetData(sql);
            currentRecord = 0;
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
            myParent.tss2.Text = "edit in progress...";
            ToggleButtonState(true);
            addMode = false;
        }
        private void AddMode()
        {
            myParent.tss2.Text = "add new record in progress...";
            ToggleButtonState(true);
            addMode = true;
            ClearForm();
            myParent.tss1.Text = $"Record {dtPractitioners.Rows.Count + 1} of {dtPractitioners.Rows.Count+1}";
        }
        private void ToggleButtonState(bool state)
        {
            btnAdd.Enabled = !state;
            btnDelete.Enabled = !state;
            btnSave.Enabled = state;
            btnCancel.Enabled = state;
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
            txtHourly.Text = dtPractitioners.Rows[currentRecord]["HourlyRate"].ToString();
            txtPremium.Text = dtPractitioners.Rows[currentRecord]["PremiumAddOnCost"].ToString();

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

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentRecord < dtPractitioners.Rows.Count-1)
            {
                currentRecord++;
                PopulateForm();
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentRecord >0)
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
            if(currentRecord != dtPractitioners.Rows.Count-1)
            {
                currentRecord = dtPractitioners.Rows.Count-1;
                PopulateForm();
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddMode();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ReadyMode();
        }
    }
}
