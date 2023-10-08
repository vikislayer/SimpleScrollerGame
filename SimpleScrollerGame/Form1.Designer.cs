namespace SimpleScrollerGame
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            BackMove = new System.Windows.Forms.Timer(components);
            Player = new PictureBox();
            moveLeftTmr = new System.Windows.Forms.Timer(components);
            moveRightTmr = new System.Windows.Forms.Timer(components);
            moveUpTmr = new System.Windows.Forms.Timer(components);
            moveDownTmr = new System.Windows.Forms.Timer(components);
            BulletMovement = new System.Windows.Forms.Timer(components);
            EnemyMovement = new System.Windows.Forms.Timer(components);
            EnemyBulletMovement = new System.Windows.Forms.Timer(components);
            Replay = new Button();
            Exit = new Button();
            GameState = new Label();
            Score = new Label();
            Game_Difficulty = new Label();
            ((System.ComponentModel.ISupportInitialize)Player).BeginInit();
            SuspendLayout();
            // 
            // BackMove
            // 
            BackMove.Enabled = true;
            BackMove.Interval = 10;
            BackMove.Tick += BackMove_Tick;
            // 
            // Player
            // 
            Player.BackColor = SystemColors.ActiveCaptionText;
            Player.Image = (Image)resources.GetObject("Player.Image");
            Player.Location = new Point(275, 379);
            Player.Name = "Player";
            Player.Size = new Size(50, 50);
            Player.SizeMode = PictureBoxSizeMode.Zoom;
            Player.TabIndex = 0;
            Player.TabStop = false;
            Player.Click += pictureBox1_Click;
            // 
            // moveLeftTmr
            // 
            moveLeftTmr.Interval = 10;
            moveLeftTmr.Tick += moveLeftTmr_Tick;
            // 
            // moveRightTmr
            // 
            moveRightTmr.Interval = 10;
            moveRightTmr.Tick += moveRightTmr_Tick;
            // 
            // moveUpTmr
            // 
            moveUpTmr.Interval = 10;
            moveUpTmr.Tick += moveUpTmr_Tick;
            // 
            // moveDownTmr
            // 
            moveDownTmr.Interval = 10;
            moveDownTmr.Tick += moveDownTmr_Tick;
            // 
            // BulletMovement
            // 
            BulletMovement.Enabled = true;
            BulletMovement.Interval = 20;
            BulletMovement.Tick += BulletMovement_Tick;
            // 
            // EnemyMovement
            // 
            EnemyMovement.Enabled = true;
            EnemyMovement.Interval = 20;
            EnemyMovement.Tick += EnemyMovement_Tick;
            // 
            // EnemyBulletMovement
            // 
            EnemyBulletMovement.Enabled = true;
            EnemyBulletMovement.Interval = 10;
            EnemyBulletMovement.Tick += EnemyBulletMovement_Tick;
            // 
            // Replay
            // 
            Replay.Location = new Point(200, 196);
            Replay.MinimumSize = new Size(200, 50);
            Replay.Name = "Replay";
            Replay.Size = new Size(200, 50);
            Replay.TabIndex = 1;
            Replay.Text = "Replay";
            Replay.UseVisualStyleBackColor = true;
            Replay.Visible = false;
            Replay.Click += Replay_Click;
            // 
            // Exit
            // 
            Exit.Location = new Point(200, 252);
            Exit.Name = "Exit";
            Exit.Size = new Size(200, 50);
            Exit.TabIndex = 2;
            Exit.Text = "Exit";
            Exit.UseVisualStyleBackColor = true;
            Exit.Visible = false;
            Exit.Click += Exit_Click;
            // 
            // GameState
            // 
            GameState.AutoSize = true;
            GameState.BackColor = SystemColors.ActiveCaptionText;
            GameState.FlatStyle = FlatStyle.Flat;
            GameState.Font = new Font("Segoe UI", 22.2F, FontStyle.Regular, GraphicsUnit.Point);
            GameState.ForeColor = SystemColors.ControlLightLight;
            GameState.Location = new Point(192, 118);
            GameState.MinimumSize = new Size(200, 50);
            GameState.Name = "GameState";
            GameState.Size = new Size(200, 50);
            GameState.TabIndex = 3;
            GameState.Text = "label1";
            GameState.Visible = false;
            // 
            // Score
            // 
            Score.AutoSize = true;
            Score.ForeColor = SystemColors.ControlLightLight;
            Score.Location = new Point(12, 9);
            Score.MinimumSize = new Size(75, 20);
            Score.Name = "Score";
            Score.Size = new Size(75, 20);
            Score.TabIndex = 4;
            Score.Text = "Score : 00";
            // 
            // Game_Difficulty
            // 
            Game_Difficulty.AutoSize = true;
            Game_Difficulty.ForeColor = SystemColors.ControlLightLight;
            Game_Difficulty.Location = new Point(420, 9);
            Game_Difficulty.MinimumSize = new Size(150, 20);
            Game_Difficulty.Name = "Game_Difficulty";
            Game_Difficulty.Size = new Size(150, 20);
            Game_Difficulty.TabIndex = 5;
            Game_Difficulty.Text = "Difficulty Level : 00";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(582, 453);
            Controls.Add(Game_Difficulty);
            Controls.Add(Score);
            Controls.Add(GameState);
            Controls.Add(Exit);
            Controls.Add(Replay);
            Controls.Add(Player);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(600, 500);
            Name = "Form1";
            RightToLeftLayout = true;
            Text = "Form1";
            Load += Form1_Load;
            KeyDown += Form1_KeyDown;
            KeyUp += Form1_KeyUp;
            ((System.ComponentModel.ISupportInitialize)Player).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer BackMove;
        private PictureBox Player;
        private System.Windows.Forms.Timer moveLeftTmr;
        private System.Windows.Forms.Timer moveRightTmr;
        private System.Windows.Forms.Timer moveUpTmr;
        private System.Windows.Forms.Timer moveDownTmr;
        private System.Windows.Forms.Timer BulletMovement;
        private System.Windows.Forms.Timer EnemyMovement;
        private System.Windows.Forms.Timer EnemyBulletMovement;
        private Button Replay;
        private Button Exit;
        private Label GameState;
        private Label Score;
        private Label Game_Difficulty;
    }
}