using Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2020_8
{
  public class Program : BaseAdventSolver, IAdventSolver
  {

    public override string SolverName => "Day 8: Handheld Halting"/*TODO: Task Name*/;

    public override string InputsFolderName => "SolverAOC2020_8";

    public override string SolveTask1(string InputData)
    {
      List<Instruction> inst = ReadInstructions(InputData);

      long acumulator = 0;
      int instruction = 0;
      
      while(!inst[instruction].IsExecuted())
      {
        inst[instruction].Execute(ref instruction, ref acumulator);
      }

      return $"{acumulator}";
    }

    public override string SolveTask2(string InputData)
    {

      List<Instruction> inst2 = ReadInstructions(InputData);

      for(int i = 0; i < inst2.Count; i++)
      {
        List<Instruction> inst = ReadInstructions(InputData);

        if(inst[i].Name == "jmp")
        {
          inst[i].Name = "nop";
        } else if (inst[i].Name == "nop")
        {
          inst[i].Name = "jmp";
        } else
        {
          continue;
        }

        long acumulator = 0;
        int instruction = 0;

        while (!inst[instruction].IsExecuted())
        {
          inst[instruction].Execute(ref instruction, ref acumulator);

          if(instruction >= inst.Count)
          {
            return $"{acumulator}";
          }
        }
      }

      return $"Not Found";

      
    }

    private Instruction ReadInstruction(string line)
    {
      string name = line.Substring(0, 3);
      int value = int.Parse(line.Substring(4));
      return new Instruction(name, value);
    }

    private List<Instruction> ReadInstructions(string input)
    {
      List<Instruction> ret = new List<Instruction>();
      using(StringReader sr = new StringReader(input))
      {
        string line;
        while((line = sr.ReadLine()) != null)
        {
          var inst = ReadInstruction(line);
          ret.Add(inst);
        }
      }
      return ret;
    }
  }
}
