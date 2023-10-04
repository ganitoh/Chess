using Chess.Domain.Models.GameTools;

namespace Chess.Domain.Models.Pieces
{
    public class Pawn : Piece
    {
        private bool isFirstStepTaken = false;

        public Pawn(Color color, Coordinates coordinates) : base(color, coordinates) { }

        protected override List<CoordinatesShift> GetPieceMoves()
        {
            List<CoordinatesShift> resultShift = new List<CoordinatesShift>();
 
            if (this.Color == Color.black)
            {
                resultShift.Add(new CoordinatesShift(0, -1));
                if (!isFirstStepTaken)
                    resultShift.Add(new CoordinatesShift(0, -2));

            }
            else if (this.Color == Color.white)
            {
                resultShift.Add(new CoordinatesShift(0, 1));
                if (!isFirstStepTaken)
                    resultShift.Add(new CoordinatesShift(0, 2));
            }

            return resultShift;
        }

        protected override bool IsSquareAvailableForMove(Coordinates newCoordinates, Board board)
        {
            bool result =  base.IsSquareAvailableForMove(newCoordinates, board);

            if (!isFirstStepTaken)
            {
                if (this.Color == Color.white && !board.IsSquareEmpty(newCoordinates.Shift(new CoordinatesShift(0, -1))) && this.Coordinates == newCoordinates.Shift(new CoordinatesShift(0, -1))) 
                {
                    result = false;
                }
                else if (this.Color == Color.black && !board.IsSquareEmpty(newCoordinates.Shift(new CoordinatesShift(0, 1))) && this.Coordinates == newCoordinates.Shift(new CoordinatesShift(0, 1)))
                {
                    result = false;
                }
                else if (this.Color == Color.white && !board.IsSquareEmpty(newCoordinates.Shift(new CoordinatesShift(0, 1))) && this.Coordinates != newCoordinates.Shift(new CoordinatesShift(0, -1)))
                {
                    result = true;
                }
                else if (this.Color == Color.black && !board.IsSquareEmpty(newCoordinates.Shift(new CoordinatesShift(0, 1))) && this.Coordinates != newCoordinates.Shift(new CoordinatesShift(0, 1)))
                {
                    result = true;
                }
            }

            return result;
        }
    }
}
