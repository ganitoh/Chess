using Chess.Domain.Models.GameTools;


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
        public virtual void BeatePiece(Board board,Coordinates coordinates)
        {
            board.pieces.Remove(coordinates);
            board.pieces.Remove(this.Coordinates);
            board.pieces.Add(coordinates, this);
            this.Coordinates = coordinates;
        }
        protected List<CoordinatesShift> DiagonalShift()
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

            for (int i = - 7; i <= 7; i++)
            {
                if (i == 0)
                    continue;

                result.Add(new CoordinatesShift(i, 0));
            }

            for (int i = - 7; i <= 7; i++)
            {
                if (i == 0)
                    continue;

                result.Add(new CoordinatesShift(0, i));
            }

            return result;
        }

    }
}
