namespace Chess.Domain.Intarfaces
{
    public interface IMovePiece
    {
        public bool ButtonClicked { get; set; }
        void Step(bool isWhiteStep);
    }
}
