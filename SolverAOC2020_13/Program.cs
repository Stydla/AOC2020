using Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2020_13
{
  public class Program : BaseAdventSolver, IAdventSolver
  {

    public override string SolverName => "Day 13: Shuttle Search"/*TODO: Task Name*/;

    public override string InputsFolderName => "SolverAOC2020_13";

    public override string SolveTask1(string InputData)
    {

      Input input = new Input(InputData);

      int closest = int.MaxValue;
      int busId = -1;
      foreach(var bus in input.BusList)
      {
        int remain = input.Estimate % bus;
        int add = 0;
        if(remain > 0)
        {
          add = bus - remain;
        }
        if(closest > add + input.Estimate)
        {
          closest = add + input.Estimate;
          busId = bus;
        }
      }

      int waitMin = closest - input.Estimate;
      int res = waitMin * busId;

      return $"{res}";
    }

    public override string SolveTask2(string InputData)
    {

      
      List<ModEquation> equations = GetEquations(InputData);

      LinEquation prevEq = new LinEquation() { a = 1, b = 0 }; // TODO
      for(int i = 0; i < equations.Count; i++)
      {
        LinEquation tmpEq = equations[i].Solve(prevEq);
        prevEq = prevEq.Solve(tmpEq);
      }

      BigInteger res = prevEq.Solve(0);

      return $"{res}";

    }

    private List<ModEquation> GetEquations(string input)
    {
      List<ModEquation> ret = new List<ModEquation>();
      using (StringReader sr = new StringReader(input))
      {
        string line = sr.ReadLine(); // ignore
        line = sr.ReadLine();

        string[] ins = line.Split(',');
        for(int i = 0; i < ins.Length; i++)
        {
          int tmp;
          if(int.TryParse(ins[i], out tmp)) 
          {
            ModEquation me = new ModEquation();
            me.mod = tmp;
            me.res = -i + tmp;
            ret.Add(me);
          }
        }
      }
      return ret;
    }
  }
}
