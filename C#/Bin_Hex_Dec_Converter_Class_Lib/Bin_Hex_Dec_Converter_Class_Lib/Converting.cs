using System;

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
    }
}
