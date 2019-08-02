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
    public delegate void Win(int time, int trys, Form1 sender);

    public partial class Form1 : Form
    {
        Random random = new Random();
        int trys = 0;
        int time = 0;

        public event Win Wygrana;

        List<string> icons = new List<string>()
        {
            "!","@","%","$","b","N","V","L",
            "!","@","%","$","b","N","V","L"
        };

        Label firstClicked, secondCliced;

        public Form1()
        {
            InitializeComponent();
            AssignIconsToSquares();
        }


        private void label_Click(object sender, EventArgs e)
        {
            if (firstClicked != null && secondCliced != null)
                return;

            Label clickedLabel;

            if (sender is Label)
                clickedLabel = (Label)sender;
            else
                return;

            if (clickedLabel.ForeColor == Color.Black)
                return;

            if (firstClicked == null)
            {
                firstClicked = clickedLabel;
                firstClicked.ForeColor = Color.Black;
                return;
            }

            secondCliced = clickedLabel;
            secondCliced.ForeColor = Color.Black;


            CheckForWin();

            

            if(firstClicked.Text == secondCliced.Text)
            {
                firstClicked = null;
                secondCliced = null;
                //Wygrana(time, trys, this);
            }
            else
                timer1.Start();
        }

        private void CheckForWin()
        {
            Label label;
            for(int i = 0; i<tableLayoutPanel1.Controls.Count; i++)
            {
                if (tableLayoutPanel1.Controls[i] is Label)
                {
                    label = (Label)tableLayoutPanel1.Controls[i];
                    if (label.ForeColor == label.BackColor)
                        return;
                }
                else
                    continue;
            }

            Wygrana(time, trys, this);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            firstClicked.ForeColor = firstClicked.BackColor;
            secondCliced.ForeColor = secondCliced.BackColor;

            firstClicked = null;
            secondCliced = null;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            time++;
        }

        private void AssignIconsToSquares()
        {
            Label label;
            int randomNumber;

            for(int i=0; i<tableLayoutPanel1.Controls.Count; i++)
            {
                if (tableLayoutPanel1.Controls[i] is Label)
                    label = (Label)tableLayoutPanel1.Controls[i];
                else
                    continue;

                randomNumber = random.Next(0, icons.Count);
                label.Text = icons[randomNumber];
               

                icons.RemoveAt(randomNumber);
            }
        }
    }
}
