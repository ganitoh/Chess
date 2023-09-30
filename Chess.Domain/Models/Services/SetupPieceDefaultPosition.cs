using Chess.Domain.Models.Pieces;

namespace Chess.Domain.Models.Services
{
    public static class SetupPieceDefaultPosition
    {
        private static Dictionary<Coordinates,Piece> pieces = new Dictionary<Coordinates,Piece>();
        public static Dictionary<Coordinates,Piece> SetupDefaultPiecePositions()
        {
            SetPiecePawnDefault();
            SetPieceRookDefault();
            SetPieceKnightDefault();
            SetPieceBishopDefault();
            SetPieceQueenDefault();
            SetPieceKingDefault();

            return pieces;
        }

        public static void SetPiece(Coordinates coordinates, Piece piece)
        {
            pieces.Add(coordinates, piece);

        }

        private static void SetPieceKingDefault()
        {
            Coordinates coordinatesKingBlack = new Coordinates(FileCoordinates.E, 8);
            Coordinates coordinatesKingWhite = new Coordinates(FileCoordinates.E, 1);

            SetPiece(coordinatesKingBlack, new King(Color.black, coordinatesKingBlack));
            SetPiece(coordinatesKingWhite, new King(Color.white, coordinatesKingWhite));
        }
        private static void SetPieceQueenDefault()
        {
            Coordinates coordinatesQueenBlack = new Coordinates(FileCoordinates.D, 8);
            Coordinates coordinatesQueenWhite = new Coordinates(FileCoordinates.D, 1);

            SetPiece(coordinatesQueenBlack, new Queen(Color.black, coordinatesQueenBlack));
            SetPiece(coordinatesQueenWhite, new Queen(Color.white, coordinatesQueenWhite));
        }
        private static void SetPieceBishopDefault()
        {
            Coordinates[] coordinatesKnight =
            {
                new Coordinates(FileCoordinates.C,8),
                new Coordinates(FileCoordinates.F,8),
                new Coordinates(FileCoordinates.C,1),
                new Coordinates(FileCoordinates.F,1),
            };

            for (int i = 0; i < coordinatesKnight.Length; i++)
            {
                if (i < 2)
                    SetPiece(coordinatesKnight[i], new Bishop(Color.black, coordinatesKnight[i]));
                else
                    SetPiece(coordinatesKnight[i], new Bishop(Color.white, coordinatesKnight[i]));
            }
        }
        private static void SetPieceKnightDefault()
        {
            Coordinates[] coordinatesKnight =
            {
                new Coordinates(FileCoordinates.B,8),
                new Coordinates(FileCoordinates.G,8),
                new Coordinates(FileCoordinates.B,1),
                new Coordinates(FileCoordinates.G,1),
            };


            for (int i = 0; i < coordinatesKnight.Length; i++)
            {
                if (i < 2)
                    SetPiece(coordinatesKnight[i], new Knight(Color.black, coordinatesKnight[i]));
                else
                    SetPiece(coordinatesKnight[i], new Knight(Color.white, coordinatesKnight[i]));
            }
        }
        private static void SetPieceRookDefault()
        {
            Coordinates[] coordinatesRook =
            {
                new Coordinates(FileCoordinates.A,8),
                new Coordinates(FileCoordinates.H,8),
                new Coordinates(FileCoordinates.A,1),
                new Coordinates(FileCoordinates.H,1),
            };

            for (int i = 0; i < coordinatesRook.Length; i++)
            {
                if (i < 2)
                    SetPiece(coordinatesRook[i], new Rook(Color.black, coordinatesRook[i]));
                else
                    SetPiece(coordinatesRook[i], new Rook(Color.white, coordinatesRook[i]));
            }
        }
        private static void SetPiecePawnDefault()
        {
            foreach (var item in Enum.GetValues(typeof(FileCoordinates)))
            {
                SetPiece(new Coordinates((FileCoordinates)item, 2), new Pawn(Color.white, new Coordinates((FileCoordinates)item, 2)));
                SetPiece(new Coordinates((FileCoordinates)item, 7), new Pawn(Color.black, new Coordinates((FileCoordinates)item, 7)));
            }
        }
    }
}
