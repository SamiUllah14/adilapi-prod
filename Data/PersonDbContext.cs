using Microsoft.EntityFrameworkCore;

namespace adilapi
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>().HasData(
                new Person
                {
                    Id = 1,
                    Name = "Sami Doe",
                    Address = "123 Main Street",
                    MobileNumber = "1234567890",
                    Password = "password123" // Example password
                },
                new Person
                {
                    Id = 2,
                    Name = "Kaleem Smith",
                    Address = "456 Elm Street",
                    MobileNumber = "9876543210",
                    Password = "password456"
                }
            );
        }
    }
}
