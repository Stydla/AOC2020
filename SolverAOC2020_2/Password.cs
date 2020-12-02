using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SolverAOC2020_2
{
  class Password
  {
    private Condition Condition;
    private string value;
    public Password(string input)
    {
      Condition = new Condition();
      //1-3 a: abcde
      Match m = Regex.Match(input, "([0-9]*)-([0-9]*) ([a-z]): ([a-z]*)");
      Condition.Con1 = int.Parse(m.Groups[1].Value);
      Condition.Con2 = int.Parse(m.Groups[2].Value);
      Condition.Letter = char.Parse(m.Groups[3].Value);

      value = m.Groups[4].Value;
    }

    public bool IsValid1()
    {
      int cnt = value.Split(Condition.Letter).Length - 1;

      return cnt >= Condition.Con1 && cnt <= Condition.Con2;
    }

    public bool IsValid2()
    {
      bool pos1 = value[Condition.Con1 - 1] == Condition.Letter;
      bool pos2 = value[Condition.Con2 - 1] == Condition.Letter;
      return pos1 != pos2;
    }
  }
}
