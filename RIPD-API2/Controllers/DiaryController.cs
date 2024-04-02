using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RIPD_API2.Data;
using RIPD_API2.Models;

namespace RIPD_API2.Controllers
{
  [Route("api/user/{userId}/diary")]
  [ApiController]
  public class DiaryController : ControllerBase
  {
    private readonly IMapper _mapper;
    private readonly DataBaseContext _dbContext;

    public DiaryController(IMapper mapper, DataBaseContext dbContext)
    {
      _mapper = mapper;
      _dbContext = dbContext;
    }

    [HttpPost("food")]
    public async Task AddFoodEntryAsync([FromRoute] Guid userId, Food_DiaryEntryDTO_Create createDiaryFood)
    {
      Food food = await _dbContext.Foods.FindAsync(createDiaryFood.FoodId);
      Diary diary = await _dbContext.Diaries.FindAsync(userId);

      Food_DiaryEntry diaryFood = new()
      {
        DiaryId = userId,
        Diary = diary,
        FoodId = createDiaryFood.FoodId,
        Food = food,
        Amount = createDiaryFood.Amount,
        Added = createDiaryFood.Added
      };

      diary.FoodEntries.Add(diaryFood);
      _dbContext.Update(diary);
      await _dbContext.SaveChangesAsync();
    }

    [HttpGet("food/{date}")]
    public async Task<List<Food>> GetFoodEntriesByDateAsync([FromRoute] Guid userId, [FromRoute] DateTime date)
    {
      List<Food> foods = new();
      IQueryable<Food_DiaryEntry> foodEntries = _dbContext.Diaries
        .Where(d => d.OwnerID.Equals(userId)).First().FoodEntries
        .Where(f => f.Added.Equals(date)).AsQueryable();

      foodEntries.ForEachAsync(d =>
      {
        foods.Add(d.Food);
      });

      return foods;
    }
  }
}
