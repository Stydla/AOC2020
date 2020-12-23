using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2020_23
{
  public class CupChain
  {
    public Cup StartCup { get; set; }
    public Cup EndCup { get; set; }


    public bool Contains(int num)
    {
      Cup tmp = StartCup;
      while(tmp != EndCup)
      {
        if(tmp.Number == num)
        {
          return true;
        }
        tmp = tmp.Next;
      }
      return EndCup.Number == num;
    }
  }
}
