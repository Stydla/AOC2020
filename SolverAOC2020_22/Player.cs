using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SolverAOC2020_22
{
  public class Player
  {
    
    public int Number { get; set; }
    private Queue<int> Deck { get; set; } = new Queue<int>();

    public List<List<int>> GameHistory { get; set; } = new List<List<int>>();

    public Player(string input)
    {
      using(StringReader sr = new StringReader(input))
      {
        string player = sr.ReadLine();
        Match m = Regex.Match(player, @"Player (\d*):");
        Number = int.Parse(m.Groups[1].Value);

        string line;
        while((line = sr.ReadLine())!= null)
        {
          Deck.Enqueue(int.Parse(line));
        }
      }

    }

    public Player(Player p)
    {
      Number = p.Number;
      int current = p.GetCurrentCard();
      Deck = new Queue<int>(p.Deck.Skip(1).Take(current));
    }

    internal bool HasCards()
    {
      return Deck.Count != 0;
    }

    internal int GetScore()
    {
      int sum = 0;
      int multiplier = Deck.Count;
      foreach(int i in Deck)
      {
        sum = sum + i * multiplier;
        multiplier--;
      }
      return sum;
    }

    internal void Print()
    {
      Console.WriteLine(string.Join(",", Deck.ToArray()));
    }

    internal int GetCurrentCard()
    {
      return Deck.Peek();
    }

    internal int TakeCurrentCard()
    {
      return Deck.Dequeue();
    }

    internal void AddCard(int c)
    {
      Deck.Enqueue(c);
    }

    internal bool IsInHistory()
    {
      foreach(var history in GameHistory)
      {
        if (history.Count != Deck.Count) continue;
        bool found = true;
        int index = 0;
        foreach(int val in Deck)
        {
          if(val != history[index])
          {
            found = false;
            break;
          }
          index++;
        }
        if(found)
        {
          return true;
        }
      }
      return false;
    }

    internal void AddToHistory()
    {
      GameHistory.Add(Deck.ToList());
    }

    internal int CardCount()
    {
      return Deck.Count;
    }
  }
}
