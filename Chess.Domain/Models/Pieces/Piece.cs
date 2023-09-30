
namespace Chess.Domain.Models.Pieces
{
    public abstract class Piece
    {
        public Color Color { get; }
        public Coordinates Coordinates { get; set; } = null!;

        public Piece(Color color, Coordinates coordinates)
        {
            Color = color;
            Coordinates = coordinates;
        }

        public  List<Coordinates> GetAvailableMoveSquare(Board board)
        {
            List<Coordinates> result = new List<Coordinates>();

            GetPieceMoves().ForEach(shift =>
            {
                if (Coordinates.IsCorrectShift(shift))
                {
                    Coordinates newCoordinates = this.Coordinates.Shift(shift);

                    if (IsSquareAvailableForMove(newCoordinates,board))
                        result.Add(newCoordinates);
                }
            });

            return result;
        }

        protected virtual bool IsSquareAvailableForMove(Coordinates newCoordinates, Board board)
            => board.IsSquareEmpty(newCoordinates) || board.GetPiece(newCoordinates).Color != this.Color;

        protected abstract List<CoordinatesShift> GetPieceMoves();
        private List<Coordinates> GetBlockSquareHorizontalAndVertical(Board board)
        {
            var shifts = HorizontalAndVerticalShift();
            var result = new List<Coordinates>();

            foreach (var shift in shifts)
            {
                Coordinates blockCoordinates = this.Coordinates.Shift(shift);

                if (!board.IsSquareEmpty(blockCoordinates))
                {
                    if (shift.RankShift == 0)
                    {
                        for (int i = 1; i < 8; i++)
                        {
                            result.Add(blockCoordinates.Shift(new CoordinatesShift(i,0)));
                        }
                    }
                    else if (shift.FileShift == 0)
                    {
                        for (int i = 1; i < 8; i++)
                        {
                            result.Add(blockCoordinates.Shift(new CoordinatesShift(0, i)));
                        }
                    }
                }
            }

            return result;
        }

        protected  List<CoordinatesShift> DiagonalShift()
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
        protected List<CoordinatesShift> HorizontalAndVerticalShift()
        {
            var result = new List<CoordinatesShift>();

            for (int i = -7; i <= 7; i++)
            {
                if (i == 0)
                    continue;

                result.Add(new CoordinatesShift(i, 0));
            }

            for (int i = -7; i <= 7; i++)
            {
                if (i == 0)
                    continue;

                result.Add(new CoordinatesShift(0, i));
            }

            return result;
        }

    }
}
