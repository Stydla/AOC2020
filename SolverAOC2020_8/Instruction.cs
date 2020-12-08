using System;

namespace SolverAOC2020_8
{
  internal class Instruction
  {
    public Instruction(string name, int value)
    {
      Name = name;
      Value = value;
    }

    public string Name { get; set; }
    public int Value { get; }
    public int ExecuteCount { get; private set; }

    internal bool IsExecuted()
    {
      return ExecuteCount > 0;
    }

    internal void Execute(ref int instruction, ref long acumulator)
    {
      ExecuteCount++;
      switch (Name)
      {
        case "nop":
          {
            instruction++;
          }
          break;
        case "acc":
          {
            instruction++;
            acumulator += Value;
          }
          break;
        case "jmp":
          {
            instruction += Value;
          }
          break;
        default:
          throw new Exception($"Invalid instruciton {Name}");
      }
    }
  }
}