
using AutoMapper;
using Mock.Dtos;
using Mock.Models;

namespace Mock.Profiles
{
  public class LearningInstitutionsProfile : Profile
  {
    public LearningInstitutionsProfile()
    {
      CreateMap<LearningInstitution, LearningInstitutionReadDto>();
      CreateMap<LearningInstitutionCreateDto, LearningInstitution>();
      CreateMap<LearningInstitutionUpdateDto, LearningInstitution>();
      CreateMap<LearningInstitution, LearningInstitutionUpdateDto>();
    }
  }
}