using Chess.Domain.Models;
using Chess.Domain.Models.Pieces;

namespace Chess.Domain.Intarfaces
{
    public interface IMove
    {
        void Step(Piece piece,Board board);
    }
}
