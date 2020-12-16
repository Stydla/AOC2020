using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2020_16
{
  public class Ticket
  {
    public List<int> Fields = new List<int>();
    public List<int> InvalidFields = new List<int>();

    public Ticket(string input)
    {
      string[] vals = input.Split(',');
      Fields = new List<int>(vals.Select(int.Parse));
    }

    public bool IsInvalid()
    {
      return InvalidFields.Count > 0;
    }

    internal int SumInvalid()
    {
      int sum = 0;
      foreach(int invalidField in InvalidFields)
      {
        sum += Fields[invalidField];
      }
      return sum;
    }
  }
}
