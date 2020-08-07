using System.ComponentModel.DataAnnotations;

namespace Mock.Dtos
{
  public class LearningInstitutionCreateDto
  {
    [Required]
    public string Name { get; set; }
  }
}