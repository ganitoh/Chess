using Chess.Domain.Models.Pieces;
using Chess.Domain.Services;
using System.Net.Sockets;

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

        public bool IsShah(Color color)
        {
            var king = pieces.Values.FirstOrDefault(p => p.GetType() == typeof(King) && p.Color == color);

            var stepsKing = king!.GetAvailableMoveSquare(this);

            foreach (var piece in pieces.Values.Where(p => p.Color != color))
            {
                var stepsEnemyPiece = piece.GetAvailableMoveSquare(this);

                if (stepsEnemyPiece.Contains(king.Coordinates))
                    return true;
            }

            return false;
        }

        

        
    }
}
