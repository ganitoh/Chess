using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Domain.Models.Pieces
{
    public class Knight : Piece
    {
        public Knight(Color color, Coordinates coordinates) : base(color, coordinates) { }

        protected override List<CoordinatesShift> GetPieceMoves()
        {
            return  new List<CoordinatesShift>
            {
                new CoordinatesShift(1, 2),
                new CoordinatesShift(-1, 2),
                new CoordinatesShift(2, 1),
                new CoordinatesShift(2, -1),
                new CoordinatesShift(-2, 1),
                new CoordinatesShift(-2, -1),
                new CoordinatesShift(1, -2),
                new CoordinatesShift(-1, -2 ),
            };
        }
    }
}
