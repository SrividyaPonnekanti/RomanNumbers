using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumbers
{
    public class Conversions
    {
        public static string IntToRoman(int num)
        {
            
            string[] symbols = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
            int[] values = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };

            StringBuilder romanNumeral = new StringBuilder();

            
            for (int i = 0; i < symbols.Length; i++)
            {
                
                while (num >= values[i])
                {
                    romanNumeral.Append(symbols[i]);
                    num -= values[i];
                }
            }

            return romanNumeral.ToString();
        }



        static bool IsRomanNumeral(string input)
        {
            // Define valid Roman numeral symbols
            string validSymbols = "IVXLCDM";

            foreach (char c in input)
            {
                if (!validSymbols.Contains(c))
                {
                    
                    return false;
                }
            }

            // Check for invalid combinations
            if (input.Contains("VV") || input.Contains("LL") || input.Contains("DD") ||
                input.Contains("IIII") || input.Contains("XXXX") || input.Contains("CCCC") ||
                input.Contains("MMMM"))
            {
                return false;
            }

            // Check for valid combinations
            if (input.Contains("IVIV") || input.Contains("IXIX") ||
                input.Contains("XLXL") || input.Contains("XCXC") ||
                input.Contains("CDCD") || input.Contains("CMCM"))
            {
                return false;
            }

            return true;
        }



       public static int RomanToInteger(string romanNumeral)
        {
            Dictionary<char, int> romanValues = new Dictionary<char, int>()
        {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
        };

            int total = 0;
            int prevValue = 0;

            foreach (char c in romanNumeral)
            {
                int currentValue = romanValues[c];

                if (prevValue < currentValue)
                {
                    total += currentValue - 2 * prevValue; // Subtract twice the previous value
                }
                else
                {
                    total += currentValue;
                }

                prevValue = currentValue;
            }

            // Check if the input was a valid Roman numeral or not
            string reconstructed = IntToRoman(total);
            if (reconstructed != romanNumeral)
            {
                return -1;
            }

            return total;
        }


        public static void Main(string[] args)
        {

            // Task 1 Output
            Console.WriteLine(IntToRoman(2022));  // Output: "MMXXII"
            Console.WriteLine(IntToRoman(1990));  // Output: "MCMXC"
            Console.WriteLine(IntToRoman(2008));  // Output: "MMVIII"
            Console.WriteLine(IntToRoman(1666));  // Output: "MDCLXVI"
            Console.WriteLine(IntToRoman(3999));  // Output: "MMMCMXCIX"
             // Task 2 Output
            Console.WriteLine(RomanToInteger("MMXXI")); //2021
            Console.WriteLine(RomanToInteger("MMMCMXCIX")); //3999


            //Manually enter any number between 1 & 3999
            //INT to Roman
            Console.WriteLine("Enter a positive integer between 1 and 3999:");
            string input = Console.ReadLine();

            int number;
            if (int.TryParse(input, out number))
            {
                if (number >= 1 && number <= 3999)
                {
 
                    string romanNumeral = IntToRoman(number);
                    Console.WriteLine($"Roman numeral representation: {romanNumeral}");
                }
                else
                {
                    Console.WriteLine("Input is not within the valid range (1 to 3999).");
                }
            }
            else
            {
                Console.WriteLine("Input is not a valid integer.");
            }




            //Roman to INT
            Console.WriteLine("Enter a Roman numeral:");
            string romanValue = Console.ReadLine();

            if (IsRomanNumeral(romanValue))
            {
                Console.WriteLine("Input is a valid Roman numeral.");
               long convertedVlue= RomanToInteger(romanValue);
                Console.WriteLine($"Integer value for given Roman numeral is : {convertedVlue}");
            }
            else
            {
                Console.WriteLine("Input is not a valid Roman numeral.");
            }
        }
    }
}
