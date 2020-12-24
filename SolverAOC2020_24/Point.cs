namespace SolverAOC2020_24
{
  public class Point
  {

    public int X { get; set; }
    public int Y { get; set; }

    public override bool Equals(object obj)
    {
      if(obj is Point p)
      {
        return p.X == X && p.Y == Y;
      }
      return false;
    }

    public override int GetHashCode()
    {
      int hash = 7;
      hash = hash * 23 + X;
      hash = hash * 23 + Y;
      return hash;
    }

    public Point Move(string dir)
    {
      Point ret = new Point();
      switch (dir)
      {
        case "e":
          {
            ret.X = X + 2;
            ret.Y = Y;
            break;
          }
        case "se":
          {
            ret.X = X + 1;
            ret.Y = Y + 1;
            break;
          }
        case "sw":
          {
            ret.X = X - 1;
            ret.Y = Y + 1;
            break;
          }
        case "w":
          {
            ret.X = X - 2;
            ret.Y = Y;
            break;
          }
        case "nw":
          {
            ret.X = X - 1;
            ret.Y = Y - 1;
            break;
          }
        case "ne":
          {
            ret.X = X + 1;
            ret.Y = Y - 1;
            break;
          }
      }
      return ret;
    }
  }
}