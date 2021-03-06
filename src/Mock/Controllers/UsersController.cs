using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Mock.Data;
using Mock.Dtos;
using Mock.Models;

namespace Mock.Controllers
{
  [Route("api/mock/users")]
  [ApiController]
  public class UsersController : ControllerBase
  {
    private readonly IMockRepo _repository;
    private readonly IMapper _mapper;

    private readonly IConfiguration _configuration;
    public UsersController(IMockRepo repository, IMapper mapper, IConfiguration configuration)
    {
      _repository = repository;
      _mapper = mapper;
      _configuration = configuration;
    }

    // GET api/mock/users
    [HttpGet]
    public ActionResult<IEnumerable<UserReadDto>> GetAllUsers()
    {
      Response.Headers.Add("Access-Control-Allow-Origin", "*");
      var userItems = _repository.GetAllUsers();
      if (userItems == null)
      {
        return NotFound();
      }
      return Ok(_mapper.Map<IEnumerable<UserReadDto>>(userItems));
    }

    [HttpGet("configuration")]
    public ActionResult<string> GetConnectionString()
    {
      Response.Headers.Add("Access-Control-Allow-Origin", "*");
      return Ok(_configuration["SQLCONNSTR_DefaultConnection"]);
    }

    // GET api/mock/users/{id}
    [HttpGet("{id}", Name = "GetUserById")]
    public ActionResult<UserReadDto> GetUserById(int id)
    {
      Response.Headers.Add("Access-Control-Allow-Origin", "*");
      var user = _repository.GetUserById(id);
      if (user == null)
      {
        return NotFound();
      }
      return Ok(_mapper.Map<UserReadDto>(user));
    }

    // POST api/mock/users
    [HttpPost]
    public ActionResult<UserReadDto> CreateUser(UserCreateDto userCreateDto)
    {
      Response.Headers.Add("Access-Control-Allow-Origin", "*");
      var userModel = _mapper.Map<User>(userCreateDto);
      _repository.CreateUser(userModel);
      _repository.SaveChanges();

      var userReadDto = _mapper.Map<UserReadDto>(userModel);

      return CreatedAtRoute(nameof(GetUserById),
        new { Id = userReadDto.Id },
        userReadDto);
    }

    // PUT api/commands/{id}
    [HttpPut("{id}")]
    public ActionResult UpdateUser(int id, UserUpdateDto userUpdateDto)
    {
      Response.Headers.Add("Access-Control-Allow-Origin", "*");
      var userModelFromRepo = _repository.GetUserById(id);
      if (userModelFromRepo == null)
      {
        return NotFound();
      }

      _mapper.Map(userUpdateDto, userModelFromRepo);

      _repository.UpdateUser(userModelFromRepo);

      _repository.SaveChanges();

      return NoContent();
    }

    // PATCH api/mock/users/{id}
    [HttpPatch("{id}")]
    public ActionResult PartialUserUpdate(int id, JsonPatchDocument<UserUpdateDto> patchDoc)
    {
      Response.Headers.Add("Access-Control-Allow-Origin", "*");
      var userModelFromRepo = _repository.GetUserById(id);
      if (userModelFromRepo == null)
      {
        return NotFound();
      }
      var userToPatch = _mapper.Map<UserUpdateDto>(userModelFromRepo);
      patchDoc.ApplyTo(userToPatch, ModelState);
      if (!TryValidateModel(userToPatch))
      {
        return ValidationProblem(ModelState);
      }

      _mapper.Map(userToPatch, userModelFromRepo);

      _repository.UpdateUser(userModelFromRepo);

      _repository.SaveChanges();

      return NoContent();
    }

    // DELETE api/mock/users/{id}
    [HttpDelete("{id}")]
    public ActionResult DeleteUser(int id)
    {
      Response.Headers.Add("Access-Control-Allow-Origin", "*");
      var userModelFromRepo = _repository.GetUserById(id);
      if (userModelFromRepo == null)
      {
        return NotFound();
      }

      _repository.DeleteUser(userModelFromRepo);
      _repository.SaveChanges();

      return NoContent();
    }
  }
}