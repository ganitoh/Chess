using Chess.Domain.Models.GameTools;

namespace Chess.Domain.Models.Pieces
{
    public class King : Piece
    {
        public King(Color color, Coordinates coordinates) : base(color, coordinates) { }

        protected override List<CoordinatesShift> GetPieceMoves()
        {
            List<CoordinatesShift> resultShift = new List<CoordinatesShift>
            {
                new CoordinatesShift(-1,1),
                new CoordinatesShift(0,1),
                new CoordinatesShift(1,1),
                new CoordinatesShift(-1,0),
                new CoordinatesShift(1,0),
                new CoordinatesShift(-1,-1),
                new CoordinatesShift(0,-1),
                new CoordinatesShift(1,-1),
            };

            return resultShift;
        }

        private bool IsAvailableForMoveTheKing(Board board)
        {
            throw new Exception();
        }
    }
}
