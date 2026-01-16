using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FloodFill
{
    public partial class Form1 : Form
    {
        private Bitmap bmp;
        private PictureBox pictureBox;
        public Form1()
        {
            InitializeComponent();
            this.Text = "FloodFill";
            this.Width = 400;
            this.Height = 300;

            bmp = new Bitmap(this.Width, this.Height);
            pictureBox = new PictureBox
            {
                Dock = DockStyle.Fill,
                Image = bmp
            };
            this.Controls.Add(pictureBox);

            UmpleDreptunghi(50, 50, 200, 100, Color.Blue);
        }
        private void UmpleDreptunghi(int xmin, int ymin, int xmax, int ymax, Color culoare)
        {
            for(int y = ymin; y <= ymax; y++)
            {
                for(int x = xmin; x <= xmax; x++)
                {
                    bmp.SetPixel(x, y, culoare);
                }
            }

            pictureBox.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
