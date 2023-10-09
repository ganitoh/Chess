using Chess.Domain.Intarfaces;
using Chess.Domain.Models.GameTools;
using Chess.Domain.Models.Pieces;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Color = Chess.Domain.Models.GameTools.Color;

namespace Chess.Desktop.Service
{
    internal class MovePiece : IMovePiece
    {
        #region private field
        private List<Coordinates> _activeSquareForMove;
        private Board _board;
        private Grid _boardGrid;
        private Button? _activeButton;
        private Piece? _activePiece;
        #endregion

        public bool StepTaken { get; set; }

        public MovePiece(Grid boardGrid,Board board)
        {
            _activeSquareForMove = new List<Coordinates>();
            _boardGrid = boardGrid;
            _board = board;
        }

        public void Step(bool isWhiteStep)
        {
            if (isWhiteStep)
                BindingActionForActivePieces(Color.white);
            else
                BindingActionForActivePieces(Color.black);
        }

        private void BindingActionForActivePieces(Color colorPiece)
        {
            foreach (var piece in _board.pieces.Values.ToList().FindAll(p => p.Color == colorPiece))
            {
                var pieceButton = _boardGrid.Children.Cast<Button>().FirstOrDefault(e => Grid.GetColumn(e) == (int)piece.Coordinates.File - 1 && Grid.GetRow(e) == 7 - (piece.Coordinates.Rank - 1));
                pieceButton!.Click += ActivePiece;
            }
        }

        private void ActivePiece(object sender, System.Windows.RoutedEventArgs e)
        {
            CleareShiftAtSwithActivePiece();
            _activeButton = (Button)sender ;

            if (_activeButton is not null)
            {
                ShowStepForActivePiece();
            }

            foreach (var coordinates in _activeSquareForMove)
            {
                var element = _boardGrid.Children.Cast<Button>().FirstOrDefault(e => Grid.GetColumn(e) == (int)coordinates.File - 1 && Grid.GetRow(e) == 7 - (coordinates.Rank - 1));

                element!.Click += MoveActivePiece;
            }
        }
        private void ShowStepForActivePiece()
        {
            Coordinates coordinatesActivePiece = GetCoordinatesPieceAtButton(_activeButton!);

            _activePiece = _board.pieces[coordinatesActivePiece];

            var listShiftPiece = _activePiece?.GetAvailableMoveSquare(_board);

            if (listShiftPiece is not null)
            {
                foreach (Coordinates coordinates in listShiftPiece)
                {
                    var btt = _boardGrid.Children.Cast<Button>().FirstOrDefault(e => Grid.GetColumn(e) == (int)coordinates.File - 1 && Grid.GetRow(e) == 7 - (coordinates.Rank - 1));

                    if (btt is not null)
                    {
                        if (!_board.IsSquareEmpty(coordinates) && _board.pieces[coordinates].Color != _activePiece?.Color)
                        {
                            btt.Background = Brushes.Red;
                            _activeSquareForMove!.Add(coordinates);

                        }
                        else
                        {
                            Image img = new Image();
                            img.Source = new BitmapImage(new System.Uri("/Sprite/stepPoint.png", System.UriKind.Relative));

                            btt.Content = img;
                            _activeSquareForMove!.Add(coordinates);
                        }
                    }
                }
            }
        }
        private void MoveActivePiece(object sender, System.Windows.RoutedEventArgs e)
        {
            CleareShiftAtSwithActivePiece();

            Button? btt = sender as Button;

            Coordinates coordinatesForStep = GetCoordinatesPieceAtButton(btt!);

            if (_board.IsSquareEmpty(coordinatesForStep))
                _board.StepPiece(coordinatesForStep, _activePiece!);
            else
                _board.BeatPiece(coordinatesForStep, _activePiece!);
            

            _activeButton!.Content = null;
            _activeButton!.Click -= ActivePiece;

            StepTaken = true;

            UnbindingActivePieces();
        }

        private void CleareShiftAtSwithActivePiece()
        {
            if (_activeSquareForMove.Count != 0)
                CleareShift();
            
            _activeSquareForMove = new List<Coordinates>();
        }
        private void CleareShift()
        {
            foreach (var coordinates in _activeSquareForMove)
            {
                int column = (int)coordinates.File - 1;
                int row = 8 - coordinates.Rank;

                var squareButton = _boardGrid.Children.Cast<Button>().FirstOrDefault(e => Grid.GetColumn(e) == column && Grid.GetRow(e) == row);

                if (!_board.IsSquareEmpty(coordinates))
                {
                    if (_board.IsSquareBlack(coordinates))
                        squareButton!.Background = Brushes.SandyBrown;
                    else
                        squareButton!.Background = Brushes.Bisque;

                    RenderBoard render = new RenderBoard(_boardGrid,_board);
                    render.Render(coordinates);
                    squareButton.Click -= MoveActivePiece;

                    continue;
                }

                squareButton!.Content = null;
                squareButton.Click -= MoveActivePiece;
            }
        }
        private Coordinates GetCoordinatesPieceAtButton(Button btt)
        {
            int file = Grid.GetColumn(btt) + 1;
            int rank = 8 - Grid.GetRow(btt);

            return new Coordinates((FileCoordinates)file, rank);
        }
        private void UnbindingActivePieces()
        {
            foreach (var piece in _board.pieces.Values)
            {
                var btt = _boardGrid.Children.Cast<Button>().FirstOrDefault(e => Grid.GetColumn(e) == (int)piece.Coordinates.File - 1 && Grid.GetRow(e) == 7 - (piece.Coordinates.Rank - 1));
                btt!.Click -= ActivePiece;
            }
        }
    }
}
