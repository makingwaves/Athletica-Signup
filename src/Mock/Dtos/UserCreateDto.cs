
using System.ComponentModel.DataAnnotations;

namespace Mock.Dtos
{
  public class UserCreateDto
  {
    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(100)]
    public string LastName { get; set; }

    [RegularExpression(@"\d{4}[VH]")]
    public string LastPaidStudentFee { get; set; }

    [Required]
    [RegularExpression(@"\d{8}")]
    public string BirthDate { get; set; }

    public int? LearningInstitutionId { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string PhoneNumber { get; set; }

    [Required]
    public string Address { get; set; }

    public int? BrisId { get; set; }

    [Required]
    [RegularExpression(@"\d{11}")]
    public string Ssn { get; set; }   

  }
}