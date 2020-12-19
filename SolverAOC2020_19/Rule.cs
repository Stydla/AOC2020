using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2020_19
{
  public class Rule
  {

    public int RuleNumber { get; set; }

    public char Char { get; set; } = '\0';

    public List<Rule> NextRules1 = new List<Rule>();
    public List<Rule> NextRules2 = new List<Rule>();


    public override string ToString()
    {
      return $"{RuleNumber}";
    }
    public static void ParseRule(string input, List<Rule> availableRules)
    {
      //0: 4 1 5
      //3: 4 5 | 5 4
      //4: "a"

      string[] tmp = input.Split(':');

      int newRuleNumber = int.Parse(tmp[0]);
      var rule = GetRule(newRuleNumber, availableRules);

      if (tmp[1].Contains("a"))
      {
        rule.Char = 'a';
      }
      else if (tmp[1].Contains("b"))
      {
        rule.Char = 'b';
      }
      else
      {
        string[] tmp2 = tmp[1].Split('|');
        if (tmp2.Length == 1)
        {
          foreach (int ruleNum in tmp2[0].Trim().Split(' ').Select(int.Parse))
          {
            var ruleTmp = GetRule(ruleNum, availableRules);
            rule.NextRules1.Add(ruleTmp);
          }
        }
        else if (tmp2.Length == 2)
        {
          foreach (int ruleNum in tmp2[0].Trim().Split(' ').Select(int.Parse))
          {
            var ruleTmp = GetRule(ruleNum, availableRules);
            rule.NextRules1.Add(ruleTmp);
          }
          foreach (int ruleNum in tmp2[1].Trim().Split(' ').Select(int.Parse))
          {
            var ruleTmp = GetRule(ruleNum, availableRules);
            rule.NextRules2.Add(ruleTmp);
          }
        }
        else
        {
          throw new Exception($"Invalid input rule: {input}");
        }

      }
    }

    internal string GetRegexPattern()
    {
      if(IsEndRule()) 
      {
        return Char.ToString();
      }

      StringBuilder sb = new StringBuilder();
      sb.Append('(');
      foreach(Rule rTmp in NextRules1)
      {
        sb.Append(rTmp.GetRegexPattern());
      }
      if(NextRules2.Count >0)
      {
        sb.Append("|");
        foreach (Rule rTmp in NextRules2)
        {
          sb.Append(rTmp.GetRegexPattern());
        }
      }
      sb.Append(')');
      return sb.ToString();
    }

    internal string GetRegexPattern2(int deep, int maxDeep)
    {
      if(deep == maxDeep)
      {
        return "X";
      } 
      if (IsEndRule())
      {
        return Char.ToString();
      }

      StringBuilder sb = new StringBuilder();
      sb.Append('(');
      foreach (Rule rTmp in NextRules1)
      {
        sb.Append(rTmp.GetRegexPattern2(deep + 1, maxDeep));
      }
      if (NextRules2.Count > 0)
      {
        sb.Append("|");
        foreach (Rule rTmp in NextRules2)
        {
          sb.Append(rTmp.GetRegexPattern2(deep + 1, maxDeep));
        }
      }
      sb.Append(')');
      return sb.ToString();
    }

    public static Rule GetRule(int ruleNum, List<Rule> availableRules)
    {
      var rule = availableRules.Where(x => x.RuleNumber == ruleNum).FirstOrDefault();
      if (rule == null)
      {
        rule = new Rule();
        rule.RuleNumber = ruleNum;
        availableRules.Add(rule);
      }
      return rule;
    }

    public bool IsEndRule()
    {
      return Char != '\0';
    }

  }
}
