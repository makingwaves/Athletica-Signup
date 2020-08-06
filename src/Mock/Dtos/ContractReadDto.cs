using System.ComponentModel.DataAnnotations;

namespace Mock.Dtos
{
  public class ContractReadDto
  {
    public int Id { get; set; }

    public int? LearningInstitutionId { get; set; }

    public int LockInPeriod { get; set; }

    public int MonthlyFeeNok { get; set; }

  }
}