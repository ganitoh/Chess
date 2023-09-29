using System.Windows.Controls;
using Chess.Desktop.Service;
using Chess.Domain.Models;

namespace Chess.Desktop.View.BoardView
{
    public partial class BoardControl : UserControl
    {
        public BoardControl()
        {
            InitializeComponent();
            StartGame();
        }

        private void StartGame()
        {
            Board board = new Board();
            RenderBoard render = new RenderBoard(boardGrid, board);
            MovePiece movePiece = new MovePiece(boardGrid, board);

            Game startGame = new Game(render, movePiece);
            startGame.GameLoop();
        }
    }
}
