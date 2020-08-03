using System;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
  public class Membership
  {
    [Key]
    public int Id { get; set; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public int ContractId { get; set; }

    [Required]
    [RegularExpression(@"\d{8}")]
    public string StartDate { get; set; }

    [Required]
    public int FacilityId { get; set; }

    public string AgressoId { get; set; }
  }
}