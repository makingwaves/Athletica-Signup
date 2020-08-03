using System;
using System.Threading.Tasks;
using AutoMapper;
using Backend.ClientDtos;
using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
  [Route("/api/signup/users")]
  [ApiController]
  public class UsersController : ControllerBase
  {
    private readonly IBackendRepo _repository;
    private readonly IMapper _mapper;

    public UsersController(IMapper mapper, IBackendRepo repository)
    {
      _repository = repository;
      _mapper = mapper;
    }

    [HttpGet("existing")]
    public async Task<ActionResult> GetUserByPhoneNumber([FromQuery] string phoneNumber)
    {
      Response.Headers.Add("Access-Control-Allow-Origin", "*");
      if (phoneNumber == null)
      {
        return BadRequest(new ArgumentNullException(nameof(phoneNumber)));
      }
      var user = await _repository.GetUserByProp(u => u.PhoneNumber == phoneNumber);
      if (user == null)
      {
        return Ok(new { exists = false });
      }
      return Ok(new { exists = true });
    }

    [HttpGet("byemail")]
    public async Task<ActionResult<UserReadDto>> GetUserByEmail([FromQuery] string email)
    {
      Response.Headers.Add("Access-Control-Allow-Origin", "*");
      if (email == null)
      {
        return BadRequest(new ArgumentNullException(nameof(email)));
      }
      var user = await _repository.GetUserByProp(u => u.Email == email);
      if (user == null)
      {
        return NotFound();
      }
      return Ok(_mapper.Map<UserReadDto>(user));
    }

    [HttpGet("{id}", Name = "GetUserById")]
    public async Task<ActionResult<UserReadDto>> GetUserById(int id)
    {
      Response.Headers.Add("Access-Control-Allow-Origin", "*");
      var user = await _repository.GetUserById(id);
      if (user == null)
      {
        return NotFound();
      }
      return Ok(_mapper.Map<UserReadDto>(user));
    }

    [HttpGet("byssn")]
    public async Task<ActionResult<UserReadDto>> GetUserBySsn([FromQuery] string ssn)
    {
      Response.Headers.Add("Access-Control-Allow-Origin", "*");
      if (ssn == null)
      {
        return BadRequest(new ArgumentNullException(nameof(ssn)));
      }
      var user = await _repository.GetUserByProp(u => u.Ssn == ssn);
      if (user == null)
      {
        return NotFound();
      }
      return Ok(_mapper.Map<UserReadDto>(user));
    }

    [HttpGet("studentfee")]
    public async Task<ActionResult> GetUserLastPaidStudentFee([FromQuery] string ssn)
    {
      if (ssn == null)
      {
        return BadRequest(new ArgumentNullException(nameof(ssn)));
      }
      var brisUser = await _repository.GetBrisUserBySsn(ssn);
      if (brisUser == null)
      {
        return NotFound();
      }
      return Ok(new { LastPaidStudentFee = brisUser.LastPaidStudentFee });
    }

    [HttpPost]
    public async Task<ActionResult<UserReadDto>> CreateUser(UserCreateDto userCreateDto)
    {
      Response.Headers.Add("Access-Control-Allow-Origin", "*");

      await CheckUserExistsValidationErrors(userCreateDto);

      User userToCreate = await MapToBrisUser(userCreateDto);

      if (ModelState.ErrorCount > 0)
      {
        return ValidationProblem(ModelState);
      }

      User user = await _repository.CreateUser(userToCreate);
      if (user == null)
      {
        return Conflict();
      }
      var userReadDto = _mapper.Map<UserReadDto>(user);
      return CreatedAtRoute(nameof(GetUserById), new { id = userReadDto.Id }, userReadDto);

    }

    [HttpPatch("{id}")]
    public async Task<ActionResult> PartialUserUpdate(int id, JsonPatchDocument<UserUpdateDto> patchDoc)
    {
      var exampleUser = new UserUpdateDto();
      exampleUser.FirstName = "First";
      exampleUser.LastName = "Last";
      exampleUser.PhoneNumber = "12345678";
      exampleUser.Address = "Street 1, 0123, Oslo";

      patchDoc.ApplyTo(exampleUser, ModelState);
      if (!TryValidateModel(exampleUser))
      {
        return ValidationProblem(ModelState);
      }

      var success = await _repository.PartialUserUpdate(id, patchDoc);
      if (success)
      {
        return NoContent();
      }

      return Conflict();

    }

    private async Task<User> MapToBrisUser(UserCreateDto userCreateDto)
    {
      BrisUser brisUser = await _repository.GetBrisUserBySsn(userCreateDto.Ssn);

      User user = _mapper.Map<User>(userCreateDto);
      string bdate = Helper.SsnToBirthDate(userCreateDto.Ssn);
      if (bdate == null)
      {
        ModelState.AddModelError(string.Empty, "Invalid social security number.");
      }
      user.BirthDate = bdate;
      user.BrisId = brisUser?.Id;
      user.LastPaidStudentFee = brisUser?.LastPaidStudentFee;

      return user;
    }

    private async Task<bool> CheckUserExistsValidationErrors(UserCreateDto userCreateDto)
    {
      async Task<bool> modelError(Func<User, string> userProp, Func<UserCreateDto, string> ucdProp, string propName)
      {
        var user = await _repository.GetUserByProp(u => userProp(u) == ucdProp(userCreateDto));
        if (user != null)
        {
          ModelState.AddModelError(string.Empty,
                                   $"User with {propName} {ucdProp(userCreateDto)} already exists.");
          return true;
        }
        return false;
      };
      return await modelError(u => u.Ssn, ucd => ucd.Ssn, "social security number")
          || await modelError(u => u.PhoneNumber, ucd => ucd.PhoneNumber, "phone number")
          || await modelError(u => u.Email, ucd => ucd.Email, "email");
    }
  }
}