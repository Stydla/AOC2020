using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2020_21
{
  public class Program : BaseAdventSolver, IAdventSolver
  {

    public override string SolverName => "Day 21: Allergen Assessment"/*TODO: Task Name*/;

    public override string InputsFolderName => "SolverAOC2020_21";

    public override string SolveTask1(string InputData)
    {
      Data data = new Data(InputData);
      data.LoadFoods();
      data.AssignAlergens();

      int count = data.GetNumberOfAlergenFreeIngredients();

      return $"{count}";
    }

    public override string SolveTask2(string InputData)
    {
      Data data = new Data(InputData);
      data.LoadFoods();
      data.AssignAlergens();

      string res = data.Solve2();

      return $"{res}";
    }
  }
}
