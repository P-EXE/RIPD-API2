using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RIPD_API2.Data;
using RIPD_API2.Models;

namespace RIPD_API2.Controllers
{
  [Route("api/user")]
  [ApiController]
  public class UserController : ControllerBase
  {
    private readonly IMapper _mapper;
    private readonly DataBaseContext _dbContext;

    public UserController(IMapper mapper, DataBaseContext dbContext)
    {
      _mapper = mapper;
      _dbContext = dbContext;
    }

    [HttpGet("{userId}/foods/manufactured")]
    public async Task<List<Food>?> GetUserManufacturedFoodsAsync([FromRoute] string userId)
    {
      List<Food> foods = await _dbContext.Foods
        .Where(f => f.ManufacturerId.ToString() == userId).ToListAsync();
      return foods;
    }

    [HttpGet("{userId}/foods/contributed")]
    public async Task<List<Food>?> GetUserContributedFoodsAsync([FromRoute] string userId)
    {
      List<Food> foods = await _dbContext.Foods
        .Where(f => f.ContributerId.ToString() == userId).ToListAsync();
      return foods;
    }
  }
}
