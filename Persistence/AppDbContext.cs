using aspcore_angular.Models;
using Microsoft.EntityFrameworkCore;

namespace aspcore_angular.Persistence
{
  public class AppDbContext : DbContext
  {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<Make> Makes { get; set; }
  }
}