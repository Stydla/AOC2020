using Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2020_11
{
  public class Program : BaseAdventSolver, IAdventSolver
  {

    public override string SolverName => "Day 11: Seating System"/*TODO: Task Name*/;

    public override string InputsFolderName => "SolverAOC2020_11";

    public override string SolveTask1(string InputData)
    {

      var data = LoadData(InputData);

      bool changed = true;

      while(changed)
      {
        data = NextRound(data, ref changed);
      }

      int cnt = 0;
      foreach(var d in data)
      {
        int tmp = d.ToString().Count(x => x == '#');
        cnt += tmp;
      }
     
      return $"{cnt}";
    }

    public override string SolveTask2(string InputData)
    {
      var data = LoadData(InputData);

      bool changed = true;

      while (changed)
      {
        data = NextRound2(data, ref changed);
        foreach (var d in data)
        {
          Console.WriteLine(d);
        }
        Console.WriteLine();
      }

      int cnt = 0;
      foreach (var d in data)
      {
        int tmp = d.ToString().Count(x => x == '#');
        cnt += tmp;
      }

      return $"{cnt}";
    }

    private List<StringBuilder> LoadData(string input)
    {
      List<StringBuilder> ret = new List<StringBuilder>();
      using(StringReader sr = new StringReader(input))
      {
        string line;
        while((line = sr.ReadLine()) != null)
        {
          ret.Add(new StringBuilder(line));
        }
      }
      return ret;
    }

    private List<StringBuilder> NextRound(List<StringBuilder> input, ref bool changed)
    {
      changed = false;
      List<StringBuilder> ret = new List<StringBuilder>();
      for (int i = 0; i < input.Count; i++)
      {
        ret.Add(new StringBuilder());

        for(int j = 0; j < input[i].Length; j++)
        {
          if(input[i][j] == '.')
          {
            ret[i].Append('.');
            continue;
          }

          int occupiedAdjacent = 0;
          int freeAdjacent = 0;
          for (int a = i - 1; a <= i + 1; a++)
          {
            for (int b = j - 1; b <= j + 1; b++)
            {
              if (a == i && b == j) continue;
              if (a < 0 || b < 0) continue;
              if (a >= input.Count || b >= input[i].Length) continue;

              if (input[a][b] == '#')
              {
                occupiedAdjacent++;
              }
              if(input[a][b] == 'L')
              {
                freeAdjacent++;
              }
            }
          }

          if (input[i][j] == 'L')
          {
            if(occupiedAdjacent == 0)
            {
              ret[i].Append('#');
              changed = true;
            } else
            {
              ret[i].Append('L');
            }
          } else
          if(input[i][j] == '#')
          {
            if (occupiedAdjacent >= 4)
            {
              ret[i].Append('L');
              changed = true;
            }
            else
            {
              ret[i].Append('#');
            }
          }
        }
      }
      return ret;
    }

    private List<StringBuilder> NextRound2(List<StringBuilder> input, ref bool changed)
    {
      changed = false;
      List<StringBuilder> ret = new List<StringBuilder>();
      for (int i = 0; i < input.Count; i++)
      {
        ret.Add(new StringBuilder());

        for (int j = 0; j < input[i].Length; j++)
        {
          if (input[i][j] == '.')
          {
            ret[i].Append('.');
            continue;
          }

          int occupiedAdjacent = 0;
          int freeAdjacent = 0;

          int a;
          int b;
          // T
          a = i - 1;
          while(a >= 0 && input[a][j] == '.')
          {
            a--;
          } 
          if(a >= 0)
          {
            if (input[a][j] == '#')
            {
              occupiedAdjacent++;
            } else
            {
              freeAdjacent++;
            }
          }

          // D
          a = i + 1;
          while (a < input.Count && input[a][j] == '.')
          {
            a++;
          }
          if (a < input.Count)
          {
            if (input[a][j] == '#')
            {
              occupiedAdjacent++;
            }
            else
            {
              freeAdjacent++;
            }
          }

          // R
          b = j + 1;
          while (b < input[i].Length && input[i][b] == '.')
          {
            b++;
          }
          if (b < input[i].Length)
          {
            if (input[i][b] == '#')
            {
              occupiedAdjacent++;
            }
            else
            {
              freeAdjacent++;
            }
          }

          // L
          b = j - 1;
          while (b >= 0 && input[i][b] == '.')
          {
            b--;
          }
          if (b >= 0)
          {
            if (input[i][b] == '#')
            {
              occupiedAdjacent++;
            }
            else
            {
              freeAdjacent++;
            }
          }

          //TR
          a = i - 1;
          b = j + 1;
          while (a >= 0 && b < input[i].Length && input[a][b] == '.')
          {
            a--;
            b++;
          }
          if (a >= 0 && b < input[i].Length)
          {
            if (input[a][b] == '#')
            {
              occupiedAdjacent++;
            }
            else
            {
              freeAdjacent++;
            }
          }

          //DR
          a = i + 1;
          b = j + 1;
          while (a < input.Count && b < input[i].Length && input[a][b] == '.' )
          {
            a++;
            b++;
          }
          if (a < input.Count && b < input[i].Length)
          {
            if (input[a][b] == '#')
            {
              occupiedAdjacent++;
            }
            else
            {
              freeAdjacent++;
            }
          }

          //TL
          a = i - 1;
          b = j - 1;
          while (a >= 0 && b >= 0 && input[a][b] == '.')
          {
            a--;
            b--;
          }
          if (a >= 0 && b >= 0)
          {
            if (input[a][b] == '#')
            {
              occupiedAdjacent++;
            }
            else
            {
              freeAdjacent++;
            }
          }

          //DL
          a = i + 1;
          b = j - 1;
          while (a < input.Count && b >= 0 && input[a][b] == '.' )
          {
            a++;
            b--;
          }
          if (a < input.Count && b >= 0)
          {
            if (input[a][b] == '#')
            {
              occupiedAdjacent++;
            }
            else
            {
              freeAdjacent++;
            }
          }


          if (input[i][j] == 'L')
          {
            if (occupiedAdjacent == 0)
            {
              ret[i].Append('#');
              changed = true;
            }
            else
            {
              ret[i].Append('L');
            }
          }
          else
          if (input[i][j] == '#')
          {
            if (occupiedAdjacent >= 5)
            {
              ret[i].Append('L');
              changed = true;
            }
            else
            {
              ret[i].Append('#');
            }
          }
        }
      }
      return ret;
    }


  }
}
