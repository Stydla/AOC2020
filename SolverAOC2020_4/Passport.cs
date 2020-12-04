using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SolverAOC2020_4
{
  class Passport
  {

    string BirthYear;
    string IssueYear;
    string ExpirationYear;
    string Height;
    string HairColor;
    string EyeColor;
    string PassportID;
    string CountryID;

    public bool IsValidFields()
    {
      return !string.IsNullOrWhiteSpace(BirthYear) &&
        !string.IsNullOrWhiteSpace(IssueYear) &&
        !string.IsNullOrWhiteSpace(ExpirationYear) &&
        !string.IsNullOrWhiteSpace(Height) &&
        !string.IsNullOrWhiteSpace(HairColor) &&
        !string.IsNullOrWhiteSpace(EyeColor) &&
        !string.IsNullOrWhiteSpace(PassportID);
    }

    public bool IsValidValues()
    {
      return ValidateBirthYear() &&
        ValidateExpirationYear() &&
        ValidateEyeColor() &&
        ValidateHairColor() &&
        ValidateHeight() &&
        ValidateIssueYear() &&
        ValidatePassportID();
    }

    private bool ValidateBirthYear()
    {
      if (BirthYear == null) return false;
      if (Regex.IsMatch(BirthYear, "[0-9]{4}"))
      {
        int year = int.Parse(BirthYear);
        return year >= 1920 && year <= 2002;
      }
      return false;
    }

    private bool ValidateIssueYear()
    {
      if (IssueYear == null) return false;
      if (Regex.IsMatch(IssueYear, "[0-9]{4}"))
      {
        int year = int.Parse(IssueYear);
        return year >= 2010 && year <= 2020;
      }
      return false;
    }

    private bool ValidateExpirationYear()
    {
      if (ExpirationYear == null) return false;
      if (Regex.IsMatch(ExpirationYear, "[0-9]{4}"))
      {
        int year = int.Parse(ExpirationYear);
        return year >= 2020 && year <= 2030;
      }
      return false;
    }

    private bool ValidateHeight()
    {
      if (Height == null) return false;
      Match m = Regex.Match(Height, "(\\d*)(cm|in)");
      if (m.Success)
      {
        int val = int.Parse(m.Groups[1].Value);
        string units = m.Groups[2].Value;
        if (units == "in")
        {
          return val >= 59 && val <= 76;
        }
        if (units == "cm")
        {
          return val >= 150 && val <= 193;
        }
      }
      return false;
    }

    private bool ValidateHairColor()
    {
      if (HairColor == null) return false;
      return Regex.IsMatch(HairColor, "^#[0-9a-f]{6}$");
    }

    private bool ValidateEyeColor()
    {
      if (EyeColor == null) return false;
      return Regex.IsMatch(EyeColor, "^(amb|blu|brn|gry|grn|hzl|oth)$");
    }

    private bool ValidatePassportID()
    {
      if (PassportID == null) return false;
      return Regex.IsMatch(PassportID, "^[0-9]{9}$");
    }

    public void Print()
    {
      Console.WriteLine($"{BirthYear} {IssueYear} {ExpirationYear} {PassportID} {HairColor} {EyeColor} {Height}");
    }


    public void AddField(string data)
    {
      Match m = Regex.Match(data, "([^:]*):(.*)");
      string key = m.Groups[1].Value;
      string value = m.Groups[2].Value;

      switch (key)
      {
        case "byr":
          BirthYear = value;
          break;
        case "iyr":
          IssueYear = value;
          break;
        case "eyr":
          ExpirationYear = value;
          break;
        case "hgt":
          Height = value;
          break;
        case "hcl":
          HairColor = value;
          break;
        case "ecl":
          EyeColor = value;
          break;
        case "pid":
          PassportID = value;
          break;
        case "cid":
          CountryID = value;
          break;
        default:
          throw new Exception($"Ivanlid Key: {key}");
      }
    }

  }
}
