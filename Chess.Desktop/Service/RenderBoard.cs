using Chess.Domain.Intarfaces;
using Chess.Domain.Models;
using Chess.Domain.Models.Pieces;
using System;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Chess.Desktop.Service
{
    internal class RenderBoard : IRenderBoard
    {
        #region Private Field
        private Grid _boardGrid = null!;
        private readonly Board _board = null!;
       //private TaskCompletionSource<Coordinates> buttonClickedTask = null!;
        #endregion

        public RenderBoard(Grid boardGrid, Board board)
        {
            this._boardGrid = boardGrid;
            _board = board;
        }

        public void Render()
        {
            foreach (var item in _board.pieces.Values)
            {
                if (item.GetType() == typeof(Pawn))
                    RenderPieceSprite("/Sprite/whitePawn.png", "/Sprite/blackPawn.png", item);
                else if (item.GetType() == typeof(Knight))
                    RenderPieceSprite("/Sprite/whiteKnight.png", "/Sprite/blackKnight.png", item);
                else if (item.GetType() == typeof(Bishop))
                    RenderPieceSprite("/Sprite/whiteBishop.png", "/Sprite/blackBishop.png", item);
                else if (item.GetType() == typeof(Rook))
                    RenderPieceSprite("/Sprite/whiteRook.png", "/Sprite/blackRook.png", item);
                else if (item.GetType() == typeof(Queen))
                    RenderPieceSprite("/Sprite/whiteQueen.png", "/Sprite/blackQueen.png", item);
                else if (item.GetType() == typeof(King))
                    RenderPieceSprite("/Sprite/whiteKing.png", "/Sprite/blackKing.png", item);
            }
        }

        private void RenderPieceSprite(string whiteSpritePath, string blackSpritePath, Piece piece)
        {
            var element = _boardGrid.Children.Cast<Button>().FirstOrDefault(e => Grid.GetColumn(e) == (int)piece.Coordinates.File - 1 && Grid.GetRow(e) == 7 - (piece.Coordinates.Rank - 1));

            Image img = new Image();

            if (piece.Color == Chess.Domain.Models.Color.black)
                img.Source = new BitmapImage(new Uri(blackSpritePath, UriKind.Relative));
            else
                img.Source = new BitmapImage(new Uri(whiteSpritePath, UriKind.Relative));

            element!.Content = img;
        }



        //public async Task WaitClickButton()
        //{
        //    buttonClickedTask = new TaskCompletionSource<Coordinates>();
        //    await buttonClickedTask.Task;
        //}
    }
}
