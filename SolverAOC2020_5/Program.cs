using Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2020_5
{
  public class Program : BaseAdventSolver, IAdventSolver
  {

    public override string SolverName => "Day 5: Binary Boarding"/*TODO: Task Name*/;

    public override string InputsFolderName => "SolverAOC2020_5";

    public override string SolveTask1(string InputData)
    {
      var lines = ReadInput(InputData);
      var ids = lines.Select(x => GetId(x)).ToList();
      int max = ids.Max();

      return $"{max}";
    }

    public override string SolveTask2(string InputData)
    {

      var lines = ReadInput(InputData);
      var ids = lines.Select(x => GetId(x)).ToList();

      for(int current = 0; current < 128*8; current++)
      {
        if(ids.Contains(current - 1) &&
          ids.Contains(current + 1) &&
          !ids.Contains(current))
        {
          return $"{current}";
        }
       
      }
      return "Not found";
      
    }

    private int GetId(string data)
    {
      string rowBin = data.Substring(0, 7);
      string colBin = data.Substring(7, 3);

      rowBin = rowBin.Replace("F", "0").Replace("B", "1");
      colBin = colBin.Replace("L", "0").Replace("R", "1");

      int row = Convert.ToInt32(rowBin, 2);
      int col = Convert.ToInt32(colBin, 2);

      return row * 8 + col;
    }

    private List<string> ReadInput(string input)
    {
      List<string> ret = new List<string>();
      using(StringReader sr = new StringReader(input))
      {
        string line;
        while((line = sr.ReadLine()) != null)
        {
          ret.Add(line);
        }
      }
      return ret;
    }
  }
}
