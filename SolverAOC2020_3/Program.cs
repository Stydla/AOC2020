using Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2020_3
{
  public class Program : BaseAdventSolver, IAdventSolver
  {

    public override string SolverName => "Day 3: Toboggan Trajectory"/*TODO: Task Name*/;

    public override string InputsFolderName => "SolverAOC2020_3";

    public override string SolveTask1(string InputData)
    {

      long res = Solve(InputData, 3, 1);
      return $"{res}";
    }

    public override string SolveTask2(string InputData)
    {
      long res = Solve(InputData, 1, 1);
      res *= Solve(InputData, 3, 1);
      res *= Solve(InputData, 5, 1);
      res *= Solve(InputData, 7, 1);
      res *= Solve(InputData, 1, 2);
      return $"{res}";
    }

    private long Solve(string input, int right, int down)
    {
      var lines = LoadData(input);

      int pos = 0;
      int treeCount = 0;
      for (int i = 0; i < lines.Count; i += down)
      {
        if (lines[i][pos] == '#')
        {
          treeCount++;
        }

        pos = (pos + right) % lines[i].Length;

      }

      return treeCount;
    } 

    private List<string> LoadData(string input)
    {
      List<string> res = new List<string>();

      using(StringReader sr = new StringReader(input))
      {
        string line;
        while((line = sr.ReadLine()) != null)
        {
          res.Add(line);
        }
      }
      return res;

    }
  }
}
