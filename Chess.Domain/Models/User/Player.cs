namespace Chess.Domain.Models.User
{
    public class Player : Person
    {
        public int LocalMMR { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public Player(string id, string name, string surname) : base(id, name, surname) {}

        public Player(string id, string name, string surname, string login, string password) : base(id,name,surname)
        {
            Login = login;
            Password = password;
        }

        
    }
}
