using System;
using System.Collections.Generic;
using System.Linq;
using Mock.Models;

namespace Mock.Data
{
  public class SqlMockRepo : IMockRepo
  {

    private readonly MockContext _context;

    public SqlMockRepo(MockContext context)
    {
      _context = context;
    }

    public void CreateContract(Contract contract)
    {
      if (contract == null)
      {
        throw new ArgumentNullException(nameof(contract));
      }
      _context.Contracts.Add(contract);
    }

    public void CreateLearningInstitution(LearningInstitution inst)
    {
      if (inst == null)
      {
        throw new ArgumentNullException(nameof(inst));
      }
      _context.LearningInstitutions.Add(inst);
    }

    public void CreateMembership(Membership membership)
    {
      if (membership == null)
      {
        throw new ArgumentNullException(nameof(membership));
      }
      _context.Memberships.Add(membership);
    }

    public void CreateUser(User user)
    {
      if (user == null)
      {
        throw new ArgumentNullException(nameof(user));
      }
      _context.Users.Add(user);
    }

    public void DeleteContract(Contract contract)
    {
      if (contract == null)
      {
        throw new ArgumentNullException(nameof(contract));
      }
      _context.Contracts.Remove(contract);
    }

    public void DeleteLearningInstitution(LearningInstitution learningInstitution)
    {
      if (learningInstitution == null)
      {
        throw new ArgumentNullException(nameof(learningInstitution));
      }
      _context.LearningInstitutions.Remove(learningInstitution);
    }

    public void DeleteMembership(Membership membership)
    {
      if (membership == null)
      {
        throw new ArgumentNullException(nameof(membership));
      }
      _context.Memberships.Remove(membership);
    }

    public void DeleteUser(User user)
    {
      if (user == null)
      {
        throw new ArgumentNullException(nameof(user));
      }
      _context.Users.Remove(user);
    }

    public IEnumerable<BrisUser> GetAllBrisUsers()
    {
      return _context.BrisUsers.ToList();
    }

    public IEnumerable<Contract> GetAllContracts()
    {
      return _context.Contracts.ToList();
    }

    public IEnumerable<Facility> GetAllFacilities()
    {
      return _context.Facilities.ToList();
    }

    public IEnumerable<LearningInstitution> GetAllLearningInstitutions()
    {
      return _context.LearningInstitutions.ToList();
    }

    public IEnumerable<Membership> GetAllMemberships()
    {
      return _context.Memberships.ToList();
    }

    public IEnumerable<User> GetAllUsers()
    {
      return _context.Users.ToList();
    }

    public BrisUser GetBrisUserById(int id)
    {
      return _context.BrisUsers.FirstOrDefault(p => p.Id == id);
    }

    public Contract GetContractById(int id)
    {
      return _context.Contracts.FirstOrDefault(p => p.Id == id);
    }

    public Facility GetFacilityById(int id)
    {
      return _context.Facilities.FirstOrDefault(f => f.FacilityId == id);
    }

    public LearningInstitution GetLearningInstitutionById(int id)
    {
      return _context.LearningInstitutions.FirstOrDefault(p => p.Id == id);
    }

    public Membership GetMembershipById(int id)
    {
      return _context.Memberships.FirstOrDefault(p => p.Id == id);
    }

    public User GetUserById(int id)
    {
      return _context.Users.FirstOrDefault(p => p.Id == id);
    }

    public bool SaveChanges()
    {
      return _context.SaveChanges() >= 0;
    }

    public void UpdateContract(Contract contract)
    {
      // Nothing
    }

    public void UpdateLearningInstitution(LearningInstitution inst)
    {
      // Nothing
    }

    public void UpdateMembership(Membership membership)
    {
      // Nothing
    }

    public void UpdateUser(User user)
    {
      // Nothing
    }
  }
}