namespace Chess.Domain.Models
{
    public class Game
    {
        private  Board _board = null!;
        private bool isWhiteStep = true;
        public event Action<Board>? RenderBoard;
        public event Action<Board,bool>? MakeMove;

        public Game()
        {
            _board = new Board();
        }

        public void GameLoop()
        {
            while (isWhiteStep)
            {
                //render - отображаем доску
                RenderBoard?.Invoke(_board);

                //make move - делаем ход
                MakeMove?.Invoke(_board, isWhiteStep);

                //pass move - передаем ход 
                isWhiteStep = !isWhiteStep;


            }
        }

        private bool IsGameContinue()
        {
            return true;
        }
    }
}
