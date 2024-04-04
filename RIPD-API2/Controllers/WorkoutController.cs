using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RIPD_API2.Data;
using RIPD_API2.Models;

namespace RIPD_API2.Controllers;

[Route("api/workouts")]
[ApiController]
public class WorkoutController : ControllerBase
{
  private readonly IMapper _mapper;
  private readonly DataBaseContext _dbContext;

  public WorkoutController(IMapper mapper, DataBaseContext dbContext)
  {
    _mapper = mapper;
    _dbContext = dbContext;
  }

  #region Create

  [HttpPost]
  public async Task CreateWorkoutAsync([FromBody] WorkoutDTO_Create createWorkout)
  {
    User? contributer = await _dbContext.Users.FindAsync(createWorkout.ContributerId);
    Workout workout = new()
    {
      Name = createWorkout.Name,
      Description = createWorkout.Description,
      ContributerId = createWorkout.ContributerId,
      Contributer = contributer,
      Energy = createWorkout.Energy
    };

    await _dbContext.Workouts.AddAsync(workout);
    await _dbContext.SaveChangesAsync();
  }

  #endregion Create

  #region Read

  [HttpGet("{workoutId}")]
  public async Task<Workout?> GetWorkoutByIdAsync([FromRoute] string workoutId)
  {
    Workout? workout = await _dbContext.Workouts
      .FindAsync(workoutId);
    return workout;
  }

  #endregion Read
}
