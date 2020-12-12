using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2020_12
{
  class Ship
  {

    public Point Position { get; set; } = new Point();
    public Point Waypoint { get; private set; }

    public EDirection Direction { get; set; }
    public object ManhattanDistance
    {
      get
      {
        return Math.Abs(Position.X) + Math.Abs(Position.Y);
      }
    }

    public Ship()
    {
      Direction = EDirection.East;
    }

    public Ship(Point waypoint)
    {
      Waypoint = waypoint;
      Direction = EDirection.East;
    }

    public void Move(MoveCommand moveCommand)
    {
      switch (moveCommand.Command)
      {
        case ECommand.North:
          Position.Y -= moveCommand.Value;
          break;
        case ECommand.East:
          Position.X += moveCommand.Value;
          break;
        case ECommand.South:
          Position.Y += moveCommand.Value;
          break;
        case ECommand.West:
          Position.X -= moveCommand.Value;
          break;
        case ECommand.Right:
          for(int i = 0; i < moveCommand.Value; i++)
          {
            Direction = Direction.Next();
          }
          break;
        case ECommand.Left:
          for (int i = 0; i < moveCommand.Value; i++)
          {
            Direction = Direction.Prev();
          }
          break;
        case ECommand.Forward:
          var tmp = new MoveCommand(Direction, moveCommand.Value);
          Move(tmp);
          break;
      }
    }

    internal void Move2(MoveCommand moveCommand)
    {
      switch (moveCommand.Command)
      {
        case ECommand.North:
          Waypoint.Y -= moveCommand.Value;
          break;
        case ECommand.East:
          Waypoint.X += moveCommand.Value;
          break;
        case ECommand.South:
          Waypoint.Y += moveCommand.Value;
          break;
        case ECommand.West:
          Waypoint.X -= moveCommand.Value;
          break;
        case ECommand.Right:
          for (int i = 0; i < moveCommand.Value; i++)
          {
            long tmp = Waypoint.X;
            Waypoint.X = - Waypoint.Y;
            Waypoint.Y = tmp;
          }
          break;
        case ECommand.Left:
          for (int i = 0; i < moveCommand.Value; i++)
          {
            long tmp = Waypoint.X;
            Waypoint.X = Waypoint.Y;
            Waypoint.Y = - tmp;
          }
          break;
        case ECommand.Forward:
          Position.X += (Waypoint.X * moveCommand.Value);
          Position.Y += (Waypoint.Y * moveCommand.Value);
          break;
      }
    }
  }
}
