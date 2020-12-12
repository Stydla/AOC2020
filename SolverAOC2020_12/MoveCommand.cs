namespace SolverAOC2020_12
{
  public class MoveCommand
  {

    public ECommand Command { get; set; }
    public int Value { get; set; }

    public MoveCommand(EDirection dir, int val)
    {
      Value = val;
      switch (dir)
      {
        case EDirection.North:
          Command = ECommand.North;
          break;
        case EDirection.East:
          Command = ECommand.East;
          break;
        case EDirection.South:
          Command = ECommand.South;
          break;
        case EDirection.West:
          Command = ECommand.West;
          break;
      }
    }

    public MoveCommand(string input)
    {
      string cmd = input.Substring(0, 1);
      Value = int.Parse(input.Substring(1));
      switch(cmd)
      {
        case "N":
          Command = ECommand.North;
          break;
        case "E":
          Command = ECommand.East;
          break;
        case "S":
          Command = ECommand.South;
          break;
        case "W":
          Command = ECommand.West;
          break;
        case "L":
          Value /= 90;
          Command = ECommand.Left;
          break;
        case "R":
          Value /= 90;
          Command = ECommand.Right;
          break;
        case "F":
          Command = ECommand.Forward;
          break;
        default:
          throw new System.Exception($"Impossible to parse command {cmd}");
      }
    }
  }
}