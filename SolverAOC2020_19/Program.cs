using Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SolverAOC2020_19
{
  public class Program : BaseAdventSolver, IAdventSolver
  {

    public override string SolverName => "Day 19: Monster Messages"/*TODO: Task Name*/;

    public override string InputsFolderName => "SolverAOC2020_19";

    public override string SolveTask1(string InputData)
    {
      Data data = LoadData(InputData);

      Rule startRule = data.Rules.Where(x => x.RuleNumber == 0).First();
      string pattern = $"^{startRule.GetRegexPattern()}$";
      
      Regex r = new Regex(pattern);
      int res = 0;
      foreach (string line in data.Lines)
      {
        if(r.IsMatch(line))
        {
          res++;
        }
      }
      return $"{res}";
    }

    public override string SolveTask2(string InputData)
    {
      Data data = LoadData(InputData);

      Rule r8 = Rule.GetRule(8, data.Rules);
      Rule r11 = Rule.GetRule(11, data.Rules);

      data.ModifyRule("8: 42 | 42 8");
      data.ModifyRule("11: 42 31 | 42 11 31");
      


      Rule startRule = data.Rules.Where(x => x.RuleNumber == 0).First();
      string pattern = $"^{startRule.GetRegexPattern2(0, data.Rules.Count)}$";

      Regex r = new Regex(pattern);
      int res = 0;
      foreach (string line in data.Lines)
      {
        if (r.IsMatch(line))
        {
          res++;
        }
      }
      return $"{res}";
    }


    private Data LoadData(string input)
    {
      Data ret = new Data();
      using (StringReader sr = new StringReader(input))
      {
        int type = 0;
        string line;
        while ((line = sr.ReadLine()) != null)
        {
          if(string.IsNullOrEmpty(line))
          {
            type++;
            continue;
          }
          if(type == 0)
          {
            Rule.ParseRule(line, ret.Rules);
          } else
          {
            ret.Lines.Add(line);
          }
          
        }
      }
      return ret;
    }

  }
}
