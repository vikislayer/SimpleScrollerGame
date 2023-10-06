namespace SimpleScrollerGame
{
    public partial class Form1 : Form
    {
        PictureBox[] backImages;
        int speedbackground;

        PictureBox[] enemies;
        int[] enemyHealth;
        int enemySpd;

        int backSize;
        int playerSpeed;
        Random rnd;
        bool movLeft; bool movRight; bool movUp; bool movDown;

        PictureBox[] Bullets;
        int BulletSpeed;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            movLeft = false; movRight = false; movUp = false; movDown = false;
            enemyHealth = new int[20];
            enemySpd = 1;
            playerSpeed = 3;
            speedbackground = 6;
            backImages = new PictureBox[20];
            rnd = new Random();

            BulletSpeed = 25;
            Bullets = new PictureBox[3];

            enemies = new PictureBox[20];

            Image Bullet = Image.FromFile(@"assets\Bullet.png"); // Load Bullet Image

            Image Enem0 = Image.FromFile(@"assets\Enemy_0.png");  // Load Enemy images
            Image Enem1 = Image.FromFile(@"assets\Enemy_1.png");
            Image Enem2 = Image.FromFile(@"assets\Enemy_2.png");

            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i] = new PictureBox();
                enemies[i].Size = new Size(35, 35);
                enemies[i].BorderStyle = BorderStyle.None;
                enemies[i].SizeMode = PictureBoxSizeMode.Zoom;
                enemies[i].Visible = false;
                this.Controls.Add(enemies[i]);

                if (i < 10)
                {
                    enemies[i].Location = new Point((1 + i) * 50, -50);
                } //Spawn Enemies
                else
                {
                    enemies[i].Location = new Point((i - 9) * 50, -100);
                }

                int enemyType = rnd.Next(1, 10);
                if (enemyType < 3)
                {
                    enemies[i].Image = Enem2;
                    enemyHealth[i] = 5;
                }  //Set enemy images
                else if (enemyType < 6)
                {
                    enemies[i].Image = Enem1;
                    enemyHealth[i] = 2;
                }
                else
                {
                    enemies[i].Image = Enem0;
                    enemyHealth[i] = 1;
                }

            }

            for (int i = 0; i < Bullets.Length; i++)
            {
                Bullets[i] = new PictureBox();
                Bullets[i].Size = new Size(10, 10);
                Bullets[i].Image = Bullet;
                Bullets[i].SizeMode = PictureBoxSizeMode.Zoom;
                Bullets[i].BorderStyle = BorderStyle.None;
                this.Controls.Add(Bullets[i]);

            }

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
                if (movDown == true)
                {
                    moveDownTmr.Stop();
                }
                moveUpTmr.Start();
                movUp = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                if (movUp == true)
                {
                    moveUpTmr.Stop();
                }
                moveDownTmr.Start();
                movDown = true;
            }
            if (e.KeyCode == Keys.Left)
            {
                if (movRight == true)
                {
                    moveRightTmr.Stop();
                }
                moveLeftTmr.Start();
                movLeft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                if (movLeft == true)
                {
                    moveLeftTmr.Stop();
                }
                moveRightTmr.Start();
                movRight = true;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            //moveDownTmr.Stop();
            //moveLeftTmr.Stop();
            //moveRightTmr.Stop();
            //moveUpTmr.Stop();
            if (e.KeyCode == Keys.Up)
            {
                moveUpTmr.Stop();
                movUp = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                moveDownTmr.Stop();
                movDown = false;
            }
            if (e.KeyCode == Keys.Left)
            {
                moveLeftTmr.Stop();
                movLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                moveRightTmr.Stop();
                movRight = false;
            }
        }

        private void BulletMovement_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < Bullets.Length; i++)
            {
                if (Bullets[i].Top > 0)
                {
                    Bullets[i].Visible = true;
                    Bullets[i].Top -= BulletSpeed;
                }
                else
                {
                    Bullets[i].Visible = false;
                    Bullets[i].Location = new Point(Player.Location.X + 20, Player.Location.Y + (20 * i));  // Location from which bullets are fired
                }
            }
        }

        private void EnemyMovement_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].Visible = true;
                enemies[i].Top += enemySpd;
                if (enemies[i].Top > this.Height)
                {
                    if (i < 10)
                    {
                        enemies[i].Location = new Point((1 + i) * 50, -50);
                    }
                    else
                    {
                        enemies[i].Location = new Point((i - 9) * 50, -50);
                    }
                }
            }
        }
    }
}