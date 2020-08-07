using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Mock.Data;
using Mock.Dtos;
using Mock.Models;

namespace Mock.Controllers
{
  [Route("api/mock/learninginstitutions")]
  [ApiController]
  public class LearningInstitutionsController : ControllerBase
  {
    private readonly IMockRepo _repository;
    private readonly IMapper _mapper;

    public LearningInstitutionsController(IMockRepo repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    // GET /api/mock/learninginstitutions
    [HttpGet]
    public ActionResult<IEnumerable<LearningInstitutionReadDto>> GetAllLearningInstitutions()
    {
      Response.Headers.Add("Access-Control-Allow-Origin", "*");
      var instItems = _repository.GetAllLearningInstitutions();
      if (instItems == null)
      {
        return NotFound();
      }
      return Ok(_mapper.Map<IEnumerable<LearningInstitutionReadDto>>(instItems));
    }

    // GET /api/mock/learninginstitutions/{id}
    [HttpGet("{id}", Name = "GetLearningInstitutionById")]
    public ActionResult<LearningInstitutionReadDto> GetLearningInstitutionById(int id)
    {
      Response.Headers.Add("Access-Control-Allow-Origin", "*");
      var inst = _repository.GetLearningInstitutionById(id);
      if (inst == null)
      {
        return NotFound();
      }
      return Ok(_mapper.Map<LearningInstitutionReadDto>(inst));
    }

    // POST /api/mock/learninginstitutions
    [HttpPost]
    public ActionResult<LearningInstitutionReadDto> CreateLearningInstitution(LearningInstitutionCreateDto instCreateDto)
    {
      Response.Headers.Add("Access-Control-Allow-Origin", "*");
      var instModel = _mapper.Map<LearningInstitution>(instCreateDto);
      _repository.CreateLearningInstitution(instModel);
      _repository.SaveChanges();

      var instReadDto = _mapper.Map<LearningInstitutionReadDto>(instModel);
      return CreatedAtRoute(nameof(GetLearningInstitutionById),
                            new { id = instReadDto.Id },
                            instReadDto);
    }

    // PUT /api/mock/learninginstitutions/{id}
    [HttpPut("{id}")]
    public ActionResult UpdateLearningInstitution(int id, LearningInstitutionUpdateDto instUpdateDto)
    {
      Response.Headers.Add("Access-Control-Allow-Origin", "*");
      var instModelFromRepo = _repository.GetLearningInstitutionById(id);
      if (instModelFromRepo == null)
      {
        return NotFound();
      }

      _mapper.Map(instUpdateDto, instModelFromRepo);

      _repository.UpdateLearningInstitution(instModelFromRepo);

      _repository.SaveChanges();

      return NoContent();
    }

    // PATCH api/mock/learninginstitutions/{id}
    [HttpPatch("{id}")]
    public ActionResult PartialLearningInstitutionUpdate(int id, JsonPatchDocument<LearningInstitutionUpdateDto> patchDoc)
    {
      Response.Headers.Add("Access-Control-Allow-Origin", "*");
      var instModelFromRepo = _repository.GetLearningInstitutionById(id);
      if (instModelFromRepo == null)
      {
        return NotFound();
      }

      var instToPatch = _mapper.Map<LearningInstitutionUpdateDto>(instModelFromRepo);
      patchDoc.ApplyTo(instToPatch, ModelState);

      if (!TryValidateModel(instToPatch))
      {
        return ValidationProblem(ModelState);
      }

      _mapper.Map(instToPatch, instModelFromRepo);

      _repository.UpdateLearningInstitution(instModelFromRepo);

      _repository.SaveChanges();

      return NoContent();
    }

    // DELETE api/mock/learninginstitutions/{id}
    [HttpDelete("{id}")]
    public ActionResult DeleteLearningInstitution(int id)
    {
      Response.Headers.Add("Access-Control-Allow-Origin", "*");
      var instModelFromRepo = _repository.GetLearningInstitutionById(id);
      if (instModelFromRepo == null)
      {
        return NotFound();
      }

      _repository.DeleteLearningInstitution(instModelFromRepo);

      _repository.SaveChanges();

      return NoContent();
    }

  }
}