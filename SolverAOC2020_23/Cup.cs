using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2020_23
{
  public class Cup
  {
    public int Number { get; set; }

    public Cup Next { get; set; }
    public Cup Prev { get; set; }

    public Cup(int number)
    {
      Number = number;
    }

    public CupChain RemoveNext(int count)
    {
      CupChain cc = new CupChain();
      cc.StartCup = this.Next;
      cc.EndCup = this.Next;
      for(int i = 0; i < count - 1; i++)
      {
        cc.EndCup = cc.EndCup.Next;
      }

      this.Next = cc.EndCup.Next;
      cc.EndCup.Next.Prev = this;
      cc.EndCup.Next = null;
      cc.StartCup.Prev = null;

      return cc;
    }

    internal void InsertChain(CupChain cc)
    {
      Cup nextTmp = Next;
      Next = cc.StartCup;
      cc.StartCup.Prev = this;
      nextTmp.Prev = cc.EndCup;
      cc.EndCup.Next = nextTmp;

    }
  }
}
