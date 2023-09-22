namespace Chess.Domain.Models.Pieces
{
    public class Queen : Piece
    {
        public Queen(Color color, Coordinates coordinates) : base(color, coordinates) { }

        protected override List<CoordinatesShift> GetPieceMoves()
        {
            var diagonalShift = DiagonalShift();
            var horizontalVerticalshift = HorizontalAndVerticalShift();

            var resultShift = diagonalShift.Concat(horizontalVerticalshift).ToList();

            return resultShift;
            
        }
    }
}
