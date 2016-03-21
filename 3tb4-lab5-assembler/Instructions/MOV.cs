using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3tb4_lab5_assembler.Instructions
{
    public class MOV : AssemblyInstruction
    {
        private Register destinationRegister;
        public MOV(string rawLine, int lineNumber)
            : base(rawLine, lineNumber)
        {
            instructionId = "0111";

            if (isValidPre())
            {
                register = Helpers.GetRegister(rawSymbols[2]);
                destinationRegister = Helpers.GetRegister(rawSymbols[1]);
            }
            else if (!isValidPost())
            {
                Program.errorList.Add(Helpers.GetErrorMessageWithLineNumber(lineNumber, rawLine, "Register was not found or syntax incorrect"));
            }
        }
        public override byte GetLineMachineCode()
        {
            return Helpers.GetByteFromBoolString(instructionId + destinationRegister.GetRegisterText() + register.GetRegisterText());
        }

        public override bool isValidPre()
        {
            return (rawSymbols.Count() == 3);
        }

        public override bool isValidPost()
        {
            return register != Register.None && destinationRegister != Register.None;
        }
    }
}
