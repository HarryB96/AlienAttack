namespace AlienAttack
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.HealthBar = new System.Windows.Forms.ProgressBar();
            this.health = new System.Windows.Forms.Label();
            this.StartPage = new System.Windows.Forms.Panel();
            this.WinPage = new System.Windows.Forms.Panel();
            this.FailPanel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.WinScore = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.ScoreButton = new System.Windows.Forms.Button();
            this.InstructionsButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.player = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Instructions = new System.Windows.Forms.Panel();
            this.button14 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.StartPage.SuspendLayout();
            this.WinPage.SuspendLayout();
            this.FailPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            this.Instructions.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // HealthBar
            // 
            this.HealthBar.Location = new System.Drawing.Point(672, 12);
            this.HealthBar.Name = "HealthBar";
            this.HealthBar.Size = new System.Drawing.Size(100, 23);
            this.HealthBar.TabIndex = 1;
            this.HealthBar.Tag = "healthBar";
            // 
            // health
            // 
            this.health.AutoSize = true;
            this.health.BackColor = System.Drawing.SystemColors.Desktop;
            this.health.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.health.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.health.Location = new System.Drawing.Point(610, 15);
            this.health.Name = "health";
            this.health.Size = new System.Drawing.Size(56, 20);
            this.health.TabIndex = 2;
            this.health.Text = "Health";
            // 
            // StartPage
            // 
            this.StartPage.BackColor = System.Drawing.SystemColors.Desktop;
            this.StartPage.Controls.Add(this.WinPage);
            this.StartPage.Controls.Add(this.ScoreButton);
            this.StartPage.Controls.Add(this.InstructionsButton);
            this.StartPage.Controls.Add(this.button2);
            this.StartPage.Controls.Add(this.button1);
            this.StartPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StartPage.Location = new System.Drawing.Point(0, 0);
            this.StartPage.Name = "StartPage";
            this.StartPage.Size = new System.Drawing.Size(784, 561);
            this.StartPage.TabIndex = 3;
            // 
            // WinPage
            // 
            this.WinPage.Controls.Add(this.FailPanel);
            this.WinPage.Controls.Add(this.WinScore);
            this.WinPage.Controls.Add(this.button6);
            this.WinPage.Controls.Add(this.button5);
            this.WinPage.Controls.Add(this.label5);
            this.WinPage.Location = new System.Drawing.Point(0, 0);
            this.WinPage.Name = "WinPage";
            this.WinPage.Size = new System.Drawing.Size(784, 561);
            this.WinPage.TabIndex = 7;
            this.WinPage.Visible = false;
            // 
            // FailPanel
            // 
            this.FailPanel.Controls.Add(this.Instructions);
            this.FailPanel.Controls.Add(this.label4);
            this.FailPanel.Controls.Add(this.label2);
            this.FailPanel.Controls.Add(this.button4);
            this.FailPanel.Controls.Add(this.button3);
            this.FailPanel.Location = new System.Drawing.Point(0, 0);
            this.FailPanel.Name = "FailPanel";
            this.FailPanel.Size = new System.Drawing.Size(784, 561);
            this.FailPanel.TabIndex = 7;
            this.FailPanel.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label4.Location = new System.Drawing.Point(277, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(272, 55);
            this.label4.TabIndex = 3;
            this.label4.Text = "Game Over";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "label2";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(512, 337);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 1;
            this.button4.Text = "Quit";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(209, 337);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 0;
            this.button3.Text = "Retry";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // WinScore
            // 
            this.WinScore.AutoSize = true;
            this.WinScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WinScore.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.WinScore.Location = new System.Drawing.Point(346, 258);
            this.WinScore.Name = "WinScore";
            this.WinScore.Size = new System.Drawing.Size(51, 20);
            this.WinScore.TabIndex = 4;
            this.WinScore.Text = "label7";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(512, 337);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 2;
            this.button6.Text = "Quit";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(209, 337);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 1;
            this.button5.Text = "Replay";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label5.Location = new System.Drawing.Point(277, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(205, 55);
            this.label5.TabIndex = 0;
            this.label5.Text = "You Win";
            // 
            // ScoreButton
            // 
            this.ScoreButton.Location = new System.Drawing.Point(350, 335);
            this.ScoreButton.Name = "ScoreButton";
            this.ScoreButton.Size = new System.Drawing.Size(75, 23);
            this.ScoreButton.TabIndex = 7;
            this.ScoreButton.Text = "Score";
            this.ScoreButton.UseVisualStyleBackColor = true;
            this.ScoreButton.Click += new System.EventHandler(this.button8_Click);
            // 
            // InstructionsButton
            // 
            this.InstructionsButton.Location = new System.Drawing.Point(350, 273);
            this.InstructionsButton.Name = "InstructionsButton";
            this.InstructionsButton.Size = new System.Drawing.Size(75, 23);
            this.InstructionsButton.TabIndex = 6;
            this.InstructionsButton.Text = "Instructions";
            this.InstructionsButton.UseVisualStyleBackColor = true;
            this.InstructionsButton.Click += new System.EventHandler(this.button7_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(350, 404);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Quit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(350, 210);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // player
            // 
            this.player.BackColor = System.Drawing.Color.Transparent;
            this.player.Image = global::AlienAttack.Properties.Resources.Rocket;
            this.player.Location = new System.Drawing.Point(375, 500);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(50, 50);
            this.player.TabIndex = 0;
            this.player.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Score: 0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Location = new System.Drawing.Point(227, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Time:";
            // 
            // Instructions
            // 
            this.Instructions.Controls.Add(this.button14);
            this.Instructions.Controls.Add(this.button13);
            this.Instructions.Controls.Add(this.button12);
            this.Instructions.Controls.Add(this.button11);
            this.Instructions.Controls.Add(this.button10);
            this.Instructions.Controls.Add(this.button9);
            this.Instructions.Controls.Add(this.label8);
            this.Instructions.Controls.Add(this.label7);
            this.Instructions.Controls.Add(this.label6);
            this.Instructions.Enabled = false;
            this.Instructions.Location = new System.Drawing.Point(3, 3);
            this.Instructions.Name = "Instructions";
            this.Instructions.Size = new System.Drawing.Size(784, 561);
            this.Instructions.TabIndex = 7;
            this.Instructions.Visible = false;
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(706, 3);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(75, 23);
            this.button14.TabIndex = 8;
            this.button14.Text = "Menu";
            this.button14.UseVisualStyleBackColor = true;
            // 
            // button13
            // 
            this.button13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button13.Location = new System.Drawing.Point(591, 180);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(75, 71);
            this.button13.TabIndex = 7;
            this.button13.Text = "Right";
            this.button13.UseVisualStyleBackColor = true;
            // 
            // button12
            // 
            this.button12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button12.Location = new System.Drawing.Point(494, 180);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(75, 71);
            this.button12.TabIndex = 6;
            this.button12.Text = "Left";
            this.button12.UseVisualStyleBackColor = true;
            // 
            // button11
            // 
            this.button11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button11.Location = new System.Drawing.Point(241, 180);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(75, 71);
            this.button11.TabIndex = 5;
            this.button11.Text = "D";
            this.button11.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10.Location = new System.Drawing.Point(137, 180);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 71);
            this.button10.TabIndex = 4;
            this.button10.Text = "A";
            this.button10.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.Location = new System.Drawing.Point(197, 381);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(361, 67);
            this.button9.TabIndex = 3;
            this.button9.Text = "Space";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label8.Location = new System.Drawing.Point(346, 335);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 20);
            this.label8.TabIndex = 2;
            this.label8.Text = "Shoot";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label7.Location = new System.Drawing.Point(347, 151);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Move";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label6.Location = new System.Drawing.Point(231, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(269, 55);
            this.label6.TabIndex = 0;
            this.label6.Text = "Instructions";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.StartPage);
            this.Controls.Add(this.health);
            this.Controls.Add(this.HealthBar);
            this.Controls.Add(this.player);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyIsUp);
            this.StartPage.ResumeLayout(false);
            this.WinPage.ResumeLayout(false);
            this.WinPage.PerformLayout();
            this.FailPanel.ResumeLayout(false);
            this.FailPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            this.Instructions.ResumeLayout(false);
            this.Instructions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.ProgressBar HealthBar;
        private System.Windows.Forms.Label health;
        private System.Windows.Forms.Panel StartPage;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ScoreButton;
        private System.Windows.Forms.Button InstructionsButton;
        private System.Windows.Forms.Panel WinPage;
        private System.Windows.Forms.Panel FailPanel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label WinScore;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel Instructions;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
    }
}

