namespace SimpleScrollerGame
{
    public partial class Form1 : Form
    {
        PictureBox[] backImages;
        int speedbackground;
        int backSize;
        int playerSpeed = 10;
        Random rnd;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            speedbackground = 6;
            backImages = new PictureBox[20];
            rnd = new Random();

            for (int i = 0; i < backImages.Length; i++)
            {
                backImages[i] = new PictureBox();
                backImages[i].BorderStyle = BorderStyle.None;
                backImages[i].Location = new Point(rnd.Next(10, 590), rnd.Next(-10, 400));
                backSize = rnd.Next(1, 3);
                backImages[i].Size = new Size(backSize, backSize);
                backImages[i].BackColor = Color.White;
                this.Controls.Add(backImages[i]);
            }
        }

        private void BackMove_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < backImages.Length / 3; i++)
            {
                backImages[i].Top += speedbackground / 3;
                if (backImages[i].Top >= this.Height)
                {
                    backImages[i].Top = -backImages[i].Height;
                }
            }
            for (int i = backImages.Length / 3; i < 2 * backImages.Length / 3; i++)
            {
                backImages[i].Top += 2 * speedbackground / 3;
                if (backImages[i].Top >= this.Height)
                {
                    backImages[i].Top = -backImages[i].Height;
                }
            }
            for (int i = 2 * backImages.Length / 3; i < backImages.Length; i++)
            {
                backImages[i].Top += speedbackground;
                if (backImages[i].Top >= this.Height)
                {
                    backImages[i].Top = -backImages[i].Height;
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void moveLeftTmr_Tick(object sender, EventArgs e)
        {
            if (Player.Left > 10)
            {
                Player.Left -= playerSpeed;
            }
        }

        private void moveUpTmr_Tick(object sender, EventArgs e)
        {
            if (Player.Top > 10)
            {
                Player.Top -= playerSpeed;
            }
        }

        private void moveRightTmr_Tick(object sender, EventArgs e)
        {
            if (Player.Left < 490)
            {
                Player.Left += playerSpeed;
            }
        }

        private void moveDownTmr_Tick(object sender, EventArgs e)
        {
            if (Player.Top < 400)
            {
                Player.Top += playerSpeed;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                moveUpTmr.Start();
            }
            if (e.KeyCode == Keys.Down)
            {
                moveDownTmr.Start();
            }
            if (e.KeyCode == Keys.Left)
            {
                moveLeftTmr.Start();
            }
            if (e.KeyCode == Keys.Right)
            {
                moveRightTmr.Start();
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            moveDownTmr.Stop();
            moveLeftTmr.Stop();
            moveRightTmr.Stop();
            moveUpTmr.Stop();
        }
    }
}