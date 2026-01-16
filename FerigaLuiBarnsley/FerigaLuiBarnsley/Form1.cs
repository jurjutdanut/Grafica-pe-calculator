using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FerigaLuiBarnsley
{
    public partial class Form1 : Form
    {
        Graphics g;
        

        private List<(double, double)> puncteFractal;
        public Form1()
        {
            InitializeComponent();
            this.Text = "Barnsley Fern";
            this.Width = 800;
            this.Height = 800;
            this.DoubleBuffered = true;
            

            puncteFractal = GenereazaBarnsleyFern(500000);
        }

        private List<(double, double)> GenereazaBarnsleyFern(int numarPuncte)
        {
            var puncte = new List<(double, double)>();
            double x = 0, y = 0;
            var rand = new Random();

            for(int i = 0; i < numarPuncte; i++)
            {
                double r = rand.NextDouble();
                double xNou, yNou;

                if(r < 0.01)
                {
                    xNou = 0;
                    yNou = 0.16 * y;
                }
                else if (r < 0.86)
                {
                    xNou = 0.85 * x + 0.04 * y;
                    yNou = -0.04 * x + 0.85 * y + 1.6;
                }
                else if (r < 0.93)
                {
                    xNou = 0.2 * x - 0.26 * y;
                    yNou = 0.23 * x + 0.22 * y + 1.6;
                }
                else
                {
                    xNou = -0.15 * x + 0.28 * y;
                    yNou = 0.26 * x + 0.24 * y + 0.44;
                }

                x = xNou;
                y = yNou;
                puncte.Add((x, y));

            }

            return puncte;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (puncteFractal == null || puncteFractal.Count == 0)
                return;

            int latimeFormular = this.ClientSize.Width;
            int inaltimeFormular = this.ClientSize.Height;

            double xMin = double.MaxValue, xMax = double.MinValue;
            double yMin = double.MaxValue, yMax = double.MinValue;

            foreach(var p in puncteFractal)
            {
                if (p.Item1 < xMin) xMin = p.Item1;
                if (p.Item1 > xMax) xMax = p.Item1;
                if (p.Item2 < yMin) yMin = p.Item2;
                if (p.Item2 > yMax) yMax = p.Item2;
            }

            foreach(var p in puncteFractal)
            {
                int xPixel = (int)((p.Item1 - xMin) / (xMax - xMin) * latimeFormular);
                int yPixel = inaltimeFormular - (int)((p.Item2 - yMin) / (yMax - yMin) * inaltimeFormular);

                e.Graphics.FillRectangle(Brushes.Green, xPixel, yPixel, 1, 1);
            }

        
        }
    }
}
