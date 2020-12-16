using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SolverAOC2020_16
{
  public class Rule
  {
    public string Name { get; set; }
    public int Index { get; set; } = -1;
    public List<int> PossibleIdexList { get; set; } = new List<int>();
    public List<Range> Ranges { get; set; } = new List<Range>();

    public Rule(string input)
    {
      Match m = Regex.Match(input, @"([^:]*): (\d*)-(\d*) or (\d*)-(\d*)");
      Name = m.Groups[1].Value;
      int from1 = int.Parse(m.Groups[2].Value);
      int to1 = int.Parse(m.Groups[3].Value);
      int from2 = int.Parse(m.Groups[4].Value);
      int to2 = int.Parse(m.Groups[5].Value);

      Ranges.Add(new Range() { From = from1, To = to1 });
      Ranges.Add(new Range() { From = from2, To = to2 });

    }

    public bool IsValid(int number)
    {
      foreach (Range r in Ranges)
      {
        if (r.InRange(number))
        {
          return true;
        }
      }
      return false;
    }
  }
}
