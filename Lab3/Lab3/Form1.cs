using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Lab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "Scalare Dreptunghi";
            this.Size = new Size(800, 600);
            this.BackColor = Color.White;
            this.DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            PointF[] originalRect = new PointF[]
            {
                new PointF(100,100),
                new PointF(200,100),
                new PointF(200,200),
                new PointF(100,200)
            };
            g.DrawPolygon(new Pen(Color.Blue, 2), originalRect);
            float scale = 2.0f;
            PointF[] scaledRect = new PointF[originalRect.Length];
            for(int i = 0; i < originalRect.Length; i++)
            {
                scaledRect[i] = new PointF(originalRect[i].X * scale, originalRect[i].Y * scale);
            }
            g.DrawPolygon(new Pen(Color.Red, 2), scaledRect);
            base.OnPaint(e);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
