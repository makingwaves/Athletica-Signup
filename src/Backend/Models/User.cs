
using System.ComponentModel.DataAnnotations;
using Backend.Attributes;
using Backend.Data;

namespace Backend.Models
{
  public class User
  {
    [Key]
    public int Id { get; set; }

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
    [Date]
    public string BirthDate { get; set; }

    public int? LearningInstitutionId { get; set; }

    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [RegularExpression(@"\d{8}")]
    [Phone]
    public string PhoneNumber { get; set; }

    [Required]
    [RegularExpression(@"[\w\s]+\,\s?\d{4}\,[a-zA-Z\s]+")]
    public string Address { get; set; }

    public int? BrisId { get; set; }

    [Required]
    [RegularExpression(@"\d{11}")]
    public string Ssn { get; set; }

  }
}