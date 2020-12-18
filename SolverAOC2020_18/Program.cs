using Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SolverAOC2020_18
{
  public class Program : BaseAdventSolver, IAdventSolver
  {

    public override string SolverName => "Day 18: Operation Order"/*TODO: Task Name*/;

    public override string InputsFolderName => "SolverAOC2020_18";

    public override string SolveTask1(string InputData)
    {

      var data = LoadData(InputData);
      BigInteger total = 0;
      foreach(string line in data)
      {
        BigInteger res = SolveLine(line, 0);
        
        total += res;
      }

      return $"{total}";
    }

    public override string SolveTask2(string InputData)
    {
      var data = LoadData(InputData);

      BigInteger total = 0;
      foreach (string line in data)
      {
        BigInteger res = SolveLine(line, 1);
        total += res;
      }

      return $"{total}";
    }

    private List<string> LoadData(string input)
    {
      List<string> ret = new List<string>();
      using(StringReader sr = new StringReader(input))
      {
        string line;
        while((line = sr.ReadLine()) != null)
        {
          ret.Add(line);
        }
      }
      return ret;
    }

    private BigInteger SolveLine(string line, int evalMethod)
    {
      string ret = line;
      while (ret.Contains("("))
      {
        ret = ReplaceParenthesses(ret, evalMethod);
      }
      if(evalMethod == 0)
      {
        return Evaluate(ret);
      } else
      {
        return Evaluate2(ret);
      }
      
    }

    private string ReplaceParenthesses(string input, int evalMethod)
    {
      Match m = Regex.Match(input, @"^.*(\((.*?)\)).*$");
      string expressionWithPar = m.Groups[1].Value;
      string expression = m.Groups[2].Value;
      BigInteger num;
      if(evalMethod == 0)
      {
        num = Evaluate(expression);
      } else
      {
        num = Evaluate2(expression);
      }
      
      return input.Replace(expressionWithPar, num.ToString());
    }

    private BigInteger Evaluate2(string input)
    {
      string line = input;
      while(true)
      {
        Regex regPlus = new Regex(@"(.*[ (]|)((\d+) \+ (\d+))([ )].*|)");
        Match m = regPlus.Match(line);
        if(m.Success)
        {
          string before = m.Groups[1].Value;
          string expr = m.Groups[2].Value;
          BigInteger numL = BigInteger.Parse(m.Groups[3].Value);
          BigInteger numR = BigInteger.Parse(m.Groups[4].Value);
          string after = m.Groups[5].Value;

          string replacement = (numL + numR).ToString();

          line = $"{before}{replacement}{after}";
          
        } else
        {
          break;
        }
      }
      return Evaluate(line);
    }

    private BigInteger Evaluate(string input)
    {
      BigInteger numL = 0;
      char op = 'X';
      MatchCollection matches = Regex.Matches(input, @"(\d+)|(\+)|(\*)");
      foreach(Match m in matches)
      {
        string v = m.Groups[0].Value;
        if(v == "*")
        {
          op = v[0];
        } else if(v=="+")
        {
          op = v[0];
        } else
        {
          switch(op)
          {
            case '+': 
              {
                BigInteger numR = BigInteger.Parse(v);
                numL = numL + numR;
                break;
              }
            case '*':
              {
                BigInteger numR = BigInteger.Parse(v);
                numL = numL * numR;
                break;
              }
            case 'X':
              {
                numL = BigInteger.Parse(v);
                break;
              }
            default:
              throw new Exception($"Invalid operator {op}");
          }
        }
      }
      return numL;
    }

  }
}
