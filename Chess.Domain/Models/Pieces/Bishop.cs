using Chess.Domain.Models.GameTools;
using Chess.Domain.Services;

namespace Chess.Domain.Models.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Color color, Coordinates coordinates) : base(color, coordinates) { }

        protected override List<CoordinatesShift> GetPieceMoves() => CalculateShift.GetDiagonalShift();

        protected override bool IsSquareAvailableForMove(Coordinates newCoordinates, Board board)
        {
            return base.IsSquareAvailableForMove(newCoordinates, board);

        }
    }
}
