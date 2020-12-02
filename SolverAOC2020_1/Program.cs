using Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2020_1
{
  public class Program : BaseAdventSolver, IAdventSolver
  {

    public override string SolverName => "Day 1: Report Repair"/*TODO: Task Name*/;

    public override string InputsFolderName => "SolverAOC2020_1";

    public override string SolveTask1(string InputData)
    {

      List<int> data = LoadData(InputData);
      for (int i = 0; i < data.Count; i++)
      {
        for(int j = i+1; j < data.Count; j++)
        {
          int sum = data[i] + data[j];
          if(sum == 2020)
          {
            return $"{data[i] * data[j]}";
          }
        }
      }
      throw new Exception("Result not found");

    }

    public override string SolveTask2(string InputData)
    {
      List<int> data = LoadData(InputData);
      for (int i = 0; i < data.Count; i++)
      {
        for (int j = i+1; j < data.Count; j++)
        {
          for(int k = j+1; k < data.Count;k++)
          {
            int sum = data[i] + data[j] + data[k];
            if (sum == 2020)
            {
              return $"{data[i] * data[j] * data[k]}";
            }
          }
          
        }
      }
      throw new Exception("Result not found");
    }

    private List<int> LoadData(string InputData)
    {
      List<int> data = new List<int>();
      using (StringReader sr = new StringReader(InputData))
      {
        string line;
        while ((line = sr.ReadLine()) != null)
        {
          data.Add(int.Parse(line)); 
        }
      }
      return data;
    }


  }
}
