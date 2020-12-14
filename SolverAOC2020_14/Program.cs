using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SolverAOC2020_14
{
  public class Program : BaseAdventSolver, IAdventSolver
  {

    public override string SolverName => "Day 14: Docking Data"/*TODO: Task Name*/;

    public override string InputsFolderName => "SolverAOC2020_14";

    public override string SolveTask1(string InputData)
    {

      Data data = new Data(InputData);
      Memory memory = new Memory();

      while (!data.IsEnd())
      {
        string line = data.Next();

        ProcessLine(memory, line);
      }

      BigInteger res = memory.SumValues();

      return $"{res}";
    }

    public override string SolveTask2(string InputData)
    {
      Data data = new Data(InputData);
      Memory2 memory = new Memory2();

      while (!data.IsEnd())
      {
        string line = data.Next();

        ProcessLine2(memory, line);
      }

      BigInteger res = memory.SumValues();

      return $"{res}";
    }

    private void ProcessLine(Memory memory, string line)
    {
      if (line.StartsWith("mask"))
      {
        string tmp = line.Replace("mask = ", "");
        memory.ProcessMask(tmp);
        
      } else if(line.StartsWith("mem"))
      {
        Match m = Regex.Match(line, "mem\\[(\\d*)\\] = (\\d*)");
        BigInteger index = BigInteger.Parse(m.Groups[1].Value);
        BigInteger val = BigInteger.Parse(m.Groups[2].Value);
        memory.ProcessValue(index, val);
      }
    }

    private void ProcessLine2(Memory2 memory, string line)
    {
      if (line.StartsWith("mask"))
      {
        string tmp = line.Replace("mask = ", "");
        memory.ProcessMask(tmp);

      }
      else if (line.StartsWith("mem"))
      {
        Match m = Regex.Match(line, "mem\\[(\\d*)\\] = (\\d*)");
        BigInteger index = BigInteger.Parse(m.Groups[1].Value);
        BigInteger val = BigInteger.Parse(m.Groups[2].Value);
        memory.ProcessValue(index, val);
      }
    } 



  }
}
