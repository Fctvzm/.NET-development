using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EndTerm
{
    public partial class Form1 : Form
    {
        Color color1, color2, color;
        Ball ball;
        int numberOfBalls, cnt = 0, x = 56, y = 26, diameter = 8;

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show(e.Location + "");
        }

        private void num_Click(object sender, EventArgs e)
        {
            numberOfBalls = Int16.Parse(textBox1.Text);
            Color1.Enabled = true;
            Color2.Enabled = true;
            Color3.Enabled = true;
            //MessageBox.Show("Yes");
        }


        public Form1()
        {
            InitializeComponent();
            Color1.Click += new EventHandler(chooseColor);
            Color2.Click += new EventHandler(chooseColor);
            Color3.Click += new EventHandler(chooseColor);
        }

        private void chooseColor(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            color = colorDialog1.Color;
            Button button = sender as Button;
            button.BackColor = color;
            switch (cnt)
            {
                case 0:
                    color1 = colorDialog1.Color;
                    break;
                case 1:
                    int temp = y + diameter;
                    y += diameter * (numberOfBalls + 1);
                    color2 = colorDialog1.Color;
                    coloringVertical(color1, color2, x, temp, y);
                    break;
                case 2:
                    coloringDiagonal(color1, color2, color, x, y - diameter * (numberOfBalls + 1), y);
                    x += diameter * (numberOfBalls + 1);
                    y -= (diameter * numberOfBalls) / 2 + (diameter / 2);
                    break;
            }
            addBall(color, x, y);
            cnt++;
            if (cnt == 3)
            {
                ToolTip tip = new ToolTip();
                tip.ShowAlways = true;
                foreach(Control ball in panel2.Controls)
                {
                    Ball b = ball as Ball;
                    tip.SetToolTip(ball, b.color.R + "," + b.color.G + "," + b.color.B);
                }
            }
        }

        private void addBall (Color color, int x, int y)
        {
            ball = new Ball(color);
            ball.Location = new Point(x, y);
            ball.Size = new Size(diameter, diameter);
            panel2.Controls.Add(ball);
        }

        private int [] difference (Color c1, Color c2)
        {
            int[] deltas = new int[3];
            deltas[0] = (c2.R - c1.R) / numberOfBalls;
            deltas[1] = (c2.G - c1.G) / numberOfBalls;
            deltas[2] = (c2.B - c1.B) / numberOfBalls;
            return deltas;
        }

        private void coloringVertical (Color col1, Color col2, int x, int y1, int y2)
        {
            int[] deltas = difference(col1, col2); 
            int r = col1.R + deltas[0], g = col1.G + deltas[1], b = col1.B + deltas[2];
            while (y1 < y2)
            {
                addBall(Color.FromArgb(r, g, b), x, y1);
                r += deltas[0];
                g += deltas[1];
                b += deltas[2];
                y1 += diameter;
            }
        }

        private void coloringDiagonal(Color col1, Color col2, Color col3, int x, int y1, int y2)
        {
            int[] delta1 = difference(col1, col3);
            int r1 = col1.R + delta1[0], g1 = col1.G + delta1[1], b1 = col1.B + delta1[2];

            int[] delta2 = difference(col2, col3);
            int r2 = col2.R + delta2[0], g2 = col2.G + delta2[1], b2 = col2.B + delta2[2];

            for (int i = 0; i < numberOfBalls; i++)
            {
                y1 += diameter / 2;
                y2 -= diameter / 2;
                x += diameter;

                col1 = Color.FromArgb(r1, g1, b1);
                col2 = Color.FromArgb(r2, g2, b2);

                coloringVertical(col1, col2, x, y1, y2);

                addBall(col1, x, y1);
                addBall(col2, x, y2);

                r1 += delta1[0];
                g1 += delta1[1];
                b1 += delta1[2];
                r2 += delta2[0];
                g2 += delta2[1];
                b2 += delta2[2];
            }

        }
    }
}
