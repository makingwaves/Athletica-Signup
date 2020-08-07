using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Mock.Data;
using Mock.Dtos;

namespace Mock.Controllers
{
  [Route("api/mock/facilities")]
  [ApiController]
  public class FacilitiesController : ControllerBase
  {
    private readonly IMapper _mapper;
    private readonly IMockRepo _repository;

    public FacilitiesController(IMapper mapper, IMockRepo repository)
    {
      _mapper = mapper;
      _repository = repository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<FacilityReadDto>> GetAllFacilities()
    {
      var facilityItems = _repository.GetAllFacilities();
      if (facilityItems == null)
      {
        return NotFound();
      }
      return Ok(_mapper.Map<IEnumerable<FacilityReadDto>>(facilityItems));
    }

    [HttpGet("{id}")]
    public ActionResult<FacilityReadDto> GetFacilityById(int id)
    {
      var facility = _repository.GetFacilityById(id);
      if (facility == null)
      {
        return NotFound();
      }
      return Ok(_mapper.Map<FacilityReadDto>(facility));
    }
  }

}