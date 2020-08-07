using System.Threading.Tasks;
using AutoMapper;
using Backend.ClientDtos;
using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
  [Route("api/signup/memberships")]
  [ApiController]
  public class MembershipsController : ControllerBase
  {
    private readonly IMapper _mapper;
    private readonly IBackendRepo _repository;

    public MembershipsController(IMapper mapper, IBackendRepo repository)
    {
      _mapper = mapper;
      _repository = repository;
    }

    [HttpPost]
    public async Task<ActionResult> CreateMembership(MembershipCreateDto membershipCreateDto)
    {
      var user = await _repository.GetUserById(membershipCreateDto.UserId);
      var facility = await _repository.GetFacilityById(membershipCreateDto.FacilityId);
      var contract = await _repository.GetContractById(membershipCreateDto.ContractId);

      if (user == null)
      {
        ModelState.AddModelError(string.Empty, "User does not exist");
      }
      if (facility == null)
      {
        ModelState.AddModelError(string.Empty, "Facility ID does not exist");
      }
      if (contract == null)
      {
        ModelState.AddModelError(string.Empty, "Contract ID does not exist");
      }

      if (ModelState.ErrorCount > 0)
      {
        return ValidationProblem(ModelState);
      }

      bool success = await _repository.CreateMembership(_mapper.Map<Membership>(membershipCreateDto));
      if (success)
      {
        return NoContent();
      }
      return Conflict();
    }

  }
}