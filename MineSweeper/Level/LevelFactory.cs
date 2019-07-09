using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper.Level
{
    public class LevelFactory
    {
        public DifficultyLevel GetLevel(string userInput)
        {
            if (userInput == "Easy")
            {
                return new LevelOne();
            }
            else if (userInput == "Medium")
            {
                return new LevelTwo();
            }
            else if(userInput == "Hard")
            {
                return new LevelThree();
            }
            else
            {
                return null;
            }
        }
    }
}
