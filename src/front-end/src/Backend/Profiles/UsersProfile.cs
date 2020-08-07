using AutoMapper;
using Backend.Models;

namespace Backend.Profiles
{
  public class UsersProfile : Profile
  {
    public UsersProfile()
    {
      CreateMap<MockApiDtos.UserReadDto, User>();
      CreateMap<User, ClientDtos.UserReadDto>();
      CreateMap<ClientDtos.UserCreateDto, User>();
      CreateMap<User, MockApiDtos.UserCreateDto>();
      CreateMap<User, ClientDtos.UserUpdateDto>();
    }
  }
}