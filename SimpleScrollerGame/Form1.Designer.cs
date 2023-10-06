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
            Player.Location = new Point(275, 375);
            Player.Name = "Player";
            Player.Size = new Size(50, 50);
            Player.SizeMode = PictureBoxSizeMode.StretchImage;
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
            EnemyMovement.Interval = 10;
            EnemyMovement.Tick += EnemyMovement_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(582, 453);
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
    }
}