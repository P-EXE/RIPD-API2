namespace RIPD_API2.Models;

public class Workout
{
  public int Id { get; set; }
  public required string Name { get; set; }
  public required string Description { get; set; }
  public required Guid ContributerId { get; set; }
  public required User Contributer { get; set; }
  public float Energy { get; set; }
}
