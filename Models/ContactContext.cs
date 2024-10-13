using Microsoft.EntityFrameworkCore;

namespace ContactApp.Models
{
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> options) : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;

        // Use protected override for OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed data for Category
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Family" },
                new Category { CategoryId = 2, Name = "Friends" },
                new Category { CategoryId = 3, Name = "Work" }
            );

            // Seed data for Contact
            modelBuilder.Entity<Contact>().HasData(
                new Contact
                {
                    ContactId = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    PhoneNumber = "1234567890",
                    Email = "john.doe@example.com",
                    CategoryID = 1
                },
                new Contact
                {
                    ContactId = 2,
                    FirstName = "Jane",
                    LastName = "Smith",
                    PhoneNumber = "9876543210",
                    Email = "jane.smith@example.com",
                    CategoryID = 1
                },
                new Contact
                {
                    ContactId = 3,
                    FirstName = "Alice",
                    LastName = "Johnson",
                    PhoneNumber = "5647382910",
                    Email = "alice.johnson@example.com",
                    CategoryID = 2
                }
            );
        }
    }
}
