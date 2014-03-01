using System;
using System.Text;

namespace DentistManager.Domain.Common
{
    public class GeneratRandomValue
    {
        public string generatRandomValue()
        {
            char[] ar = new char[] { 'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p', 'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'z', 'x', 'c', 'v', 'b', 'n', 'm', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            StringBuilder bld = new StringBuilder();
            Random rnd = new Random();

            for (int i = 0; i < 29; i++)
            {
                bld.Append(ar[rnd.Next(0, 34)]);
            }
            bld.Insert(rnd.Next(4, 25), '_');
            return bld.ToString();
        }
        public string generatRandomValue(int RandomValueLength)
        {
            char[] ar = new char[] { 'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p', 'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'z', 'x', 'c', 'v', 'b', 'n', 'm', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            StringBuilder bld = new StringBuilder();
            Random rnd = new Random();

            for (int i = 0; i < RandomValueLength; i++)
            {
                bld.Append(ar[rnd.Next(0, 34)]);
            }
            if (RandomValueLength>10)
                bld.Insert(rnd.Next(2, RandomValueLength), '_');

            return bld.ToString();
        }
    }
}
