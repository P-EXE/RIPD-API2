using Microsoft.EntityFrameworkCore;
using RIPD_API2.Models;

namespace RIPD_API2.Data;

public class MongoDataBaseContext : DbContext
{
  public DbSet<Run> Runs { get; set; }
  public MongoDataBaseContext(DbContextOptions<MongoDataBaseContext> options) : base(options)
  {
  }

  protected override void OnModelCreating(ModelBuilder builder)
  {
    base.OnModelCreating(builder);

    builder.Entity<Run>();
  }
}