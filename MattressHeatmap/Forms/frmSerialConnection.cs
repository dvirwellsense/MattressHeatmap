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
    public partial class frmSerialConnection : Form
    {
        public Form1 MainForm;

        public frmSerialConnection()
        {
            InitializeComponent();
        }

        private void frmSerialConnection_Load(object sender, EventArgs e)
        {
            EventPublisher.StartSequenceStepFinished_Event += EventPublisher_StartSequenceStepFinished_Event;
            //MainForm.ConnectToSerial();
        }

        private void EventPublisher_StartSequenceStepFinished_Event(int stepIndex, string operationName)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new EventPublisher.EventHandler_StartSequenceStep(EventPublisher_StartSequenceStepFinished_Event), new object[] { stepIndex, operationName });
                return;
            }

            HandleStepFinished(stepIndex);
        }

        private void HandleStepFinished(int stepIndex)
        {
            Label stepLabel = GetStepLabel(stepIndex);
            stepLabel.Enabled = true;
            stepLabel.Text = '▣' + stepLabel.Text.Substring(1);

            progressBarSequence.Value = stepIndex + 1;

            if (stepIndex == 9) timerFinished.Start();
        }

        private Label GetStepLabel(int stepIndex)
        {
            foreach (Control label in panelSteps.Controls)
            {
                if (label.Tag.ToString().Equals(stepIndex.ToString())) return (Label)label;
            }

            return null;
        }


        private void timerFinished_Tick(object sender, EventArgs e)
        {
            timerFinished.Stop();
            EventPublisher.StartSequenceStepFinished_Event -= EventPublisher_StartSequenceStepFinished_Event;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MainForm.CancelConnectingToSerial();
            Close();
        }

        private void timerStarted_Tick(object sender, EventArgs e)
        {
            timerStarted.Stop();
            MainForm.ConnectToSerial();
        }
    }
}
