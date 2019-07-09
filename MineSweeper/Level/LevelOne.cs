using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper.Level
{
    class LevelOne : DifficultyLevel
    {
        public override void StartGame(MineSweeper mineSweeper)
        {
            mineSweeper.Height = 463;
            mineSweeper.Width = 416;
            board = new Board(mineSweeper, 8, 8, 10);
            board.InitializeBoard();
        }
    }
}
