using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2020_16
{
  public class Program : BaseAdventSolver, IAdventSolver
  {

    public override string SolverName => "Day 16: Ticket Translation"/*TODO: Task Name*/;

    public override string InputsFolderName => "SolverAOC2020_16";

    public override string SolveTask1(string InputData)
    {

      Data d = new Data(InputData);

      d.MarkInvalidFields();

      int res = d.Solve1();

      return $"{res}";
    }

    public override string SolveTask2(string InputData)
    {
      Data d = new Data(InputData);

      d.MarkInvalidFields();
      d.DiscardInvalidTickets();
      d.AssignRulesIndex();

      long res = d.Solve2();

      return $"{res}";
    }

  }
}
