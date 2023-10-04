using Chess.Domain.Models.Pieces;
using Chess.Domain.Services;

namespace Chess.Domain.Models.GameTools
{
    public class Board
    {
        public Dictionary<Coordinates, Piece> pieces = new Dictionary<Coordinates, Piece>();

        public Board()
        {
            pieces = SetupPieceDefaultPosition.SetupDefaultPiecePositions();
        }

        public void SetPiece(Coordinates coordinates, Piece piece)
        {
            pieces.Add(coordinates, piece);
        }

        public void StepPiece(Coordinates coordinates, Piece piece)
        {
            pieces.Remove(piece.Coordinates);
            pieces.Add(coordinates, piece);
            piece.Coordinates = coordinates;
        }

        public void BeatPiece(Coordinates coordinates, Piece piece)
        {
            piece.BeatePiece(this, coordinates);
        }

        public Piece GetPiece(Coordinates coordinates) => pieces[coordinates];
        public bool IsSquareEmpty(Coordinates coordinates) => !pieces.ContainsKey(coordinates);

    }
}
