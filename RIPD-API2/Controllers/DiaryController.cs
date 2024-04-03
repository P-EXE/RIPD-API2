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
      User? user = await _dbContext.Users.Where(u => u.Id == userId).FirstOrDefaultAsync();
      Food? food = await _dbContext.Foods.FindAsync(createDiaryFood.FoodId);

      int lastEntryNr = _dbContext.Users
        .Include(u => u.Diary).ThenInclude(d => d.FoodEntries)
        .Where(u => u.Id == userId).First()
        .Diary
        .FoodEntries.Select(f => (int?)f.EntryNr).Max() ?? 0;

      Food_DiaryEntry diaryFood = new()
      {
        DiaryId = userId,
        Diary = user.Diary,
        EntryNr = lastEntryNr + 1,
        FoodId = createDiaryFood.FoodId,
        Food = food,
        Amount = createDiaryFood.Amount,
        Consumed = createDiaryFood.Consumed,
        Added = DateTime.UtcNow
      };

      user.Diary.FoodEntries.Add(diaryFood);
      await _dbContext.SaveChangesAsync();
    }

    [HttpGet("foods/recent")]
    public async Task<IEnumerable<Food?>> GetRecentFoodEntriesAsync([FromRoute] Guid userId)
    {
      IEnumerable<Food?> foods = _dbContext.Users
        .Include(u => u.Diary).ThenInclude(d => d.FoodEntries).ThenInclude(f => f.Food)
        .Where(u => u.Id.Equals(userId)).First()
        .Diary
        .FoodEntries
        .OrderByDescending(f => f.Consumed).Take(20).Select(f => f.Food).AsEnumerable();
      return foods;
    }

    [HttpGet("foods/{date}")]
    public async Task<IEnumerable<Food?>> GetFoodEntriesByDateAsync([FromRoute] Guid userId, [FromRoute] DateTime date)
    {
      IEnumerable<Food?> foods = _dbContext.Users
        .Include(u => u.Diary).ThenInclude(d => d.FoodEntries).ThenInclude(f => f.Food)
        .Where(u => u.Id.Equals(userId)).First()
        .Diary
        .FoodEntries
        .Where(f => f.Consumed.Date.Equals(date.Date)).Select(f => f.Food).AsEnumerable();
      return foods;
    }

    [HttpPatch("foods/{foodEntryNr}")]
    public async Task UpdateFoodEntryById([FromRoute] Guid userId, [FromRoute] int foodEntryNr, Food_DiaryEntryDTO_Update updateDiaryFood)
    {
      Food_DiaryEntry foodEntry = _dbContext.Users
        .Include(u => u.Diary).ThenInclude(d => d.FoodEntries)
        .Where(u => u.Id == userId).FirstOrDefault()
        .Diary
        .FoodEntries
        .Where(f => f.EntryNr == foodEntryNr).FirstOrDefault();

      foodEntry.Amount = updateDiaryFood.Amount;
      foodEntry.Consumed = updateDiaryFood.Added;

      _dbContext.Update(foodEntry);
      await _dbContext.SaveChangesAsync();
    }

    [HttpDelete("foods/{foodEntryNr}")]
    public async Task DeleteFoodEntryById([FromRoute] Guid userId, [FromRoute] int foodEntryNr)
    {
      Food_DiaryEntry? foodEntry = _dbContext.Users
        .Include(u => u.Diary).ThenInclude(d => d.FoodEntries)
        .Where(u => u.Id == userId).First()
        .Diary
        .FoodEntries
        .Where (fe => fe.EntryNr == foodEntryNr).FirstOrDefault();

      _dbContext.Remove(foodEntry);
      await _dbContext.SaveChangesAsync();
    }
  }
}
