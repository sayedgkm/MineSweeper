using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeper
{
    public class Board
    {
        public MineSweeper MineSweeper { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int NumberOfMines { get; set; }
        public int TotalNumberOfExposedCell { get; set; }

        public Cell[,] Cells;

        public bool firstClick { get; set; }
        public Board(MineSweeper MineSweeper, int Height, int Width, int NumberOfMines)
        {
            this.MineSweeper = MineSweeper;
            this.Height = Height;
            this.Width = Width;
            this.NumberOfMines = NumberOfMines;
            this.Cells = new Cell[Height, Width];
            this.TotalNumberOfExposedCell = 0;
            this.firstClick = true;
        }

        public void InitializeBoard()
        {
            RemoveCell();
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Cell cell = new Cell(this, i, j, 50);

                    cell.MouseDown += CellClick;
                    Cells[i, j] = cell;
                    MineSweeper.Controls.Add(cell);
                }
            }

            PlaceRandomMines(this.NumberOfMines);
        }
        void PlaceRandomMines(int n)
        {
            Random random = new Random();

            for (int i = 0; i < n; i++)
            {
                int x = random.Next(0, this.Height);
                int y = random.Next(0, this.Width);
                Cell cell = Cells[x, y];
                while (!cell.PlaceBomb())
                {
                    x = random.Next(0, this.Height);
                    y = random.Next(0, this.Width);
                    cell = Cells[x, y];
                }
            }
        }
        private void CellClick(object sender, MouseEventArgs e)
        {
            if(MineSweeper.GameOver == true)
            {
                return ;
            }
            var cell = (Cell)sender;

            if (e.Button == MouseButtons.Left)
            {
                if(firstClick)
                {
                    while(firstClick&&cell.GetIsBomb())
                    {
                        cell.SetIsBomb(false);
                        PlaceRandomMines(1);
                    }

                    firstClick = false;
                }
                cell.MouseLeftClick();
            }
            else if (e.Button == MouseButtons.Right)
            {
                cell.MouseRightClick();
            }

            CheckForWin();
        }
        public void CheckForWin()
        {
            if(TotalNumberOfExposedCell + NumberOfMines == Height*Width)
            {
                for (int i = 0; i < Height; i++)
                {
                    for (int j = 0; j < Width; j++)
                    {
                        if (Cells[i, j].GetIsBomb() == true)
                        {
                            Cells[i, j].UpdateDisplay();
                        }
                    }
                }
                MineSweeper.GameOver = true;
                MessageBox.Show("You Won!");
            }
        }

        public void RemoveCell()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Cell cell = Cells[i,j];

                    MineSweeper.Controls.Remove(cell);
                }
            }
        }
       
    }
}
