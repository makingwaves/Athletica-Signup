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
      CreateMap<ClientDtos.UserUpdateDto, User>();
      CreateMap<User, MockApiDtos.UserCreateDto>();
      CreateMap<User, MockApiDtos.UserUpdateDto>();
      CreateMap<User, ClientDtos.UserUpdateDto>();
    }
  }
}