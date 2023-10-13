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
            var result =  base.IsSquareAvailableForMove(newCoordinates, board);

            result = CalculationAvailableStep.AvailabaleDiagonalShift(board,this.Coordinates).Contains(newCoordinates);

            return result;

        }
    }
}
