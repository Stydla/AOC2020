using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SolverAOC2020_24
{
  public class Data
  {

    public Dictionary<Point, Tile> Tiles { get; set; } = new Dictionary<Point, Tile>();


    public Data(string input)
    {
      using(StringReader sr = new StringReader(input))
      {
        string line;
        while((line = sr.ReadLine())!= null)
        {
          ParseLine(line);
        }
      }
    }

    private void ParseLine(string line)
    {
      MatchCollection mc = Regex.Matches(line, "e|se|sw|w|nw|ne");

      Point current = new Point() { X = 0, Y = 0 };

      foreach(Match m in mc)
      {
        current = current.Move(m.Value);
      }
      Tile t = GetTileOrCreate(current);
      t.Flip();

    }

    public Tile GetTileOrCreate(Point position)
    {
      Tile tile;
      if (Tiles.ContainsKey(position))
      {
        tile = Tiles[position];
      } else
      {
        tile = new Tile(position);
        Tiles.Add(position, tile);
      }
      return tile;
    }

    public Tile GetTileOnly(Point position)
    {
      Tile tile;
      if (Tiles.ContainsKey(position))
      {
        tile = Tiles[position];
      }
      else
      {
        tile = new Tile(position);
      }
      return tile;
    }


    public int GetBlackTilesCount()
    {
      var blackTiles = Tiles.Where(x => x.Value.IsBlack());
      return blackTiles.Count();
    }

    public void SimulateDay(int count)
    {
      for (int i = 0; i < count; i++) 
      {
        NextDay();
      }
    }

    private void NextDay()
    {

      AddNeighbours();

      Dictionary<Point, Tile> newTiles = new Dictionary<Point, Tile>();

      foreach(Tile t in Tiles.Values)
      {
        List<Tile> neighbours = GetNeighbours(t);
        var btNeighbours = neighbours.Where(x => x.IsBlack());
        int btNeighboursCount = btNeighbours.Count();
        int wtNeighboursCount = 6 - btNeighboursCount;

        if(t.IsBlack())
        {
          if(btNeighboursCount == 0 || btNeighboursCount > 2)
          {
            //do nothing
          } else
          {
            Tile tmp = new Tile(t.Position);
            tmp.Flip();
            newTiles.Add(t.Position, t);
          }
        } else
        {
          if(btNeighboursCount == 2)
          {
            Tile tmp = new Tile(t.Position);
            tmp.Flip();
            newTiles.Add(tmp.Position, tmp);
          }
        }
      }

      Tiles = newTiles;
    }

    private List<Tile> GetNeighbours(Tile t)
    {
      List<Tile> ret = new List<Tile>();

      Tile tmp = t;
      Point tmpPosition;

      //"e|se|sw|w|nw|ne"
      tmpPosition = tmp.Position.Move("e");
      ret.Add(GetTileOnly(tmpPosition));

      tmpPosition = tmp.Position.Move("se");
      ret.Add(GetTileOnly(tmpPosition));

      tmpPosition = tmp.Position.Move("sw");
      ret.Add(GetTileOnly(tmpPosition));

      tmpPosition = tmp.Position.Move("w");
      ret.Add(GetTileOnly(tmpPosition));

      tmpPosition = tmp.Position.Move("nw");
      ret.Add(GetTileOnly(tmpPosition));

      tmpPosition = tmp.Position.Move("ne");
      ret.Add(GetTileOnly(tmpPosition));

      return ret;
    }

    private void AddNeighbours()
    {
      List<Tile> vals = new List<Tile>(Tiles.Values);

      foreach(Tile tmp in vals)
      {
        Point tmpPosition;

        //"e|se|sw|w|nw|ne"
        tmpPosition = tmp.Position.Move("e");
        GetTileOrCreate(tmpPosition);

        tmpPosition = tmp.Position.Move("se");
        GetTileOrCreate(tmpPosition);

        tmpPosition = tmp.Position.Move("sw");
        GetTileOrCreate(tmpPosition);

        tmpPosition = tmp.Position.Move("w");
        GetTileOrCreate(tmpPosition);

        tmpPosition = tmp.Position.Move("nw");
        GetTileOrCreate(tmpPosition);

        tmpPosition = tmp.Position.Move("ne");
        GetTileOrCreate(tmpPosition);
      }
    }
  }
}
