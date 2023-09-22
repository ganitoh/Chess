

namespace Chess.Domain.Models.Pieces
{
    //ладья
    public class Rook : Piece
    {
        public Rook(Color color, Coordinates coordinates) : base(color, coordinates) { }

        protected override List<CoordinatesShift> GetPieceMoves() => HorizontalAndVerticalShift();
    }
}
