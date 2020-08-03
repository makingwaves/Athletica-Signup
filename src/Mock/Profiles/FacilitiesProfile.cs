using AutoMapper;
using Mock.Dtos;
using Mock.Models;

namespace Mock.Profiles
{
  public class FacilitiesProfile : Profile
  {
    public FacilitiesProfile()
    {
      CreateMap<Facility, FacilityReadDto>();
    }
  }
}