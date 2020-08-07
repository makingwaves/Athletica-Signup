using System.ComponentModel.DataAnnotations;

namespace Backend.ClientDtos
{
  public class MembershipCreateDto
  {
    [Required]
    public int UserId { get; set; }

    [Required]
    public int ContractId { get; set; }

    [Required]
    [RegularExpression(@"\d{8}")]
    [Attributes.Date]
    public string startDate { get; set; }

    [Required]
    public int FacilityId { get; set; }
  }
}