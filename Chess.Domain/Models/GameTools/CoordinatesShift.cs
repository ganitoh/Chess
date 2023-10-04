namespace Chess.Domain.Models.GameTools
{
    public class CoordinatesShift
    {
        public int FileShift { get; set; }
        public int RankShift { get; set; }

        public CoordinatesShift(int fileShift, int rankShift)
        {
            FileShift = fileShift;
            RankShift = rankShift;
        }
    }
}