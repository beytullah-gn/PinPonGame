using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PinPonGame
{
    public partial class GameForm : Form
    {
        public int speed_left = 4;
        public int speed_top = 4;
        public int score = 0;

        public GameForm()
        {

            InitializeComponent();
            timer1.Enabled = true;
            Cursor.Hide();
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;
            this.Bounds = Screen.PrimaryScreen.Bounds;
            racket.Top = playground.Bottom - (playground.Bottom/10);
            gameover_label.Left = (playground.Width / 2) - (gameover_label.Width / 2);
            gameover_label.Top = (playground.Height / 2) - (gameover_label.Height / 2);
            gameover_label.Visible = false;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            racket.Left = Cursor.Position.X-(racket.Width/2);
            ball.Left += speed_left;
            ball.Top  += speed_top;
            if(ball.Left <= playground.Left)
            {
                speed_left = -speed_left;

            }
            if (ball.Right >= playground.Right)
            {
                speed_left = -speed_left;

            }
            if (ball.Top <= playground.Top)
            {
                speed_top = -speed_top;

            }
            if (ball.Bottom >= playground.Bottom)
            {
                gameover_label.Visible = true;
                timer1.Enabled = false;

            }
            if (ball.Bottom >= racket.Top && ball.Bottom <= racket.Bottom && ball.Left >= racket.Left && ball.Right <= racket.Right)
            {
                speed_top += 2;
                speed_left += 2;
                speed_top =- speed_top;
                score += 1;
                points_label.Text = score.ToString();
                Random random = new Random();
                playground.BackColor = Color.FromArgb(random.Next(100, 255), random.Next(100, 255),random.Next(100, 255));

            }

        }

        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            if (e.KeyCode == Keys.F1)
            {
                ball.Top = 50;
                ball.Left = 50;
                speed_left = 4;
                speed_top = 4;
                score = 0;
                points_label.Text = "0";
                timer1.Enabled = true;
                gameover_label.Visible = false;
                playground.BackColor = Color.White;
            }
        }

        private void GameForm_Load(object sender, EventArgs e)
        {

        }
    }
}
