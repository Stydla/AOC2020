using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2020_25
{
  public class Data
  {

    public BigInteger CardPublicKey;
    public BigInteger DoorPublicKey;

    public BigInteger EncryptionKey;

    public BigInteger CardLoopCount;
    public BigInteger DoorLoopCount;

    public Data(string input )
    {
      using (StringReader sr = new StringReader(input))
      {
        string line = sr.ReadLine();
        CardPublicKey = BigInteger.Parse(line);

        line = sr.ReadLine();
        DoorPublicKey = BigInteger.Parse(line);
      }
    }


    public void SolveLoops(BigInteger subjectNumber)
    {
      CardLoopCount = SolveLoop(CardPublicKey, subjectNumber);
      DoorLoopCount = SolveLoop(DoorPublicKey, subjectNumber);
    }

    public BigInteger SolveLoop(BigInteger key, BigInteger subjectNumber)
    {
      
      BigInteger value = 1;
      BigInteger loopCount = 0;

      while(value != key)
      {
        value = TransformStep(value, subjectNumber);
        loopCount++;
      }
      return loopCount;
    }

    private BigInteger TransformStep(BigInteger value, BigInteger subjectNumber)
    {
      //Set the value to itself multiplied by the subject number.
      //Set the value to the remainder after dividing the value by 20201227.
      BigInteger ret = value;
      ret = subjectNumber * ret;
      ret = ret % 20201227;
      return ret;
    }

    private BigInteger Transform(BigInteger encryptionKey, BigInteger loopSize)
    {
      BigInteger value = 1;
      for(int i = 0; i < loopSize; i++)
      {
        value = TransformStep(value, encryptionKey);
      }
      return value;
    }

    public void SolveEncryptionKey()
    {
      EncryptionKey = Transform(DoorPublicKey, CardLoopCount);
      
    }

  }
}
