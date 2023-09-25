﻿using Chess.Domain.Models.Pieces;
using Chess.Domain.Models.Services;

namespace Chess.Domain.Models
{
    public class Board
    {
        public Dictionary<Coordinates, Piece> pieces = new Dictionary<Coordinates, Piece>();

        public Board()
        {
            pieces = SetupPieceDefaultPosition.SetupDefaultPiecePositions();
        }

        public void SetPiece( Coordinates coordinates, Piece piece)
        {
            pieces.Add(coordinates, piece);
        }

        public Piece GetPiece(Coordinates coordinates)=> pieces[coordinates];
        public bool IsSquareEmpty(Coordinates coordinates) => !pieces.ContainsKey(coordinates);
        
    }
}
