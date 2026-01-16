using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SetJulia
{
    public partial class Form1 : Form
    {
        Graphics g;
        Bitmap bmp;

        public Form1()
        {
            InitializeComponent();
            this.Text = "Set Julia";
            this.Width = 800;
            this.Height = 800;
            pictureBox1.Width = this.Width;
            pictureBox1.Height = this.Height;
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);
            this.DoubleBuffered = true;

            GenereazaSetJulia();
        }

        private void GenereazaSetJulia()
        {
            int latime = this.ClientSize.Width;
            int inaltime = this.ClientSize.Height;

            double cx = 0.355;
            double cy = 0.355;

            int maxIter = 150;

            double minX = -3.0, maxX = 3.0;
            double minY = -3.0, maxY = 3.0;

            for(int px = 0; px < latime; px++)
            {
                for(int py = 0; py < inaltime; py++)
                {
                    double zx = minX + (double)px / latime * (maxX - minX);
                    double zy = minY + (double)py / inaltime * (maxY - minY);

                    int iter = 0;
                    while (zx * zx + zy * zy < 4 && iter < maxIter)
                    {
                        double xNou = zx * zx - zy * zy + cx;
                        double yNou = 2 * zx * zy + cy;

                        zx = xNou;
                        zy = yNou;
                        iter++;
                    }

                    int c = (int)(255.0 * iter / maxIter);
                    bmp.SetPixel(px, py, Color.FromArgb(c, 0, 255 - c));
                }
            }

            pictureBox1.Image = bmp;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (bmp != null)
                e.Graphics.DrawImage(bmp, 0, 0);
        }
    }
}
