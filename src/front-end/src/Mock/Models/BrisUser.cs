using System.ComponentModel.DataAnnotations;

namespace Mock.Models
{
  public class BrisUser
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
    public string Ssn { get; set; }   
    
  }
}