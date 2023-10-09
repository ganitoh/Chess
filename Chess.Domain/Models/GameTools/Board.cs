using Chess.Domain.Models.Pieces;
using Chess.Domain.Services;

namespace Chess.Domain.Models.GameTools
{
    public class Board
    {
        public Dictionary<Coordinates, Piece> pieces;

        public Board()
        {
            pieces = SetupPieceDefaultPosition.SetupDefaultPiecePositions();
        }

        public bool IsSquareEmpty(Coordinates coordinates) => !pieces.ContainsKey(coordinates);
        public Piece GetPiece(Coordinates coordinates) => pieces[coordinates];
        public void StepPiece(Coordinates coordinates, Piece piece)
        {
            pieces.Remove(piece.Coordinates);
            pieces.Add(coordinates, piece);
            piece.Coordinates = coordinates;
        }

        public void BeatPiece(Coordinates coordinates, Piece piece)
        {
            pieces.Remove(coordinates);
            pieces.Remove(piece.Coordinates);
            pieces.Add(coordinates, piece);
            piece.Coordinates = coordinates;
        }

        public bool IsSquareBlack(Coordinates coordinates)
        {
            if (((int)coordinates.File + coordinates.Rank) % 2 == 0)
                return true;
            else 
                return false;
        }
    }
}
