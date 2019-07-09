using MineSweeper.Level;
using System.Windows.Forms;

namespace MineSweeper
{
    public partial class MineSweeper : Form
    {
        public bool GameOver { get; set; }
        private DifficultyLevel difficultyLevel;
        private Board board;
        private string userInputLevel;
        public MineSweeper()
        {
            InitializeComponent();
            userInputLevel = "Easy";
        }
        private void OnClickLevelItem(object sender, System.EventArgs e)
        {
            userInputLevel = sender.ToString();
        }

        private void OnClickNewGame(object sender, System.EventArgs e)
        {
            GameOver = false;
            if(board!=null)
            {
                board.RemoveCell();
            }
            difficultyLevel = new LevelFactory().GetLevel(userInputLevel);
            difficultyLevel.StartGame(this);
            board = difficultyLevel.GetBoardInstance();
        }

        private void OnClickExit(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
