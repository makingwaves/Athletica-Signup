using System.ComponentModel.DataAnnotations;

namespace Backend.ClientDtos
{
  public class UserCreateDto
  {
    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(100)]
    public string LastName { get; set; }

    public int? LearningInstitutionId { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [RegularExpression(@"\d{8}")]
    [Phone]
    public string PhoneNumber { get; set; }

    [Required]
    [RegularExpression(@"[\w\s]+\,\s?\d{4}\,[a-zA-Z\s]+")]
    public string Address { get; set; }

    [Required]
    [RegularExpression(@"\d{11}")]
    public string Ssn { get; set; }

  }
}