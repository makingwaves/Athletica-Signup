using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Backend.ClientDtos;
using Backend.Data;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
  [Route("api/signup/contracts")]
  [ApiController]
  public class ContractsController : ControllerBase
  {
    private readonly IMapper _mapper;
    private readonly IBackendRepo _repository;

    public ContractsController(IMapper mapper, IBackendRepo repository)
    {
      _mapper = mapper;
      _repository = repository;
    }

    [HttpGet("byinstitution")]
    public async Task<ActionResult<IEnumerable<ContractReadDto>>> GetContractsByInstitution([FromQuery] int? instId)
    {
      Response.Headers.Add("Access-Control-Allow-Origin", "*");
      var contractModels = await _repository.GetContractsByInstitution(instId);
      if (contractModels == null)
      {
        return NotFound();
      }
      return Ok(_mapper.Map<IEnumerable<ContractReadDto>>(contractModels));
    }

  }
}