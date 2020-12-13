using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;


namespace SolverAOC2020_13
{
  /// <summary>
  /// X === res % mod
  /// </summary>
  class ModEquation
  {
    public BigInteger res;
    public BigInteger mod;

    public LinEquation Solve(LinEquation eq)
    {
      BigInteger b = res - eq.b;

      if (b < 0) 
      {
        b = (b % mod) + mod;
      }

      BigInteger inverse = BigInteger.ModPow(eq.a, mod - 2, mod);
      BigInteger r = b* inverse;

      LinEquation newLE = new LinEquation();
      newLE.a = mod;
      newLE.b = r % mod;
      

      return newLE;
    }
  }
}
