using System.Collections.Generic;
using System.IO;
using System.Linq;
using _3tb4_lab5_assembler.Instructions;

namespace _3tb4_lab5_assembler
{
    public class Assembler
    {
        private readonly List<string> _rawlines;
        private List<IAssemblyInstruction> instructions = new List<IAssemblyInstruction>();
        public Assembler(string fileName)
        {
            if (File.Exists(fileName))
            { _rawlines = File.ReadAllLines(fileName).Select(l => l.ToUpper()).ToList(); }
            else
            {
                throw new FileNotFoundException(string.Format("Could not find file: {0}", fileName));
            }
        }

        public void Assemble()
        {
            for (int i = 0; i < _rawlines.Count(); i++)
            {
                var rawLine = _rawlines[i];

                if (rawLine.Contains("#"))
                {
                    var index = rawLine.IndexOf('#');

                    rawLine = rawLine.Substring(0, index);
                }
                if (!string.IsNullOrWhiteSpace(rawLine))

                    switch (rawLine.Split(' ', ',')[0])
                    {
                        case "CLR":
                            instructions.Add(new CLR(rawLine, i));
                            break;

                        case "BR":
                        case "BRZ":
                            instructions.Add(new BRX(rawLine, i));
                            break;

                        case "MOV":
                            instructions.Add(new MOV(rawLine, i));
                            break;

                        case "MOVA":
                        case "MOVR":
                        case "MOVRHS":
                            instructions.Add(new MOVX(rawLine, i));
                            break;

                        case "SR0":
                        case "SRH0":
                            instructions.Add(new SRX(rawLine, i));
                            break;

                        case "PAUSE":
                            instructions.Add(new PAUSE(rawLine, i));
                            break;

                        case "ADDI":
                        case "SUBI":
                            instructions.Add(new ADDSUBX(rawLine, i));
                            break;

                        default:
                            Program.errorList.Add(Helpers.GetErrorMessageWithLineNumber(i, rawLine));
                            break;
                    }
            }
        }

        public List<byte> GetByteCodeProgram()
        {
            return instructions.Select(l => l.GetLineMachineCode()).ToList();
        }
    }
}