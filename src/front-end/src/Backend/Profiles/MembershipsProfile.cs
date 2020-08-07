using AutoMapper;
using Backend.Models;

namespace Backend.Profiles
{
  public class MembershipsProfile : Profile
  {
    public MembershipsProfile()
    {
      CreateMap<ClientDtos.MembershipCreateDto, Membership>();
      CreateMap<Membership, MockApiDtos.MembershipCreateDto>();
      CreateMap<MockApiDtos.MembershipReadDto, Membership>();
    }
  }
}