using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2020_23
{
  public class Data2
  {

    public List<Cup> CupList { get; set; } = new List<Cup>();
    public List<Cup> OrderedCupList { get; set; } = new List<Cup>();
    public Cup CurrentCup;
    public int CupMax;
    public Data2(string inputData)
    {
      foreach (char c in inputData)
      {
        Cup cup = new Cup(c - '0');
        CupList.Add(cup);
      }
      CupMax = CupList.Max(x => x.Number);
    }

    public void Fill2()
    {
      for (int i = 10; i <= 1000 * 1000; i++)
      {
        Cup cup = new Cup(i);
        CupList.Add(cup);
      }
      CupMax = CupList.Max(x => x.Number);
    }

    public void Link()
    {
      for (int i = 0; i < CupList.Count - 1; i++)
      {
        CupList[i].Next = CupList[i + 1];
        CupList[i + 1].Prev = CupList[i];
      }
      CupList[0].Prev = CupList[CupList.Count - 1];
      CupList[CupList.Count - 1].Next = CupList[0];

      CurrentCup = CupList[0];
      OrderedCupList = CupList.OrderBy(x => x.Number).ToList();
    }

    internal void Move(int count)
    {
      for (int i = 0; i < count; i++)
      {
        //PrintCups(i);
        Move();
      }
    }

    private void Move()
    {

      //pickup three cups
      CupChain cc = CurrentCup.RemoveNext(3);

      //select destination cup
      int destinationCupNumber = CurrentCup.Number-1;
      if(destinationCupNumber < 1)
      {
        destinationCupNumber = CupMax;
      }
      while (cc.Contains(destinationCupNumber))
      {
        destinationCupNumber--;
        if (destinationCupNumber < 1)
        {
          destinationCupNumber = CupMax;
        }
      }

      //place picked cups
      Cup destinationCup = OrderedCupList[destinationCupNumber-1];
      destinationCup.InsertChain(cc);

      //select current cup
      CurrentCup = CurrentCup.Next;
    }

    public void PrintCups(int index)
    {
      Cup startCup = CurrentCup;
      for (int i = 0; i < index; i++)
      {
        startCup = startCup.Prev;
      }
      Console.Write(startCup.Number);
      Cup tmp = startCup.Next;
      while(tmp != startCup)
      {      
        Console.Write(tmp.Number);
        tmp = tmp.Next;
      }
      Console.WriteLine();
      return;
    }

    public void PrintPrev(Cup cup) 
    {
      Cup tmp = cup;
      Console.Write(tmp.Number);
      tmp = tmp.Prev;
      StringBuilder sb = new StringBuilder();
      while (tmp != cup)
      {
        sb.Append(tmp.Number);
        tmp = tmp.Prev;
      }
      var arr = sb.ToString().ToCharArray();
      Array.Reverse(arr);
      string rev = new string(arr);
      Console.WriteLine(rev);
    }

    public void PrintNext(Cup cup)
    {
      Cup tmp = cup;
      Console.Write(tmp.Number);
      tmp = tmp.Next;
      while (tmp != cup)
      {
        Console.Write(tmp.Number);
        tmp = tmp.Next;
      }
      Console.WriteLine();
    }


    public string GetResult1()
    {
      StringBuilder sb = new StringBuilder();
      Cup c = OrderedCupList[0];
      Cup tmp = c.Next;
      while(tmp != c)
      {
        sb.Append(tmp.Number);
        tmp = tmp.Next;
      }
      return sb.ToString();
    }

    public string GetResult2()
    {
      Cup cup1 = OrderedCupList[0].Next;
      Cup cup2 = cup1.Next;
      long val1 = cup1.Number;
      long val2 = cup2.Number;
      return $"{val1 * val2}";
    }

  }
}
