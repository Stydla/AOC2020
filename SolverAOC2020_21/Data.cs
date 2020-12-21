using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2020_21
{
  public class Data
  {
    public List<string> Input = new List<string>();
    public List<Food> Foods = new List<Food>();
    public HashSet<Alergen> Alergens = new HashSet<Alergen>();
    public HashSet<Ingredient> Ingredients = new HashSet<Ingredient>();

    public Data(string input)
    {
      using(StringReader sr = new StringReader(input))
      {
        string line;
        while((line = sr.ReadLine()) != null)
        {
          Input.Add(line);
        }
      }
    }

    internal int GetNumberOfAlergenFreeIngredients()
    {
      int cnt = 0;
      foreach(Food f in Foods)
      {
        foreach(Ingredient i in f.Ingredients)
        {
          if(i.Alergen == null)
          {
            cnt++;
          }
        }
      }
      return cnt;
    }

    internal string Solve2()
    {
      var ingr = Ingredients.Where(x => x.Alergen != null).ToList();
      ingr.Sort((x, y) => string.Compare(x.Alergen.Name, y.Alergen.Name));

      return string.Join(",", ingr.Select(x => x.Name));

    }

    public void FillPossibleIngredients()
    {
      foreach (Ingredient i in Ingredients)
      {
        foreach (Alergen a in Alergens)
        {
          a.PossibleIngredients.Add(i);
        }
      }
    }


    internal void AssignAlergens()
    {

      FillPossibleIngredients();
      

      while(true)
      {

        foreach(Alergen alergen in Alergens)
        {
          var foodsWithAlergen = Foods.Where(x => x.Alergens.Contains(alergen));
          foreach(Food f in foodsWithAlergen)
          {

            var except = Ingredients.Except(f.Ingredients);
            except = except.Union(Ingredients.Where(x => x.Alergen != null));
            foreach(var ingr in except)
            {
              alergen.PossibleIngredients.Remove(ingr);
            }
          }
        }

        var exact = Alergens.Where(x => x.PossibleIngredients.Count == 1);
        foreach(Alergen al in exact)
        {
          Ingredient ingr = al.PossibleIngredients.First();
          al.Ingredient = ingr;
          ingr.Alergen = al;
        }
        if(exact.Count() > 0)
        {
          continue;
        }

        break;
        
      }

    }

    public void LoadFoods()
    {
      foreach(string line in Input)
      {
        Food tmp = new Food(line, this);
        Foods.Add(tmp);
      }
    }
    


    public Alergen GetAlergen(string name)
    {
      Alergen ret = Alergens.Where(x => x.Name == name).FirstOrDefault();
      if(ret == null)
      {
        ret = new Alergen(name);
        Alergens.Add(ret);
      }
      return ret;
    }
    public Ingredient GetIngredient(string name)
    {
      Ingredient ret = Ingredients.Where(x => x.Name == name).FirstOrDefault();
      if (ret == null)
      {
        ret = new Ingredient(name);
        Ingredients.Add(ret);
      }
      return ret;
    }

  }
}
