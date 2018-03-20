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

            Menu();
            
        }

        static void Menu()
        {
            bool running = true;
      
            while (running)
            {
                Console.Clear();
                string selection;
                Console.WriteLine("Binary Converter");
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("1. Binary  => Decimal");
                Console.WriteLine("2. Decimal => Binary");
                Console.WriteLine("0. Exit");
                Console.WriteLine();

                selection = Console.ReadLine();

                switch (selection)
                {
                    case "1":
                    case "1.":
                        Bin_Dec();
                        break;
                    case "2":
                    case "2.":
                        Dec_Bin();
                        break;
                    case "0":
                    case "0.":
                        Console.Clear();
                        running = false;
                        break;
                    default:
                        break;
                }

                Console.ReadKey();
            }
        }

        static void Bin_Dec()
        {
            int result;
            int bin;

            Console.Write("Please enter binary Number: ");

            try
            {
                bin = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                result = conv.GetDec(bin);
                if (result == -1)
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

        static void Dec_Bin()
        {
            int result;
            int dec;

            Console.Write("Please enter decimal Number: ");

            try
            {
                dec = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                result = conv.GetBin(dec);
                Console.WriteLine($"Decimal\t\tBinary\n--------------------------------\n{dec}\t\t{result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
