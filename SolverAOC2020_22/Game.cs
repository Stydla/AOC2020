using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2020_22
{
  public class Game
  {
    public List<Player> Players = new List<Player>();

    public Game(string input)
    {
      string[] players = input.Split(new string[] { "\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries);
      foreach(string p in players)
      {
        Player tmp = new Player(p);
        Players.Add(tmp);
      }
    }

    public Game(List<Player> players)
    {
      //Console.WriteLine("Starting sub game");
      foreach(Player p in players)
      {
        Player tmp = new Player(p);
        Players.Add(tmp);
      }
    }

    internal bool IsEnd()
    {
      return Players.Any(x=>!x.HasCards());
    }

    internal void Solve()
    {
      while (!this.IsEnd())
      {
        this.NextRound();
      }
    }

    internal void Solve2()
    {
      while (!this.IsEnd())
      {
        this.NextRound2();
      }
    }

    public void Print(Player winner)
    {
      foreach(var p in Players)
      {
        p.Print();
      }
      Console.WriteLine($"Winner: {winner.Number}");
      Console.WriteLine();
    }

    internal void NextRound()
    {
      int maxValueCard = Players.Max(x => x.GetCurrentCard());
      Player roundWinner = Players.Where(x => x.GetCurrentCard() == maxValueCard).First();

      List<int> cards = new List<int>();
      foreach(Player p in Players)
      {
        int card = p.TakeCurrentCard();
        cards.Add(card);
      }
      cards.Sort();
      cards.Reverse();

      foreach(int c in cards)
      {
        roundWinner.AddCard(c);
      }

    }

    internal void NextRound2()
    {
      Player roundWinner = null;
      foreach (Player p in Players)
      {
        if(p.IsInHistory())
        {
          roundWinner = Players[0]; // winner Player 1
        }
      }

      if(roundWinner == null)
      {
        //Create History
        foreach (Player p in Players)
        {
          p.AddToHistory();
        }

        bool enoughForRecursion = true;
        foreach(Player p in Players)
        {
          if(p.GetCurrentCard() >= p.CardCount())
          {
            enoughForRecursion = false;
          }
        }
        if(enoughForRecursion)
        {
          Game subGame = new Game(Players);
          subGame.Solve2();
          int winnerNumber = subGame.GetWinnerNumber();
          roundWinner = Players.Where(x => x.Number == winnerNumber).First();
          //Start Sub Game
        } else
        {
          int maxValueCard = Players.Max(x => x.GetCurrentCard());
          roundWinner = Players.Where(x => x.GetCurrentCard() == maxValueCard).First();
        }
      }

      //Print(roundWinner);

      // Move Cards
      var looser = Players.Where(x => x.Number != roundWinner.Number).First();

      roundWinner.AddCard(roundWinner.TakeCurrentCard());
      roundWinner.AddCard(looser.TakeCurrentCard());

    }

    public int GetWinnerNumber()
    {
      var playersWithCards = Players.Where(x => x.HasCards());
      if (playersWithCards.Count() != 1)
      {
        throw new Exception("There is no winner");
      }

      return playersWithCards.First().Number;
    }

    internal int GetWinningPlayerScore()
    {
      var playersWithCards = Players.Where(x => x.HasCards());
      if(playersWithCards.Count()!=1)
      {
        throw new Exception("There is no winner");
      }

      return playersWithCards.First().GetScore();

    }
  }
}
