using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2020_20
{
  public class Program : BaseAdventSolver, IAdventSolver
  {

    public override string SolverName => "Day 20: Jurassic Jigsaw"/*TODO: Task Name*/;

    public override string InputsFolderName => "SolverAOC2020_20";

    public override string SolveTask1(string InputData)
    {

      Data data = new Data(InputData);
      data.CreateAllTiles();
      int edgesCnt = data.DistinctEdgesCount();
      data.Solve();
      data.CreateGrid();


      long res = data.CornersMultiply();

      return $"{res}";
      
    }

    public override string SolveTask2(string InputData)
    {
      Data data = new Data(InputData);
      data.CreateAllTiles();
      data.Solve();
      data.CreateGrid();

      data.CrateImage();

      var rotatedImages = data.CreateAllTiles(data.ImageTile);
      List<int> waterCount = new List<int>();
      foreach(Tile t in rotatedImages)
      {
        t.ReplaceMonster(data.Monster);
        waterCount.Add(t.Print().Count(x => x == '#'));
      }
      
      long res = waterCount.Min();

      return $"{res}";
    }
  }
}
