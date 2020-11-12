using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingTimestamp
{
   class Program
   {
      public static byte ConvertToBcd(byte x)
      {

         int msb = x / 10;

         int lsb = x - (msb * 10);

         msb = msb << 4;

         return (byte)(msb | lsb);

      }


      public static byte[] GetLocalTimeInBCD()
      {

         DateTime now = DateTime.Now;

         byte[] Data = new byte[4];
         // 0000 0000 / 0000 0000 / 0000 0000 / 0000 0000
         Data[0] = (byte)(now.Year - 100);

         Data[1] = (byte)now.Month;

         Data[2] = (byte)now.Day;

         Data[3] = (byte)now.Hour;


         for (int i = 0; i < 4; i++)
         {

            Data[i] = ConvertToBcd(Data[i]);

         }

         return Data;

      }

      static void Main(string[] args)
      {
      }
   }
}
