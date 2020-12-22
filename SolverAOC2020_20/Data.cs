using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2020_20
{
  public class Data
  {
    public List<Tile> Tiles { get; set; } = new List<Tile>();

    public List<Tile> AllTiles { get; set; } = new List<Tile>();

    public List<List<Tile>> Grid { get; set; } = new List<List<Tile>>();

    public List<List<char>> Image { get; set; } = new List<List<char>>();

    public Tile ImageTile { get; set; }

    public List<List<char>> Monster = new List<List<char>>();

    public Data(string input)
    {
      using (StringReader sr = new StringReader(input))
      {
        StringBuilder sb = new StringBuilder();
        string line;
        while (true)
        {
          line = sr.ReadLine();
          if (line == "")
          {
            Tile t = new Tile(sb.ToString());
            Tiles.Add(t);
            sb.Clear();
          }
          else if (line == null)
          {
            Tile t = new Tile(sb.ToString());
            Tiles.Add(t);
            break;
          }
          else
          {
            sb.AppendLine(line);
          }
        }
      }
      InitMonster();
    }

    private void InitMonster()
    {
      Monster.Add(new List<char>("                  # "));
      Monster.Add(new List<char>("#    ##    ##    ###"));
      Monster.Add(new List<char>(" #  #  #  #  #  #   "));
    }

    internal void CrateImage()
    {
      Tile tile = Grid[0][0];
      int tileY = tile.Fields.Count;
      int tileX = tile.Fields[0].Count;

      int height = Grid.Count * (tileY - 2);
      int width = Grid[0].Count * (tileX - 2);

      for (int i = 0; i < height; i++)
      {
        Image.Add(new List<char>());
      }

      int lineNum = 0;
      for (int i = 0; i < Grid.Count; i++)
      {
        for (int j = 0; j < Grid[0].Count; j++)
        {

          lineNum = i * (tileY - 2);

          for (int iNew = 1; iNew < tileY - 1; iNew++)
          {
            for (int jNew = 1; jNew < tileX - 1; jNew++)
            {
              Image[lineNum + iNew - 1].Add(Grid[i][j].Fields[iNew][jNew]);
            }
          }
        }
      }
      string imageString = PrintImage();
      ImageTile = new Tile($"Tile 0:\r\n{imageString}");
    }
    public string PrintImage()
    {
      StringBuilder sb = new StringBuilder();
      for (int i = 0; i < Image.Count; i++)
      {
        for (int j = 0; j < Image[i].Count; j++)
        {
          sb.Append(Image[i][j]);
        }
        sb.AppendLine();
      }
      return sb.ToString();
    }

    internal long CornersMultiply()
    {
      int maxY = Grid.Count - 1;
      int maxX = Grid[0].Count - 1;
      return Grid[0][0].Id * Grid[0][maxX].Id * Grid[maxY][0].Id * Grid[maxY][maxX].Id;
    }

    public void Solve()
    {
      List<Tile> AvailableTiles = new List<Tile>(AllTiles);
      Tile first = AvailableTiles[0];
      first.Point = new Point(0, 0);
      AvailableTiles.RemoveAll(x => x.Id == first.Id);

      List<Tile> currentTiles = new List<Tile>();
      currentTiles.Add(first);

      while (currentTiles.Count > 0)
      {

        List<Tile> forRemove = new List<Tile>();
        List<Tile> matchedTiles = new List<Tile>();


        foreach (Tile current in currentTiles)
        {
          forRemove.Add(current);
          foreach (Tile available in AvailableTiles)
          {
            if (current.MatchTop(available))
            {
              matchedTiles.Add(available);
              available.Point = new Point(current.Point.X, current.Point.Y - 1);
            }
            if (current.MatchBottom(available))
            {
              matchedTiles.Add(available);
              available.Point = new Point(current.Point.X, current.Point.Y + 1);
            }
            if (current.MatchRight(available))
            {
              matchedTiles.Add(available);
              available.Point = new Point(current.Point.X + 1, current.Point.Y);
            }
            if (current.MatchLeft(available))
            {
              matchedTiles.Add(available);
              available.Point = new Point(current.Point.X - 1, current.Point.Y);
            }
          }
          if (matchedTiles.Count > 0)
          {
            break;
          }
        }

        currentTiles.AddRange(matchedTiles);
        foreach (var mt in matchedTiles)
        {
          AvailableTiles.RemoveAll(x => x.Id == mt.Id);
        }

        foreach (var t in forRemove)
        {
          currentTiles.RemoveAll(x => x.Id == t.Id);
        }

      }
    }

    public void CreateGrid()
    {
      var tiles = AllTiles.Where(x => x.Point != null);
      int xMin = tiles.Min(x => x.Point.X);
      int xMax = tiles.Max(x => x.Point.X);
      int yMin = tiles.Min(x => x.Point.Y);
      int yMax = tiles.Max(x => x.Point.Y);



      for (int i = yMin, iGrid = 0; i <= yMax; i++, iGrid++)
      {
        Grid.Add(new List<Tile>());
        for (int j = xMin; j <= xMax; j++)
        {
          Tile t = tiles.Where(x => x.Point.X == j && x.Point.Y == i).First();
          Grid[iGrid].Add(t);
        }
      }

    }

    public void CreateAllTiles()
    {
      foreach (Tile t in Tiles)
      {
        Tile tmp = t;
        AllTiles.Add(tmp);
        AllTiles.Add(tmp.FlipLeftRight());
        AllTiles.Add(tmp.FlipTopDown());
        for (int i = 0; i < 3; i++)
        {

          tmp = tmp.RotateRight();
          AllTiles.Add(tmp);
          if (i == 0)
          {
            AllTiles.Add(tmp.FlipLeftRight());
            AllTiles.Add(tmp.FlipTopDown());
          }

        }
      }
    }

    public int DistinctEdgesCount()
    {
      List<string> edges = new List<string>();
      foreach(Tile t in Tiles)
      {
        StringBuilder sb = new StringBuilder();
        foreach (char c in t.Fields[0])
        {
          sb.Append(c);
        }
        edges.Add(sb.ToString());
        edges.Add(Reverse(sb.ToString()));
        sb.Clear();

        foreach (char c in t.Fields[t.Fields.Count - 1])
        {
          sb.Append(c);
        }
        edges.Add(sb.ToString());
        edges.Add(Reverse(sb.ToString()));
        sb.Clear();

        for(int i = 0; i< t.Fields.Count; i++)
        {
          char c = t.Fields[i][0];
          sb.Append(c);
        }
        edges.Add(sb.ToString());
        edges.Add(Reverse(sb.ToString()));
        sb.Clear();

        for (int i = 0; i < t.Fields.Count; i++)
        {
          char c = t.Fields[i][t.Fields.Count-1];
          sb.Append(c);
        }
        edges.Add(sb.ToString());
        edges.Add(Reverse(sb.ToString()));
        sb.Clear();
      }
      return edges.Distinct().Count();
    }

    public static string Reverse(string s)
    {
      char[] charArray = s.ToCharArray();
      Array.Reverse(charArray);
      return new string(charArray);
    }

    public List<Tile> CreateAllTiles(Tile t)
    {
      List<Tile> ret = new List<Tile>();
      Tile tmp = t;
      ret.Add(tmp);
      ret.Add(tmp.FlipLeftRight());
      ret.Add(tmp.FlipTopDown());
      for (int i = 0; i < 3; i++)
      {

        tmp = tmp.RotateRight();
        ret.Add(tmp);
        if (i == 0)
        {
          ret.Add(tmp.FlipLeftRight());
          ret.Add(tmp.FlipTopDown());
        }
      }
      return ret;
    }




      public string Print()
      {
        StringBuilder sb = new StringBuilder();
        foreach (Tile t in Tiles)
        {
          sb.AppendLine(t.Print());
        }
        return sb.ToString();
      }
    }
  }
