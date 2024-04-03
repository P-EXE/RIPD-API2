using Microsoft.EntityFrameworkCore;

namespace RIPD_API2.Models;

public class Food_DiaryEntryDTO_Update
{
  public double Amount { get; set; }
  public DateTime Consumed { get; set; }
  public DateTime Added { get; set; }
}
