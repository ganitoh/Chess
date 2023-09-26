using Chess.Domain.Models;
using Chess.Domain.Models.Pieces;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;

namespace Chess.Desktop.Service
{
    internal class MovePiece
    {
        private bool _isWhiteStep = true;
        private Board _board = null!;
        private Button? _activeButton;
        private Grid _boardGrid = null!;
        private Piece? _activePiece;
        private List<Coordinates> _activeSquareForMove = new List<Coordinates>();

        public MovePiece( Grid boardGrid,Board board)
        {
            _boardGrid = boardGrid;
            _board = board;
        }

        public void Step()
        {
            foreach (var piece in _board.pieces.Values)
            {
                var btt = _boardGrid.Children.Cast<Button>().FirstOrDefault(e => Grid.GetColumn(e) == (int)piece.Coordinates.File - 1 && Grid.GetRow(e) == 7 - (piece.Coordinates.Rank - 1));
                btt!.Click += ActivePiece;
            }

        }

        private void ActivePiece(object sender, System.Windows.RoutedEventArgs e)
        {
            var pieceBtn = sender as Button;
            _activeButton = pieceBtn;

            if (pieceBtn is not null)
            {
                if (_isWhiteStep)
                {
                    int file = Grid.GetColumn(pieceBtn) + 1;
                    int rank = 8 - Grid.GetRow(pieceBtn);

                    Piece? piece = _board.pieces.Values.FirstOrDefault(p => (int)p.Coordinates.File == file && (int)p.Coordinates.Rank == rank && p.Color == Domain.Models.Color.white);

                    _activePiece = piece;

                    var listShiftPiece = piece?.GetAvailableMoveSquare(_board);

                    if (listShiftPiece is not null)
                    {
                        foreach (Coordinates coordinates in listShiftPiece)
                        {
                            var element = _boardGrid.Children.Cast<Button>().FirstOrDefault(e => Grid.GetColumn(e) == (int)coordinates.File - 1 && Grid.GetRow(e) == 7 - (coordinates.Rank - 1));

                            if (element is not null)
                            {
                                element.Background = Brushes.White;
                                _activeSquareForMove.Add(coordinates);
                            }
                        }

                    }
                }
            }


            foreach (var coordinates in _activeSquareForMove)
            {
                var element = _boardGrid.Children.Cast<Button>().FirstOrDefault(e => Grid.GetColumn(e) == (int)coordinates.File - 1 && Grid.GetRow(e) == 7 - (coordinates.Rank - 1));

                element!.Click += MoveActivePiece;

            }
        }

        private void MoveActivePiece(object sender, System.Windows.RoutedEventArgs e)
        {
            Button? btt = sender as Button;

            int file = Grid.GetColumn(btt) + 1;
            int rank = 8 - Grid.GetRow(btt);

            Coordinates coordinatesForStep = new Coordinates((FileCoordinates)file, rank);

            _board.StepPiece(coordinatesForStep, _activePiece!);
            _activeButton!.Content = null;

            RenderBoard render = new RenderBoard(_boardGrid,_board);
            render.Render();
            btt!.Click -= MoveActivePiece;
           

        }
    }
}
