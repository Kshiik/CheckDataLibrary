using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CheckDataLibrary
{
    public class VinCheck
    {
        public bool CheckVin(string vin, int year)
        {
            vin = vin.ToUpper();
            char[] chars = vin.ToCharArray();
            int[] numb = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            char[] letters = "ABCDEFGHJKLMNPRSTUVWXYZ".ToCharArray();
            int[] numbers = { 1,2,3,4,5,6,7,8,1,2,3,4,5,7,9,2,3,4,5,6,7,8,9 };
            int[] weight = { 8,7,6,5,4,3,2,10,0,9,8,7,6,5,4,3,2};
            int kontrolsumm = 0;
            double a = 0;
            double chk = 0;
            string x = "X";

            if (String.IsNullOrEmpty(vin))
                return false;
            if (vin.Length != 17)
                return false;
            if ((!Regex.Match(vin, "[A-Z]").Success) && (!Regex.Match(vin, "[0-9]").Success))
                return false;
            if (Regex.Match(vin, "[I, Q, O]").Success)
                return false;
            //for (int i = 0; i < vin.Length; i++)
            //{
            //    if ((Convert.ToInt32(char.GetNumericValue(chars[8])) != numb[i]) && (Convert.ToString(char.GetNumericValue(chars[8])) != "X"))
            //        return false;
            //}

            //рассчет контрольной суммы
            for (int i = 0; i < chars.Length; i++)
            {
                for (int j = 0; j < letters.Length; j++)
                {
                    if (chars[i] == letters[j])
                    {
                        chars[i] = Convert.ToChar(numbers[j]);
                        kontrolsumm =+ (weight[j] * chars[i]); 
                    }
                }
            }
            a = kontrolsumm / 11;
            a = Math.Round(a)*11;
            chk = kontrolsumm - a;
            //чет не то, фигня какая-то
            if (chk == 10)
                x = Convert.ToString(char.GetNumericValue(chars[8]));
            else
                chk = Convert.ToInt32(char.GetNumericValue(chars[8]));
            //

            //определение изготовителя(страна)
            string[] countriesCharsNegative = { "AP", "A0", "BS", "B0", "CS", "C0", "DS", "D0", "EL", "E0", "FL", "F0", "GA,", "G0", "HA", "H0", "NT", "N0", "PS", "P0", "T2", "T0", "UA", "UG", "U1", "U4", "U8", "U0", "ZS", "ZW", "6X", "60", "83", "80", "90" };
            string firstTwoNumbers = Convert.ToString(chars[0]) + Convert.ToString(chars[1]);
            for (int i = 0; i < countriesCharsNegative.Length; i++)
            {
                if (firstTwoNumbers == countriesCharsNegative[i])
                    return false;
            }

            //определение даты иготовления

            return true;
        }
        public string GetVINCountry(string vin)
        {
            

            return vin;
        }
        public bool CorrectYear(string vin, int year)
        {

            return true;
        }
    }
}
