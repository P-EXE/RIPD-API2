using Microsoft.EntityFrameworkCore;

namespace RIPD_API2.Models;

[PrimaryKey(nameof(DiaryId), nameof(EntryNr))]
[Owned]
public class Workout_DiaryEntry : DiaryEntry
{
  public required int? WorkoutId { get; set; }
  public required Workout? Workout { get; set; }
  public required double? Amount { get; set; }
}
