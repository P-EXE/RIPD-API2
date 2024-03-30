namespace RIPD_API2.Models;

public class Workout
{
  public Guid Id { get; set; }
  public required string Name { get; set; }
  public required string Description { get; set; }
  public required Guid ContributerId { get; set; }
  public required User Contributer { get; set; }
  public ICollection<Workout_DiaryEntry> DiaryEntries = new HashSet<Workout_DiaryEntry>();
  public float Energy { get; set; }
}
