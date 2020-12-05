using Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2020_4
{
  public class Program : BaseAdventSolver, IAdventSolver
  {

    public override string SolverName => "Day 4: Passport Processing"/*TODO: Task Name*/;

    public override string InputsFolderName => "SolverAOC2020_4";

    public override string SolveTask1(string InputData)
    {

      var passports = LoadPassports(InputData);

      var validPassports = passports.Where(x => x.IsValidFields());

      return $"{validPassports.Count()}";

    }

    public override string SolveTask2(string InputData)
    {
      var passports = LoadPassports(InputData);

      var validPassports = passports.Where(x => x.IsValidValues());

      return $"{validPassports.Count()}";
    }


    private List<Passport> LoadPassports(string InputData)
    {
      List<Passport> ret = new List<Passport>();

      using (StringReader ss = new StringReader(InputData))
      {

        Passport currentPassport = null;
        
        string line;
        while ((line = ss.ReadLine()) != null)
        {
          if (line.Length == 0)
          {
            // next passport
            currentPassport = new Passport();
            ret.Add(currentPassport);
            continue;
          }
          if(currentPassport == null)
          {
            currentPassport = new Passport();
            ret.Add(currentPassport);
          }

          string [] items = line.Split(' ');

          foreach(var it in items)
          {
            currentPassport.AddField(it);
          }
        }
      }

      return ret;
    }

  }
}
