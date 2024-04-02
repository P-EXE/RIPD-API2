using Microsoft.AspNetCore.Identity;

namespace RIPD_API2.Models;

public class User : IdentityUser<Guid>
{
  public ICollection<Food>? ContributedFoods = new HashSet<Food>();
  public ICollection<Food>? ManufacturedFoods = new HashSet<Food>();
  public ICollection<Workout>? ContributedWorkouts = new HashSet<Workout>();
  public Diary Diary = new Diary();
}
