using System;
using System.Linq;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Backend.Models;
using Newtonsoft.Json;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;

namespace Backend.Data
{
  public class BackendRepo : IBackendRepo
  {
    private readonly ApiRetriever _apiRetriever;
    private readonly IMapper _mapper;

    public BackendRepo(IMapper mapper)
    {
      _apiRetriever = new ApiRetriever(mapper);
      _mapper = mapper;
    }

    public async Task<bool> CreateMembership(Membership membership)
    {
      var result = await _apiRetriever.CreateMembership(membership);
      return result != null;
    }

    public async Task<Contract> GetContractByLockInAndInstitution(int lockIn, int? instId)
    {
      var contracts = await _apiRetriever.GetContracts();
      if (contracts == null)
      {
        return null;
      }
      return contracts.FirstOrDefault
      (
        c => c.LockInPeriod == lockIn
             && c.LearningInstitutionId == instId
      );
    }

    public async Task<User> GetUserByProp(Func<User, bool> pred)
    {
      var users = await _apiRetriever.GetUsers();
      if (users == null)
      {
        return null;
      }
      return users.FirstOrDefault(pred);
    }

    public async Task<User> GetUserById(int id)
    {
      var user = await _apiRetriever.GetUserById(id);
      if (user == null)
      {
        return null;
      }
      return user;
    }

    public async Task<IEnumerable<Contract>> GetContractsByInstitution(int? instId)
    {
      var contracts = await _apiRetriever.GetContracts();
      if (contracts == null)
      {
        return null;
      }
      return contracts.Where(c => c.LearningInstitutionId == instId);
    }

    public async Task<IEnumerable<LearningInstitution>> GetAllLearningInstitutions()
    {
      return await _apiRetriever.GetLearningInstitutions();
    }

    public async Task<User> CreateUser(User user)
    {
      var createdUser = await _apiRetriever.CreateUser(user);
      return createdUser;
    }

    public async Task<Facility> GetFacilityById(int id)
    {
      var facilities = await _apiRetriever.GetAllFacilities();
      return facilities?.FirstOrDefault(f => f.FacilityId == id);
    }

    public async Task<Contract> GetContractById(int id)
    {
      var contract = await _apiRetriever.GetContractById(id);
      return contract;
    }

    public async Task<BrisUser> GetBrisUserBySsn(string ssn)
    {
      IEnumerable<BrisUser> brisUsers = await _apiRetriever.GetBrisUsers();
      return brisUsers?.FirstOrDefault(bu => bu.Ssn == ssn);
    }

    public async Task<bool> PartialUserUpdate(int id, JsonPatchDocument<ClientDtos.UserUpdateDto> patchDoc)
    {
      return await _apiRetriever.PartialUserUpdate(id, patchDoc);
    }
  }
}