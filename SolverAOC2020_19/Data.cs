using System;
using System.Collections.Generic;
using System.Linq;

namespace SolverAOC2020_19
{
  public class Data
  {

    public List<Rule> Rules { get; set; } = new List<Rule>();
    public List<string> Lines { get; set; } = new List<string>();

    internal void ModifyRule(string v)
    {
      int num = int.Parse(v.Split(':')[0]);
      Rule rTmp = Rules.Where(x => x.RuleNumber == num).First();
      rTmp.NextRules1.Clear();
      rTmp.NextRules2.Clear();

      Rule.ParseRule(v, Rules);
    }
  }
}