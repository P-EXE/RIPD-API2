using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace RIPD_API2.Models;

[PrimaryKey(nameof(DiaryId), nameof(EntryNr))]
[Owned]
public class Workout_DiaryEntry
{
  [Key]
  public Guid DiaryId { get; set; }
  public Diary Diary { get; set; }
  [Key]
  public int EntryNr { get; set; }
  public int WorkoutId { get; set; }
  public Workout Workout { get; set; }
  public double Amount { get; set; }
  public DateTime Added { get; set; }
}
