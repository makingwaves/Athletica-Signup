using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Mock.Data;
using Mock.Dtos;

namespace Mock.Controllers
{
  [Route("api/mock/brisusers")]
  [ApiController]
  public class BrisUsersController : ControllerBase
  {
    private readonly IMockRepo _repository;
    private readonly IMapper _mapper;

    public BrisUsersController(IMockRepo repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    // GET api/mock/brisusers
    [HttpGet]
    public ActionResult<IEnumerable<BrisUserReadDto>> GetAllBrisUsers()
    {
      var brisUserItems = _repository.GetAllBrisUsers();
      if (brisUserItems == null)
      {
        return NotFound();
      }

      return Ok(_mapper.Map<IEnumerable<BrisUserReadDto>>(brisUserItems));
    }

    // GET api/mock/brisusers/{id}
    [HttpGet("{id}")]
    public ActionResult<BrisUserReadDto> GetBrisUserById(int id)
    {
      var brisUserModel = _repository.GetBrisUserById(id);
      if (brisUserModel == null)
      {
        return NotFound();
      }
      return Ok(_mapper.Map<BrisUserReadDto>(brisUserModel));
    }
  }
}