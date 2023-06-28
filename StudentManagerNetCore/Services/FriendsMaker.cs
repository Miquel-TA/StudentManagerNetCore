using StudentManagerNetCore.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;



namespace StudentManagerNetCore.Services
{
    public class FriendsMaker
    {
        private readonly IUserGreeter userGreater;



        public FriendsMaker(IUserGreeter userGreater)
        {
            this.userGreater = userGreater;
            Console.WriteLine($"Created {nameof(FriendsMaker)} instance with userGreeter hash id " +
                $"{userGreater.GetHashCode().ToString()}");
        }



        public string TellAJoke()
        {
            return $"{userGreater.Salute()} quieres ser mi amigo?";
        }
    }
}