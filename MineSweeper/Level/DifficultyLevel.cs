using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper.Level
{
    public abstract class DifficultyLevel
    {
        public Board board { get; set; }
        public abstract void StartGame(MineSweeper mineSweeper);

        public Board GetBoardInstance()
        {
            return board;
        }
    }
}
