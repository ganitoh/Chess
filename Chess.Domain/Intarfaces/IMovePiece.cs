namespace Chess.Domain.Intarfaces
{
    public interface IMovePiece
    {
        public bool StepTaken { get; set; }
        void Step(bool isWhiteStep);
    }
}
