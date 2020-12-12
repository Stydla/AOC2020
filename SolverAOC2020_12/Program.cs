using Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2020_12
{
  public class Program : BaseAdventSolver, IAdventSolver
  {

    public override string SolverName => "SolverAOC2020_12"/*TODO: Task Name*/;

    public override string InputsFolderName => "SolverAOC2020_12";

    public override string SolveTask1(string InputData)
    {

      Ship s = new Ship();

      List<MoveCommand> moveCommands = ReadInput(InputData);
      
      foreach(var mc in moveCommands)
      {
        s.Move(mc);
      }

      return $"{s.ManhattanDistance}";

    }

    

    public override string SolveTask2(string InputData)
    {
      Ship s = new Ship(new Point() { X = 10, Y = -1 });

      List<MoveCommand> moveCommands = ReadInput(InputData);

      foreach (var mc in moveCommands)
      {
        s.Move2(mc);
      }

      return $"{s.ManhattanDistance}";

    }

    private List<MoveCommand> ReadInput(string inputData)
    {
      List<MoveCommand> ret = new List<MoveCommand>();
      using (StringReader sr = new StringReader(inputData))
      {
        string line;
        while((line = sr.ReadLine()) != null)
        {
          var mc = new MoveCommand(line);
          ret.Add(mc);
        }
      }
      return ret;
    }
  }
}
