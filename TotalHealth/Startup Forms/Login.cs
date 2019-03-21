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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.Text = Application.ProductName + " - Login";
            txtPassword.UseSystemPasswordChar = true;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text.Trim();
            string passWord = txtPassword.Text.Trim();
            try
            {
                string sql = $"SELECT * FROM Login WHERE Username = '{userName}'";
                DataTable dtLogin = GetData(sql);
                if (dtLogin.Rows.Count == 0)
                {
                    MessageBox.Show("That Username is not recognized. Try again.");
                    txtUserName.Focus();
                }
                else
                {
                    if (dtLogin.Rows[0]["password"].ToString() != passWord)
                    {
                        MessageBox.Show("That password is incorrect. Please try again.");
                        txtPassword.Focus();
                        txtPassword.SelectAll();
                    }
                    else
                    {
                        DialogResult = DialogResult.OK;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
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

    }
}
