using System.ComponentModel.DataAnnotations;

namespace Mock.Dtos
{
  public class ContractCreateDto
  {

    public int? LearningInstitutionId { get; set; }

    [Required]
    [Range(0, 2)]
    public int LockInPeriod { get; set; }

    [Required]
    public int MonthlyFeeNok { get; set; }

  }
}