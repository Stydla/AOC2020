using Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2020_15
{
  public class Program : BaseAdventSolver, IAdventSolver
  {

    public override string SolverName => "Day 15: Rambunctious Recitation"/*TODO: Task Name*/;

    public override string InputsFolderName => "SolverAOC2020_15";

    public override string SolveTask1(string InputData)
    {
      int numberCount = 2020;

      List<int> data = LoadData(InputData);
      List<SpokenData> spokenData = new List<SpokenData>();

      for(int i = 0; i < data.Count; i++)
      {
        var tmp = new SpokenData();
        tmp.value = data[i];
        tmp.turn = i;
        spokenData.Add(tmp);
      }

      for(int i = data.Count; i < numberCount; i++)
      {
        SpokenData prev = spokenData[i - 1];

        var sdList = spokenData.Where(x => x.value == prev.value).ToList();
        if(sdList.Count() > 1)
        {
          sdList.OrderBy(x => x.turn);
          var sd = new SpokenData();
          sd.turn = i;
          sd.value = prev.turn - sdList[sdList.Count() - 2].turn;
          spokenData.Add(sd);
        } else
        {
          var tmp = new SpokenData();
          tmp.value = 0;
          tmp.turn = i;
          spokenData.Add(tmp);
        }

      }

      return $"{spokenData[numberCount-1].value}";

    }

    private class SpokenData
    {
      public int turn;
      public int value;
    }

    private class SpokenData2
    {
      public int last = -1;
      public int lastlast = -1;
      public int value;
    }



    private List<int> LoadData(string inputData)
    {
      List<int> ret = new List<int>();
      using(StringReader sr = new StringReader(inputData))
      {
        string line = sr.ReadLine();
        foreach(var it in line.Split(','))
        {
          int tmp = int.Parse(it);
          ret.Add(tmp);
        }
      }
      return ret;
    }

    public override string SolveTask2(string InputData)
    {

      int numberCount = 30000000;

      List<int> data = LoadData(InputData);
      Dictionary<int,SpokenData2> spokenData = new Dictionary<int, SpokenData2>();

      for (int i = 0; i < data.Count; i++)
      {
        var tmp = new SpokenData2();
        tmp.value = data[i];
        tmp.last = i;
        spokenData.Add(tmp.value, tmp);
      }

      int prevVal = spokenData[data[data.Count - 1]].value;
      for (int i = data.Count; i < numberCount; i++)
      {
        if(spokenData.ContainsKey(prevVal))
        {
          SpokenData2 sd = spokenData[prevVal];
          if(sd.lastlast == -1)
          {
            int val2 = 0;
            if (spokenData.ContainsKey(val2))
            {
              spokenData[val2].lastlast = spokenData[val2].last;
              spokenData[val2].last = i;
              prevVal = spokenData[val2].value;
            }
            else
            {
              SpokenData2 tmp = new SpokenData2();
              tmp.last = i;
              tmp.value = val2;
              spokenData.Add(tmp.value, tmp);
              prevVal = val2;
            }
          } else
          {
            int val2 = sd.last - sd.lastlast;
            if(spokenData.ContainsKey(val2))
            {
              spokenData[val2].lastlast = spokenData[val2].last;
              spokenData[val2].last = i;
              prevVal = spokenData[val2].value;
            } else
            {
              SpokenData2 tmp = new SpokenData2();
              tmp.last = i;
              tmp.value = val2;
              spokenData.Add(tmp.value, tmp);
              prevVal = tmp.value;
            }
            
          }
          
        } else
        {
          var tmp = new SpokenData2();
          tmp.value = data[i];
          tmp.last = i;
          tmp.lastlast = -1;
          spokenData.Add(i,tmp);
        }
       

      }

      return $"{prevVal}";
    }
  }
}
