using System.ComponentModel.DataAnnotations;

namespace Mock.Models
{
  public class Contract
  {
    [Key]
    public int Id { get; set; }

    public int? LearningInstitutionId { get; set; }

    [Required]
    [Range(0, 2)]
    /**
    lock in period:    0
    no lock in period: 1
    single month:      2
    */
    public int LockInPeriod { get; set; }

    [Required]
    public int MonthlyFeeNok { get; set; }

  }
}