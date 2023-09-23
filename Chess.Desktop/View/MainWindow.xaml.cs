using Chess.Desktop.View.BoardView;
using Chess.Domain.Models;
using Chess.Domain.Models.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using Chess.Desktop.View.GameView;

namespace Chess.Desktop
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            boardContentControl.Content = new GameControl();
        }
    }
}
