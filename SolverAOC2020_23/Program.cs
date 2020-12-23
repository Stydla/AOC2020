using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2020_23
{
  public class Program : BaseAdventSolver, IAdventSolver
  {

    public override string SolverName => "Day 23: Crab Cups"/*TODO: Task Name*/;

    public override string InputsFolderName => "SolverAOC2020_23";

    public override string SolveTask1(string InputData)
    {
      Data2 data = new Data2(InputData);
      data.Link();
      data.Move(100);
      string res = data.GetResult1();

      return res;
    }

    public override string SolveTask2(string InputData)
    {
      Data2 data = new Data2(InputData);
      data.Fill2();
      data.Link();
      data.Move(1000 * 1000 * 10);

      return data.GetResult2();
    }
  }
}
