using AutoMapper;

namespace RIPD_API2.Models;

public class User_AMProfile : Profile
{
  public User_AMProfile()
  {
    CreateMap<UserDTO_Create, User>();
  }
}
