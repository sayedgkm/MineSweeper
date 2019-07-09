using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeper
{
    public class Cell : Button
    {
        private int XLocation { get; set; }
        private int YLocation { get; set; }
        private bool IsExposed { get; set; }
        private int Number { get; set; } /// Number of mines available in it's neighbouring cell
        private int CellSize { get; set; }
        private bool IsBomb { get; set; }
        private Board board { get; set; }
        private int marginTop { get; set; }
        public Cell(Board board, int XLocation, int YLocation, int CellSize)
        {
            this.board = board;
            this.XLocation = XLocation;
            this.YLocation = YLocation;
            this.CellSize = CellSize;
            this.IsBomb = false;
            this.IsExposed = false;
            this.marginTop = 24;
            this.Location = new Point(XLocation * CellSize, (YLocation * CellSize) + marginTop);
            this.Size = new Size(CellSize, CellSize);
            this.UseVisualStyleBackColor = true;
        }
        
        public bool GetIsBomb()
        {
            return IsBomb;
        }

        public void SetIsBomb(bool IsBomb)
        {
            this.IsBomb = IsBomb;
        }
        public bool PlaceBomb()
        {
            if (IsBomb == false)
            {
                IsBomb = true;
                return true;
            }

            return false;
        }
        private bool IsValidLocation(int XLocation, int YLocation)
        {
            return (XLocation >= 0 && XLocation < board.Height && YLocation >= 0 && YLocation < board.Width);
        }
        private int CountNeighbourMine()
        {
            int numberOfMine = 0;

            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    int newX = XLocation + i;
                    int newY = YLocation + j;
                    if (IsValidLocation(newX, newY))
                    {
                        numberOfMine += (board.Cells[newX, newY].IsBomb == true) ? 1 : 0;
                    }
                }
            }

            return numberOfMine;
        }
        public void MouseRightClick()
        {
            if (IsExposed)
            {
                return;
            }

            if (this.Text == "?")
            {
                this.Text = "";
            }
            else
            {
                this.Text = "?";
            }
        }
        public void MouseLeftClick()
        {
            if (IsBomb)
            {
                for (int i = 0; i < board.Height; i++)
                {
                    for (int j = 0; j < board.Width; j++)
                    {
                        if (board.Cells[i, j].IsBomb == true)
                        {
                            board.Cells[i, j].UpdateDisplay();
                        }
                    }
                }
                board.MineSweeper.GameOver = true;
                MessageBox.Show("You have opened a mine! Game Ends");
                return;
            }

            UpdateDisplay();
        }

        void ExpandNeighbour()
        {
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    int newX = XLocation + i;
                    int newY = YLocation + j;

                    if (IsValidLocation(newX, newY))
                    {
                        Cell cell = board.Cells[newX, newY];
                        if (cell.IsExposed == false && cell.IsBomb == false)
                        {
                            cell.UpdateDisplay();
                        }
                    }
                }
            }
        }
        public void UpdateDisplay()
        {
            if (IsExposed)
            {
                return;
            }

            this.UseVisualStyleBackColor = false;
            IsExposed = true;
            board.TotalNumberOfExposedCell++;

            if (IsBomb)
            {
                this.Text = "B";
                return;
            }

            int count = this.CountNeighbourMine();
            if (count == 0)
            {
                this.Text = "";
                ExpandNeighbour();
            }
            else
            {
                this.Text = count.ToString();
            }

        }
    }
}
