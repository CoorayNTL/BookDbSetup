using BookDbSetup.Model;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace BookDbSetup
{
    public class AppDbContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=db;Port=3307;Database=publishingdb;User=root;Password=admin"; //updated with Docker connection string change to Srver=db
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Initial schema and seeding
            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.Property(a => a.Name).IsRequired().HasMaxLength(100);
                entity.Property(a => a.Country).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(b => b.Id);
                entity.Property(b => b.Title).IsRequired().HasMaxLength(200);
                entity.Property(b => b.PublicationYear).IsRequired();
                entity.HasOne(b => b.Author).WithMany(a => a.Books).HasForeignKey(b => b.AuthorId);
            });

            modelBuilder.Entity<Publisher>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Name).IsRequired().HasMaxLength(100);
                entity.Property(p => p.City).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.HasKey(g => g.Id);
                entity.Property(g => g.Name).IsRequired().HasMaxLength(100);
            });

            // Seed data
            modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, Name = "J.K. Rowling", Country = "UK" }
            );
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "Harry Potter and the Philosopher's Stone", PublicationYear = 1997, AuthorId = 1 }
            );
            modelBuilder.Entity<Publisher>().HasData(
                new Publisher { Id = 1, Name = "Bloomsbury", City = "London" }
            );
        }
    }
}
