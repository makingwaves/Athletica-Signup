using AutoMapper;
using Backend.Models;

namespace Backend.Profiles
{
  public class BrisUsersProfile : Profile
  {
    public BrisUsersProfile()
    {
      CreateMap<MockApiDtos.BrisUserReadDto, BrisUser>();
    }

  }
}