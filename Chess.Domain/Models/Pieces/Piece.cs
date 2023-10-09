using Chess.Domain.Models.GameTools;

namespace Chess.Domain.Models.Pieces
{
    public abstract class Piece
    {

        public Color Color { get; }
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
    }
}
