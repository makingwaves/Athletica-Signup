using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Attributes
{

  public class DateAttribute : ValidationAttribute
  {

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
      var dateString = (string)value;
      int day = Int32.Parse(dateString.Substring(0, 2));
      int month = Int32.Parse(dateString.Substring(2, 2));
      int year = Int32.Parse(dateString.Substring(4));
      DateTime date;
      try
      {
        date = new DateTime(year, month, day);
      }
      catch (Exception e)
      {
        return new ValidationResult(e.Message);
      }

      if (date > DateTime.Today)
      {
        return new ValidationResult("Date cannot be in the future.");
      }
      if (date < DateTime.Today.AddYears(-150))
      {
        return new ValidationResult($"Year value must be greater than {DateTime.Today.AddYears(-150).Year}.");
      }
      return ValidationResult.Success;
    }
  }


}