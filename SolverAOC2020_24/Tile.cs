using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2020_24
{
  public class Tile
  {
    public Point Position;

    public int Color;

    public Tile(Point position)
    {
      this.Position = position;
      Color = 0;
    }

    public void Flip()
    {
      Color = (Color + 1) % 2;
    }

    public bool IsBlack()
    {
      return Color == 1;
    }


  }
}
