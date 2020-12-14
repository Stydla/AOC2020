using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2020_14
{
  class Memory
  {

    private string Mask;
    private Dictionary<BigInteger, BigInteger> Mem = new Dictionary<BigInteger, BigInteger>();

    public void ProcessMask(string mask)
    {
      Mask = mask;
    }

    public void ProcessValue(BigInteger index, BigInteger value)
    {
      BigInteger tmpVal = 0;
      StringBuilder sb = new StringBuilder();
      for(int i = 0; i < Mask.Length; i++)
      {
        sb.Append('0');
      }
      string binVal = value.ToBinaryString();
      for (int i = 0; i < binVal.Length; i++)
      {
        int sbIndex = sb.Length - 1 - i;
        sb[sbIndex] = binVal[binVal.Length -1 - i];
      }

      
      for(int i = Mask.Length -1; i >=0 ; i--)
      {
        char c = Mask[i];

        switch(c)
        {
          case 'X':
            continue;            
          case '0':
            {
              sb[i] = '0';
              break;
            }
          case '1':
            {
              sb[i] = '1';
              break;
            }
          default:
            throw new Exception($"Invalid mask char {c}, index: {i}");
        }
      }
      if(Mem.ContainsKey(index))
      {
        Mem.Remove(index);
      }

      BigInteger memValue = BinToDec(sb.ToString());
      Mem.Add(index, memValue);
      
    }

    public BigInteger SumValues()
    {
      BigInteger sum = 0;
      foreach(var bi in Mem)
      {
        sum += bi.Value;
      }
      return sum;
    }

    public BigInteger BinToDec(string value)
    {
      BigInteger res = 0;

      foreach (char c in value)
      {
        res <<= 1;
        res += c == '1' ? 1 : 0;
      }

      return res;
    }

  }
}
