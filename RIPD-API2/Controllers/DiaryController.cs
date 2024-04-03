using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RIPD_API2.Data;
using RIPD_API2.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

    [HttpPost("foods")]
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

    [HttpGet("foods/recent")]
    public async Task<IEnumerable<Food?>> GetRecentFoodEntriesAsync([FromRoute] Guid userId)
    {
      IEnumerable<Food?> foods = _dbContext.Diaries
        .Include(d => d.FoodEntries).ThenInclude(f => f.Food)
        .Where(d => d.OwnerId.Equals(userId)).First()
        .FoodEntries
        .OrderByDescending(f => f.Added).Take(20).Select(f => f.Food).AsEnumerable();
      return foods;
    }

    [HttpGet("foods/{date}")]
    public async Task<IEnumerable<Food?>> GetFoodEntriesByDateAsync([FromRoute] Guid userId, [FromRoute] DateTime date)
    {
      IEnumerable<Food?> foods = _dbContext.Diaries
        .Include(d => d.FoodEntries).ThenInclude(f => f.Food)
        .Where(d => d.OwnerId.Equals(userId)).First()
        .FoodEntries
        .Where(f => f.Added.Date.Equals(date.Date)).Select(f => f.Food).AsEnumerable();
      return foods;
    }
  }
}
