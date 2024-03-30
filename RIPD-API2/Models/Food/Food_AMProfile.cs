using AutoMapper;

namespace RIPD_API2.Models;

public class Food_AMProfile : Profile
{
	public Food_AMProfile()
	{
		CreateMap<FoodDTO_Create, Food>();
	}
}
