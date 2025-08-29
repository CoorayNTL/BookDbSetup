using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        using var context = new AppDbContext();
        await context.Database.MigrateAsync(); 
        var authors = await context.Authors.ToListAsync();
        Console.WriteLine($"Seeded {authors.Count} authors.");

        context.Genres.Add(new Genre { Id = 1, Name = "Fantasy" });
        await context.SaveChangesAsync();
        Console.WriteLine("Migration applied and verified.");
    }
}