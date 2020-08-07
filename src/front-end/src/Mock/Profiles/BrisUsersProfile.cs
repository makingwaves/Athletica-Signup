using Mock.Dtos;
using Mock.Models;
using AutoMapper;

namespace Mock.Profiles
{
  public class BrisUsersProfile : Profile
  {
    public BrisUsersProfile()
    {
      CreateMap<BrisUser, BrisUserReadDto>();
    }
  }
}