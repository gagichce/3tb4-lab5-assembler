using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;

namespace _3tb4_lab5_assembler.Instructions
{
    public class ADDSUBX : AssemblyInstruction
    {
        public ADDSUBX(string rawLine, int lineNumber)
            : base(rawLine, lineNumber)
        {
            instructionId = "000";
            if (rawSymbols[0] == "SUBI")
                instructionId = "001";

            immediateLength = 3;

            if (isValidPre())
            {
                register = Helpers.GetRegister(rawSymbols[1]);
                immediateByte = Helpers.GetBoolStringFromDecimal(rawSymbols[2], immediateLength);
            }
            else if (isValidPost())
            {
            }
            else
            {
                Program.errorList.Add(Helpers.GetErrorMessageWithLineNumber(lineNumber, rawLine,
                    "Register was not found or incorrect syntax"));

            }
        }
        public override byte GetLineMachineCode()
        {
            return Helpers.GetByteFromBoolString(instructionId + immediateByte + register.GetRegisterText());
        }

        public override bool isValidPre()
        {
            int temp;
            return (rawSymbols.Any() && rawSymbols.Count() <= 3) && int.TryParse(rawSymbols[2], out temp);
        }

        public override bool isValidPost()
        {
            return register != Register.None;
        }
    }
}
