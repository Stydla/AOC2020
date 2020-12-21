using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2020_21
{
  public class Alergen
  {
    public Alergen(string name)
    {
      Name = name;
    }

    public string Name { get; set; }
    public Ingredient Ingredient {get; set;}
    public HashSet<Ingredient> PossibleIngredients { get; set; } = new HashSet<Ingredient>();

    public override int GetHashCode()
    {
      return Name.GetHashCode();
    }
    public override bool Equals(object obj)
    {
      if(obj is Alergen a)
      {
        return this.Name == a.Name;
      }
      return false;
    }

  }

  
}
