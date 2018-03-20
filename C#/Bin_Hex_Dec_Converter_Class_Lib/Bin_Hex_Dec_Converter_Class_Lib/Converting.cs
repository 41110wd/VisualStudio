using System;
using System.Collections.Generic;

namespace Bin_Hex_Dec_Converter_Class_Lib
{
    public static class Converting
    {

        #region Convert from binary to decimal

        public static int GetDec(int bin)
        {
            int buffer;
            int result = 0;

            // Loop throw until Parameter bin is 0
            for(int i = 0;bin>0;i++)
            {

                // if Parameter bin contains a non binary number return -1
                buffer = bin % 10;
                if(buffer>1)
                {
                    return -1;
                }

                // ad a single binary number to result as decimal and divide bin by 10 to get to the next binray number
                result += (int)(buffer * Math.Pow(2,i));
                bin /= 10;
            }
            return result;
        }

        #endregion

        #region Convert from decimal to binary

        public static int GetBin(int dec)
        {

            // string List is used to store binary values otherwise zeros will be lost when adding
            List<string> list_str = new List<string>();
            int buffer;
            int result;
            string result_str = "";

            // loop throw until dec is 0. list stores binary number
            for(int i = 0;dec>0;i++)
            {
                buffer = dec%2;
                list_str.Add(buffer.ToString());
                dec /= 2;
            }

            // list need to be reversed so for example 01 can get 10 as intended. after that every binary stored as string in the list will be added to a string variable
            list_str.Reverse();
            foreach(string s in list_str)
            {
                result_str += s;
            }
            result = Convert.ToInt32(result_str);
            return result;
        }

        #endregion

        #region Convert From hexadecimal to decimal

        public static int GetDec_Hex(string hex)
        {

            // Dictionary is needed to figure out the coresponding decimal number to a hexadecimal number. Arrays have the length of the string Parameter hex
            int result = 0;
            int[] int_ar = new int[hex.Length];
            string[] str_ar = new string[hex.Length];

            Dictionary<char, int> dic = new Dictionary<char, int>();
            dic.Add('A', 10);
            dic.Add('B', 11);
            dic.Add('C', 12);
            dic.Add('D', 13);
            dic.Add('E', 14);
            dic.Add('F', 15);   

            // string array is filled with chars from the string Parameter hex, which get converted to strings so it is possible to try to convert them into int
            for (int i = 0;i<hex.Length;i++)
            {
                str_ar[i] = hex[i].ToString();

                try
                {
                    int_ar[i] = Convert.ToInt32(str_ar[i]);
                }

                // if a string can't be converted to a number, the Dictionary is looked at and the corespondng value is stored in the int array if it is inside of the Dictionary
                catch
                {
                    dic.TryGetValue(hex[i], out int_ar[i]);
                    if (int_ar[i] == 0)
                        return -1;
                }
            }

            // int Array needs to be reversed. index i of array is multiplied by 16^i and then added to result
            Array.Reverse(int_ar);

            for (int i = 0;i<str_ar.Length;i++)
            {
                result += int_ar[i] * (int)(Math.Pow(16, i));
            }

            return result;
        }

        #endregion
    }
}
