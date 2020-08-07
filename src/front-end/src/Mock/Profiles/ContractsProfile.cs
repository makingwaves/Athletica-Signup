
using AutoMapper;
using Mock.Dtos;
using Mock.Models;

namespace Mock.Profiles
{
  public class ContractsProfile : Profile
  {
    public ContractsProfile()
    {
      CreateMap<Contract, ContractReadDto>();
      CreateMap<ContractCreateDto, Contract>();
      CreateMap<ContractUpdateDto, Contract>();
      CreateMap<Contract, ContractUpdateDto>();
    }
  }
}