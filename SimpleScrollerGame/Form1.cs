namespace SimpleScrollerGame
{
    public partial class Form1 : Form
    {
        PictureBox[] backImages;
        int speedbackground;

        PictureBox[] enemies;
        int[] enemyHealth;
        int enemySpd;

        PictureBox[] enemyBullets;
        int enemyBulletSpeed;

        int score;
        int level;
        int difficulty;
        bool pause;
        bool gameover;
        int backSize;
        int playerSpeed;
        Random rnd;
        bool movLeft; bool movRight; bool movUp; bool movDown; bool latestUp; bool latestRight;

        PictureBox[] Bullets;
        int BulletSpeed;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            movLeft = false; movRight = false; movUp = false; movDown = false; latestUp = false; latestRight = false;
            enemyHealth = new int[20];
            pause = false;
            gameover = false;
            level = 0;
            score = 0;
            enemySpd = 1;
            difficulty = 9;
            enemyBulletSpeed = 1;
            playerSpeed = 3;
            speedbackground = 6;
            backImages = new PictureBox[20];
            enemyBullets = new PictureBox[20];
            rnd = new Random();

            BulletSpeed = 16;
            Bullets = new PictureBox[3];

            enemies = new PictureBox[20];

            Image Bullet = Image.FromFile(@"assets\Bullet.png"); // Load Bullet Image

            Image Enem0 = Image.FromFile(@"assets\Enemy_0.png");  // Load Enemy images
            Image Enem1 = Image.FromFile(@"assets\Enemy_1.png");
            Image Enem2 = Image.FromFile(@"assets\Enemy_2.png");

            //Spawn Enemies
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
                }
                else
                {
                    enemies[i].Location = new Point((i - 9) * 50, -100);
                }

                int enemyType = rnd.Next(1, 10);
                if (enemyType < 3)
                {
                    enemies[i].Image = Enem2;
                    enemyHealth[i] = 5;
                }
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

            // Spawn enemy Bullets
            for (int i = 0; i < enemyBullets.Length; i++)
            {
                enemyBullets[i] = new PictureBox();
                enemyBullets[i].Size = new Size(2, 10);
                enemyBullets[i].BackColor = Color.Blue;
                enemyBullets[i].Visible = false;
                int x = rnd.Next(0, 20);
                enemyBullets[i].Location = new Point(enemies[x].Location.X, enemies[x].Location.Y - 20);
                this.Controls.Add(enemyBullets[i]);
            }

            // Spawns Player Bullets
            for (int i = 0; i < Bullets.Length; i++)
            {
                Bullets[i] = new PictureBox();
                Bullets[i].Size = new Size(10, 10);
                Bullets[i].Image = Bullet;
                Bullets[i].SizeMode = PictureBoxSizeMode.Zoom;
                Bullets[i].BorderStyle = BorderStyle.None;
                this.Controls.Add(Bullets[i]);

            }

            // Spawns stars in background
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
        // Sets Different Movement speeds for stars in Background
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
            if (Player.Left > 10 && latestRight == false && movLeft == true)
            {
                Player.Left -= playerSpeed;
            }
        }

        private void moveUpTmr_Tick(object sender, EventArgs e)
        {
            if (Player.Top > 10 && latestUp == true && movUp == true)
            {
                Player.Top -= playerSpeed;
            }
        }

        private void moveRightTmr_Tick(object sender, EventArgs e)
        {
            if (Player.Left < 490 && latestRight == true && movRight == true)
            {
                Player.Left += playerSpeed;
            }

        }

        private void moveDownTmr_Tick(object sender, EventArgs e)
        {
            if (Player.Top < 400 && latestUp == false && movDown == true)
            {
                Player.Top += playerSpeed;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!pause)
            {
                if (e.KeyCode == Keys.Up)
                {
                    latestUp = true;
                    moveUpTmr.Start();
                    movUp = true;
                }
                if (e.KeyCode == Keys.Down)
                {
                    latestUp = false;
                    moveDownTmr.Start();
                    movDown = true;
                }
                if (e.KeyCode == Keys.Left)
                {
                    latestRight = false;
                    moveLeftTmr.Start();
                    movLeft = true;
                }
                if (e.KeyCode == Keys.Right)
                {
                    latestRight = true;
                    moveRightTmr.Start();
                    movRight = true;
                }
            }
            if (e.KeyCode == Keys.Space)
            {
                if (!gameover)
                {
                    if (pause)
                    {
                        SrtTmr();
                        GameState.Visible = false;
                        pause = false;
                    }
                    else
                    {
                        GameState.Location = new Point(this.Width / 2 - 100, 135);
                        GameState.Text = "PAUSED";
                        GameState.Visible = true;
                        EndTmr();
                        pause = true;

                    }
                }
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Up)
            {
                if (movDown == true)
                {
                    latestUp = false;
                }
                moveUpTmr.Stop();
                movUp = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                if (movUp == true)
                {
                    latestUp = true;
                }
                moveDownTmr.Stop();
                movDown = false;
            }
            if (e.KeyCode == Keys.Left)
            {
                if (movRight == true)
                {
                    latestRight = true;
                }
                moveLeftTmr.Stop();
                movLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                if (movLeft == true)
                {
                    latestRight = false;
                }
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

                    Collision();
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

        public static int HorzEnemRespawn(int i)
        {
            if (i < 10)
            {
                return 1 + 1;
            }
            else
            {
                return i - 9;
            }
        }

        private void Collision()
        {

            for (int i = 0; i < enemyBullets.Length; i++)
            {
                if (enemyBullets[i].Bounds.IntersectsWith(Player.Bounds))
                {
                    enemyBullets[i].Visible = false;
                    Player.Visible = false;
                    score = score / 2;
                    Lose("GAMEOVER");
                }
            }

            for (int i = 0; i < enemies.Length; i++)
            {
                if (Bullets[0].Bounds.IntersectsWith(enemies[i].Bounds) ||
                    Bullets[1].Bounds.IntersectsWith(enemies[i].Bounds) ||
                    Bullets[2].Bounds.IntersectsWith(enemies[i].Bounds))
                {
                    enemies[i].Location = new Point(HorzEnemRespawn(i) * 50, -100);
                    score += 1;
                    Score.Text = (score < 10) ? "Score : 0" + score.ToString() : "Score : " + score.ToString();

                    if (score % 30 == 0)
                    {
                        level += 1;
                        Game_Difficulty.Text = (level < 10) ? "Difficulty Level : 0" + level.ToString() : "Difficulty Level : " + level.ToString();
                        if (enemySpd <= 10 && enemyBulletSpeed <= 10 && difficulty >= 0)
                        {
                            difficulty--;
                            enemySpd++;
                            enemyBulletSpeed++;
                        }
                        if (level == 10)
                        {
                            score = score * 2;
                            Lose("Good Job");  //On hindsight, not a great name for function, as this is the result where you win
                        }
                    }
                }

                for (int j = 0; j < Bullets.Length; j++)
                {
                    if (Bullets[j].Bounds.IntersectsWith(enemies[i].Bounds))
                    {
                        Bullets[i].Location = new Point(Player.Location.X + 17, Player.Location.Y + (20 * i));
                    }
                }

                if (Player.Bounds.IntersectsWith(enemies[i].Bounds))
                {
                    Player.Visible = false;
                    score = score / 2;
                    Lose("GAMEOVER");
                }
            }
        }
        private void Lose(String txt)
        {
            EndTmr();
            gameover = true;
            GameState.Location = new Point(this.Width / 2 - 100, 135);
            GameState.Text = txt;
            GameState.Visible = true;
            Replay.Visible = true;
            Exit.Visible = true;


        }

        private void EndTmr()
        {
            EnemyMovement.Stop();
            BackMove.Stop();
            BulletMovement.Stop();
            EnemyBulletMovement.Stop();
            moveDownTmr.Stop();
            moveUpTmr.Stop();   
            moveRightTmr.Stop();
            moveLeftTmr.Stop();
        }

        private void SrtTmr()
        {
            EnemyMovement.Start();
            BackMove.Start();
            BulletMovement.Start();
            EnemyBulletMovement.Start();
            moveDownTmr.Start();
            moveUpTmr.Start();
            moveRightTmr.Start();
            moveLeftTmr.Start();
        }

        private void EnemyBulletMovement_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < (enemyBullets.Length - (difficulty*2)); i++)
            {
                if (enemyBullets[i].Top < this.Height)
                {
                    enemyBullets[i].Visible = true;
                    enemyBullets[i].Top += enemyBulletSpeed;
                }
                else
                {
                    enemyBullets[i].Visible = false;
                    int x = rnd.Next(0, 20);
                    enemyBullets[i].Location = new Point(enemies[x].Location.X + 17, enemies[x].Location.Y - 20);
                }
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void Replay_Click(object sender, EventArgs e)
        {
            gameover = false;
            this.Controls.Clear();
            InitializeComponent();
            Form1_Load(e, e);
        }
    }
}