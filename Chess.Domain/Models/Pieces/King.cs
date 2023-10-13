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

        protected override bool IsSquareAvailableForMove(Coordinates newCoordinates, Board board)
        {
            var result =  base.IsSquareAvailableForMove(newCoordinates, board);

            foreach (var piece in board.pieces.Values.Where(P => P.Color != this.Color && P.GetType() != typeof(King)))
            {
                var stepsEnemyPiece = piece.GetAvailableMoveSquare(board);

                if (stepsEnemyPiece.Contains(newCoordinates))
                    return false;
                else if (piece.HitSquareOnTheNextMove(newCoordinates,board))
                    return false;
            }

            return result;
        }
    }
}
