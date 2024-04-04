using Microsoft.EntityFrameworkCore;
using RIPD_API2.Models;

namespace RIPD_API2.Data;

public class MongoDataBaseContext : DbContext
{
  public DbSet<Run> Runs => Set<Run>();
  public MongoDataBaseContext(DbContextOptions<SQLDataBaseContext> options) : base(options)
  {
  }

  protected override void OnModelCreating(ModelBuilder builder)
  {
    base.OnModelCreating(builder);
  }
}