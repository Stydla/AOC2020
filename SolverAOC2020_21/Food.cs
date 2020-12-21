using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SolverAOC2020_21
{
  public class Food
  {

    public HashSet<Alergen> Alergens = new HashSet<Alergen>();
    public HashSet<Ingredient> Ingredients = new HashSet<Ingredient>();

    public Food(string input, Data data)
    {
      Match m = Regex.Match(input, @"([^\(]*) \(contains ([^)]*)\)");
      string ingredients = m.Groups[1].Value;
      string alergens = m.Groups[2].Value;

      string[] ingredientsArr = ingredients.Split(' ');
      foreach(string ingrName in ingredientsArr)
      {
        Ingredient ingr = data.GetIngredient(ingrName.Trim());
        Ingredients.Add(ingr);
      }

      string[] alergensArr = alergens.Split(',');
      foreach (string alerName in alergensArr)
      {
        Alergen aler = data.GetAlergen(alerName.Trim());
        Alergens.Add(aler);
      }
    }

    
  }
}
