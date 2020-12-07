using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2020_7
{
  public class Bag
  {
    public string Name { get; set; }
    public List<Bag> Parents { get; set; } = new List<Bag>();
    public Dictionary<Bag, int> Childs { get; set; } = new Dictionary<Bag, int>();

    public Bag(string name)
    {
      Name = name;
    }
    internal Bag Find(string name)
    {
      if (Name == name) return this;

      foreach(var c in Childs)
      {
        var b = c.Key.Find(name);
        if (b != null)
        {
          return b;
        }
      }
      return null;

    }

    internal void ParentCount(List<Bag> visitedBags)
    {
     
      foreach (Bag parent in this.Parents)
      {
        if(!visitedBags.Contains(parent))
        {
          visitedBags.Add(parent);
          parent.ParentCount(visitedBags);
        }
      }
      return;
    }

    internal int BagCount()
    {
      int cnt = 1;
      
      foreach (var child in this.Childs)
      {
        int val = child.Value;
        int cCount = child.Key.BagCount();
        cnt += (val * cCount);
      }
      return cnt;
    }

    public override string ToString()
    {
      return Name;
    }
  }
}
