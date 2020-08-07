using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
  public class Facility
  {

    [Required]
    public int FacilityId { get; set; }

    [Required]
    public string Name { get; set; }

  }
}