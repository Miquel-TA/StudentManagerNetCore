using StudentManagerNetCore.Abstractions;
using System;

namespace StudentManagerNetCore.Services
{
    public class UserGreeter : IUserGreeter
    {

        private readonly string user;

        public UserGreeter(string user)
        {
            this.user = user;
            Console.WriteLine($"Create {nameof(UserGreeter)} instance with user {this.user}");
        }

        public string Salute()
        {
            return $"Hola usuario {user}";
        }

    }
}
