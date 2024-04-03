﻿using Microsoft.EntityFrameworkCore;

namespace RIPD_API2.Models;

[Owned]
[PrimaryKey(nameof(DiaryId), nameof(EntryNr))]
public class FitnessTarget : DiaryEntry
{
  public required Guid BodyMetricUser { get; set; }
  public required int StartBodyMetricEntryNr { get; set; }
  public required BodyMetric StartBodyMetric { get; set; }
  public required int GoalBodyMetricEntryNr { get; set; }
  public required BodyMetric GoalBodyMetric { get; set; }
  public required DateTime StartDateTime { get; set; }
  public required DateTime EndDateTime { get; set; }
}