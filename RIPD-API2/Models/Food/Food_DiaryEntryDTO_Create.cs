using Microsoft.EntityFrameworkCore;

namespace RIPD_API2.Models;

public class Food_DiaryEntryDTO_Create
{
  public int? FoodId { get; set; }
  public double Amount { get; set; }
  public DateTime Added { get; set; }
}
