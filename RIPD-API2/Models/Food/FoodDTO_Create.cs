﻿namespace RIPD_API2.Models;

public class FoodDTO_Create
{
  public string? Barcode { get; set; }
  public required string Name { get; set; }
  public required Guid ManufacturerId { get; set; }
  public required Guid ContributerId { get; set; }
  public string? Description { get; set; }
  public string? Image { get; set; }
}
