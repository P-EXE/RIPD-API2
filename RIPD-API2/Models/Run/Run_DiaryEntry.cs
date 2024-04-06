using Microsoft.EntityFrameworkCore;

namespace RIPD_API2.Models;

[PrimaryKey(nameof(DiaryId), nameof(EntryNr))]
[Owned]
public class Run_DiaryEntry : DiaryEntry
{
  public required string? MongoDBId { get; set; }
}
