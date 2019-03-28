using System;
using System.Collections.Generic;

namespace MyHome.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            User user1 = new User() { Email="daniel@gmail.com", Name="Daniel" };
            User user2 = new User() { Email = "daniel@gmail.com", Name = "Daniel" };

            //bool user1EqualsUser1 = user1.Equals(user1);
            //bool user1EqualsUser2 = user1.Equals(user2);

            ICollection<User> utilisateursSansDoublons = new HashSet<User>();
            Console.WriteLine("Ajout de l'utilisateur 1");
            utilisateursSansDoublons.Add(user1);
            Console.WriteLine("Ajout de l'utilisateur 2");
            utilisateursSansDoublons.Add(user2);


            ICollection<User> utilisateursAvecDoublonsPotentiels = new List<User>();
            Console.WriteLine("Ajout de l'utilisateur 1");
            utilisateursAvecDoublonsPotentiels.Add(user1);
            Console.WriteLine("Ajout de l'utilisateur 2");
            utilisateursAvecDoublonsPotentiels.Add(user2);




            Console.Read();
        }
    }

    public class User : IComparable<User>
    {
        public string Email { get; set; }
        public string Name { get; set; }

        public override int GetHashCode()
        {
            var hash = string.IsNullOrEmpty(Email) ? 0 : Email.GetHashCode();
            Console.WriteLine($"Le hash de {Email} vaut {hash}");
            return hash;
        }

        public override bool Equals(object obj)
        {
            return GetHashCode().Equals(obj.GetHashCode());
        }

        public int CompareTo(User other)
        {
            return GetHashCode().CompareTo(other.GetHashCode());
        }
    }
}
