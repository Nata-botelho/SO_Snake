using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace MultiThreadingSnake
{
    public partial class Main : Form
    {
        int cols = 50, rows = 34, score = 0, HEAD = 0, TAIL = 0, nx = 0, ny = 0; //colunas, linhas, pontos, marcador inicial, fim da cobra, next x, next y
        bool[,] bodyLocation;           //matriz que guarda as posições atuais de todas as celulas da cobra
        bool gameOver = false;
        Cell[] snake = new Cell[1250];  //array de celulas que forma a cobra
        List<int> available = new List<int>();

        Random rand = new Random();
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        public Main()
        {

            InitializeComponent();
            GameStart();
            LaunchTimer();

            Thread colliderCheckThread = new Thread(checkColliders);
            colliderCheckThread.Name = "Collider Checker";
            colliderCheckThread.Start();
        }

        private void checkColliders()
        {
            int x, y;

            while (!gameOver)
            {
                x = snake[HEAD].Location.X;
                y = snake[HEAD].Location.Y;
                Console.WriteLine(Thread.CurrentThread.Name+" "+snake[HEAD].Location+" "+nx+" "+ny);

                if (nx != 0 || ny != 0)
                {
                    if (crashBorder(nx + x, ny + y))
                    {
                        timer.Stop();
                        MessageBox.Show("Game Over");
                        gameOver = true;
                    }
                    else if (itselfCrash((y + ny) / 20, (x + nx) / 20))
                    {
                        timer.Stop();
                        MessageBox.Show("Snake crashed his Body!");
                        gameOver = true;
                    }

                }
                Thread.Sleep(100);
            }
        }

        private void LaunchTimer()
        {
            timer.Interval = 100;
            timer.Tick += move;
            timer.Start();
        }

        private void GameStart()
        {
            bodyLocation = new bool[rows+1, cols+1];

            Cell head = new Cell((rand.Next() % cols) * 20, (rand.Next() % rows) * 20);

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                {
                    bodyLocation[i, j] = false;
                    available.Add(i * cols + j);
                }

            bodyLocation[(head.Location.Y / 20), (head.Location.X / 20)] = true;
            available.Remove(head.Location.Y / 20 * cols + head.Location.X / 20);
            snake[HEAD] = head;
            Controls.Add(head);

            newFoodLocation();
        }

        private void newFoodLocation()
        {
            available.Clear();

            for (int i = 0; i < rows; i++)

                for (int j = 0; j < cols; j++)

                    if (!bodyLocation[i, j]) available.Add(i * cols + j);

            int idx = rand.Next(available.Count) % available.Count;

            FoodLabel.Left = (available[idx] * 20) % (cols*20);

            FoodLabel.Top = (available[idx] * 20) / (cols*20) * 20;
        }

        private void move(object sender, EventArgs e)
        {
            if (nx == 0 && ny == 0) return;

            int x = snake[HEAD].Location.X;
            int y = snake[HEAD].Location.Y;

            if (collectFood(nx + x, ny + y))
            {

                score += 1;
                ScoreLabel.Text = "Score: " + score.ToString();

                //if (itselfCrash((y + ny) / 20, (x + nx) / 20)) return;

                Cell head = new Cell(x + nx, y + ny);

                HEAD = (HEAD - 1 + 1250) % 1250;
                snake[HEAD] = head;
                bodyLocation[head.Location.Y / 20, head.Location.X / 20] = true;
                Controls.Add(head);
                newFoodLocation();
            }

            else
            {
                //if (itselfCrash((y + ny) / 20, (x + nx) / 20)) return;

                bodyLocation[snake[TAIL].Location.Y / 20, snake[TAIL].Location.X / 20] = false;
                HEAD = (HEAD - 1 + 1250) % 1250;
                snake[HEAD] = snake[TAIL];
                snake[HEAD].Location = new Point(x + nx, y + ny);
                TAIL = (TAIL - 1 + 1250) % 1250;
                bodyLocation[(y + ny) / 20, (x + nx) / 20] = true;
            }

        }

        private bool itselfCrash(int row, int col)
        {
            return (bodyLocation[row, col]);
        }

        private bool collectFood(int x, int y)
        {
            if (FoodLabel.Location.X == x && FoodLabel.Location.Y == y)
                return true;

            return false;
        }

        private bool crashBorder(int x, int y)
        {
            if (x < 0 || x > 1000 || y < 0 || y > 660)
                return true;

            return false;
        }


        private void mainInput(object sender, KeyEventArgs key)
        {
            nx = ny = 0;
            switch (key.KeyCode)
            {
                case Keys.Right:
                    nx = 20;
                    break;
                case Keys.Left:
                    nx = -20;
                    break;
                case Keys.Up:
                    ny = -20;
                    break;
                case Keys.Down:
                    ny = 20;
                    break;
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {

        }
    }
}
