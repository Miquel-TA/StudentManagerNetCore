using StudentManagerNetCore.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagerNetCore.Services
{
    public class Greeter : IGreeter
    {

        public Guid Id { get; private set; }

        public Greeter()
        {
            Id = Guid.NewGuid();
            Console.WriteLine($"Created {nameof(Greeter)} instance with id {Id}");
        }

        public string Salute(string name)
        {
            return $"Hola {name}, ¿Eres un crack de .NET?";
        } 

    }
}
