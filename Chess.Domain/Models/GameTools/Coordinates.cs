namespace Chess.Domain.Models.GameTools
{
    public class Coordinates
    {
        public FileCoordinates File { get; } = default;
        public int Rank { get; }

        public Coordinates(FileCoordinates file, int rank)
        {
            File = file;
            Rank = rank;
        }

        public Coordinates Shift(CoordinatesShift coordinates) => new Coordinates((FileCoordinates)((int)File + coordinates.FileShift), Rank + coordinates.RankShift);

        public bool IsCorrectShift(CoordinatesShift coordinates)
        {
            int file = (int)File + coordinates.FileShift;
            int rank = Rank + coordinates.RankShift;

            if (file < 1 || file > 8)
                return false;
            else if (rank < 1 || rank > 8)
                return false;

            return true;
        }

        public override bool Equals(object? obj)
        {
            return obj is Coordinates coordinates &&
                   File == coordinates.File &&
                   Rank == coordinates.Rank;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(File, Rank);
        }
    }
}