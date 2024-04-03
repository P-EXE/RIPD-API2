using Microsoft.EntityFrameworkCore;

namespace RIPD_API2.Models;

[PrimaryKey(nameof(OwnerId))]
public class Diary
{
  public Guid OwnerId { get; set; }
  public User Owner { get; set; }

  public ICollection<Food_DiaryEntry> FoodEntries = new HashSet<Food_DiaryEntry>();
  public ICollection<Workout_DiaryEntry> WorkoutEntries = new HashSet<Workout_DiaryEntry>();
  public ICollection<Run> Runs = new HashSet<Run>();
  
  public ICollection<BodyMetric> BodyMetrics = new HashSet<BodyMetric>();
  public ICollection<FitnessTarget> FitnessTargets = new HashSet<FitnessTarget>();
}
