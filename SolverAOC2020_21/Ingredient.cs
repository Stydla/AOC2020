using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2020_21
{
  public class Ingredient
  {
    public Ingredient(string name)
    {
      Name = name;
    }

    public string Name { get; set; }
    public Alergen Alergen { get; set; }
    public override int GetHashCode()
    {
      return Name.GetHashCode();
    }
    public override bool Equals(object obj)
    {
      if (obj is Ingredient a)
      {
        return this.Name == a.Name;
      }
      return false;
    }
  }
}
