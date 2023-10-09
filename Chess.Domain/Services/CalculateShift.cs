using Chess.Domain.Models.GameTools;

namespace Chess.Domain.Services
{
    internal static class CalculateShift
    {
        public static List<CoordinatesShift> GetAllShift()
        {
            var diagonalShift = GetDiagonalShift();
            var horizontalVerticalshift = GetHorizontalAndVerticalShift();

            var resultShift = diagonalShift.Concat(horizontalVerticalshift).ToList();

            return resultShift;
        }
        public static List<CoordinatesShift> GetDiagonalShift()
        {
            var result = new List<CoordinatesShift>();

            int fileShift = -7;
            int rankShift = -7;

            while (fileShift <= 7 && rankShift <= 7)
            {
                if (fileShift == 0 && rankShift == 0)
                {
                    fileShift++;
                    rankShift++;
                    continue;
                }

                result.Add(new CoordinatesShift(fileShift, rankShift));

                fileShift++;
                rankShift++;
            }

            fileShift = 1;
            rankShift = -1;

            while (fileShift <= 7 && rankShift >= -7)
            {
                if (fileShift == 0 && rankShift == 0)
                {
                    fileShift++;
                    rankShift--;
                    continue;
                }

                result.Add(new CoordinatesShift(fileShift, rankShift));

                fileShift++;
                rankShift--;
            }

            fileShift = -1;
            rankShift = 1;

            while (fileShift >= -7 && rankShift <= 7)
            {
                if (fileShift == 0 && rankShift == 0)
                {
                    fileShift--;
                    rankShift++;
                    continue;
                }

                result.Add(new CoordinatesShift(fileShift, rankShift));

                fileShift--;
                rankShift++;
            }

            return result;
        }
        public static List<CoordinatesShift> GetHorizontalAndVerticalShift()
        {
            var horizontalShift = GetHorizontalShift();
            var verticalShift = GetVerticalShift();

            return horizontalShift.Concat(verticalShift).ToList();

        }
        public static List<CoordinatesShift> GetVerticalShift()
        {
            var result = new List<CoordinatesShift>();

            for (int i = -7; i <= 7; i++)
            {
                if (i == 0)
                    continue;

                result.Add(new CoordinatesShift(0, i));
            }

            return result;
        }
        public static List<CoordinatesShift> GetHorizontalShift()
        {
            var result = new List<CoordinatesShift>();

            for (int i = -7; i <= 7; i++)
            {
                if (i == 0)
                    continue;

                result.Add(new CoordinatesShift(i, 0));
            }

            return result;
        }
    }
}
