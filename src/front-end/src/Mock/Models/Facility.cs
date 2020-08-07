using System.ComponentModel.DataAnnotations;

namespace Mock.Models
{
  public class Facility
  {
    [Key]
    public int Id { get; set; }

    [Required]
    public int FacilityId { get; set; }

    [Required]
    public string Name { get; set; }

  }
}