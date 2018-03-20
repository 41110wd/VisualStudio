using System;
using System.Collections.Generic;

namespace Bin_Hex_Dec_Converter_Class_Lib
{
    public class Converting
    {

        public int GetDec(int bin)
        {
            int buffer;
            int result = 0;
            for(int i = 0;bin>0;i++)
            {
                buffer = bin % 10;
                if(buffer>1)
                {
                    return -1;
                }
                result += (int)(buffer * Math.Pow(2,i));
                bin /= 10;
            }
            return result;
        }

        public int GetBin(int dec)
        {
            List<string> list_str = new List<string>();
            int buffer;
            int result;
            string result_str = "";

            for(int i = 1;dec>0;i+=10)
            {
                buffer = dec%2;
                list_str.Add(buffer.ToString());
                dec /= 2;
            }
            list_str.Reverse();
            foreach(string s in list_str)
            {
                result_str += s;
            }
            result = Convert.ToInt32(result_str);
            return result;
        }
    }
}
