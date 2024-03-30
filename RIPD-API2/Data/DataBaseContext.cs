using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RIPD_API2.Models;

namespace RIPD_API2.Data;

public class DataBaseContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
  public DbSet<Food> Foods => Set<Food>();

  public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
  {

  }

  protected override void OnModelCreating(ModelBuilder builder)
  {
    base.OnModelCreating(builder);

    #region User
    builder.Entity<User>(u =>
    {
      u.HasOne(u => u.Diary).WithOne(d => d.Owner);

      u.HasMany(u => u.ManufacturedFoods).WithOne(f => f.Manufacturer)
      .HasForeignKey(f => f.ManufacturerId)
      .OnDelete(DeleteBehavior.NoAction);
      u.HasMany(u => u.ContributedFoods).WithOne(f => f.Contributer)
      .HasForeignKey(f => f.ContributerId)
      .OnDelete(DeleteBehavior.NoAction);
    });
    #endregion User

    #region Diary
    builder.Entity<Diary>(d =>
    {
      d.HasOne(d => d.Owner).WithOne(u => u.Diary);

      d.OwnsMany(d => d.FoodEntries).WithOwner(f => f.Diary);
      d.OwnsMany(d => d.WorkoutEntries).WithOwner(w => w.Diary);
      d.OwnsMany(d => d.Runs).WithOwner(r => r.Diary);
    });

    builder.Entity<Food_DiaryEntry>(f =>
    {
      f.HasOne(f => f.Food).WithMany(f => f.DiaryEntries);
    });

    builder.Entity<Workout_DiaryEntry>(f =>
    {
      f.HasOne(w => w.Workout).WithMany(w => w.DiaryEntries);
    });

    builder.Entity<Run>(r =>
    {
      r.HasOne(r => r.Diary).WithMany(d => d.Runs);
    });
    #endregion Diary

    builder.Entity<Food>(f =>
    {
      f.HasOne(f => f.Manufacturer).WithMany(u => u.ManufacturedFoods)
      .HasForeignKey(f => f.ManufacturerId)
      .OnDelete(DeleteBehavior.NoAction);
      f.HasOne(f => f.Contributer).WithMany(u => u.ContributedFoods)
      .HasForeignKey(f => f.ContributerId)
      .OnDelete(DeleteBehavior.NoAction);
      f.HasMany(f => f.DiaryEntries).WithOne(f => f.Food)
      .HasForeignKey(f => f.FoodId);
    });

    builder.Entity<Workout>(w =>
    {
      w.HasOne(w => w.Contributer).WithMany(u => u.ContributedWorkouts)
      .HasForeignKey(w => w.ContributerId)
      .OnDelete(DeleteBehavior.NoAction);
      w.HasMany(w => w.DiaryEntries).WithOne(w => w.Workout)
      .HasForeignKey(w => w.WorkoutId);
    });
  }
}
