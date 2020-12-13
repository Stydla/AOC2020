using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2020_13
{
  public class Input
  {
    public int Estimate { get; }

    public List<int> BusList { get; } = new List<int>();

    public Input(string input)
    {
      using(StringReader sr = new StringReader(input))
      {

        string line = sr.ReadLine();
        Estimate = int.Parse(line);

        line = sr.ReadLine();
        string [] it = line.Split(',');
        foreach(string i in it)
        {
          int tmp;
          if(int.TryParse(i, out tmp))
          {
            BusList.Add(tmp);
          }
        }
      }

    }

  }
}
