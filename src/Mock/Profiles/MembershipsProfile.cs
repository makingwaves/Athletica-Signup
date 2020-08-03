using AutoMapper;
using Mock.Dtos;
using Mock.Models;

namespace Mock.Profiles
{
  public class MembershipsProfile : Profile
  {
    public MembershipsProfile()
    {
      CreateMap<Membership, MembershipReadDto>();
      CreateMap<MembershipCreateDto, Membership>();
      CreateMap<MembershipUpdateDto, Membership>();
      CreateMap<Membership, MembershipUpdateDto>();
    }
  }
}