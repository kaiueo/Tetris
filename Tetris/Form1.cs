using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    public partial class Form1 : Form
    {
        private Image wallImage;
        private Game game;
        public Form1()
        {
            InitializeComponent();
            wallImage = new Bitmap(wallPanel.Width, wallPanel.Height);
            game = new Game(timer, this);
        }

        private void button1_Click(object sender, EventArgs e)
        {

           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        public void Draw()
        {
            Graphics g = Graphics.FromImage(wallImage);
            g.Clear(this.BackColor);
            for(int bgy = 0; bgy < 20; bgy++)
            {
                for(int bgx = 0;bgx < 14; bgx++)
                {
                    if(game.Wall.Bg[bgy, bgx] == 1)
                    {
                        g.FillRectangle(new SolidBrush(Color.Blue), bgx * 20, bgy * 20, 20, 20);
                    }
                }
            }

            for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    if(game.currentBrick.CurrentShape[i][j] == 1)
                    {
                        g.FillRectangle(new SolidBrush(Color.Blue), (j + game.CurrentX) * 20, (i + game.CurrentY) * 20, 20, 20);
                    }
                }
            }
            Graphics gg = wallPanel.CreateGraphics();
            gg.DrawImage(wallImage, 0, 0);
        }

        public void start()
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 14; j++)
                {
                    game.Wall.Bg[i, j] = 0;
                }
            }
            timer.Interval = 1000;
            game.beginDrop();
            this.Focus();



        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Draw();
            base.OnPaint(e);
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            start();
        }

        public void message(String s)
        {
            MessageBox.Show(s);
        }
        public void updateScore()
        {
            scoreLabel.Text = game.Score.ToString();
            Draw();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            game.downBricks();
        }
    }
}
