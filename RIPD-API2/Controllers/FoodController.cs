using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RIPD_API2.Data;
using RIPD_API2.Models;

namespace RIPD_API2.Controllers;

[Route("api/foods")]
[ApiController]
public class FoodController : ControllerBase
{
  private readonly IMapper _mapper;
  private readonly DataBaseContext _dbContext;

  public FoodController(IMapper mapper, DataBaseContext dbContext)
  {
    _mapper = mapper;
    _dbContext = dbContext;
  }

  [HttpPost, Authorize]
  public async Task CreateFoodAsync([FromBody] FoodDTO_Create createFood)
  {
    User manufacturer = await _dbContext.Users.Where(u => u.Id.Equals(createFood.Manufacturer)).FirstOrDefaultAsync();
    User contributer = await _dbContext.Users.Where(u => u.Id.Equals(createFood.Contributer)).FirstOrDefaultAsync();
    Food food = new()
    {
      Name = createFood.Name,
      ManufacturerId = manufacturer.Id,
      Manufacturer = manufacturer,
      ContributerId = contributer.Id,
      Contributer = contributer,
      CreationDateTime = DateTime.Now
    };

    await _dbContext.Foods.AddAsync(food);
    await _dbContext.SaveChangesAsync();
  }

  [HttpGet("{foodId}")]
  public async Task<Food> GetFoodByIdAsync([FromRoute] int foodId)
  {
    Food food = await _dbContext.Foods.FindAsync(foodId);
    return food;
  }
}
