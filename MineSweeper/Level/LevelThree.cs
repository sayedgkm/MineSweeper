using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper.Level
{
    class LevelThree : DifficultyLevel
    {
        public override void StartGame(MineSweeper mineSweeper)
        {
            mineSweeper.Width = 615;
            mineSweeper.Height = 663;
            board = new Board(mineSweeper, 12, 12, 80);
            board.InitializeBoard();
        }
    }
}
