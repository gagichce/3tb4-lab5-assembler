using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3tb4_lab5_assembler.Instructions
{
    public class SRX : AssemblyInstruction
    {
        public SRX(string rawLine, int lineNumber)
            : base(rawLine, lineNumber)
        {
            instructionId = "0100";
            if (rawSymbols[0] == "SRH0")
                instructionId = "0101";

            immediateLength = 4;

            if (isValidPre())
            {
                immediateByte = Helpers.GetBoolStringFromDecimal(rawSymbols[1], immediateLength);
            }
        }

        public override byte GetLineMachineCode()
        {
            return Helpers.GetByteFromBoolString(instructionId + immediateByte);
        }

        public override bool isValidPre()
        {
            return (rawSymbols.Any() && rawSymbols.Count() <= 2);
        }

        public override bool isValidPost()
        {
            return base.isValidPost();
        }
    }
}
