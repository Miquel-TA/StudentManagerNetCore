using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StudentManagerNetCore.Abstractions;
using StudentManagerNetCore.Data;
using StudentManagerNetCore.Models;
using StudentManagerNetCore.Services;
using System;

class Program
{
    static void Main(string[] args)
    {
        // See https://aka.ms/new-console-template for more information

        Console.WriteLine("Hello, World!");



        //Register
        var services = new ServiceCollection();
        //services.AddSingleton<IGreeter,Greeter>();



        //Para realizar la inyección por llamada
        services.AddTransient<IGreeter, Greeter>();




        //Resolve
        var serviceProvider = services.BuildServiceProvider();



        var greeter1 = serviceProvider.GetService<IGreeter>();
        var greeter2 = serviceProvider.GetService<IGreeter>();
        Console.WriteLine(greeter1?.Salute("Pepe"));
        Console.WriteLine(greeter2?.Salute("Manuel"));
        PrintHash(greeter1);
        PrintHash(greeter2);



        //Crear su propio scope para Multitenant Architecture. By default is Singleton
        using (var scope = services.BuildServiceProvider().CreateScope())
        {
            var greeter3 = scope.ServiceProvider.GetService<IGreeter>();
            Console.WriteLine(greeter3?.Salute("Fernando"));
            PrintHash(greeter3);
        }



        //Fase de registro con parámetro y factoría
        //Cada vez que realicemos una instancia de FriendsMaker,
        //entonces vamos a pedir una nueva instancia de UserGreeter
        services.AddTransient<IUserGreeter>(sp =>
        {
            return new UserGreeter("Lucas");
        });
        //Lo registramos "AsSelf" porque no tiene ninguna abstracción
        services.AddTransient<FriendsMaker>();



        //Fase de resolución
        var serviceProvider2 = services.BuildServiceProvider();
        var friendMaker = serviceProvider2.GetService<FriendsMaker>();
        Console.WriteLine(friendMaker.TellAJoke());



        static void PrintHash(Object? obj)
        {
            Console.WriteLine(obj?.GetHashCode().ToString());
        }

        /*

        var optionsBuilder = new DbContextOptionsBuilder<Db>();

        using (var context = new Db(optionsBuilder.Options))
        {
            // Ensure database is deleted and re-created
            var tablesDeleted = context.Database.EnsureDeleted();
            if (tablesDeleted)
            {
                Console.WriteLine("Tables deleted.");
            }
            else
            {
                Console.WriteLine("Tables not deleted.");
            }

            var tablesCreated = context.Database.EnsureCreated();
            if (tablesCreated)
            {
                Console.WriteLine("Tables created.");
            }
            else
            {
                Console.WriteLine("Tables already exist.");
            }

            // Create
            var newStudent = new Student("John Doe", new DateTime(2000, 1, 1), 23, DateTime.Now);
            context.Students.Add(newStudent);
            context.SaveChanges();

            // Read
            var students = context.Students.ToList();
            Console.WriteLine("Reading students after creation.");
            foreach (var student in students)
            {
                Console.WriteLine($"Student: {student.Name}, Birthday: {student.Birthday}, Age: {student.Age}, CreatedDate: {student.CreatedDate}");
            }

            // Update
            var firstStudent = context.Students.First();
            firstStudent.Name = "Jane Doe";
            context.SaveChanges();

            // Read
            students = context.Students.ToList();
            Console.WriteLine("Reading students after update.");
            foreach (var student in students)
            {
                Console.WriteLine($"Student: {student.Name}, Birthday: {student.Birthday}, Age: {student.Age}, CreatedDate: {student.CreatedDate}");
            }

            // Delete
            var studentToDelete = context.Students.First(s => s.Id == newStudent.Id);
            context.Students.Remove(studentToDelete);
            context.SaveChanges();

            // Read
            students = context.Students.ToList();
            Console.WriteLine("Reading students after deletion.");
            foreach (var student in students)
            {
                Console.WriteLine($"Student: {student.Name}, Birthday: {student.Birthday}, Age: {student.Age}, CreatedDate: {student.CreatedDate}");
            }

            Console.WriteLine("END.");
        }
        */
    }
}
