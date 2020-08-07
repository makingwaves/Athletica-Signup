using System.Collections.Generic;
using Mock.Models;

namespace Mock.Data
{
  public interface IMockRepo
  {

    bool SaveChanges();

    IEnumerable<User> GetAllUsers();

    User GetUserById(int id);

    void CreateUser(User user);

    IEnumerable<Contract> GetAllContracts();

    Contract GetContractById(int id);

    void CreateContract(Contract contract);

    IEnumerable<LearningInstitution> GetAllLearningInstitutions();

    LearningInstitution GetLearningInstitutionById(int id);

    void CreateLearningInstitution(LearningInstitution inst);

    IEnumerable<Membership> GetAllMemberships();

    Membership GetMembershipById(int id);

    void CreateMembership(Membership membership);

    void UpdateUser(User user);

    void UpdateLearningInstitution(LearningInstitution inst);

    void UpdateContract(Contract contract);

    void UpdateMembership(Membership membership);

    void DeleteContract(Contract contract);

    void DeleteLearningInstitution(LearningInstitution learningInstitution);
    BrisUser GetBrisUserById(int id);
    void DeleteMembership(Membership membership);

    void DeleteUser(User user);

    IEnumerable<BrisUser> GetAllBrisUsers();

    IEnumerable<Facility> GetAllFacilities();

    Facility GetFacilityById(int id);
  }
}