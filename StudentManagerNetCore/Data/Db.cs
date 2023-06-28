using Microsoft.EntityFrameworkCore;
using StudentManagerNetCore.Models;

namespace StudentManagerNetCore.Data
{
    public class Db : DbContext
    {
        public Db(DbContextOptions<Db> options) : base(options) { }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .Property(s => s.Id)
                .ValueGeneratedOnAdd();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=StudentManagerNetCore;Trusted_Connection=True;TrustServerCertificate=true;");
        }
    }
}
