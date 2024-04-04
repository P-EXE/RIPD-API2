using Microsoft.EntityFrameworkCore;

namespace RIPD_API2.Models;

[Owned]
[PrimaryKey(nameof(DiaryId), nameof(EntryNr))]
public class BodyMetric : DiaryEntry
{
  public double? Height { get; set; }
  public double? Weight { get; set; }
  public required DateTime Recorded { get; set; }
}