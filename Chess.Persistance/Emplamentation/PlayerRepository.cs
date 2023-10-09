using Chess.Domain.Models.User;
using Chess.Persistance.Intarfaces;
using System.Diagnostics.Tracing;

namespace Chess.Persistance.Emplamentation
{
    internal class PlayerRepository : IPlayerRepository
    {
        private ApplicationContext _context = null!;
        public PlayerRepository()
        {
                _context = new ApplicationContext();
        }
        public PlayerRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void AddEntity(Player entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            _context.Players.Add(entity);
            _context.SaveChanges();
        }

        public void DeleteEntity(Player entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            _context.Players.Remove(entity);
            _context.SaveChanges();
        }

        public Player Get(int id)
        {
            var player = _context.Players.FirstOrDefault(p => p.Id == id.ToString());

            if (player is not null)
                return player;
            else
                throw new Exception("Unable to find {login}");
            
        }

        public Player Get(string login)
        {
            var player =  _context.Players.FirstOrDefault(x => x.Login == login);

            if (player is not null)
                return player;
            else
                throw new Exception($"Unable to find {login}");
            
        }

        public IEnumerable<Player> GetAll()
        {
            return _context.Players.ToList();
        }

        public void UpdateEntity(Player entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            var player = _context.Players.FirstOrDefault(x => x.Id == entity.Id);

            if (player is not null)
            {
                player.LocalMMR = entity.LocalMMR;
                player.Name = entity.Name;
                player.Password = entity.Password;
                player.Login = entity.Login;
            }

            _context.SaveChanges();
            
        }
    }
}
