using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cercul
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        void DrawCircleBresenham(Graphics g, int x0, int y0, int r, Pen pen)
        {
            int x = 0, y = r;
            int d = 3 - 2 * r;

            while (x <= y)
            {
                DrawSymmetricPoints(g, x0, y0, x, y, pen);
                if (d < 0)
                {
                    d = d + 4 * x + 6;
                }
                else
                {
                    d = d + 4 * (x - y) + 10;
                    y--;
                }
                x++;
            }
        }

        void DrawSymmetricPoints(Graphics g, int x0, int y0, int x, int y, Pen pen)
        {
            g.DrawRectangle(pen, x0 + x, y0 + y, 1, 1);
            g.DrawRectangle(pen, x0 - x, y0 + y, 1, 1);
            g.DrawRectangle(pen, x0 + x, y0 - y, 1, 1);
            g.DrawRectangle(pen, x0 - x, y0 - y, 1, 1);
            g.DrawRectangle(pen, x0 + y, y0 + x, 1, 1);
            g.DrawRectangle(pen, x0 - y, y0 + x, 1, 1);
            g.DrawRectangle(pen, x0 + y, y0 - x, 1, 1);
            g.DrawRectangle(pen, x0 - y, y0 - x, 1, 1);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Blue, 1);
            DrawCircleBresenham(g, 200, 200, 100, pen);
        }
    }
}
