using Mock.Models;
using Microsoft.EntityFrameworkCore;

namespace Mock.Data
{
  public class MockContext : DbContext
  {
    public MockContext(DbContextOptions<MockContext> opt) : base(opt)
    {

    }

    public DbSet<User> Users { get; set; }

    public DbSet<Contract> Contracts { get; set; }

    public DbSet<LearningInstitution> LearningInstitutions { get; set; }

    public DbSet<Membership> Memberships { get; set; }

    public DbSet<BrisUser> BrisUsers { get; set; }

    public DbSet<Facility> Facilities { get; set; }

  }
}