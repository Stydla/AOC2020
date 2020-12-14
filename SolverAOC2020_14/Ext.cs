﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2020_14
{
  static class Ext
  {

    public static string ToBinaryString(this BigInteger bigint)
    {
      var bytes = bigint.ToByteArray();
      var idx = bytes.Length - 1;

      // Create a StringBuilder having appropriate capacity.
      var base2 = new StringBuilder(bytes.Length * 8);

      // Convert first byte to binary.
      var binary = Convert.ToString(bytes[idx], 2);

      // Ensure leading zero exists if value is positive.
      if (binary[0] != '0' && bigint.Sign == 1)
      {
        base2.Append('0');
      }

      // Append binary string to StringBuilder.
      base2.Append(binary);

      // Convert remaining bytes adding leading zeros.
      for (idx--; idx >= 0; idx--)
      {
        base2.Append(Convert.ToString(bytes[idx], 2).PadLeft(8, '0'));
      }

      return base2.ToString();
    }
  }
}
