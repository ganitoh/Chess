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
                resultShift.Add(new CoordinatesShift(-1, -1));
                resultShift.Add(new CoordinatesShift(1, -1));

                if (!isFirstStepTaken)
                    resultShift.Add(new CoordinatesShift(0, -2));

            }
            else if (this.Color == Color.white)
            {
                resultShift.Add(new CoordinatesShift(0, 1));
                resultShift.Add(new CoordinatesShift(1, 1));
                resultShift.Add(new CoordinatesShift(-1, 1));

                if (!isFirstStepTaken)
                    resultShift.Add(new CoordinatesShift(0, 2));
            }

            return resultShift;
        }

        protected override bool IsSquareAvailableForMove(Coordinates newCoordinates, Board board)
        {
            bool result =  board.IsSquareEmpty(newCoordinates);

            if (newCoordinates.File != this.Coordinates.File)
            {
                if (!board.IsSquareEmpty(newCoordinates) && board.GetPiece(newCoordinates).Color != this.Color)
                    return true;
                else
                    return false;

            }

            if (!result)
                return result;
            else if (Math.Abs(newCoordinates.Rank - this.Coordinates.Rank) == 2)
                result = DoubleStepCheck(newCoordinates, board);

            return result;
        }

        private bool DoubleStepCheck(Coordinates newCoordinates,Board board)
        {
            if (this.Color == Color.white && !board.IsSquareEmpty(newCoordinates.Shift(new CoordinatesShift(0, -1))))
                 return false;
            else if (this.Color == Color.black && !board.IsSquareEmpty(newCoordinates.Shift(new CoordinatesShift(0, 1))))
                 return false;
            
            return true;
        }
    }
}
