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
        int enemySpeed = 5;
        Random rnd = new Random();
        static List<Enemy> enemies = new List<Enemy>();
        static Enemy enemyToRemove = null;
        int playerHealth = 100;

        public Form1()
        {
            InitializeComponent();

            if (timer1.Enabled)
            {
                makeBasicEnemies(6);
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
            //win
            if (enemies.Count == 0)
            {
                gameOver();
                MessageBox.Show("Congratulations you win!");
            }

            
            //player movement
            if (goLeft && player.Left > 0)
            {
                player.Left -= playerSpeed;
            }
            if (goRight && player.Left < 730)
            {
                player.Left += playerSpeed;
            }

            //bullet movement
            foreach (Control bullet in this.Controls)
            {
                if (bullet is PictureBox && (bullet.Tag == "bullet"))
                {
                    bullet.Top -= 20;
                }
                if (((PictureBox)bullet).Top < this.Height - 600)
                {
                    this.Controls.Remove(bullet);
                    ((PictureBox)bullet).Dispose();
                }
            }

            //bullet interaction
            foreach (Enemy basicEnemy in enemies)
            {
                foreach (Control bullet in this.Controls)
                {
                    if (basicEnemy.pictureBox is PictureBox && basicEnemy.pictureBox.Tag == "basic enemy")
                    {
                        if (bullet is PictureBox && bullet.Tag == "bullet")
                        {
                            if (basicEnemy.pictureBox.Bounds.IntersectsWith(bullet.Bounds))
                            {
                                this.Controls.Remove(basicEnemy.pictureBox);
                                enemyToRemove = basicEnemy;
                                this.Controls.Remove(bullet);
                            }
                        }
                    }
                }
            }
            if (enemyToRemove != null)
            {
                enemies.Remove(enemyToRemove);
                enemyToRemove = null;
            }

            //enemy movement
            foreach (Enemy enemy in enemies)
            {
                if (enemy.Direction == "left" && enemy.pictureBox.Left > 0)
                {
                    enemy.pictureBox.Left -= enemySpeed;
                    enemy.Direction = "left";
                }
                if (enemy.Direction == "left" && enemy.pictureBox.Left == 0)
                {
                    enemy.pictureBox.Left += enemySpeed;
                    enemy.Direction = "right";
                }
                if (enemy.Direction == "right" && enemy.pictureBox.Left < 730)
                {
                    enemy.pictureBox.Left += enemySpeed;
                    enemy.Direction = "right";
                }
                if (enemy.Direction == "right" && enemy.pictureBox.Left == 730)
                {
                    enemy.pictureBox.Left -= enemySpeed;
                    enemy.Direction = "left";
                }
                
            }
            
        }

        //Bullet timer
        private void timer2_Tick(object sender, EventArgs e)
        {
            foreach (var enemy in enemies)
            {
                if (enemy.pictureBox.Left == player.Left)
                {
                    enemyShoot();
                }
                foreach (Control enemyBullet in this.Controls)
                {
                    if (enemyBullet is PictureBox && enemyBullet.Tag == "enemyBullet")
                    {
                        enemyBullet.Top += 10;
                        if (enemyBullet.Top == this.Bottom)
                        {
                            this.Controls.Remove(enemyBullet);
                            ((PictureBox)enemyBullet).Dispose();
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
            
            for (int i = 0; i < number; i++)
            {
                PictureBox basic = new PictureBox();
                basic.Size = new Size(50, 50);
                basic.Tag = "basic enemy";
                basic.BackColor = System.Drawing.Color.Blue;
                                
                var basicEnemy = new Enemy()
                {
                    enemyType = EnemyType.basic,
                    pictureBox = basic
                    
                };
                enemies.Add(basicEnemy);

                
            }
            foreach (var enemy in enemies)
            {
                enemy.pictureBox.Left = rnd.Next(0, 15) * 50;
                enemy.pictureBox.Top = rnd.Next(0, 8) * 50;
                this.Controls.Add(enemy.pictureBox);
                enemy.pictureBox.BringToFront();
                enemy.Direction = "left";
            }
        }

        private void enemyShoot()
        {
            foreach (Enemy enemy in enemies)
            {
                PictureBox enemyBullet = new PictureBox();
                enemyBullet.Size = new Size(5, 5);
                enemyBullet.Tag = "enemyBullet";
                enemyBullet.BackColor = System.Drawing.Color.Green;
                enemyBullet.Left = enemy.pictureBox.Left + enemy.pictureBox.Width / 2;
                enemyBullet.Top = enemy.pictureBox.Bottom;
                this.Controls.Add(enemyBullet);
                enemyBullet.BringToFront();
                
            }
            
        }

        private void gameOver()
        {
            timer1.Stop();
            timer2.Stop();
        }

        
    }

    public enum EnemyType
    {
        basic, medium
    }
    public class Enemy
    {
        public EnemyType enemyType { get; set; }
        public PictureBox pictureBox { get; set; }
        private string direction;
        public string Direction { get => direction; set => direction = value; }

        
    }
}
