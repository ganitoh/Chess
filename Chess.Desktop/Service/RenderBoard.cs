using Chess.Domain.Intarfaces;
using Chess.Domain.Models;
using Chess.Domain.Models.Pieces;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Chess.Desktop.Service
{
    internal class RenderBoard : IRenderBoard
    {
        private Grid boardGrid = null!;
        readonly Board _board = null!;
        private bool _isWhiteStep;
        private TaskCompletionSource<Coordinates> buttonClickedTask = null!;

        public RenderBoard(Grid boardGrid, Board board, bool isWhiteStep)
        {
            this.boardGrid = boardGrid;
            _board = board;
            _isWhiteStep = isWhiteStep;
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
            var element = boardGrid.Children.Cast<Button>().FirstOrDefault(e => Grid.GetColumn(e) == (int)piece.Coordinates.File - 1 && Grid.GetRow(e) == 7 - (piece.Coordinates.Rank - 1));

            Image img = new Image();

            if (piece.Color == Chess.Domain.Models.Color.black)
                img.Source = new BitmapImage(new Uri(blackSpritePath, UriKind.Relative));
            else
                img.Source = new BitmapImage(new Uri(whiteSpritePath, UriKind.Relative));

            element!.Content = img;
            element.Click += ActivePiece;
        }

        private void ActivePiece(object sender, RoutedEventArgs e)
        {
            var pieceBtn = sender as Button;

            if (pieceBtn is not null)
            {
                Piece? piece;
                if (_isWhiteStep)
                {
                    int file = Grid.GetColumn(pieceBtn) + 1;
                    int rank =  7 - Grid.GetRow(pieceBtn)  + 1 ;

                    piece = _board.pieces.Values.FirstOrDefault(p => (int)p.Coordinates.File == file && (int)p.Coordinates.Rank == rank && p.Color == Domain.Models.Color.white);

                    var listShiftPiece = piece?.GetAvailableMoveSquare(_board);

                    if (listShiftPiece is not null)
                    {
                        foreach (Coordinates coordinates in listShiftPiece)
                        {
                            var element = boardGrid.Children.Cast<Button>().FirstOrDefault(e => Grid.GetColumn(e) == (int)coordinates.File - 1 && Grid.GetRow(e) == 7 - (coordinates.Rank - 1));

                            if (element is not null)
                            {
                                element.Background = Brushes.White;
                            }
                        }

                    }
                }
            }
        }

        public async Task WaitClickButton()
        {
            buttonClickedTask = new TaskCompletionSource<Coordinates>();
            await buttonClickedTask.Task;
        }
    }
}
