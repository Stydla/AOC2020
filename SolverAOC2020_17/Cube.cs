using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2020_17
{
  public class Cube
  {

    public HashSet<Point4d> Active { get; set; } = new HashSet<Point4d>();

    private Cube() { }

    public Cube(string input)
    {
      using (StringReader sr = new StringReader(input))
      {
        string line;
        int z = 0;
        int y = 0;
        while((line = sr.ReadLine()) != null)
        {
          for(int x = 0; x < line.Length; x++)
          {
            char c = line[x];
            if(c == '.')
            {
            }
            if(c== '#')
            {
              Point4d p = new Point4d(x, y, z, 0);
              Active.Add(p);
            }
          }
          y++;
        }
      }
    }

    

    public Cube Next()
    {
      Cube ret = new Cube();

      HashSet<Point4d> forSearch = new HashSet<Point4d>();


      foreach(Point4d p in Active)
      {
        var neighbours = GetNeighbours(p);
        foreach(Point4d n in neighbours)
        {
          if(!forSearch.Contains(n))
          {
            forSearch.Add(n);
          }
        }
      }

      foreach(Point4d p in forSearch)
      {
        var neighbours = GetNeighbours(p);
        int cnt = 0;
        foreach (Point4d n in neighbours)
        {
          if (Active.Contains(n))
          {
            cnt++;
          }
        }
        if(Active.Contains(p))
        {
          //Was active
          if (cnt == 2 || cnt == 3)
          {
            ret.Active.Add(p);
          }
        } else
        {
          //Was inactive
          if(cnt == 3)
          {
            ret.Active.Add(p);
          }
        }
      }

      return ret;
    }

    public Cube Next4d()
    {
      Cube ret = new Cube();

      HashSet<Point4d> forSearch = new HashSet<Point4d>();


      foreach (Point4d p in Active)
      {
        var neighbours = GetNeighbours4d(p);
        foreach (Point4d n in neighbours)
        {
          if (!forSearch.Contains(n))
          {
            forSearch.Add(n);
          }
        }
      }

      foreach (Point4d p in forSearch)
      {
        var neighbours = GetNeighbours4d(p);
        int cnt = 0;
        foreach (Point4d n in neighbours)
        {
          if (Active.Contains(n))
          {
            cnt++;
          }
        }
        if (Active.Contains(p))
        {
          //Was active
          if (cnt == 2 || cnt == 3)
          {
            ret.Active.Add(p);
          }
        }
        else
        {
          //Was inactive
          if (cnt == 3)
          {
            ret.Active.Add(p);
          }
        }
      }

      return ret;
    }

    private List<Point4d> GetNeighbours(Point p)
    {
      List<Point4d> ret = new List<Point4d>();
      for(int z = -1; z < 2; z++)
      {
        for (int y = -1; y < 2; y++)
        {
          for (int x = -1; x < 2; x++)
          {
            if(z != 0 || y != 0 || x != 0)
            {
              ret.Add(new Point4d(p.X + x, p.Y + y, p.Z + z, 0));
            }
          }
        }
      }
      return ret;
    }

    private List<Point> GetNeighbours4d(Point4d p)
    {
      List<Point> ret = new List<Point>();
      for (int z = -1; z < 2; z++)
      {
        for (int y = -1; y < 2; y++)
        {
          for (int x = -1; x < 2; x++)
          {
            for(int w = -1; w < 2; w++)
            {
              if (z != 0 || y != 0 || x != 0 || w != 0)
              {
                ret.Add(new Point4d(p.X + x, p.Y + y, p.Z + z, p.W + w));
              }
            }
            
          }
        }
      }
      return ret;
    }



  }
}
