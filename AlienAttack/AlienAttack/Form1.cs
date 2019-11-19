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
        int stage = 1;
        int score = 0;
        int time = 600;

        public Form1()
        {
            InitializeComponent();
            FailPanel.Hide();
            WinPage.Hide();
        }

        #region StartPage
        private void button1_Click(object sender, EventArgs e)
        {
            StartPage.Dispose();
            makeBasicEnemies(6);
            timer1.Start();
            timer2.Start();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region FailPage
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region WinPage
        private void button5_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region PlayerInput
        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                goLeft = true;
            }
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                goRight = true;
            }
            if (e.KeyCode == Keys.Space && !isPressed)
            {
                isPressed = true;
                makeBullet();
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                goRight = false;
            }
            if (isPressed)
            {
                isPressed = false;
            }
        }
        #endregion

        #region Timers
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (enemies.Count == 0 && stage == 1)
            {
                makeMediumEnemies(6);
                stage = 2;

            }

            if (enemies.Count == 0 && stage == 2)
            {
                WinPage.Show();
                WinPage.BringToFront();
                gameOver();
            }


            #region HealthBarAndLose
            if (playerHealth > 1)
            {
                HealthBar.Value = playerHealth;
            }
            else
            {
                HealthBar.Value = 0;
                FailPanel.Show();
                FailPanel.BringToFront();
                gameOver();
            }
            #endregion

            #region PlayerMovement
            //player movement
            if (goLeft && player.Left > 0)
            {
                player.Left -= playerSpeed;
            }
            if (goRight && player.Left < 730)
            {
                player.Left += playerSpeed;
            }
            #endregion

            #region PlayerShooting
            foreach (Control bullet in this.Controls)
            {
                if (bullet is PictureBox && (bullet.Tag == "bullet"))
                {
                    bullet.Top -= 20;
                }
                if (bullet is PictureBox && ((PictureBox)bullet).Top == this.Top && bullet.Tag == "bullet")
                {
                    this.Controls.Remove(bullet);
                    ((PictureBox)bullet).Dispose();
                }
            }
            #endregion

            #region BulletInteraction

            foreach (Enemy enemy in enemies)
            {
                foreach (Control bullet in this.Controls)
                {
                    if (enemy.pictureBox is PictureBox && enemy.pictureBox.Tag.ToString().Contains("enemy"))
                    {
                        if (bullet is PictureBox && bullet.Tag == "bullet")
                        {
                            if (enemy.pictureBox.Bounds.IntersectsWith(bullet.Bounds))
                            {
                                this.Controls.Remove(bullet);
                                ((PictureBox)bullet).Dispose();
                                enemy.Health -= 1;
                                if (enemy.Health == 0)
                                {
                                    this.Controls.Remove(enemy.pictureBox);
                                    enemyToRemove = enemy;
                                    if (enemy.pictureBox.Tag == "medium enemy")
                                    {
                                        score += 300;
                                    }
                                    else if (enemy.pictureBox.Tag =="basic enemy")
                                    {
                                        score += 100;
                                    }
                                }
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
            #endregion

            label1.Text = "Score: " + score;

            #region EnemyMovement
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
            #endregion

            #region EnemyBulletInteraction
            //enemy bullet interaction
            foreach (Control enemyBullet in this.Controls)
            {
                if (enemyBullet is PictureBox && enemyBullet.Tag == "enemyBullet")
                {
                    if (((PictureBox)enemyBullet).Bounds.IntersectsWith(player.Bounds))
                    {
                        playerHealth -= 35;
                        this.Controls.Remove(enemyBullet);
                        ((PictureBox)enemyBullet).Dispose();
                    }
                }
            }
            #endregion
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
            if (time > 0)
            {
                time -= timer2.Interval / 100;
                label3.Text = "Time: " + time/10;
            }
            else
            {
                gameOver();
                DialogResult dialogResult = MessageBox.Show("You ran out of time", "Would you like to try again?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Application.Restart();
                }
                else if (dialogResult == DialogResult.No)
                {
                    Application.Exit();
                }
            }
        }
        #endregion

        private void makeBullet()
        {
            PictureBox bullet = new PictureBox();
            bullet.Size = new Size(5, 5);
            bullet.Tag = "bullet";
            bullet.BackColor = System.Drawing.Color.Red;
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
                basic.Image = Image.FromFile("C:\\Users\\Harry Barnett\\Engineering45\\AilenAttack\\AlienAttack\\AlienAttack\\Resources\\basicEnemy.png");

                var basicEnemy = new Enemy()
                {
                    enemyType = EnemyType.basic,
                    pictureBox = basic
                };
                enemies.Add(basicEnemy);
            }

            foreach (Enemy enemy in enemies)
            {
                enemy.pictureBox.Left = rnd.Next(0, 15) * 50;
                enemy.pictureBox.Top = rnd.Next(1, 8) * 50;
                this.Controls.Add(enemy.pictureBox);
                enemy.pictureBox.BringToFront();
                enemy.Direction = "left";
                enemy.Health = 1;
            }
        }

        private void makeMediumEnemies(int number)
        {
            for (int i = 0; i < number; i++)
            {
                PictureBox medium = new PictureBox();
                medium.Size = new Size(100, 75);
                medium.Tag = "medium enemy";
                medium.Image = Image.FromFile("C:\\Users\\Harry Barnett\\Engineering45\\AilenAttack\\AlienAttack\\AlienAttack\\Resources\\mediumEnemy.png");

                var mediumEnemy = new Enemy()
                {
                    enemyType = EnemyType.medium,
                    pictureBox = medium
                };
                enemies.Add(mediumEnemy);
            }

            foreach (Enemy enemy in enemies)
            {
                enemy.pictureBox.Left = rnd.Next(0, 6) * 100;
                enemy.pictureBox.Top = rnd.Next(1, 5) * 75;
                this.Controls.Add(enemy.pictureBox);
                enemy.pictureBox.BringToFront();
                enemy.Direction = "right";
                enemy.Health = 3;
            }
        }

        private void enemyShoot()
        {
            foreach (Enemy enemy in enemies)
            {
                PictureBox bullet = new PictureBox();
                bullet.Size = new Size(5, 5);
                bullet.Tag = "enemyBullet";
                bullet.BackColor = System.Drawing.Color.Green;
                bullet.Left = enemy.pictureBox.Left + enemy.pictureBox.Width / 2;
                bullet.Top = enemy.pictureBox.Bottom;
                this.Controls.Add(bullet);
                bullet.BringToFront();

            }
        }

        private void gameOver()
        {
            timer1.Stop();
            timer2.Stop();
            
        }
    }
}
