using AutoMapper;
using Backend.Models;

namespace Backend.Profiles
{
  public class ContractsProfile : Profile
  {
    public ContractsProfile()
    {
      CreateMap<MockApiDtos.ContractReadDto, Contract>();
      CreateMap<Contract, ClientDtos.ContractReadDto>();
    }
  }
}