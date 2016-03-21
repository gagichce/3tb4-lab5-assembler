using System;
using System.Collections.Generic;
using System.Linq;

namespace _3tb4_lab5_assembler
{
    public static class Helpers
    {
        public static byte GetByteFromBoolString(string boolString, int limitLength = 8)
        {
            byte returnByte = 0;


            for (int i = 0; i < Math.Min(boolString.Length, limitLength); i++)
            {
                if (boolString[boolString.Length - i - 1] == '1')
                {
                    returnByte += (byte)Math.Pow(2, i);
                }
            }

            return returnByte;
        }

        public static string GetBoolStringFromDecimal(string dec, int limitLength = 8)
        {
            int validNum;
            var returnString = string.Empty;

            if (int.TryParse(dec, out validNum))
            {
                for (int i = 0; i < limitLength; i++)
                {
                    string toAdd = "0";

                    if ((validNum >> i) % 2 == 1)
                    {
                        toAdd = "1";
                    }

                    returnString = toAdd + returnString;
                }
            }

            return returnString;
        }

        public static Register GetRegister(string regString)
        {
            switch (regString.Trim())
            {
                case "R0":
                    return Register.R0;
                case "R1":
                    return Register.R1;
                case "R2":
                    return Register.R2;
                case "R3":
                    return Register.R3;
            }

            return Register.None;
        }

        public static string GetErrorMessageWithLineNumber(int lineNumber, string rawLine = "", string errorMessage = "")
        {
            if (!string.IsNullOrEmpty(rawLine))
                rawLine = "\n" + rawLine;

            if (!string.IsNullOrEmpty(errorMessage))
                errorMessage = "\n" + errorMessage;

            return string.Format("Line {0} could not be converted to machine code.{1}{2}", lineNumber + 1, rawLine, errorMessage);
        }
    }
}