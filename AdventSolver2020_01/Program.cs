using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventSolver2020_01
{
  public class Program : BaseAdventSolver, IAdventSolver
  {
    public Program() : base(-1/*TODO: Year*/, -1/*TODO: Task Number*/) { }

    public override string SolverName => "AdventSolver2020_01"/*TODO: Task Name*/;

    public override string InputsFolderName => "AdventSolver2020_01";

    public override string SolveTask1(string InputData)
    {
      return "1";
    }

    public override string SolveTask2(string InputData)
    {
      return "3";
    }
  }
}
