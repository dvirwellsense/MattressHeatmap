using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MattressHeatmap
{
    public partial class frmDevelopment : Form
    {
        public Form1 MainForm;

        public frmDevelopment()
        {
            InitializeComponent();
        }

        private void frmDevelopment_Load(object sender, EventArgs e)
        {
            txtA.Text = Properties.Settings.Default.DevelopmentDefaultA.ToString();
            txtB.Text = Properties.Settings.Default.DevelopmentDefaultB.ToString();
            txtC.Text = Properties.Settings.Default.DevelopmentDefaultC.ToString();
        }

        private void btnManual_Click(object sender, EventArgs e)
        {
            if (txtA.Text.Equals("") || txtB.Text.Equals("") || txtC.Text.Equals(""))
            {
                MessageBox.Show("Please fill all parameter fields");
                return;
            }

            double a;
            double b;
            double c;

            bool isAValid = double.TryParse(txtA.Text, out a);
            bool isBValid = double.TryParse(txtB.Text, out b);
            bool isCValid = double.TryParse(txtC.Text, out c);

            if (isAValid && isBValid && isCValid)
            {
                Global.IsManual = true;
                Global.DevelopmentA = a;
                Global.DevelopmentB = b;
                Global.DevelopmentC = c;

                if (Properties.Settings.Default.DevelopmentDefaultA != a ||
                    Properties.Settings.Default.DevelopmentDefaultB != b ||
                    Properties.Settings.Default.DevelopmentDefaultC != c)
                {
                    Properties.Settings.Default.DevelopmentDefaultA = a;
                    Properties.Settings.Default.DevelopmentDefaultB = b;
                    Properties.Settings.Default.DevelopmentDefaultC = c;
                    Properties.Settings.Default.Save();
                }

                Close();

                MainForm.StartDevelopment();
            }
            else MessageBox.Show("Not all parameter fields are valid numbers");
        }

        private void txtA_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAuto_Click(object sender, EventArgs e)
        {
            Global.IsManual = false;
            Close();
            MainForm.StartDevelopment();
        }
    }
}
