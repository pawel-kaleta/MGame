using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MGame
{
    public partial class Form2 : Form
    {
        List<Pen> pens = new List<Pen>();
        Random random = new Random();
        List<List<float[]>> punkty = new List<List<float[]>>();

        public Form2()
        {
            InitializeComponent();
            newShot();
        }

        private void newShot()
        {
            
            label2.ForeColor = Color.FromArgb(random.Next(255), random.Next(255), random.Next(255));

            Pen newPen = new Pen(Color.FromArgb(random.Next(255), random.Next(255), random.Next(255)));
            pens.Add(newPen);
            int x = random.Next(25, 400);
            int y = random.Next(25, 400);
            int number = random.Next(40,50);
            List<float[]> points = new List<float[]>();
            for (int i = 0; i < number; i++)
            {
                float[] punkt = new float[4];
                punkt[0] = x;
                punkt[1] = y;
                punkt[2] = random.Next(-5,5);
                punkt[3] = random.Next(-5,5);
                points.Add(punkt);
            }
            punkty.Add(points);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            newShot();
        }

        private void frame(object sender, EventArgs e)
        {
            for (int i = 0; i < punkty.Count() - 1; i++)
            {
                bool good = false;
                for (int j = 0; j < punkty.ElementAt(i).Count() - 1; j++)
                {
                    punkty[i][j][0] += punkty[i][j][2];
                    punkty[i][j][1] += punkty[i][j][3];

                    punkty[i][j][3] += 0.1f;
                    if (punkty[i][j][1] < 460)
                        good = true;
                }
                if (!good)
                {
                    punkty.RemoveAt(i);
                    pens.RemoveAt(i);
                }
            }
            
            Refresh();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < punkty.Count() - 1; i++)
                for (int j = 0; j < punkty.ElementAt(i).Count() - 1; j++)
                {
                    e.Graphics.FillEllipse(pens[i].Brush, punkty[i][j][0], punkty[i][j][1], 3, 3);
                    
                }
        }
    }
}
