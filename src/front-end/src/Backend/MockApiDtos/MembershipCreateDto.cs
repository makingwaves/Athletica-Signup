using System;
using System.ComponentModel.DataAnnotations;

namespace Backend.MockApiDtos
{
  public class MembershipCreateDto
  {
    [Required]
    public int UserId { get; set; }

    [Required]
    public int ContractId { get; set; }

    [Required]
    [RegularExpression(@"\d{8}")]
    public string StartDate { get; set; }

    public string AgressoId { get; set; }

    [Required]
    public int FacilityId { get; set; }

  }
}