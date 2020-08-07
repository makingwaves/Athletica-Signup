using AutoMapper;
using Backend.Models;

namespace Backend.Profiles
{
  public class LearningInstitutionsProfile : Profile
  {
    public LearningInstitutionsProfile()
    {
      CreateMap<MockApiDtos.LearningInstitutionReadDto, LearningInstitution>();
      CreateMap<LearningInstitution, ClientDtos.LearningInstitutionReadDto>();
    }
  }
}