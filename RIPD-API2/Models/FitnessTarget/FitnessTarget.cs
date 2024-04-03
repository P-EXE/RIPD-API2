using Microsoft.EntityFrameworkCore;

namespace RIPD_API2.Models;

[Owned]
[PrimaryKey(nameof(DiaryId), nameof(EntryNr))]
public class FitnessTarget : DiaryEntry
{
  public int? StartBodyMetricEntryNr { get; set; }
  public BodyMetric? StartBodyMetric { get; set; }
  public required int GoalBodyMetricEntryNr { get; set; }
  public double Height { get; set; }
  public double Weight { get; set; }
  public required DateTime StartDateTime { get; set; }
  public required DateTime EndDateTime { get; set; }
}