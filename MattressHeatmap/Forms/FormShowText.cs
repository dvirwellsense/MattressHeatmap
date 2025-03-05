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
    public partial class FormShowText : Form
    {
        public string Text;

        public FormShowText()
        {
            InitializeComponent();
        }

        private void FormShowText_Load(object sender, EventArgs e)
        {
            txtMessage.Text = Text;
        }
    }
}
