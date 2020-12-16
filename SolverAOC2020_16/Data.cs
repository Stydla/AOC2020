using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2020_16
{
  public class Data
  {
    public List<Rule> Rules = new List<Rule>();
    public List<Ticket> Tickets = new List<Ticket>();
    public Ticket MyTicket;

    public Data(string input)
    {
      int type = 0;
      using(StringReader sr = new StringReader(input))
      {
        string line;
        while((line = sr.ReadLine()) != null)
        {
          if(line == "")
          {
            type++;
            sr.ReadLine(); // header
            continue;
          }
          switch(type)
          {
            case 0:
              {
                Rule r = new Rule(line);
                Rules.Add(r);
                break;
              }
            case 1:
              {
                MyTicket = new Ticket(line);
                break;
              }
            case 2:
              {
                Ticket t = new Ticket(line);
                Tickets.Add(t);
                break;
              }
          }
        }
      }
    }

    internal long Solve2()
    {
      long res = 1;
      var rules = Rules.Where(x => x.Name.StartsWith("departure"));
      foreach(var rule in rules)
      {
        long val = MyTicket.Fields[rule.Index];
        res = res * val;
      }
      return res;
    }

    public void AssignRulesIndex()
    {
      

      for (int fieldIndex = 0; fieldIndex < Rules.Count; fieldIndex++)
      {
        foreach (Rule r in Rules)
        {
          bool isValid = true;
          foreach (Ticket t in Tickets)
          {
            int fieldValue = t.Fields[fieldIndex];
            if (!r.IsValid(fieldValue))
            {
              isValid = false;
            };
          }
          if (isValid)
          {
            r.PossibleIdexList.Add(fieldIndex);
          }
        }
      }

      List<Rule> unassignedRules;
      while ((unassignedRules = GetUnassignedRules()).Count > 0)
      {
        var exact = unassignedRules.Where(x => x.PossibleIdexList.Count == 1);
        if (exact.Count() < 1) throw new Exception("Invalid posible index list");

        Rule rule = exact.First();
        int index = rule.PossibleIdexList[0];
        rule.Index = index;
        foreach(Rule r in unassignedRules)
        {
          r.PossibleIdexList.Remove(index);
        }
      }
    }

    private List<Rule> GetUnassignedRules()
    {
      return Rules.Where(x => x.Index == -1).ToList();
    }

    public void DiscardInvalidTickets()
    {
      List<Ticket> invalidTickets = Tickets.Where(x => x.IsInvalid()).ToList();
      foreach(Ticket t in invalidTickets)
      {
        Tickets.Remove(t);
      }
    }

    internal int Solve1()
    {
      int sum = 0;
      foreach(Ticket t in Tickets)
      {
        sum += t.SumInvalid();
      }
      return sum;
    }

    internal void MarkInvalidFields()
    {
      foreach(Ticket t in Tickets)
      {
        
        for(int i = 0; i < t.Fields.Count; i++) 
        {
          int field = t.Fields[i];
          bool isValid = false;
          foreach(Rule rule in Rules)
          {
            foreach(Range r in rule.Ranges)
            {
              if (r.From <= field && r.To >= field)
              {
                isValid = true;
              }
            }
          }
          if(!isValid)
          {
            t.InvalidFields.Add(i);
          }
        }
      }
    }
  }
}
