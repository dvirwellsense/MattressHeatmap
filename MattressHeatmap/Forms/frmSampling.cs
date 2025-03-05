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
    public enum SamplingRateUnits { Seconds, Minutes }

    public partial class frmSampling : Form
    {
        public Form1 MainForm;
        public Area Area;
        private bool isSampling;
        private int samplesCount;

        public frmSampling()
        {
            InitializeComponent();
        }

        private void frmSampling_Load(object sender, EventArgs e)
        {
            isSampling = false;
            comboRate.SelectedIndex = 0;
            samplesCount = 0;
            UpdateAreaLabel();
        }

        private void radios_CheckedChanged(object sender, EventArgs e)
        {
            if (radioRate.Checked)
            {
                numRate.Enabled = true;
                comboRate.Enabled = true;
            }
            else
            {
                numRate.Enabled = false;
                comboRate.Enabled = false;
            }
        }

        private void Start()
        {
            ShowCountLabel();

            bool includePressures = checkIncludePressures.Checked;
            bool allFrames = radioAll.Checked;
            int interval = 1000;
            if (!allFrames) interval = GetInterval();

            isSampling = true;

            MainForm.StartSampling(new SamplingParameters(interval, allFrames, includePressures));
        }

        private int GetInterval()
        {
            double amount = (double)numRate.Value;
            SamplingRateUnits units = GetRateUnits();

            switch (units)
            {
                case SamplingRateUnits.Seconds: return (int)(amount * 1000);
                case SamplingRateUnits.Minutes: return (int)(amount * 60 * 1000);
            }

            return -1;
        }

        private SamplingRateUnits GetRateUnits()
        {
            int index = comboRate.SelectedIndex;

            switch (index)
            {
                case 0: return SamplingRateUnits.Seconds;
                case 1: return SamplingRateUnits.Minutes;
            }

            return SamplingRateUnits.Seconds;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (isSampling) Close();
            else
            {
                btnStart.Text = "Stop";
                btnStart.Image = Properties.Resources.stop_sampling;

                Start();
            }
        }

        private void UpdateAreaLabel()
        {
            lblArea.Text = "Selected Area: " + Area.ToString();
        }

        private void ShowCountLabel()
        {
            lblCount.Text = "Samples Taken: 0";
            lblCount.Visible = true;
        }

        public void IncrementSamplesCount()
        {
            samplesCount++;
            lblCount.Text = "Samples Taken: " + samplesCount;
        }

        private void frmSampling_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void frmSampling_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm.AllowAreaSelection();

            if (isSampling)
            {
                Hide();
                MainForm.StopSampling();
            }
        }
    }
}
