using Chess.Domain.Intarfaces;

namespace Chess.Domain.Models
{
    public class Game
    {
        private IRenderBoard _boardRender;
        private IMovePiece _movePiece;
        private bool _isWhiteStep = true;

        public Game(IRenderBoard boardRender, IMovePiece movePiece)
        {
            _boardRender = boardRender;
            _movePiece = movePiece;
        }

        public async void GameLoop()
        {
            while (IsGameContinue())
            {
                _boardRender.Render();
                _movePiece.Step(_isWhiteStep);

                await Task.Run(() => 
                {
                    while (true)
                    {
                        if (_movePiece.ButtonClicked)
                            break;
                    }
                });

                _movePiece.ButtonClicked = false;

                _isWhiteStep = !_isWhiteStep;
            }
        }

        private bool IsGameContinue()
        {
            return true;
        }
    }
}
