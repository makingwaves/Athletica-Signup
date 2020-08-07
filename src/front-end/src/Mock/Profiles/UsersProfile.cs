using AutoMapper;
using Mock.Dtos;
using Mock.Models;

namespace Mock.Profiles
{
  public class UsersProfile : Profile
  {
    public UsersProfile()
    {
      CreateMap<User, UserReadDto>();
      CreateMap<UserCreateDto, User>();
      CreateMap<UserUpdateDto, User>();
      CreateMap<User, UserUpdateDto>();
    }
  }
}