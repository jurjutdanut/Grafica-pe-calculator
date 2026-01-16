using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SetulMandelbrot
{
    public partial class Form1 : Form
    {
        const int LATIME = 800;
        const int INALTIME = 600;
        const int MAX_ITER = 500;

        double minRe = -2.5;
        double maxRe = 1.0;
        double minIm = -1.0;
        double maxIm = 1.0;

        public Form1()
        {
            this.Text = "Setul Mandelbrot";
            this.Size = new Size(LATIME, INALTIME);
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Bitmap bmp = new Bitmap(LATIME, INALTIME);

            for (int px = 0; px < LATIME; px++)
            {
                for(int py = 0; py < INALTIME; py++)
                {
                    double cr = minRe + px * (maxRe - minRe) / LATIME;
                    double ci = maxIm - py * (maxIm - minIm) / INALTIME;

                    double zr = 0;
                    double zi = 0;
                    int iter = 0;

                    while(zr * zr + zi * zi <= 4 && iter < MAX_ITER)
                    {
                        double temp = zr * zr - zi * zi + cr;
                        zi = 2 * zr * zi + ci;
                        zr = temp;
                        iter++;
                    }

                    bmp.SetPixel(px, py, iter == MAX_ITER ? Color.Black : Color.Blue);
                }
            }
            pictureBox1.Image = bmp;
        }
    }
}
