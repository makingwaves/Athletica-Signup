using System;
using System.Collections.Generic;
using System.Linq;

namespace Backend
{
  public static class Helper
  {
    public static string SsnToBirthDate(string ssn)
    {

      int day = Int32.Parse(ssn.Substring(0, 2));
      int month = Int32.Parse(ssn.Substring(2, 2));
      int year = Int32.Parse(ssn.Substring(4, 2));
      int centuryIndication = Int32.Parse(ssn.Substring(6, 3));

      int[] digits = Array.ConvertAll(ssn.ToCharArray(), c => (int)Char.GetNumericValue(c));

      int c1 = 11 - ((3 * digits[0] + 7 * digits[1] + 6 * digits[2] + 1 * digits[3] + 8 * digits[4] + 9 * digits[5] + 4 * digits[6] + 5 * digits[7] + 2 * digits[8]) % 11);
      int c2 = 11 - ((5 * digits[0] + 4 * digits[1] + 3 * digits[2] + 2 * digits[3] + 7 * digits[4] + 6 * digits[5] + 5 * digits[6] + 4 * digits[7] + 3 * digits[8] + 2 * c1) % 11);

      c2 = (c2 == 11 ? 0 : c2);

      if (c1 != digits[9]
          || c2 != digits[10])
      {
        return null;
      }

      if (year >= 54
          && centuryIndication >= 500
          && centuryIndication <= 749)
      {
        year += 1800;
      }
      else if (year <= 39 && centuryIndication >= 500)
      {
        year += 2000;
      }
      else if (year >= 40
              && centuryIndication >= 900
              || centuryIndication < 500)
      {
        year += 1900;
      }
      else
      {
        return null;
      }
      return $"{day.ToString().PadLeft(2, '0')}{month.ToString().PadLeft(2, '0')}{year}";
    }
  }
}