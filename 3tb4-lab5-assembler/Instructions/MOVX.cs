using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3tb4_lab5_assembler.Instructions
{
    public class MOVX : AssemblyInstruction
    {
        public MOVX(string rawLine, int lineNumber)
            : base(rawLine, lineNumber)
        {
            instructionId = "110000";
            if (rawSymbols[0] == "MOVR")
                instructionId = "110001";
            else if (rawSymbols[0] == "MOVRHS")
                instructionId = "110010";

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
