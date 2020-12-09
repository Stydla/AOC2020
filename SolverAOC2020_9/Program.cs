using Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2020_9
{
  public class Program : BaseAdventSolver, IAdventSolver
  {

    public override string SolverName => "Day 9: Encoding Error"/*TODO: Task Name*/;

    public override string InputsFolderName => "SolverAOC2020_9";

    public override string SolveTask1(string InputData)
    {
      string firstline = InputData.Substring(0, InputData.IndexOf(Environment.NewLine));
      int preamble = int.Parse(firstline);

      var input = InputData.Substring(InputData.IndexOf('\n') + 1);
      List<long> data = LoadData(input);
     
      for(int i = 0; i < data.Count; i++)
      {
        if(!Test(data, i, preamble))
        {
          return $"{data[i]}";
        }
      }

      return "Not Found";
    }

    private bool Test(List<long> l, int index, int preamble)
    {
      if (index <= preamble) return true;
      for(int i = index - preamble; i < index; i++)
      {
        for(int j = i + 1; j < index; j++)
        {
          if(l[i] + l[j] == l[index])
          {
            return true;
          }
        }
      }
      return false;
    }

    public override string SolveTask2(string InputData)
    {
      string firstline = InputData.Substring(0, InputData.IndexOf(Environment.NewLine));
      int preamble = int.Parse(firstline);

      var input = InputData.Substring(InputData.IndexOf('\n') + 1);
      List<long> data = LoadData(input);

      long invalidNumber = int.Parse(SolveTask1(InputData));

      int lowIndex = 0;
      int highIndex = 0;
      long sum = 0;
      while(true)
      {
        if (highIndex >= data.Count || lowIndex >= data.Count) break;
        if(sum < invalidNumber)
        {
          sum += data[highIndex];
          highIndex++;
        } else if(sum > invalidNumber)
        {
          sum -= data[lowIndex];
          lowIndex++;
        } else
        {
          var tmp = data.Skip(lowIndex - 1).Take(highIndex - lowIndex);
          long res = tmp.Max() + tmp.Min();
          return $"{res}";
        }
        
      }

      return "Not Found";
    }

    private List<long> LoadData(string input)
    {
      List<long> res = new List<long>();
      using(StringReader sr = new StringReader(input))
      {
        string line;
        while((line = sr.ReadLine()) != null)
        {
          long val = long.Parse(line);
          res.Add(val);
        }
      }
      return res;
    }


  }
}
