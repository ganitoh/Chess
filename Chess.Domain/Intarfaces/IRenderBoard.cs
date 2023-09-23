using Chess.Domain.Models;

namespace Chess.Domain.Intarfaces
{
    public interface IRenderBoard
    {
        void Render(Board board);
    }
}
