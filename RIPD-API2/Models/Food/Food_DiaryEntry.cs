using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace RIPD_API2.Models;

[PrimaryKey(nameof(DiaryId),nameof(Id))]
[Owned]
public class Food_DiaryEntry
{
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int Id { get; set; }
  public required Guid DiaryId { get; set; }
  public required Diary Diary { get; set; }
  public int? FoodId { get; set; }
  public Food? Food { get; set; }
  public double Amount { get; set; }
  public DateTime Added { get; set; }
}
