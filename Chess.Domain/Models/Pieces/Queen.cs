using Chess.Domain.Models.GameTools;
using Chess.Domain.Services;

namespace Chess.Domain.Models.Pieces
{
    public class Queen : Piece
    {
        public Queen(Color color, Coordinates coordinates) : base(color, coordinates) { }

        protected override List<CoordinatesShift> GetPieceMoves() => CalculateShift.GetAllShift();

        protected override bool IsSquareAvailableForMove(Coordinates newCoordinates, Board board)
        {
            var result = base.IsSquareAvailableForMove(newCoordinates, board);

            return result;
        }
    }
}
