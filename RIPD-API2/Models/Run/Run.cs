using Microsoft.EntityFrameworkCore;

namespace RIPD_API2.Models;

[PrimaryKey(nameof(DiaryId), nameof(Id))]
[Owned]
public class Run
{
  public int Id { get; set; }
  public Guid DiaryId { get; set; }
  public Diary Diary { get; set; }
  public string MongoDBId { get; set; }
}
