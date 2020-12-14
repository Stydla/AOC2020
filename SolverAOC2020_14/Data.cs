using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2020_14
{
  class Data
  {

    private List<string> Lines = new List<string>();
    private int current;

    public Data(string input)
    {
      using (StringReader sr = new StringReader(input))
      {
        string line;
        while((line = sr.ReadLine()) != null)
        {
          Lines.Add(line);
        }
      }
      current = 0;
    }

    public string Next()
    {
      if(current == Lines.Count)
      {
        return null;
      } else
      {
        string ret = Lines[current];
        current++;
        return ret;
      }
    }

    public bool IsEnd()
    {
      return current == Lines.Count;
    }



  }
}
