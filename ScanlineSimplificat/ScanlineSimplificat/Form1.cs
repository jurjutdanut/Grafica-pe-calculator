using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScanlineSimplificat
{
    public partial class Form1 : Form
    {

        private List<Point> punctePoligon = new List<Point>()
        {
            new Point(100, 100),
            new Point(200, 80),
            new Point(250, 150),
            new Point(180, 200),
            new Point(120, 180)
        };
        public Form1()
        {
            InitializeComponent();
            this.Text = "Scanline simplificat";
            this.Width = 400;
            this.Height = 300;
            this.Paint += DeseneazaPoligonUmplut;
        }

        private void DeseneazaPoligonUmplut(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush brush = Brushes.LightSkyBlue;

            int yMin = int.MaxValue, yMax = int.MinValue;

            foreach (Point p in punctePoligon)
            {
                yMin = Math.Min(yMin, p.Y);
                yMax = Math.Max(yMax, p.Y);
            }

            for(int y = yMin; y <= yMax; y++)
            {
                List<int> intersectii = new List<int>();

                for(int i = 0; i < punctePoligon.Count; i++)
                {
                    Point p1 = punctePoligon[i];
                    Point p2 = punctePoligon[(i + 1) % punctePoligon.Count];

                    if ((y >= p1.Y && y < p2.Y) || (y >= p2.Y && y < p1.Y))
                    {
                        float x = p1.X + (float)(y - p1.Y) * (p2.X - p1.X) / (p2.Y - p1.Y);
                        intersectii.Add((int)x);
                    }
                }

                intersectii.Sort();

                for(int i = 0; i < intersectii.Count - 1; i +=2)
                {
                    g.DrawLine(Pens.Blue, intersectii[i], y, intersectii[i + 1], y);
                }
            }

            g.DrawPolygon(Pens.Black, punctePoligon.ToArray());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
