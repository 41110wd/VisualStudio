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

        static void Main(string[] args)
        {
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
                Console.WriteLine("-----------------------------------\n");
                Console.WriteLine("1. Binary      => Decimal");
                Console.WriteLine("2. Decimal     => Binary");
                Console.WriteLine("3. Hexadecimal => Decimal");
                Console.WriteLine("4. Decimal     => Hexadecimal");
                Console.WriteLine("5. Hexadecimal => Binary");
                Console.WriteLine("6. Binary      => Hexadecimal");
                Console.WriteLine("\n0. Exit");
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
                    case "3":
                    case "3.":
                        Hex_Dec();
                        break;
                    case "4":
                    case "4.":
                        Dec_Hex();
                        break;
                    case "5":
                    case "5.":
                        Hex_Bin();
                        break;
                    case "6":
                    case "6.":
                        Bin_Hex();
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

            Console.Clear();
            Console.Write("Please enter binary Number: ");

            try
            {
                bin = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                result = Converting.GetDec(bin);
                if (result == -1)
                {
                    Console.WriteLine("No binary Number was entered");
                }
                else
                    Console.WriteLine($"Binary\t\t\tDecimal\n----------------------------------------------\n{bin}\t\t\t{result}");
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

            Console.Clear();
            Console.Write("Please enter decimal Number: ");

            try
            {
                dec = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                result = Converting.GetBin(dec);
                Console.WriteLine($"Decimal\t\t\tBinary\n----------------------------------------------\n{dec}\t\t\t{result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        static void Hex_Dec()
        {
            int result;
            string hex;

            Console.Clear();
            Console.Write("Please enter hexadecimal Number: ");

            try
            {
                hex = Console.ReadLine();
                Console.Clear();
                result = Converting.GetDec_Hex(hex);
                if (result == -1)
                    throw new Exception("No hexadecimal Number was entered");
                Console.WriteLine($"Hexadecimal\t\t\tDecimal\n----------------------------------------------\n{hex}\t\t\t\t{result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        static void Dec_Hex()
        {
            string result;
            int dec;

            Console.Clear();
            Console.Write("Please enter decimal Number: ");

            try
            {
                dec = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                result = Converting.GetHex_Dec(dec);                
                Console.WriteLine($"Decimal\t\t\tHexadecimal\n----------------------------------------------\n{dec}\t\t\t{result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        static void Hex_Bin()
        {
            int result;
            string hex;

            Console.Clear();
            Console.WriteLine("Please enter hexadecimal Number: ");

            try
            {
                hex = Console.ReadLine();
                Console.Clear();
                result = Converting.GetDec_Hex(hex);
                if (result == -1)
                    throw new Exception("No hexadecimal Number was entered");

                result = Converting.GetBin(result);
                Console.WriteLine($"Hexadecimal\t\t\tBinary\n----------------------------------------------\n{hex}\t\t\t\t{result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        static void Bin_Hex()
        {
            int result;
            string str_result;
            int bin;

            Console.Clear();
            Console.WriteLine("Please enter hexadecimal Number: ");

            try
            {
                bin = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                result = Converting.GetDec(bin);
                if (result == -1)
                    throw new Exception("No binary Number was entered");

                str_result = Converting.GetHex_Dec(result);
                Console.WriteLine($"Binary\t\t\t\tHexadecimal\n----------------------------------------------\n{bin}\t\t\t\t{str_result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
