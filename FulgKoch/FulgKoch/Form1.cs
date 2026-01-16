using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FulgKoch
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.Text = "Fulgul lui Koch";
            this.Size = new Size(800, 700);
            this.BackColor = Color.White;
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics grafica = e.Graphics;

            PointF punct1 = new PointF(150, 500);
            PointF punct2 = new PointF(650, 500);
            PointF punct3 = new PointF(400, 150);

            int adancime = 5;

            DeseneazaKoch(grafica, punct1, punct2, adancime);
            DeseneazaKoch(grafica, punct2, punct3, adancime);
            DeseneazaKoch(grafica, punct3, punct1, adancime);

            //grafica.DrawEllipse(Pens.Black, punct1.X, punct1.Y, 25, 25);
            //grafica.DrawEllipse(Pens.Black, punct2.X, punct2.Y, 25, 25);
            //grafica.DrawEllipse(Pens.Black, punct3.X, punct3.Y, 25, 25);
        }

        private void DeseneazaKoch(Graphics grafica, PointF a, PointF b, int adancime)
        {
            if (adancime == 0)
            {
                grafica.DrawLine(Pens.Blue, a, b);
                return;
            }

            PointF punctIntermediar1 = new PointF(
                a.X + (b.X - a.X) / 3f,
                a.Y + (b.Y - a.Y) / 3f);

            PointF punctIntermediar2 = new PointF(
                a.X + 2f * (b.X - a.X) / 3f,
                a.Y + 2f * (b.Y - a.Y) / 3f);

            //double unghi = Math.PI / 3;
            float deltaX = punctIntermediar2.X - punctIntermediar1.X;
            float deltaY = punctIntermediar2.Y - punctIntermediar1.Y;

            PointF varfTriunghi = new PointF(
                (float)(punctIntermediar1.X + deltaX / 2.0 - Math.Sqrt(3) * deltaY / 2.0),
                (float)(punctIntermediar1.Y + deltaY / 2.0 + Math.Sqrt(3) * deltaX / 2.0)
                );

            DeseneazaKoch(grafica, a, punctIntermediar1, adancime - 1);
            DeseneazaKoch(grafica, punctIntermediar1, varfTriunghi, adancime - 1);
            DeseneazaKoch(grafica, varfTriunghi, punctIntermediar2, adancime - 1);
            DeseneazaKoch(grafica, punctIntermediar2, b, adancime - 1);
        }
    }
}
