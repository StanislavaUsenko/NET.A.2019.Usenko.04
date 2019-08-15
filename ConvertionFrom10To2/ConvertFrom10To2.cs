using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;

namespace ConvertionFrom10To2
{
    public class ConvertFrom10To2
    {

        const int _sizeOfMantissa = 52;
        const int _exponent = 1023;
        const int _base = 63;
        //<summary> 
        //converts a real number to a binary value in the format of IEEE 754 and returns a response as a string
        //</summary>
        public static string Convert(double number)
        {
            try
            {
                string response = "";

                if (double.IsNegativeInfinity(1.0/number))
                {
                    response += "1";
                    for (int i = 0; i < _base; i++) response += "0";
                    return response;
                }
                if (number == 0 )
                {
                    response += "0";
                    for (int i = 0; i < _base; i++) response += "0";
                    return response;
                }

                string decimalPart = "";
                string temp = number.ToString(CultureInfo.InvariantCulture);
                if (number < 0)
                    temp = temp.Remove(0, 1);
                string[] stringNumbers = temp.Split('.');
                long s = long.Parse(stringNumbers[0]);



                string wholePart = ConvertWholePart(s);

                if (stringNumbers.Length == 2)
                    decimalPart = ConvertDecimalPart(long.Parse(stringNumbers[1]) / Math.Pow(10, stringNumbers[1].Length),
                                                            wholePart.Length - 1);
                else
                    for (int i = 0; i<_sizeOfMantissa-wholePart.Length+1; i++) decimalPart += "0";


                string calculateExponent = ConvertWholePart(_exponent + wholePart.Length - 1);
                response += (number < 0) ? "1" : "0";
                response += calculateExponent;
                response += wholePart.Remove(0, 1);
                response += decimalPart;

                return response;
            }
            catch(Exception ex)
            {
                return $"Something wrong: {ex.Message}";
            }
            
        }

        private static string ConvertWholePart (long number)
        {
            string binaryNumber = "";
            long modulo = 0;
            int count = 0;
            while(number != 1)
            {                
                modulo = number % 2;
                number /= 2;
                binaryNumber += modulo.ToString();
                if (number == 1)
                    binaryNumber += "1";
                count++;
            }
            Console.WriteLine(count);
            char[] arr = binaryNumber.ToCharArray();
            Array.Reverse(arr);
            return new String(arr);
        }

        private static string ConvertDecimalPart(double number, int lenghtOfMovePoint)
        {
            string binaryNumber = "";
            double accuracy = _sizeOfMantissa - lenghtOfMovePoint;
            while(binaryNumber.Length <accuracy)
            {
                number *= 2;
                if (number < 1 || binaryNumber.Length == accuracy-1)
                {
                    binaryNumber += "0";

                }
                if (number > 1)
                {
                    binaryNumber += "1";
                    number -= 1;
                }
            }
            return binaryNumber;

        }

    }
}
