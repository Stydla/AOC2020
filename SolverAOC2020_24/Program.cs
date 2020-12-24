using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2020_24
{
  public class Program : BaseAdventSolver, IAdventSolver
  {

    public override string SolverName => "Day 24: Lobby Layout"/*TODO: Task Name*/;

    public override string InputsFolderName => "SolverAOC2020_24";

    public override string SolveTask1(string InputData)
    {
 
      Data data = new Data(InputData);
      
      int res = data.GetBlackTilesCount();
      return $"{res}";
      
    }

    public override string SolveTask2(string InputData)
    {
      Data data = new Data(InputData);

      data.SimulateDay(100);

      int res = data.GetBlackTilesCount();
      return $"{res}";
    }
  }
}
