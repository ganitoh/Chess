using System;
using System.CodeDom;
using System.Data.Common;
using System.Linq;
using System.Net.PeerToPeer.Collaboration;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
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

            
            

        }        
    }
}
