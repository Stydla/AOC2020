using Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2020_2
{
  public class Program : BaseAdventSolver, IAdventSolver
  {

    public override string SolverName => "Day 2: Password Philosophy"/*TODO: Task Name*/;

    public override string InputsFolderName => "SolverAOC2020_2";

    public override string SolveTask1(string InputData)
    {

      var data = Load(InputData);
      var valid = data.Where(x => x.IsValid1());

      return $"{valid.Count()}";
    }

    public override string SolveTask2(string InputData)
    {
      var data = Load(InputData);
      var valid = data.Where(x => x.IsValid2());

      return $"{valid.Count()}";
    }

    private List<Password> Load(string Input)
    {
      List<Password> ret = new List<Password>();
      using (StringReader sr = new StringReader(Input))
      {
        string line;
        while ((line = sr.ReadLine()) != null)
        {
          var psw = new Password(line);
          ret.Add(psw);
        }
      }
      return ret;
    }
  }
}
