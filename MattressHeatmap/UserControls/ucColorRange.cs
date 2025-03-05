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
    public enum ColorRangeField { Start, End, Color }

    public partial class ucColorRange : UserControl
    {
        private ColorRange range;
        private HeatMapType type = HeatMapType.Pressures;
        private int index = 0;
        private bool isRangeUpdateable;

        public delegate void EventHandler_ucColorRangeField(ucColorRange sender, ColorRangeField field);

        public event EventHandler_ucColorRangeField RangeChanged_Event;

        public ColorRange Range
        {
            get { return range; }
            set 
            { 
                range = value;
                UpdateControls();
            }
        }

        public HeatMapType Type
        {
            get { return type; }
            set
            {
                if(type != value)
                {
                    type = value;
                    UpdateAppearance();
                }

            }
        }

        public int Index
        {
            get { return index; }
            set { index = value; }
        }

        public ucColorRange()
        {
            InitializeComponent();
        }

        private void ucColorRange_Load(object sender, EventArgs e)
        {
            range = null;
            isRangeUpdateable = true;
        }

        public void SetStart(double value)
        {
            range.Start = value;
            UpdateControls();
        }

        public void SetEnd(double value)
        {
            range.End = value;
            UpdateControls();
        }

        public void SetColor(Color value)
        {
            range.Color = value;
            UpdateControls();
        }

        private void UpdateControls()
        {
            if(range != null)
            {
                isRangeUpdateable = false;

                btnColor.BackColor = range.Color;
                numStart.Value = (decimal)range.Start;
                numEnd.Value = (decimal)range.End;

                isRangeUpdateable = true;
            }
        }

        private void UpdateAppearance()
        {
            int buffer = 2;

            if(type == HeatMapType.Caps)
            {
                numStart.Size = new Size(numStart.Size.Width - lblPfStart.Size.Width - buffer, numStart.Size.Height);
                lblPfStart.Visible = true;

                numEnd.Size = new Size(numEnd.Size.Width - lblPfEnd.Size.Width - buffer, numEnd.Size.Height);
                lblPfEnd.Visible = true;
            }
            else
            {
                numStart.Size = new Size(numStart.Size.Width + buffer + lblPfStart.Size.Width, numStart.Size.Height);
                lblPfStart.Visible = false;

                numEnd.Size = new Size(numEnd.Size.Width + buffer + lblPfEnd.Size.Width, numEnd.Size.Height);
                lblPfEnd.Visible = false;
            }
        }

        private void numStart_ValueChanged(object sender, EventArgs e)
        {
            if (!isRangeUpdateable) return;

            range.Start = (double)numStart.Value;

            RangeChanged_Event?.Invoke(this, ColorRangeField.Start);
        }

        private void numEnd_ValueChanged(object sender, EventArgs e)
        {
            if (!isRangeUpdateable) return;

            range.End = (double)numEnd.Value;

            RangeChanged_Event?.Invoke(this, ColorRangeField.End);
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                btnColor.BackColor = colorDialog.Color;
                range.Color = colorDialog.Color;

                RangeChanged_Event?.Invoke(this, ColorRangeField.Color);
            }
        }
    }
}
