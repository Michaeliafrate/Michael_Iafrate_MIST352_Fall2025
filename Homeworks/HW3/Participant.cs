using System;

namespace WorkshopApp
{
    public class Participant
    {
        public int Id { get; }
        public string Name { get; set; }
        public string Email { get; set; }

        public Participant(int id, string name, string email)
        {
            if (id < 1) throw new ArgumentException("ID must be greater than zero.");
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name cannot be empty.");
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
                throw new ArgumentException("Email must contain '@'.");

            Id = id;
            Name = name;
            Email = email;
        }

        public override string ToString() => $"{Name} (ID {Id}, {Email})";
    }
}


