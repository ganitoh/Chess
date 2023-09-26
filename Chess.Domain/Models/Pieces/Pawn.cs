namespace Chess.Domain.Models.Pieces
{
    public class Pawn : Piece
    {
        private bool isFirstStep = false;

        public Pawn(Color color, Coordinates coordinates) : base(color, coordinates) { }

        protected override List<CoordinatesShift> GetPieceMoves()
        {
            List<CoordinatesShift> resultShift = new List<CoordinatesShift>();
 
            if (this.Color == Color.black)
            {
                resultShift.Add(new CoordinatesShift(0, -1));
                if (!isFirstStep)
                    resultShift.Add(new CoordinatesShift(0, -2));
            }
            else if (this.Color == Color.white)
            {
                resultShift.Add(new CoordinatesShift(0, 1));
                if (!isFirstStep)
                    resultShift.Add(new CoordinatesShift(0, 2));
            }

            return resultShift;
        }

                        
    }
}
