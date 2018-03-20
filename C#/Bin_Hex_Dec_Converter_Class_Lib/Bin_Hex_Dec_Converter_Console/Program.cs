using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bin_Hex_Dec_Converter_Class_Lib;

namespace Bin_Hex_Dec_Converter_Console
{
    class Program
    {
        static Converting conv;

        static void Main(string[] args)
        {
            conv = new Converting();
            int result;
            int bin;

            Console.Write("Please enter binary Number: ");

            try
            {
                bin = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                result = conv.GetDec(bin);
                if(result == -1)
                {
                    Console.WriteLine("No binary Number was entered");
                }
                else
                    Console.WriteLine($"Binary\t\tDecimal\n--------------------------------\n{bin}\t\t{result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
