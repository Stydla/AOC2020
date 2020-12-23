using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolverAOC2020_23
{
  internal class Data
  {


    List<int> Cups = new List<int>();
    int CurrentCupIndex = 0;

    public Data(string inputData)
    {
      foreach(char c in inputData)
      {
        Cups.Add(c - '0');
      }
    }

    internal void Move(int count)
    {
      for(int i = 0; i < count; i++)
      {
        Move();
      }
    }

    private void Move()
    {
      int currentCup = Cups[CurrentCupIndex];

      //pickup three cups
      List<int> removed = new List<int>();
      for (int i = 0; i < 3; i++)
      {
        int index = (CurrentCupIndex + 1 + i) % Cups.Count;
        removed.Add(Cups[index]);
      }
      foreach(int fr in removed)
      {
        Cups.Remove(fr);
      }

      //select destination cup
      int destinationCup = currentCup - 1;
      while(!Cups.Contains(destinationCup))
      {
        destinationCup--;
        if(destinationCup < 0)
        {
          destinationCup = Cups.Max();
        }
      }
      int destinationCupIndex = Cups.IndexOf(destinationCup);

      //place picked cups
      for(int i = 0; i < 3; i++)
      {
        int index = destinationCupIndex + i + 1;
        Cups.Insert(index, removed[i]);
      }
      while(CurrentCupIndex - Cups.IndexOf(currentCup) != 0)
      {
        int moveCup = Cups[0];
        Cups.Remove(moveCup);
        Cups.Add(moveCup);
      }
     
      //select current cup
      CurrentCupIndex = (CurrentCupIndex + 1) % Cups.Count;
    }

    internal string GetResult()
    {


      StringBuilder sb = new StringBuilder();
      int cupOneIndex = Cups.IndexOf(1);
      for(int i = 0; i < Cups.Count - 1; i++)
      {
        int index = (cupOneIndex + i + 1) % Cups.Count;
        sb.Append(Cups[index]);
      }
      
      return sb.ToString();
    }

  }
}