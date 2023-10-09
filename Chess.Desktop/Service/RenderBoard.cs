using Chess.Domain.Intarfaces;
using Chess.Domain.Models.GameTools;
using Chess.Domain.Models.Pieces;
using System;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Chess.Desktop.Service
{
    internal class RenderBoard : IRenderBoard
    {
        private Grid _boardGrid = null!;
        private readonly Board _board = null!;

        public RenderBoard(Grid boardGrid, Board board)
        {
            this._boardGrid = boardGrid;
            _board = board;
        }

        public void Render()
        {
            foreach (var item in _board.pieces.Values)
            {
                ChoiceSpriteForPiece(item);
            }
        }
        public void Render(Coordinates coordinates)
        {
            Piece piece = _board.GetPiece(coordinates);

            if (piece != null)
                ChoiceSpriteForPiece(piece);
            
        }

        private void ChoiceSpriteForPiece(Piece piece)
        {
            if (piece.GetType() == typeof(Pawn))
                RenderPieceSprite("/Sprite/whitePawn.png", "/Sprite/blackPawn.png", piece);
            else if (piece.GetType() == typeof(Knight))
                RenderPieceSprite("/Sprite/whiteKnight.png", "/Sprite/blackKnight.png", piece);
            else if (piece.GetType() == typeof(Bishop))
                RenderPieceSprite("/Sprite/whiteBishop.png", "/Sprite/blackBishop.png", piece);
            else if (piece.GetType() == typeof(Rook))
                RenderPieceSprite("/Sprite/whiteRook.png", "/Sprite/blackRook.png", piece);
            else if (piece.GetType() == typeof(Queen))
                RenderPieceSprite("/Sprite/whiteQueen.png", "/Sprite/blackQueen.png", piece);
            else if (piece.GetType() == typeof(King))
                RenderPieceSprite("/Sprite/whiteKing.png", "/Sprite/blackKing.png", piece);
        }

        private void RenderPieceSprite(string whiteSpritePath, string blackSpritePath, Piece piece)
        {
            var element = _boardGrid.Children.Cast<Button>().FirstOrDefault(e => Grid.GetColumn(e) == (int)piece.Coordinates.File - 1 && Grid.GetRow(e) == 7 - (piece.Coordinates.Rank - 1));

            Image img = new Image();

            if (piece.Color == Color.black)
                img.Source = new BitmapImage(new Uri(blackSpritePath, UriKind.Relative));
            else
                img.Source = new BitmapImage(new Uri(whiteSpritePath, UriKind.Relative));

            element!.Content = img;
        }
    }
}
