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

        }
    }
}
