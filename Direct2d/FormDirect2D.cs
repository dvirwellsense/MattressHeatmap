using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Direct2d
{
    public partial class FormDirect2D : Form
    {
        private GraphicsPath BaseSquarePath = new GraphicsPath();
        private GraphicsPath BaseGridPath = new GraphicsPath();

        public Graphics MyGraphics;
        public SizeF PixelSize= new SizeF(30,40);
        public FormDirect2D()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateBaseSquarePath();
            CreateGridPath();
        }
        public void CreateBaseSquarePath()
        {
            try
            {
                BaseSquarePath.Reset();
                BaseSquarePath.AddRectangle(new RectangleF { X = 0, Y = 0, Height = 1, Width = 1 });
            }
            catch { }
        }

        private void CreateGridPath()
        {
            BaseGridPath.Reset();
            for (int j = 0; j < 10; j++)
            {
                BaseGridPath.CloseFigure();
                BaseGridPath.AddLine(0, j * 12, 20, j * 3);
            }
            for (int j = 0; j < 10; j++)
            {
                BaseGridPath.CloseFigure();
                BaseGridPath.AddLine(j * 53, 0, j * 5, 23);
            }
        }

        public void Redraw()
        {
            picTable.Invalidate();
        }

        private void picTable_Paint(object sender, PaintEventArgs e)
        {
            MyGraphics = e.Graphics;
            DrawAll(e.Graphics);
        }

        private void DrawPixel(Graphics g,float x,float y)
        {
            try
            {
                var path = (GraphicsPath)BaseSquarePath.Clone();
                Matrix mat = new Matrix();
                mat.Translate(x, y);
                mat.Scale(PixelSize.Width, PixelSize.Height);
                path.Transform(mat);
                g.FillPath(new SolidBrush(Color.FromArgb(128, Color.Red)), path);
                g.DrawPath(new Pen(Color.Gray, 1), path);
            }
            catch { }
        }


        private void DrawPixels(Graphics g)
        {
            try
            {
                for (int y = 0; y < 10; y++)
                {
                    for (int x = 0; x < 7; x++)
                    {
                        DrawPixel(g,x*PixelSize.Width,y*PixelSize.Height); 

                    }
                }

            }
            catch { }
        }
        private void DrawGrid(Graphics g)
        {
            try
            {
                var path = (GraphicsPath)BaseGridPath.Clone();
                Matrix mat = new Matrix();
                mat.Scale(PixelSize.Width, PixelSize.Height);
                path.Transform(mat);
                g.DrawPath(new Pen(Color.Magenta, 1), path);

            }
            catch { }
        }

        private void DrawAll(Graphics g)
        {
            DrawPixels(g);
           // DrawGrid(g);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Redraw();
        }

        private void picTable_Click(object sender, EventArgs e)
        {

        }
    }
}
