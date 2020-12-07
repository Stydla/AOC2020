using Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SolverAOC2020_7
{
  public class Program : BaseAdventSolver, IAdventSolver
  {

    public override string SolverName => "Day 7: Handy Haversacks"/*TODO: Task Name*/;

    public override string InputsFolderName => "SolverAOC2020_7";

    public override string SolveTask1(string InputData)
    {

      var data = LoadData(InputData);
      var bags = ParseBags(data);

      Bag b = bags.Find(x => x.Name == "shiny gold");
      List<Bag> visited = new List<Bag>();
      b.ParentCount(visited);
      
      return $"{visited.Count}";
    }

    public override string SolveTask2(string InputData)
    {
      var data = LoadData(InputData);
      var bags = ParseBags(data);

      Bag b = bags.Find(x => x.Name == "shiny gold");
      int bagsCnt = b.BagCount();

      return $"{bagsCnt - 1}";
    }

    private List<string> LoadData(string input)
    {
      List<string> ret = new List<string>();
      using(StringReader sr = new StringReader(input))
      {
        string line = null;
        while((line = sr.ReadLine()) != null)
        {
          ret.Add(line);
        }
      }
      return ret;
    }

    private List<Bag> ParseBags(List<string> data)
    {
      List<Bag> ret = new List<Bag>();
      foreach(var d in data)
      {
        string [] a =  d.Split(new[] { " bags contain " }, StringSplitOptions.None);
        Bag rootTmp = ret.Find(x => x.Name == a[0]);
        if (rootTmp == null)
        {
          rootTmp = new Bag(a[0]);
          ret.Add(rootTmp);
        }

        if(a[1] == "no other bags.")
        {
          continue;
        }

        string [] b = a[1].Split(new[] { ", " }, StringSplitOptions.None);

        MatchCollection mc = Regex.Matches(a[1], "[ ]*(\\d*)[ ]*(.*?)[,.]");

        foreach (Match m in mc) 
        {
          int cnt = int.Parse(m.Groups[1].Value);
          string bagName = m.Groups[2].Value.Replace(" bags", "").Replace(" bag", "");
          Bag bTmp = ret.Find(x => x.Name == bagName);
          if(bTmp == null)
          {
            bTmp = new Bag(bagName);
            ret.Add(bTmp);
          }
          rootTmp.Childs.Add(bTmp, cnt);
          bTmp.Parents.Add(rootTmp);
        }

      }
      return ret;
    }

  }
}
