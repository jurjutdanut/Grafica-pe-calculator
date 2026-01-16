using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SetulLuiCantor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "Setul Cantor";
            this.Width = 800;
            this.Height = 600;
            this.DoubleBuffered = true;
        }

        public List<(double, double)> GenereazaCantor(int iteratii)
        {
            var segmente = new List<(double, double)> { (0.0, 1.0) };

            for(int i = 0; i < iteratii; i++)
            {
                var segmenteNoi = new List<(double, double)>();

                foreach (var segment in segmente)
                {
                    double stanga = segment.Item1;
                    double dreapta = segment.Item2;
                    double oTreime = (dreapta - stanga) / 3.0;

                    segmenteNoi.Add((stanga, stanga + oTreime));
                    segmenteNoi.Add((dreapta - oTreime, dreapta));
                }

                segmente = segmenteNoi;
            }

            return segmente;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            int numarIteratii = 5;
            int inaltimeSegment = 20;
            int spatiuVertical = 10;

            int latimeFormular = this.ClientSize.Width;

            for(int nivel = 0; nivel < numarIteratii; nivel++)
            {
                var segmenteNivel = GenereazaCantor(nivel);

                int pozY = nivel * (inaltimeSegment + spatiuVertical) + spatiuVertical;

                foreach(var segment in segmenteNivel)
                {
                    int xStart = (int)(segment.Item1 * latimeFormular);
                    int xEnd = (int)(segment.Item2 * latimeFormular);

                    e.Graphics.DrawLine(Pens.Black, xStart, pozY, xEnd, pozY);
                }
            }
        }

    }
}
