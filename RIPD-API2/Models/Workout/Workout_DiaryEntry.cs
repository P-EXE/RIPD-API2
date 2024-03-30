using Microsoft.EntityFrameworkCore;

namespace RIPD_API2.Models;

[PrimaryKey(nameof(DiaryId),nameof(Id))]
[Owned]
public class Workout_DiaryEntry
{
  public int Id { get; set; }
  public Guid DiaryId { get; set; }
  public Diary Diary { get; set; }
  public Guid WorkoutId { get; set; }
  public Workout Workout { get; set; }
  public double Amount { get; set; }
  public DateTime Added { get; set; }
}
