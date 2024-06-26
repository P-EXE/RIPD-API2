﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RIPD_API2.Models;

namespace RIPD_API2.Data;

public class DataBaseContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
  public DbSet<Diary> Diaries => Set<Diary>();
  public DbSet<Food> Foods => Set<Food>();
  public DbSet<Food_DiaryEntry> DiaryFoods => Set<Food_DiaryEntry>();
  public DbSet<Workout> Workouts => Set<Workout>();
  public DbSet<Workout_DiaryEntry> DiaryWorkouts => Set<Workout_DiaryEntry>();
  public DbSet<Run> Runs => Set<Run>();
  public DbSet<BodyMetric> BodyMetrics => Set<BodyMetric>();
  public DbSet<FitnessTarget> FitnessTargets => Set<FitnessTarget>();

  public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
  {
  }

  protected override void OnModelCreating(ModelBuilder builder)
  {
    base.OnModelCreating(builder);

    #region User
    builder.Entity<User>(u =>
    {
      u.OwnsOne(u => u.Diary, d =>
      {
        d.WithOwner(d => d.Owner).HasForeignKey(d => d.OwnerId);

        d.OwnsMany(d => d.FoodEntries, f =>
        {
          f.WithOwner(f => f.Diary).HasForeignKey(f => f.DiaryId);

          f.HasKey(f => new { f.DiaryId, f.EntryNr });
          f.Property(f => f.DiaryId).ValueGeneratedNever();
          f.Property(f => f.EntryNr).ValueGeneratedNever();

          f.HasOne(f => f.Food).WithMany()
          .HasForeignKey(f => f.FoodId)
          .OnDelete(DeleteBehavior.NoAction);
        });

        d.OwnsMany(d => d.WorkoutEntries, w =>
        {
          w.WithOwner(w => w.Diary).HasForeignKey(w => w.DiaryId);
          w.HasOne(w => w.Workout).WithMany()
          .HasForeignKey(w => w.WorkoutId)
          .OnDelete(DeleteBehavior.NoAction);
        });

        d.OwnsMany(d => d.Runs, r =>
        {
          r.WithOwner(r => r.Diary).HasForeignKey(r => r.DiaryId);
        });

        d.OwnsMany(d => d.BodyMetrics, b =>
        {
          b.WithOwner(b => b.Diary).HasForeignKey(b => b.DiaryId);
          b.HasKey(b => new { b.DiaryId, b.EntryNr });
          b.Property(b => b.DiaryId).ValueGeneratedNever();
          b.Property(b => b.EntryNr).ValueGeneratedNever();
        });

        d.OwnsMany(d => d.FitnessTargets, f =>
        {
          f.WithOwner(f => f.Diary).HasForeignKey(f => f.DiaryId);
          f.HasKey(f => new { f.DiaryId, f.EntryNr });
          f.Property(f => f.DiaryId).ValueGeneratedNever();
          f.Property(f => f.EntryNr).ValueGeneratedNever();

          f.HasOne(f => f.StartBodyMetric).WithMany()
          .HasForeignKey(f => f.StartBodyMetricEntryNr)
          .OnDelete(DeleteBehavior.NoAction);
        });
      });

      u.HasMany(u => u.ManufacturedFoods).WithOne(f => f.Manufacturer)
      .HasForeignKey(f => f.ManufacturerId)
      .OnDelete(DeleteBehavior.NoAction);
      u.HasMany(u => u.ContributedFoods).WithOne(f => f.Contributer)
      .HasForeignKey(f => f.ContributerId)
      .OnDelete(DeleteBehavior.NoAction);
    });
    #endregion User

    #region Food
    builder.Entity<Food>(f =>
    {
      f.HasOne(f => f.Manufacturer).WithMany(u => u.ManufacturedFoods)
      .HasForeignKey(f => f.ManufacturerId)
      .OnDelete(DeleteBehavior.NoAction);
      f.HasOne(f => f.Contributer).WithMany(u => u.ContributedFoods)
      .HasForeignKey(f => f.ContributerId)
      .OnDelete(DeleteBehavior.NoAction);
    });
    #endregion Food

    #region Workout
    builder.Entity<Workout>(w =>
    {
      w.HasOne(w => w.Contributer).WithMany(u => u.ContributedWorkouts)
      .HasForeignKey(w => w.ContributerId)
      .OnDelete(DeleteBehavior.NoAction);
    });
    #endregion Workout
  }
}
