using System.ComponentModel.DataAnnotations;

namespace Mock.Models
{
  public class LearningInstitution
  {
    [Key]
    public int Id { get; set; }

    // Could for instance have name in both Norwegian and English
    [Required]
    public string Name { get; set; }
  }
}