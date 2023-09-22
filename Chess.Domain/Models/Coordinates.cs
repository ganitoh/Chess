namespace Chess.Domain.Models
{
    public class Coordinates
    {
        public  FileCoordinates File { get; } = default(FileCoordinates);
        public  int Rank { get; }

        public Coordinates(FileCoordinates file, int rank)
        {
            this.File = file;
            this.Rank = rank;
        }

        public Coordinates Shift(CoordinatesShift coordinates) => new Coordinates((FileCoordinates)((int)this.File + coordinates.FileShift), this.Rank + coordinates.RankShift);

        public bool IsCorrectShift(CoordinatesShift coordinates)
        {
            int file = (int)this.File + (int)coordinates.FileShift;
            int rank = this.Rank + coordinates.RankShift;

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