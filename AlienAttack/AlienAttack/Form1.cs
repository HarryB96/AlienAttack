using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlienAttack
{
    public partial class Form1 : Form
    {
        bool goLeft;
        bool goRight;
        bool isPressed;
        int playerSpeed = 10;
        Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();

            if (timer1.Enabled)
            {
                makeBasicEnemies(6);
                makeMediumEnemies(0);
            }
        }
        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = true;
            }
            if (e.KeyCode == Keys.Z && !isPressed)
            {
                isPressed = true;
                makeBullet();
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
            if (isPressed)
            {
                isPressed = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (goLeft && player.Left > 0)
            {
                player.Left -= playerSpeed;
            }
            if (goRight && player.Left < 730)
            {
                player.Left += playerSpeed;
            }
            foreach (Control y in this.Controls)
            {
                if (y is PictureBox && (y.Tag == "bullet"))
                {
                    y.Top -= 20;
                }
                if (((PictureBox)y).Top < this.Height - 600)
                {
                    this.Controls.Remove(y);
                }
            }

            foreach (Control i in this.Controls)
            {
                foreach (Control j in this.Controls)
                {
                    if (i is PictureBox && i.Tag == "basic enemy")
                    {
                        if (j is PictureBox && j.Tag == "bullet")
                        {
                            if (i.Bounds.IntersectsWith(j.Bounds))
                            {
                                this.Controls.Remove(i);
                                this.Controls.Remove(j);
                            }
                        }
                    }
                }
            }
        }

        private void makeBullet()
        {
            PictureBox bullet = new PictureBox();
            bullet.Size = new Size(5, 5);
            bullet.Tag = "bullet";
            bullet.BackColor = System.Drawing.Color.Black;
            bullet.Left = player.Left + player.Width / 2;
            bullet.Top = player.Top - 5;
            this.Controls.Add(bullet);
            bullet.BringToFront();
        }

        private void makeBasicEnemies(int number)
        {
            int i = 0;
            while (i < number)
            {
                PictureBox basic = new PictureBox();
                basic.Size = new Size(50, 50);
                basic.Tag = "basic enemy";
                basic.BackColor = System.Drawing.Color.Blue;
                int x = rnd.Next(0, 16);
                int y = rnd.Next(0, 40);
                basic.Left = x * 50;
                basic.Top = y * 10;
                this.Controls.Add(basic);
                basic.BringToFront();
                i++;
            }

        }
        private void makeMediumEnemies(int number)
        {
            int i = 0;
            while (i < number)
            {
                PictureBox medium = new PictureBox();
                medium.Size = new Size(100, 50);
                medium.Tag = "medium enemy";
                medium.BackColor = System.Drawing.Color.Yellow;
                medium.Left = rnd.Next(0, 730);
                medium.Top = rnd.Next(0, 400);
                this.Controls.Add(medium);
                medium.BringToFront();
                i++;
            }

        }
        private void gameOver()
        {
            timer1.Stop();
        }
    }
}
