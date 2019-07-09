using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper.Level
{
    class LevelTwo : DifficultyLevel
    {
        public override void StartGame(MineSweeper mineSweeper)
        {
            mineSweeper.Width = 515;
            mineSweeper.Height = 562;
            board = new Board(mineSweeper, 10, 10, 50);
            board.InitializeBoard();
        }
    }
}
