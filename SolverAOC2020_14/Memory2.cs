using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2020_14
{
  class Memory2
  {
    private string Mask;
    private Dictionary<BigInteger, BigInteger> Mem = new Dictionary<BigInteger, BigInteger>();

    public void ProcessMask(string mask)
    {
      Mask = mask;
    }

    public void ProcessValue(BigInteger index, BigInteger value)
    {
      
      foreach (var i in GetIndexes(index))
      {
        if (Mem.ContainsKey(i))
        {
          Mem.Remove(i);
        }
        
        Mem.Add(i, value);
      }

    }

    private List<BigInteger> GetIndexes(BigInteger index)
    {
      BigInteger tmpVal = 0;
      StringBuilder sb = new StringBuilder();
      for (int i = 0; i < Mask.Length; i++)
      {
        sb.Append('0');
      }
      string binVal = index.ToBinaryString();
      for (int i = 0; i < binVal.Length; i++)
      {
        int sbIndex = sb.Length - 1 - i;
        sb[sbIndex] = binVal[binVal.Length - 1 - i];
      }


      for (int i = Mask.Length - 1; i >= 0; i--)
      {
        char c = Mask[i];

        switch (c)
        {
          case 'X':
            sb[i] = 'X';
            continue;
          case '0':
            {
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
      
      return BinToDec2(sb.ToString());

    }



    public BigInteger SumValues()
    {
      BigInteger sum = 0;
      foreach (var bi in Mem)
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

    public List<BigInteger> BinToDec2(string value)
    {
      List<string> ret = new List<string>();
      ret.Add(value);

      while(ret.Any(x=>x.Contains('X')))
      {
        List<string> tmp = new List<string>();
        foreach (string s in ret)
        {
          var removedX = RemoveOneX(s);
          tmp.AddRange(removedX);
        }
        ret = tmp;
      }

      List<BigInteger> biRet = new List<BigInteger>();
      foreach(string s in ret)
      {
        BigInteger v = BinToDec(s);
        biRet.Add(v);
      }

      return biRet;
    }

    private List<string> RemoveOneX(string val)
    {
      List<string> ret = new List<string>();

      if(!val.Contains('X'))
      {
        ret.Add(val);
        return ret;
      } else
      {
        int index = val.IndexOf('X');
        StringBuilder sb = new StringBuilder(val);
        sb[index] = '1';
        ret.Add(sb.ToString());
        sb[index] = '0';
        ret.Add(sb.ToString());
        return ret;
      }
    }

  }
}
