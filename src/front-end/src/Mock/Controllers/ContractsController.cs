using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Mock.Data;
using Mock.Dtos;
using Mock.Models;

namespace Mock.Controllers
{
  [Route("api/mock/contracts")]
  [ApiController]
  public class ContractsController : ControllerBase
  {
    private readonly IMockRepo _repository;
    private readonly IMapper _mapper;

    public ContractsController(IMockRepo repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    // GET /api/mock/contracts
    [HttpGet]
    public ActionResult<IEnumerable<ContractReadDto>> GetAllContracts()
    {
      Response.Headers.Add("Access-Control-Allow-Origin", "*");
      var contractItems = _repository.GetAllContracts();
      if (contractItems == null)
      {
        return NotFound();
      }
      return Ok(_mapper.Map<IEnumerable<ContractReadDto>>(contractItems));
    }

    // GET /api/mock/contracts/{id}
    [HttpGet("{id}", Name = "GetContractById")]
    public ActionResult<ContractReadDto> GetContractById(int id)
    {
      Response.Headers.Add("Access-Control-Allow-Origin", "*");
      var contract = _repository.GetContractById(id);
      if (contract == null)
      {
        return NotFound();
      }
      return (_mapper.Map<ContractReadDto>(contract));
    }

    // POST /api/mock/contracts
    [HttpPost]
    public ActionResult<ContractReadDto> CreateContract(ContractCreateDto contractCreateDto)
    {
      Response.Headers.Add("Access-Control-Allow-Origin", "*");
      var contractModel = _mapper.Map<Contract>(contractCreateDto);
      _repository.CreateContract(contractModel);
      _repository.SaveChanges();

      var ContractReadDto = _mapper.Map<ContractReadDto>(contractModel);

      return CreatedAtRoute(nameof(GetContractById),
                            new { Id = ContractReadDto.Id },
                            contractCreateDto);
    }

    // PUT /api/mock/contracts/{id}
    [HttpPut("{id}")]
    public ActionResult UpdateContract(int id, ContractUpdateDto contractUpdateDto)
    {
      Response.Headers.Add("Access-Control-Allow-Origin", "*");
      var contractModelFromRepo = _repository.GetContractById(id);
      if (contractModelFromRepo == null)
      {
        return NotFound();
      }
      _mapper.Map(contractUpdateDto, contractModelFromRepo);

      _repository.UpdateContract(contractModelFromRepo);

      _repository.SaveChanges();

      return NoContent();
    }

    // PATCH /api/mock/contracts/{id}
    [HttpPatch("{id}")]
    public ActionResult PartialContractUpdate(int id, JsonPatchDocument<ContractUpdateDto> patchDoc)
    {
      Response.Headers.Add("Access-Control-Allow-Origin", "*");
      var contractModelFromRepo = _repository.GetContractById(id);
      if (contractModelFromRepo == null)
      {
        return NotFound();
      }

      var contractToPatch = _mapper.Map<ContractUpdateDto>(contractModelFromRepo);
      patchDoc.ApplyTo(contractToPatch, ModelState);

      if (!TryValidateModel(contractToPatch))
      {
        return ValidationProblem(ModelState);
      }

      _mapper.Map(contractToPatch, contractModelFromRepo);

      _repository.UpdateContract(contractModelFromRepo);

      _repository.SaveChanges();

      return NoContent();
    }

    // DELETE api/mock/contracts/{id}
    [HttpDelete("{id}")]
    public ActionResult DeleteContract(int id)
    {
      Response.Headers.Add("Access-Control-Allow-Origin", "*");
      var contractModelFromRepo = _repository.GetContractById(id);
      if (contractModelFromRepo == null)
      {
        return NotFound();
      }

      _repository.DeleteContract(contractModelFromRepo);

      _repository.SaveChanges();

      return NoContent();
    }

  }
}