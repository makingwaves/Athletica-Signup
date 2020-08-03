using System.ComponentModel.DataAnnotations;

namespace Backend.ClientDtos
{
  public class UserUpdateDto
  {

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    [RegularExpression(@"[\w\s]+\,\s?\d{4}\,[a-zA-Z\s]+")]
    public string Address { get; set; }

    [Required]
    [RegularExpression(@"\d{8}")]
    [Phone]
    public string PhoneNumber { get; set; }

    public int? LearningInstitutionId { get; set; }

  }

}