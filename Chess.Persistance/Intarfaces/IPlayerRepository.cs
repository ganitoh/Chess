using Chess.Domain.Models.User;

namespace Chess.Persistance.Intarfaces
{
    internal interface IPlayerRepository : IRepository<Player> 
    {
        Player Get(string login);
    }
}
