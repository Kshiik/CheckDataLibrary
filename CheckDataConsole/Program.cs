using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CheckDataConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            vin = vin.ToUpper();
            char[] chars = vin.ToCharArray();
            int[] numb = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            char[] letters = "ABCDEFGHJKLMNPRSTUVWXYZ".ToCharArray();
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 1, 2, 3, 4, 5, 7, 9, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] weight = { 8, 7, 6, 5, 4, 3, 2, 10, 0, 9, 8, 7, 6, 5, 4, 3, 2 };
            int kontrolsumm = 0;
            double a = 0;
            double chk = 0;
            string x = "X";

            for (int i = 0; i < chars.Length; i++)
            {
                for (int j = 0; j < letters.Length; j++)
                {
                    if (chars[i] == letters[j])
                    {
                        chars[i] = Convert.ToChar(numbers[j]);
                        kontrolsumm = +(weight[j] * chars[i]);
                    }
                }
            }
            a = kontrolsumm / 11;
            a = Math.Round(a) * 11;
            chk = kontrolsumm - a;
            //чет не то, фигня какая-то
            if (chk == 10)
                x = Convert.ToString(char.GetNumericValue(chars[8]));
            else
                chk = Convert.ToInt32(char.GetNumericValue(chars[8]));
            //

            Console.WriteLine(kontrolsumm);
            Console.ReadKey();
        }
    }
}
