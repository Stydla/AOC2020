using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2020_16
{
  public class Range
  {
    public int From { get; set; }
    public int To { get; set; }

    internal bool InRange(int number)
    {
      return From <= number && To >= number;
    }
  }
}

