using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SolverAOC2020_20
{
  public class Tile
  {

    public long Id { get; set; }
    public int Rotation { get; set; } = 0;
    public bool FlipLR { get; set; } = false;
    public bool FlipTD { get; set; } = false;
    public Tile ParentTile { get; set; }

    public Point Point { get; set; }

    public List<List<char>> Fields { get; set; } = new List<List<char>>();

    public Tile(string input)
    {
      Rotation = 0;
      using (StringReader sr = new StringReader(input))
      {
        string line = sr.ReadLine();
        Match m = Regex.Match(line, @"Tile (\d*):");
        Id = int.Parse(m.Groups[1].Value);
        while ((line = sr.ReadLine()) != null)
        {
          Fields.Add(new List<char>());
          for (int j = 0; j < line.Length; j++)
          {
            Fields[Fields.Count - 1].Add(line[j]);
          }
        }
      }
    }

    private Tile() { }

    public Tile FlipLeftRight()
    {
      Tile ret = new Tile();
      ret.Id = this.Id;
      ret.Rotation = this.Rotation;
      ret.FlipLR = true;
      ret.ParentTile = this;

      int size = Fields.Count;
      for (int i = 0; i < size; i++)
      {
        ret.Fields.Add(new List<char>());
        for (int j = 0; j < size; j++)
        {
          ret.Fields[i].Add('?');
        }
      }

      for (int i = 0; i < size; i++)
      {
        for (int j = 0; j < size; j++)
        {
          int iNew = i;
          int jNew = size - 1 - j;
          ret.Fields[iNew][jNew] = Fields[i][j];
        }
      }

      return ret;
    }

    public Tile FlipTopDown()
    {
      Tile ret = new Tile();
      ret.Id = this.Id;
      ret.Rotation = this.Rotation;
      ret.FlipTD = true;
      ret.ParentTile = this;

      int size = Fields.Count;
      for (int i = 0; i < size; i++)
      {
        ret.Fields.Add(new List<char>());
        for (int j = 0; j < size; j++)
        {
          ret.Fields[i].Add('?');
        }
      }

      for (int i = 0; i < size; i++)
      {
        for (int j = 0; j < size; j++)
        {
          int iNew = size - 1 - i;
          int jNew = j;
          ret.Fields[iNew][jNew] = Fields[i][j];
        }
      }
      return ret;
    }

    public Tile RotateRight()
    {
      Tile ret = new Tile();
      ret.Id = this.Id;
      ret.Rotation = (this.Rotation + 1) % 4;
      ret.ParentTile = this;

      int size = Fields.Count;
      for (int i = 0; i < size; i++)
      {
        ret.Fields.Add(new List<char>());
        for (int j = 0; j < size; j++)
        {
          ret.Fields[i].Add('?');
        }
      }

      for (int i = 0; i < size; i++)
      {
        for (int j = 0; j < size; j++)
        {
          int iNew = j;
          int jNew = size - 1 - i;
          ret.Fields[iNew][jNew] = Fields[i][j];
        }
      }

      return ret;
    }

    internal bool MatchTop(Tile tile)
    {
      for (int i = 0; i < Fields.Count; i++)
      {
        if (Fields[0][i] != tile.Fields[Fields.Count - 1][i])
        {
          return false;
        }
      }
      return true;
    }

    public string Print()
    {
      StringBuilder sb = new StringBuilder();
      for (int i = 0; i < Fields.Count; i++)
      {
        sb.AppendLine(PrintLine(i));
      }
      return sb.ToString();
    }

    internal bool MatchBottom(Tile tile)
    {
      for (int i = 0; i < Fields.Count; i++)
      {
        if (Fields[Fields.Count - 1][i] != tile.Fields[0][i])
        {
          return false;
        }
      }
      return true;
    }

    internal bool MatchRight(Tile tile)
    {
      for (int i = 0; i < Fields.Count; i++)
      {
        if (Fields[i][Fields.Count - 1] != tile.Fields[i][0])
        {
          return false;
        }
      }
      return true;
    }

    public string PrintLine(int line)
    {
      StringBuilder sb = new StringBuilder();
      for (int i = 0; i < Fields[line].Count; i++)
      {
        sb.Append(Fields[line][i]);
      }
      return sb.ToString();
    }

    internal bool MatchLeft(Tile tile)
    {
      for (int i = 0; i < Fields.Count; i++)
      {
        if (Fields[i][0] != tile.Fields[i][Fields.Count - 1])
        {
          return false;
        }
      }
      return true;
    }

    public void ReplaceMonster(List<List<char>> monster)
    {
      for(int i = 0; i < Fields.Count; i++)
      {
        for(int j = 0; j < Fields[i].Count; j++)
        {

          bool found = true;
          for(int k = 0; k < monster.Count; k++)
          {
            for(int l = 0; l < monster[k].Count; l++)
            {
              if(k + i == Fields.Count || j + l ==Fields[i].Count)
              {
                found = false;
                break;
              }
              if(monster[k][l] == '#')
              {
                if(Fields[i + k][j + l] != '#')
                {
                  found = false;
                  break;
                }
              }
              if (found == false) break;
            }
          }
          if (found)
          {
            for (int k = 0; k < monster.Count; k++)
            {
              for (int l = 0; l < monster[k].Count; l++)
              {
                if (monster[k][l] == '#')
                {
                  Fields[i + k][j + l] = 'O';
                }
              }
            }
          }

        }
      }
    }
  }
}
