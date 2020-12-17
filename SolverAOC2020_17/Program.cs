using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2020_17
{
  public class Program : BaseAdventSolver, IAdventSolver
  {

    public override string SolverName => "Day 17: Conway Cubes"/*TODO: Task Name*/;

    public override string InputsFolderName => "SolverAOC2020_17";

    public override string SolveTask1(string InputData)
    {
      Cube c = new Cube(InputData);
      for(int i = 0; i < 6; i++)
      {
        c = c.Next();
      }

      int active = c.Active.Count;
      return $"{active}";
    }

    public override string SolveTask2(string InputData)
    {
      Cube c = new Cube(InputData);
      for (int i = 0; i < 6; i++)
      {
        c = c.Next4d();
      }

      int active = c.Active.Count;
      return $"{active}";
    }
  }
}
