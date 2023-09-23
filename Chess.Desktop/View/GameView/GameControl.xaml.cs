using System.Windows.Controls;


namespace Chess.Desktop.View.GameView
{
    public partial class GameControl : UserControl
    {
        public GameControl()
        {
            InitializeComponent();
            boardContentControl.Content = new BoardView.BoardControl();
        }
    }
}
