using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Sqlite;

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
        int hitsRemaining = 3;
        Panel StartPanel = new Panel();
        Panel Instructions = new Panel();
        Panel ScorePanel = new Panel();
        Panel WinPanel = new Panel();

        TextBox enterName = new TextBox();
        Button submit = new Button();
        Label doThis = new Label();
        public static List<HighScore> HighScoreList = new List<HighScore>();

        public Form1()
        {
            InitializeComponent();
            StartPanelShow(StartPanel);
        }

        #region Buttons
        private void button1_Click(object sender, EventArgs e)
        {
            StartPanel.Dispose();
            Instructions.Dispose();
            ScorePanel.Dispose();
            makeBasicEnemies(6);
            timer1.Start();
            timer2.Start();
        }

        private void Instructions_Click(object sender, EventArgs e)
        {
            InstructionsShow();
        }

        private void Scores_Click(object sender, EventArgs e)
        {
            ScorePanelShow();
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            string name = enterName.Text;
            var newScore = new HighScore(name, ((score + time) * hitsRemaining));
            addScore(newScore);
            WinPanel.Controls.Remove(submit);
            WinPanel.Controls.Remove(enterName);
            WinPanel.Controls.Remove(doThis);
        }

        private void Menu_Click(object sender, EventArgs e)
        {

            StartPanel.Show();
            Instructions.Hide();
            ScorePanel.Hide();
        }
        private void Restart_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void Quit_Click(object sender, EventArgs e)
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
                WinPanelShow();
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
                LosePanelShow();
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
                        hitsRemaining--;
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

        #region WinPanel
        private void WinPanelShow()
        {
            Label WinTitle = new Label();
            Label FinalScore = new Label();
            Button Replay = new Button();
            Button Quit = new Button();
            

            WinPanel.Size = new Size(784, 561);
            WinPanel.Location = new Point(0, 0);
            WinPanel.BackColor = System.Drawing.Color.Black;

            WinTitle.Text = "You Win";
            WinTitle.Location = new Point(277, 159);
            WinTitle.ForeColor = System.Drawing.Color.White;
            WinTitle.Size = new Size(400, 55);
            WinTitle.Font = new Font("Microsoft Sans Serif", 36, FontStyle.Bold);
            
            FinalScore.Text = "Final Score: " + ((score + time) * hitsRemaining);
            FinalScore.ForeColor = System.Drawing.Color.White;
            FinalScore.Size = new Size(200, 20);
            FinalScore.Location = new Point(357, 265);
            FinalScore.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);

            Replay.Location = new Point(209, 337);
            Replay.BackColor = System.Drawing.Color.AliceBlue;
            Replay.Text = "Replay";
            Replay.Click += Restart_Click;

            Quit.Location = new Point(512, 337);
            Quit.BackColor = System.Drawing.Color.AliceBlue;
            Quit.Text = "Quit";
            Quit.Click += Quit_Click;

            doThis.Text = "Enter Name";
            doThis.Location = new Point(300, 300);
            doThis.ForeColor = System.Drawing.Color.White;
            doThis.Size = new Size(200, 20);
            doThis.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);

            enterName.Location = new Point(300, 337);
            submit.Location = new Point(300, 400);
            submit.BackColor = System.Drawing.Color.AliceBlue;
            submit.Text = "Submit";
            submit.Click += Submit_Click;

            this.Controls.Add(WinPanel);
            WinPanel.BringToFront();
            WinPanel.Controls.Add(WinTitle);
            WinPanel.Controls.Add(FinalScore);
            WinPanel.Controls.Add(Replay);
            WinPanel.Controls.Add(Quit);
            WinPanel.Controls.Add(doThis);
            WinPanel.Controls.Add(enterName);
            WinPanel.Controls.Add(submit);
        }
        #endregion

        #region LosePanel
        private void LosePanelShow()
        {
            Panel LosePanel = new Panel();
            Label LoseTitle = new Label();
            Button Retry = new Button();
            Button Quit = new Button();

            LosePanel.Size = new Size(784, 561);
            LosePanel.Location = new Point(0, 0);
            LosePanel.BackColor = System.Drawing.Color.Black;

            LoseTitle.Text = "Game Over";
            LoseTitle.Location = new Point(277, 159);
            LoseTitle.ForeColor = System.Drawing.Color.White;
            LoseTitle.Size = new Size(400, 55);
            LoseTitle.Font = new Font("Microsoft Sans Serif", 36, FontStyle.Bold);

            Retry.Location = new Point(209, 337);
            Retry.BackColor = System.Drawing.Color.AliceBlue;
            Retry.Text = "Replay";
            Retry.Click += Restart_Click;

            Quit.Location = new Point(512, 337);
            Quit.BackColor = System.Drawing.Color.AliceBlue;
            Quit.Text = "Quit";
            Quit.Click += Quit_Click;

            this.Controls.Add(LosePanel);
            LosePanel.BringToFront();
            LosePanel.Controls.Add(LoseTitle);
            LosePanel.Controls.Add(Retry);
            LosePanel.Controls.Add(Quit);
        }
        #endregion

        #region StartPanel
        private void StartPanelShow(Panel panel)
        {
            Label MenuTitle = new Label();
            Button Start = new Button();
            Button Instructions = new Button();
            Button Quit = new Button();
            Button Score = new Button();

            panel.Size = new Size(784, 561);
            panel.Location = new Point(0, 0);
            panel.BackColor = System.Drawing.Color.Black;

            MenuTitle.Text = "Alien Attack";
            MenuTitle.Location = new Point(144, 67);
            MenuTitle.ForeColor = System.Drawing.Color.White;
            MenuTitle.Size = new Size(400, 110);
            MenuTitle.Font = new Font("Microsoft Sans Serif", 50, FontStyle.Bold);

            Start.Location = new Point(350, 255);
            Start.BackColor = System.Drawing.Color.AliceBlue;
            Start.Text = "Start";
            Start.Click += button1_Click;

            Instructions.Location = new Point(350, 310);
            Instructions.BackColor = System.Drawing.Color.AliceBlue;
            Instructions.Text = "Controls";
            Instructions.Click += Instructions_Click;

            Score.Location = new Point(350, 370);
            Score.BackColor = System.Drawing.Color.AliceBlue;
            Score.Text = "Scores";
            Score.Click += Scores_Click;

            Quit.Location = new Point(350, 406);
            Quit.BackColor = System.Drawing.Color.AliceBlue;
            Quit.Text = "Quit";
            Quit.Click += Quit_Click;

            this.Controls.Add(panel);
            panel.BringToFront();
            panel.Show();
            panel.Controls.Add(MenuTitle);
            panel.Controls.Add(Start);
            panel.Controls.Add(Instructions);
            panel.Controls.Add(Score);
            panel.Controls.Add(Quit);
        }
        #endregion

        #region InstructionsPanel
        public void InstructionsShow()
        {
            Label InstructionsTitle = new Label();
            Button Menu = new Button();
            Button Start = new Button();

            Instructions.Size = new Size(784, 561);
            Instructions.Location = new Point(0, 0);
            Instructions.BackColor = System.Drawing.Color.Black;

            InstructionsTitle.Text = "Controls";
            InstructionsTitle.Location = new Point(277, 159);
            InstructionsTitle.ForeColor = System.Drawing.Color.White;
            InstructionsTitle.Size = new Size(400, 55);
            InstructionsTitle.Font = new Font("Microsoft Sans Serif", 36, FontStyle.Bold);

            Start.Location = new Point(700, 0);
            Start.BackColor = System.Drawing.Color.AliceBlue;
            Start.Text = "Start";
            Start.Click += button1_Click;

            Menu.Location = new Point(0, 0);
            Menu.BackColor = System.Drawing.Color.AliceBlue;
            Menu.Text = "Menu";
            Menu.Click += Menu_Click;

            this.Controls.Add(Instructions);
            Instructions.Show();
            Instructions.BringToFront();
            Instructions.Controls.Add(InstructionsTitle);
            Instructions.Controls.Add(Start);
            Instructions.Controls.Add(Menu);
        }
        #endregion

        #region ScorePanel
        public void ScorePanelShow()
        {
            Label ScoreTitle = new Label();
            Button Menu = new Button();
            Button Start = new Button();
            ListView scoreList = new ListView();

            ScorePanel.Size = new Size(784, 561);
            ScorePanel.Location = new Point(0, 0);
            ScorePanel.BackColor = System.Drawing.Color.Black;

            ScoreTitle.Text = "Controls";
            ScoreTitle.Location = new Point(277, 159);
            ScoreTitle.ForeColor = System.Drawing.Color.White;
            ScoreTitle.Size = new Size(400, 55);
            ScoreTitle.Font = new Font("Microsoft Sans Serif", 36, FontStyle.Bold);

            Start.Location = new Point(700, 0);
            Start.BackColor = System.Drawing.Color.AliceBlue;
            Start.Text = "Start";
            Start.Click += button1_Click;

            Menu.Location = new Point(0, 0);
            Menu.BackColor = System.Drawing.Color.AliceBlue;
            Menu.Text = "Menu";
            Menu.Click += Menu_Click;

            using (var db = new ScoreDbContext())
            {
                HighScoreList = db.HighScores.ToList();
            }
            HighScoreList.ForEach(h => scoreList.Items.Add(h.Name + " " + h.Score, h.ID));
            scoreList.Location = new Point(200, 220);
            scoreList.Size = new Size(400, 200);

            this.Controls.Add(ScorePanel);
            ScorePanel.Show();
            ScorePanel.BringToFront();
            ScorePanel.Controls.Add(ScoreTitle);
            ScorePanel.Controls.Add(Start);
            ScorePanel.Controls.Add(Menu);
            ScorePanel.Controls.Add(scoreList);
        }
        #endregion

        static void addScore(HighScore h)
        {
            using (var db = new ScoreDbContext())
            {
                db.HighScores.Add(h);
                db.SaveChanges();
            }
        }
    }
}
