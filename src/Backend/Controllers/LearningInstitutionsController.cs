using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Backend.ClientDtos;
using Backend.Data;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{

  [Route("api/signup/learninginstitutions")]
  [ApiController]
  public class LearningInstitutionsController : ControllerBase
  {
    private readonly IMapper _mapper;
    private readonly IBackendRepo _repository;

    public LearningInstitutionsController(IMapper mapper, IBackendRepo repository)
    {
      _mapper = mapper;
      _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<LearningInstitutionReadDto>>> GetAllLearningInstitutions()
    {
      Response.Headers.Add("Access-Control-Allow-Origin", "*");
      var instModels = await _repository.GetAllLearningInstitutions();
      if (instModels == null)
      {
        return NotFound();
      }
      return Ok(_mapper.Map<IEnumerable<LearningInstitutionReadDto>>(instModels));
    }


  }
}