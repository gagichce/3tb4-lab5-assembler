using System;
using System.Collections.Generic;
using System.Linq;

namespace _3tb4_lab5_assembler
{
    public class AssemblyInstruction : IAssemblyInstruction
    {
        protected string immediateByte = "";
        protected byte immediateLength = 0;

        protected Register register = Register.None;

        protected string instructionId;
        protected string rawLine;
        protected List<string> rawSymbols;

        public AssemblyInstruction(string rawLine, int lineNumber)
        {
            this.rawLine = rawLine;

            this.rawSymbols = this.rawLine.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            if (!isValidPre())
            {
                //Program.errorList.Add(Helpers.GetErrorMessageWithLineNumber(lineNumber, rawLine));
            }
        }

        public virtual byte GetLineMachineCode()
        {
            throw new NotImplementedException();
        }

        public virtual bool isValidPre()
        {
            throw new NotImplementedException();
        }

        public virtual bool isValidPost()
        {
            throw new NotImplementedException();
        }
    }
}