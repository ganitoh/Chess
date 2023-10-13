using Chess.Domain.Models.GameTools;
using System.ComponentModel.Design;

namespace Chess.Domain.Models.Pieces
{
    public abstract class Piece
    {

        public Color Color { get; set; }
        public Coordinates Coordinates { get; set; } = null!;

        public Piece(Color color, Coordinates coordinates)
        {
            Color = color;
            Coordinates = coordinates;
        }

        public  List<Coordinates> GetAvailableMoveSquare(Board board)
        {
            List<Coordinates> result = new List<Coordinates>();

            GetPieceMoves().ForEach(shift =>
            {
                if (Coordinates.IsCorrectShift(shift))
                {
                    Coordinates newCoordinates = this.Coordinates.Shift(shift);

                    if (IsSquareAvailableForMove(newCoordinates,board))
                        result.Add(newCoordinates);
                }
            });

            return result;
        }

        protected abstract List<CoordinatesShift> GetPieceMoves();

        protected virtual bool IsSquareAvailableForMove(Coordinates newCoordinates, Board board)
            => board.IsSquareEmpty(newCoordinates) || board.GetPiece(newCoordinates).Color != this.Color;

        public bool HitSquareOnTheNextMove(Coordinates coordinates,Board board)
        {
            if (!board.IsSquareEmpty(coordinates) && board.GetPiece(coordinates).Color == this.Color)
            {
                var enemyPiece = board.GetPiece(coordinates);
                Color color = default;

                if (this.Color == Color.white)
                {
                    color = Color.white;
                    enemyPiece.Color = Color.black;
                }
                else if (this.Color == Color.black)
                {
                    color = Color.black;
                    enemyPiece.Color = Color.white;
                }

                enemyPiece.Color = this.Color;

                var movePiece = GetAvailableMoveSquare(board);

                if (movePiece.Contains(coordinates))
                {
                    enemyPiece.Color = color;

                    return false;
                }
                else
                {
                    enemyPiece.Color = color;

                    return true;
                }

            }
            else
                return false;
        }

    }
}
