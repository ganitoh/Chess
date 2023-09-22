

namespace Chess.Domain.Models.People
{
    public abstract class Person
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        protected Person(string id, string name, string surname)
        {
            Id = id;
            Name = name;
            Surname = surname;
        }
    }
}
