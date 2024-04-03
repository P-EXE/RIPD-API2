using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace RIPD_API2.Models;

[Owned]
[PrimaryKey(nameof(DiaryId), nameof(EntryNr))]
public class Food_DiaryEntry : DiaryEntry
{
  public required int? FoodId { get; set; }
  public required Food? Food { get; set; }
  public required double Amount { get; set; }
  public required DateTime Consumed { get; set; }
}
