﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RIPD_API2.Models;

namespace RIPD_API2.Data;

public class SQLDataBaseContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
  public DbSet<Diary> Diaries => Set<Diary>();
  public DbSet<Food> Foods => Set<Food>();
  public DbSet<Food_DiaryEntry> DiaryFoods => Set<Food_DiaryEntry>();
  public DbSet<Workout> Workouts => Set<Workout>();
  public DbSet<Workout_DiaryEntry> DiaryWorkouts => Set<Workout_DiaryEntry>();
  public DbSet<Run_DiaryEntry> DiaryRuns => Set<Run_DiaryEntry>();
  public DbSet<BodyMetric> BodyMetrics => Set<BodyMetric>();
  public DbSet<FitnessTarget> FitnessTargets => Set<FitnessTarget>();

  public SQLDataBaseContext(DbContextOptions<SQLDataBaseContext> options) : base(options)
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
      d.HasMany(d => d.FoodEntries)
        .WithOne(f => f.Diary)
        .HasForeignKey(f => f.DiaryId)
        .OnDelete(DeleteBehavior.Cascade);

      d.HasMany(d => d.WorkoutEntries)
        .WithOne(w => w.Diary)
        .HasForeignKey(w => w.DiaryId)
        .OnDelete(DeleteBehavior.Cascade);

      d.HasMany(d => d.RunEntries)
        .WithOne(r => r.Diary)
        .HasForeignKey(r => r.DiaryId)
        .OnDelete(DeleteBehavior.Cascade);

      d.HasMany(d => d.BodyMetrics)
        .WithOne(b => b.Diary)
        .HasForeignKey(b => b.DiaryId)
        .OnDelete(DeleteBehavior.Cascade);

      d.HasMany(d => d.FitnessTargets)
        .WithOne(f => f.Diary)
        .HasForeignKey(f => f.DiaryId)
        .OnDelete(DeleteBehavior.Cascade);
    });
    #endregion Diary

    #region Things in Diary
    builder.Entity<Food_DiaryEntry>(fe =>
    {
      fe.HasKey(f => new { f.DiaryId, f.EntryNr });
      fe.Property(f => f.DiaryId).ValueGeneratedNever();
      fe.Property(f => f.EntryNr).ValueGeneratedNever();

      fe.HasOne(f => f.Food).WithMany()
      .HasForeignKey(f => f.FoodId)
      .OnDelete(DeleteBehavior.NoAction);
    });

    builder.Entity<Workout_DiaryEntry>(we =>
    {
      we.HasOne(w => w.Workout).WithMany()
      .HasForeignKey(w => w.WorkoutId)
      .OnDelete(DeleteBehavior.NoAction);
    });

    builder.Entity<Run_DiaryEntry>(r =>
    {
    });

    builder.Entity<BodyMetric>(b =>
    {
      b.HasKey(b => new { b.DiaryId, b.EntryNr });
      b.Property(b => b.DiaryId).ValueGeneratedNever();
      b.Property(b => b.EntryNr).ValueGeneratedNever();
    });

    builder.Entity<FitnessTarget>(ft =>
    {
      ft.HasKey(ft => new { ft.DiaryId, ft.EntryNr });
      ft.Property(ft => ft.DiaryId).ValueGeneratedNever();
      ft.Property(ft => ft.EntryNr).ValueGeneratedNever();
      ft.HasOne(ft => ft.StartBodyMetric).WithMany()
      .HasForeignKey(ft => new { ft.BodyMetricUser, ft.StartBodyMetricEntryNr})
      .OnDelete(DeleteBehavior.NoAction);
      ft.HasOne(ft => ft.GoalBodyMetric).WithMany()
      .HasForeignKey(ft => new { ft.BodyMetricUser, ft.GoalBodyMetricEntryNr })
      .OnDelete(DeleteBehavior.NoAction);
    });
    #endregion Things in Diary

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
