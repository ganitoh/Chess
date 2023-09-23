using Chess.Domain.Intarfaces;
using Chess.Domain.Models.Pieces;

namespace Chess.Domain.Models
{
    public class Game
    {
        private  Board _board = null!;
        private bool isWhiteStep = true;
        private IRenderBoard _renderBoard;
        private IMove _movePiece;

        public Game(IRenderBoard renderBoard, IMove movePiece)
        {
            _board = new Board();
            _renderBoard = renderBoard;
            _movePiece = movePiece;
        }

        public void GameLoop()
        {
            while (true)
            {
                _renderBoard.Render(_board);
                _movePiece.Step()

            }
        }

        public void RenderBoard() => _renderBoard.Render(_board);
        public void MovePiece(Piece piece) => _movePiece.Step(piece,_board);
        public void SwitchPlayer() => isWhiteStep = !isWhiteStep;

    }
}
