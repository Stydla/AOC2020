using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2020_13
{
  /// <summary>
  /// x = a * y + b
  /// </summary>
  class LinEquation
  {

    public BigInteger a;
    public BigInteger b;

    public BigInteger Solve(int y)
    {
      return a * y + b;
    }

    public LinEquation Solve(LinEquation y)
    {
      LinEquation le = new LinEquation();
      le.a = a * y.a;
      le.b = b + a*(y.b);
      return le;
    }

  }
}
