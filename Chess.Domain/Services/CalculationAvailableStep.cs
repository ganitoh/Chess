using Chess.Domain.Models.GameTools;

namespace Chess.Domain.Services
{
    public static class CalculationAvailableStep
    {
        public static List<Coordinates> AvailableVerticalShift(Board board, Coordinates pieceCoordinates)
        {
            var shiftVertical = CalculateShift.GetVerticalShift();

            var result = new List<Coordinates>();

            foreach (var item in shiftVertical.Where(shift => shift.RankShift > 0))
            {
                if (pieceCoordinates.IsCorrectShift(item))
                {
                    if (board.IsSquareEmpty(pieceCoordinates.Shift(item)))
                        result.Add(pieceCoordinates.Shift(item));
                    else if (board.pieces[pieceCoordinates.Shift(item)].Color != board.pieces[pieceCoordinates].Color)
                    {
                        result.Add(pieceCoordinates.Shift(item));
                        break;
                    }
                    else
                        break;
                }
            }

            foreach (var item in shiftVertical.Where(shift => shift.RankShift < 0).OrderByDescending(shift => shift.RankShift))
            {
                if (pieceCoordinates.IsCorrectShift(item))
                {
                    if (board.IsSquareEmpty(pieceCoordinates.Shift(item)))
                        result.Add(pieceCoordinates.Shift(item));
                    else if (board.pieces[pieceCoordinates.Shift(item)].Color != board.pieces[pieceCoordinates].Color)
                    {
                        result.Add(pieceCoordinates.Shift(item));
                        break;
                    }
                    else
                        break;
                }
            }

            return result;
        }

        public static List<Coordinates> AvailableHorizontalshift(Board board, Coordinates pieceCoordinates)
        {
            var shiftHorizontal = CalculateShift.GetHorizontalShift();

            var result = new List<Coordinates>();


            foreach (var item in shiftHorizontal.Where(shift => shift.FileShift > 0))
            {
                if (pieceCoordinates.IsCorrectShift(item))
                {
                    if (board.IsSquareEmpty(pieceCoordinates.Shift(item)))
                        result.Add(pieceCoordinates.Shift(item));
                    else if (board.pieces[pieceCoordinates.Shift(item)].Color != board.pieces[pieceCoordinates].Color)
                    {
                        result.Add(pieceCoordinates.Shift(item));
                        break;
                    }
                    else
                        break;
                }
            }

            foreach (var item in shiftHorizontal.Where(shift => shift.FileShift < 0).OrderByDescending(shift => shift.FileShift))
            {
                if (pieceCoordinates.IsCorrectShift(item))
                {
                    if (board.IsSquareEmpty(pieceCoordinates.Shift(item)))
                        result.Add(pieceCoordinates.Shift(item));
                    else if (board.pieces[pieceCoordinates.Shift(item)].Color != board.pieces[pieceCoordinates].Color)
                    {
                        result.Add(pieceCoordinates.Shift(item));
                        break;
                    }
                    else
                        break;
                }
            }

            return result;

        }

        public static List<Coordinates> AvailabaleDiagonalShift(Board board,Coordinates pieceCoordinates)
        {
            var shiftDiagonal = CalculateShift.GetDiagonalShift();

            var result = new List<Coordinates>();

            foreach (var item in shiftDiagonal.Where(shift => shift.FileShift > 0 && shift.RankShift > 0).OrderBy(shift => shift.RankShift))
            {
                if (pieceCoordinates.IsCorrectShift(item))
                {
                    if (board.IsSquareEmpty(pieceCoordinates.Shift(item)))
                    {
                        result.Add(pieceCoordinates.Shift(item));
                    }
                    else if (board.pieces[pieceCoordinates.Shift(item)].Color != board.GetPiece(pieceCoordinates).Color)
                    {
                        result.Add(pieceCoordinates.Shift(item));
                        break;
                    }
                    else
                        break;
                }
            }

            return result;
        }
    }
}
