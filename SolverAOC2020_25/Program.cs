using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2020_25
{
  public class Program : BaseAdventSolver, IAdventSolver
  {

    public override string SolverName => "Day 25: Combo Breaker"/*TODO: Task Name*/;

    public override string InputsFolderName => "SolverAOC2020_25";

    public override string SolveTask1(string InputData)
    {
      Data data = new Data(InputData);
      data.SolveLoops(7);
      data.SolveEncryptionKey();

      return $"{data.EncryptionKey}";
    }

    public override string SolveTask2(string InputData)
    {
      return "OK";
    }
  }
}
