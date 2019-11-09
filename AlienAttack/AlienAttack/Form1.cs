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
        public Form1()
        {
            InitializeComponent();
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
    }
}
