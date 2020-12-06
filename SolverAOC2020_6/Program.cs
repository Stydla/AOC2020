using Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2020_6
{
  public class Program : BaseAdventSolver, IAdventSolver
  {

    public override string SolverName => "Day 6: Custom Customs"/*TODO: Task Name*/;

    public override string InputsFolderName => "SolverAOC2020_6";

    public override string SolveTask1(string InputData)
    {
      var groups = LoadGroups(InputData);

      int res = 0;
      foreach(var g in groups)
      {
        res += g.GetYesAnswerCount();
      }

      return $"{res}";
    }

    public override string SolveTask2(string InputData)
    {
      var groups = LoadGroups(InputData);

      int res = 0;
      foreach (var g in groups)
      {
        res += g.GetYesAnswerEveryoneCount();
      }

      return $"{res}";
    }

    private List<Group> LoadGroups(string InputData)
    {
      List<Group> groups = new List<Group>();
      using (StringReader sr = new StringReader(InputData))
      {
        string line;
        Group tmp = null;
        while ((line = sr.ReadLine()) != null)
        {
          if(tmp == null)
          {
            tmp = new Group();
            groups.Add(tmp);
          }
          if (line.Length == 0)
          {
            tmp = new Group();
            groups.Add(tmp);
            continue;
          }
          tmp.Answers.Add(line);
        }
        return groups;
      }
    }
  }
}
