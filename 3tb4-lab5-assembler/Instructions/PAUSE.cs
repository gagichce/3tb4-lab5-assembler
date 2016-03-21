using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3tb4_lab5_assembler.Instructions
{
    public class PAUSE : AssemblyInstruction
    {
        public PAUSE(string rawLine, int lineNumber)
            : base(rawLine, lineNumber)
        {
            instructionId = "11111111";
        }
        public override byte GetLineMachineCode()
        {
            return Helpers.GetByteFromBoolString(instructionId);
        }

        public override bool isValidPre()
        {
            return (rawSymbols.Any() && rawSymbols.Count() <= 1);
        }

        public override bool isValidPost()
        {
            return true;
        }
    }
}
