using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2020_17
{
  public class Point4d : Point
  {

    public int W { get; set; }

    public Point4d(int x, int y, int z, int w) : base(x, y, z)
    {
      W = w;
    }

    public override int GetHashCode()
    {
      return base.GetHashCode() + W * 256;
    }

    public override bool Equals(object obj)
    {
      if (obj is Point4d p)
      {
        return base.Equals(obj) && W == p.W;
      }
      return false;
    }
  }
}
