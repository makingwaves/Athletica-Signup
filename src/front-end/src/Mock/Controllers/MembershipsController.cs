using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Mock.Data;
using Mock.Dtos;
using Mock.Models;

namespace Mock.Controllers
{
  [Route("/api/mock/memberships")]
  [ApiController]
  public class MembershipsController : ControllerBase
  {
    private readonly IMockRepo _repository;
    private readonly IMapper _mapper;

    public MembershipsController(IMockRepo repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    // GET /api/mock/memberships
    [HttpGet]
    public ActionResult<IEnumerable<MembershipReadDto>> GetAllMemberhips()
    {
      Response.Headers.Add("Access-Control-Allow-Origin", "*");
      var membershipItems = _repository.GetAllMemberships();
      if (membershipItems == null)
      {
        return NotFound();
      }
      return Ok(_mapper.Map<IEnumerable<MembershipReadDto>>(membershipItems));
    }

    // GET /api/mock/memberships/{id}
    [HttpGet("{id}", Name = "GetMembershipById")]
    public ActionResult<MembershipReadDto> GetMembershipById(int id)
    {
      Response.Headers.Add("Access-Control-Allow-Origin", "*");
      var membership = _repository.GetMembershipById(id);
      if (membership == null)
      {
        return NotFound();
      }
      return Ok(_mapper.Map<MembershipReadDto>(membership));
    }

    // POST /api/mock/memberships
    [HttpPost]
    public ActionResult<MembershipReadDto> CreateMembership(MembershipCreateDto membershipCreateDto)
    {
      Response.Headers.Add("Access-Control-Allow-Origin", "*");
      var membershipModel = _mapper.Map<Membership>(membershipCreateDto);
      _repository.CreateMembership(membershipModel);
      _repository.SaveChanges();

      var membershipReadDto = _mapper.Map<MembershipReadDto>(membershipModel);
      return CreatedAtRoute(nameof(GetMembershipById),
                            new { id = membershipReadDto.Id },
                            membershipReadDto);
    }

    // PUT /api/mock/memberships/{id}
    [HttpPut("{id}")]
    public ActionResult UpdateMembership(int id, MembershipUpdateDto membershipUpdateDto)
    {
      Response.Headers.Add("Access-Control-Allow-Origin", "*");
      var membershipModelFromRepo = _repository.GetMembershipById(id);
      if (membershipModelFromRepo == null)
      {
        return NotFound();
      }

      _mapper.Map(membershipUpdateDto, membershipModelFromRepo);

      _repository.UpdateMembership(membershipModelFromRepo);

      _repository.SaveChanges();

      return NoContent();
    }

    // PATCH api/mock/memberships/{id}
    [HttpPatch("{id}")]
    public ActionResult PartialMembershipUpdate(int id, JsonPatchDocument<MembershipUpdateDto> patchDoc)
    {
      Response.Headers.Add("Access-Control-Allow-Origin", "*");
      var membershipModelFromRepo = _repository.GetMembershipById(id);
      if (membershipModelFromRepo == null)
      {
        return NotFound();
      }

      var membershipToPatch = _mapper.Map<MembershipUpdateDto>(membershipModelFromRepo);
      patchDoc.ApplyTo(membershipToPatch, ModelState);

      if (!TryValidateModel(membershipToPatch))
      {
        return ValidationProblem(ModelState);
      }

      _mapper.Map(membershipToPatch, membershipModelFromRepo);

      _repository.UpdateMembership(membershipModelFromRepo);

      _repository.SaveChanges();

      return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteMembership(int id)
    {
      Response.Headers.Add("Access-Control-Allow-Origin", "*");
      var membershipModelFromRepo = _repository.GetMembershipById(id);
      if (membershipModelFromRepo == null)
      {
        return NotFound();
      }

      _repository.DeleteMembership(membershipModelFromRepo);

      _repository.SaveChanges();

      return NoContent();
    }

  }
}