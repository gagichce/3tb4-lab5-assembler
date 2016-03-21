using System.Linq;

namespace _3tb4_lab5_assembler.Instructions
{
    public class CLR : AssemblyInstruction
    {
        public CLR(string rawLine, int lineNumber)
            : base(rawLine, lineNumber)
        {
            instructionId = "011000";

            if (isValidPre())
                register = Helpers.GetRegister(rawSymbols[1]);
            else if (!isValidPost())
            {
                Program.errorList.Add(Helpers.GetErrorMessageWithLineNumber(lineNumber, rawLine, "Register was not found or incorrect"));
            }
        }
        public override byte GetLineMachineCode()
        {
            return Helpers.GetByteFromBoolString(instructionId + register.GetRegisterText());
        }

        public override bool isValidPre()
        {
            return (rawSymbols.Any() && rawSymbols.Count() <= 2);
        }

        public override bool isValidPost()
        {
            return register != Register.None;
        }
    }
}