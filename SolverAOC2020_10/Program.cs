using Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2020_10
{
  public class Program : BaseAdventSolver, IAdventSolver
  {

    public override string SolverName => "Day 10: Adapter Array"/*TODO: Task Name*/;

    public override string InputsFolderName => "SolverAOC2020_10";

    public override string SolveTask1(string InputData)
    {

      List<int> data = ReadData(InputData);

      data.Add(0);
      data.Sort();
      data.Add(data.Max() + 3);

      long diff1cnt = 0;
      long diff3cnt = 0;
      for(int i = 0; i < data.Count - 1; i++) 
      {
        int diff = data[i + 1] - data[i];
        if (diff == 1)
        {
          diff1cnt++;
        } else if(diff == 3)
        {
          diff3cnt++;
        }
      }
      long res = diff1cnt * diff3cnt;
      return $"{res}";
    }

    public override string SolveTask2(string InputData)
    {
      List<int> data = ReadData(InputData);
      
      data.Add(0);
      data.Sort();
      data.Add(data.Max() + 3);

      List<long> wayCnts = new List<long>(data.Count);
      for (int i = 0; i < data.Count; i++)
      {
        wayCnts.Add(0);
      }

      wayCnts[data.Count-1] = 1;

      for(int i = data.Count - 2; i >= 0; i--)
      {
        int tmp = data[i];

        for(int j = i + 1; j < i + 4; j++)
        {
          if (j >= data.Count) break;

          int diff = data[j] - data[i];

          if(diff <= 3)
          {
            wayCnts[i] += wayCnts[j];
          }
          
        }
      }



      return $"{wayCnts[0]}";
    }

    private List<int> ReadData(string input)
    {
      List<int> ret = new List<int>();
      using (StringReader sr = new StringReader(input))
      {
        string line;
        while((line = sr.ReadLine()) != null)
        {
          int tmp = int.Parse(line);
          ret.Add(tmp);
        }
      }
      return ret;
    }
  }
}
