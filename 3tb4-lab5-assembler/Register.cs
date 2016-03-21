using System.Data;

namespace _3tb4_lab5_assembler
{
    public enum Register
    {
        R0,
        R1,
        R2,
        R3,
        None
    }

    public static class Extensions
    {
        public static string GetRegisterText(this Register reg)
        {
            switch (reg)
            {
                case Register.R0:
                    return "00";
                case Register.R1:
                    return "01";
                case Register.R2:
                    return "10";
                case Register.R3:
                    return "11";
            }
            return string.Empty;
        }
    }
}