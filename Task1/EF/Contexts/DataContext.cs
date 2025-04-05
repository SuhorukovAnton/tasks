using Microsoft.EntityFrameworkCore;

using Task1.EF.Models;

namespace Task1.EF.Contexts;

public class DataContext(DbContextOptions dbContext) : DbContext(dbContext)
{
    public DbSet<DataModel> Data { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DataModel>();
    }
}
