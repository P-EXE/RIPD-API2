using Microsoft.EntityFrameworkCore;

namespace RIPD_API2.Models;

[PrimaryKey(nameof(DiaryId),nameof(Id))]
[Owned]
public class Food_DiaryEntry
{
  public int Id { get; set; }
  public required Guid DiaryId { get; set; }
  public required Diary Diary { get; set; }
  public Guid? FoodId { get; set; }
  public Food? Food { get; set; }
  public double Amount { get; set; }
  public DateTime Added { get; set; }
}
