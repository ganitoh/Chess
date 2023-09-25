using System.Threading.Tasks;
using System.Windows.Controls;
using Chess.Desktop.Service;
using Chess.Domain.Models;
using Chess.Domain.Models.Pieces;

namespace Chess.Desktop.View.BoardView
{

    public partial class BoardControl : UserControl
    {
        private Board _board = null!;
        private bool _isWhiteStep = true;

        public BoardControl()
        {
            InitializeComponent();

            _board = new Board();
            RenderBoard render = new RenderBoard(boardGrid, _board, _isWhiteStep);
            render.Render();


            

        }        
    }
}
