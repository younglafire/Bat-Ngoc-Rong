using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TEST
{
    public partial class Form1 : Form
    {
        // Biến trò chơi (Game variables)
        private List<DragonBall> dragonBalls = new List<DragonBall>();
        private Timer gameTimer;
        private Random random = new Random();
        private int score = 0;
        private int lives = 3;
        private int speed = 3;
        private int difficultyLevel = 1;
        private HashSet<int> caughtStars = new HashSet<int>();
        private bool gameRunning = false;
        private Font starFont;

        // Image for dragon ball (load numbered variants from app folder if present)
        private Image[] dragonBallVariants = new Image[8]; // index1..7
        private List<int> availableVariants = new List<int>();

        public Form1()
        {
            InitializeComponent();
            InitializeGame();
        }

        // Khởi tạo trò chơi (Initialize game)
        private void InitializeGame()
        {
            this.Text = "Bắt Ngọc Rồng";
            this.Size = new Size(800, 600);
            this.DoubleBuffered = true;
            this.BackColor = Color.SkyBlue;

            starFont = new Font("Arial", 12, FontStyle.Bold);

            // Try to load numbered images named "dragonball1.png".."dragonball7.png" from the application startup folder.
            for (int i = 1; i <= 7; i++)
            {
                string variantPath = Path.Combine(Application.StartupPath, $"dragonball{i}.png");
                if (File.Exists(variantPath))
                {
                    try
                    {
                        dragonBallVariants[i] = Image.FromFile(variantPath);
                        availableVariants.Add(i);
                    }
                    catch
                    {
                        dragonBallVariants[i] = null;
                    }
                }
            }

            // IMPORTANT: do not draw fallback shapes. If no variants were imported, no dragon balls will spawn.

            gameTimer = new Timer();
            gameTimer.Interval = 40;
            gameTimer.Tick += GameTimer_Tick;

            this.Paint += Form1_Paint;
            this.MouseClick += Form1_MouseClick;
            this.FormClosed += Form1_FormClosed; // ensure image is disposed
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            for (int i = 1; i <= 7; i++)
            {
                if (dragonBallVariants[i] != null)
                {
                    dragonBallVariants[i].Dispose();
                    dragonBallVariants[i] = null;
                }
            }
        }

        // Bắt đầu trò chơi (Start game)
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!gameRunning)
            {
                StartGame();
            }
        }

        private void StartGame()
        {
            gameRunning = true;
            score = 0;
            lives = 3;
            speed = 3;
            difficultyLevel = 1;
            caughtStars.Clear();
            dragonBalls.Clear();
            gameTimer.Start();
            btnStart.Visible = false;
        }

        // Vòng lặp trò chơi (Game loop)
        private void GameTimer_Tick(object sender, EventArgs e)
        {
            // Only spawn if user imported at least one numbered PNG
            if (availableVariants.Count > 0 && random.Next(0, 100) < 3)
            {
                int stars = random.Next(1, 8); // 1-7 sao (stars)
                int x = random.Next(50, this.ClientSize.Width - 50);
                int variantIndex = availableVariants[random.Next(availableVariants.Count)];
                dragonBalls.Add(new DragonBall(x, 0, stars, variantIndex));
            }

            // Di chuyển ngọc rồng (Move dragon balls)
            for (int i = dragonBalls.Count - 1; i >= 0; i--)
            {
                dragonBalls[i].Y += speed;

                // Kiểm tra nếu rơi xuống đất (Check if hit ground)
                if (dragonBalls[i].Y > this.ClientSize.Height)
                {
                    dragonBalls.RemoveAt(i);
                    lives--;
                    if (lives <= 0)
                    {
                        GameOver();
                    }
                }
            }

            lblScore.Text = $"Điểm: {score}";
            lblLives.Text = $"❤ x {lives}";
            lblLevel.Text = $"Cấp độ: {difficultyLevel}";

            this.Invalidate();
        }

        // Vẽ trò chơi (Draw game)
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Vẽ ngọc rồng (Draw dragon balls)
            foreach (var ball in dragonBalls)
            {
                DrawDragonBall(g, ball);
            }
        }

        // Vẽ một ngọc rồng (Draw one dragon ball) - only draw imported PNGs, no overlay
        private void DrawDragonBall(Graphics g, DragonBall ball)
        {
            int size = 40;

            Image imgToDraw = null;
            if (ball.Variant >= 1 && ball.Variant <= 7)
            {
                imgToDraw = dragonBallVariants[ball.Variant];
            }

            // If the image for this variant isn't available, skip drawing this ball
            if (imgToDraw == null) return;

            Rectangle dest = new Rectangle(ball.X - size / 2, ball.Y - size / 2, size, size);
            g.DrawImage(imgToDraw, dest);
        }

        // Xử lý nhấp chuột (Handle mouse click)
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (!gameRunning) return;

            for (int i = dragonBalls.Count - 1; i >= 0; i--)
            {
                var ball = dragonBalls[i];
                int size = 40;
                double distance = Math.Sqrt(Math.Pow(e.X - ball.X, 2) + Math.Pow(e.Y - ball.Y, 2));

                if (distance <= size / 2)
                {
                    // Bắt được ngọc rồng (Caught dragon ball)
                    caughtStars.Add(ball.Stars);
                    score += difficultyLevel;
                    dragonBalls.RemoveAt(i);

                    // Kiểm tra nâng cấp độ (Check level up)
                    if (caughtStars.Count >= 7)
                    {
                        difficultyLevel++;
                        speed++;
                        caughtStars.Clear();
                    }
                    break;
                }
            }
        }

        // Kết thúc trò chơi (Game over)
        private void GameOver()
        {
            gameRunning = false;
            gameTimer.Stop();
            dragonBalls.Clear();

            DialogResult result = MessageBox.Show(
                $"Bạn đã thua!\nĐiểm số: {score}\n\nBạn có muốn chơi lại không?",
                "Trò chơi kết thúc",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                StartGame();
            }
            else
            {
                btnStart.Visible = true;
            }
        }
    }

    // Lớp ngọc rồng (Dragon ball class)
    public class DragonBall
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Stars { get; set; }
        public int Variant { get; set; } //1..7

        public DragonBall(int x, int y, int stars)
        {
            X = x;
            Y = y;
            Stars = stars;
            Variant = 1;
        }

        public DragonBall(int x, int y, int stars, int variant)
        {
            X = x;
            Y = y;
            Stars = stars;
            Variant = variant;
        }
    }
}
