using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2020_22
{
  public class Program : BaseAdventSolver, IAdventSolver
  {

    public override string SolverName => "Day 22: Crab Combat"/*TODO: Task Name*/;

    public override string InputsFolderName => "SolverAOC2020_22";

    public override string SolveTask1(string InputData)
    {

      Game game = new Game(InputData);

      game.Solve();

      int res = game.GetWinningPlayerScore();

      return $"{res}";

    }

    public override string SolveTask2(string InputData)
    {
      Game game = new Game(InputData);

      game.Solve2();

      int res = game.GetWinningPlayerScore();

      return $"{res}";
    }
  }
}
