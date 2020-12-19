using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiThreadingSnake
{
    public partial class Main : Form
    {
        int cols = 50, rows = 30, score = 0, FIRST = 0, nx = 0, ny = 0;
        bool[,] bodyLocation;
        Cell[] snake = new Cell[1000];

        Random rand = new Random();

        public Main()
        {
            InitializeComponent();
            GameStart();
        }

        private void GameStart()
        {
            bodyLocation = new bool[rows, cols];
            Cell head = new Cell((rand.Next() % cols) * 20, ((rand.Next() % rows)+3) * 20);

            for(int i=0; i<rows; i++)
                for(int j=0; j<cols; j++)
                    bodyLocation[i, j] = false;

            bodyLocation[(head.Location.Y / 20)-3, (head.Location.X / 20)] = true;
            snake[FIRST] = head;
            Controls.Add(head);
            System.Console.WriteLine("Head: " + head.Location);
            newFoodLocation();
        }

        private void newFoodLocation()
        {
            int fx, fy;
            do
            {
                fx = rand.Next()%cols;
                fy = (rand.Next()%rows);
            } while (bodyLocation[fy, fx]);
            FoodLabel.Location = new Point(fx*20, (fy+3)*20);
            System.Console.WriteLine("Food: "+FoodLabel.Location);
        }

        private void Move()
        {
            if (nx == 0 && ny == 0) return;

            int x = snake[FIRST].Location.X;
            int y = snake[FIRST].Location.Y;

            //if(itselfCrash())
        }

        private bool itselfCrash(int x, int y)
        {
            if(bodyLocation[x, y])
            {
                MessageBox.Show("Snake crashed his Body!");
                return true;
            }

            return false;
        }

        private bool collectFood(int x, int y)
        {
            if (FoodLabel.Location.X == x && FoodLabel.Location.Y == y)
                return true;

            return false;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {

        }
    }
}
