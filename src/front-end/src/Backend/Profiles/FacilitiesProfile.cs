using AutoMapper;
using Backend.Models;

namespace Backend.Profiles
{
  public class FacilitiesProfile : Profile
  {
    public FacilitiesProfile()
    {
      CreateMap<MockApiDtos.FacilityReadDto, Facility>();
    }    
    
  }
}