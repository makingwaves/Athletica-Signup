
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace Backend.Data
{
  public interface IBackendRepo
  {

    Task<User> GetUserByProp(Func<User, bool> pred);

    Task<bool> CreateMembership(Membership membership);

    Task<Contract> GetContractByLockInAndInstitution(int lockIn, int? instId);

    Task<IEnumerable<Contract>> GetContractsByInstitution(int? instId);

    Task<IEnumerable<LearningInstitution>> GetAllLearningInstitutions();

    Task<User> CreateUser(User user);

    Task<User> GetUserById(int id);

    Task<bool> PartialUserUpdate(int id, JsonPatchDocument<ClientDtos.UserUpdateDto> patchDocument);

    Task<Facility> GetFacilityById(int id);

    Task<Contract> GetContractById(int id);

    Task<BrisUser> GetBrisUserBySsn(string ssn);

    string GetCityByPostalCode(string postalCode);

    Task<Membership> GetMembershipByUserId(int userId);
    Task<bool> UpdateUser(User userToUpdate);
  }
}