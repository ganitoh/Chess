using Chess.Domain.Models.GameTools;
using Chess.Domain.Services;

namespace Chess.Domain.Models.Pieces
{
    public class Rook : Piece
    {
        private List<Coordinates> verticalAndHorizaontalShift;
        public Rook(Color color, Coordinates coordinates) : base(color, coordinates) { }

        protected override List<CoordinatesShift> GetPieceMoves() => CalculateShift.GetHorizontalAndVerticalShift();
       
        protected override bool IsSquareAvailableForMove(Coordinates newCoordinates, Board board)
        {
            var result =  base.IsSquareAvailableForMove(newCoordinates, board);

            //required refactoring
            result = CalculationAvailableStep.AvailableVerticalShift(board,this.Coordinates).Concat(CalculationAvailableStep.AvailableHorizontalshift(board, this.Coordinates)).Contains(newCoordinates);

            return result;
        }
    }
}
