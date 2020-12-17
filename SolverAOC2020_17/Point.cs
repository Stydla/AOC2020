using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2020_17
{
  public class Point
  {

    public Point(int x, int y , int z)
    {
      X = x;
      Y = y;
      Z = z;
    }
    public int X { get; set; }
    public int Y { get; set; }
    public int Z { get; set; }

    public override int GetHashCode()
    {
      return X.GetHashCode()* 256*256 + Y.GetHashCode() * 256 + Z ;
    }

    public override bool Equals(object obj)
    {
      if(obj is Point p)
      {
        return p.X == X && p.Y == Y && p.Z == Z;
      }
      return false;
    }
  }

  
}
