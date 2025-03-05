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
    public partial class ucColorRanges : UserControl
    {
        private HeatMapType type = HeatMapType.Caps;
        private List<ucColorRange> ucRanges = null;
        private List<ColorRange> originalColorRanges = null;
        private double offset = 0;

        public delegate void EventHandler_ColorRanges(List<ColorRange> colorRanges, HeatMapType type);

        public event EventHandler_ColorRanges ColorRangesChanged_Event;


        public HeatMapType Type
        {
            get { return type; }
            set
            {
                type = value;
                SetTypes();
                SetLabels();
            }
        }

        public ucColorRanges()
        {
            InitializeComponent();
        }

        private void ucColorRanges_Load(object sender, EventArgs e)
        {

        }

        public void Init()
        {
            SetLabels();
            LoadUcRanges();
            SetTypes();
            LoadRanges();
            AddListeners();
        }


        private void UcColorRanges_RangeChanged_Event(ucColorRange sender, ColorRangeField field)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new ucColorRange.EventHandler_ucColorRangeField(UcColorRanges_RangeChanged_Event), new object[] { sender, field });
                return;
            }

            OnRangeChanged(sender, field);
        }

        private void SetLabels()
        {
            if (type == HeatMapType.Caps)
            {
                lblTitle.Text = "Caps:";
                lblPf.Visible = true;
            }
            else
            {
                lblTitle.Text = "Pressures:";
                lblPf.Visible = false;
            }

            int middleClientWidth = ClientSize.Width / 2;
            int middleLabelWidth = lblTitle.Width / 2;
            lblTitle.Location = new Point(middleClientWidth - middleLabelWidth, lblTitle.Location.Y);
        }

        private void LoadUcRanges()
        {
            if (ucRanges == null) ucRanges = new List<ucColorRange>();
            else ucRanges.Clear();

            ucRanges.Add(ucColorRange0);
            ucRanges.Add(ucColorRange1);
            ucRanges.Add(ucColorRange2);
            ucRanges.Add(ucColorRange3);
            ucRanges.Add(ucColorRange4);
            ucRanges.Add(ucColorRange5);
            ucRanges.Add(ucColorRange6);
        }

        private void SetTypes()
        {
            if (ucRanges == null) return;

            for(int i = 0; i < ucRanges.Count; i++)
            {
                ucRanges[i].Type = type;
            }
        }

        private void OnRangeChanged(ucColorRange ucColorRange, ColorRangeField fieldChanged)
        {
            if (fieldChanged == ColorRangeField.Color) return;

            int index = ucColorRange.Index;

            double newValue;
            if(fieldChanged == ColorRangeField.Start)
            {
                newValue = ucColorRange.Range.Start;
                originalColorRanges[index].Start = newValue - offset;
                if (index > 0)
                {
                    ucRanges[index - 1].SetEnd(newValue);
                    originalColorRanges[index - 1].End = newValue - offset;
                }
            }
            else
            {
                newValue = ucColorRange.Range.End;
                originalColorRanges[index].End = newValue - offset;
                if (index < ucRanges.Count - 1)
                {
                    ucRanges[index + 1].SetStart(newValue);
                    originalColorRanges[index + 1].Start = newValue - offset;
                }
            }
        }

        private bool ApplyOffset()
        {
            List<ColorRange> newColorRanges = ApplyOffset(originalColorRanges);
            if (newColorRanges == null) return false;
            SetColorRanges(newColorRanges);
            return true;
        }

        private List<ColorRange> ApplyOffset(List<ColorRange> colorRanges) //Sets new offset value as well
        {
            if (originalColorRanges == null) return null;

            List<ColorRange> newColorRanges = CloneColorRanges(colorRanges);
            ApplyOffset(newColorRanges, offset);

            return newColorRanges;
        }

        private void ApplyOffset(List<ColorRange> colorRanges, double offset)
        {
            for (int i = 0; i < colorRanges.Count; i++)
            {
                colorRanges[i].Start += offset;
                colorRanges[i].End += offset;
            }
        }

        private void LoadRanges()
        {
            List<ColorRange> colorRanges = ColorRangesWriter.LoadColorRanges(type);
            originalColorRanges = CloneColorRanges(colorRanges);
            SetColorRanges(colorRanges);
            numOffset.Value = 0;
        }

        private void SaveRanges()
        {
            List<ColorRange> colorRanges = GetColorRanges();
            ColorRangesWriter.SaveColorRanges(colorRanges, type);
            originalColorRanges = CloneColorRanges(colorRanges);
            numOffset.Value = 0;
        }

        private void SetColorRanges(List<ColorRange> colorRanges)
        {
            for(int i = 0; i < ucRanges.Count; i++)
            {
                ucRanges[i].Range = colorRanges[i];
            }

            ColorRangesChanged_Event?.Invoke(colorRanges, type);
        }

        public List<ColorRange> GetColorRanges()
        {
            List<ColorRange> colorRanges = new List<ColorRange>();

            for(int i = 0; i < ucRanges.Count; i++)
            {
                colorRanges.Add(ucRanges[i].Range);
            }

            return colorRanges;
        }

        private void AddListeners()
        {
            for(int i = 0; i < ucRanges.Count; i++)
            {
                ucRanges[i].RangeChanged_Event += UcColorRanges_RangeChanged_Event;
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveRanges();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadRanges();
        }

        private List<ColorRange> CloneColorRanges(List<ColorRange> colorRanges)
        {
            List<ColorRange> result = new List<ColorRange>();

            for (int i = 0; i < colorRanges.Count; i++)
            {
                result.Add(new ColorRange(colorRanges[i]));
            }

            return result;
        }

        private void numOffset_ValueChanged(object sender, EventArgs e)
        {
            offset = (double)numOffset.Value;
            ApplyOffset();
        }
    }
}
