using Microsoft.EntityFrameworkCore;

namespace RIPD_API2.Models;

[PrimaryKey(nameof(DiaryId), nameof(EntryNr))]
[Owned]
public class RunEntry : DiaryEntry
{
  public string MongoDBId { get; set; }
}
