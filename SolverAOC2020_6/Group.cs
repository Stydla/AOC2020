using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2020_6
{
  public class Group
  {
    public List<string> Answers = new List<string>();

    public int GetYesAnswerCount()
    {
      int cnt = 0;
      for(char i = 'a'; i <= 'z'; i++)
      {
        if(Answers.Any(x=>x.Contains(i)))
        {
          cnt++;
        }
      }
      return cnt;
    }

    public int GetYesAnswerEveryoneCount()
    {
      int cnt = 0;
      for (char i = 'a'; i <= 'z'; i++)
      {
        if (Answers.Any(x => !x.Contains(i)))
        {
          continue;
        }
        cnt++;
      }
      return cnt;
    }
  }
}
