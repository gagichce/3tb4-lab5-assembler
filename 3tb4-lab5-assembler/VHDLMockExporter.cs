using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _3tb4_lab5_assembler
{
    public class VHDLMockExporter
    {

        public void Export(List<byte> machineCode, string fileName = "instruction_rom_mock.v")
        {
            string formattedContents = String.Empty;
            var outputContents = new List<string>();

            for (int i = 0; i < machineCode.Count(); i++)
            {
                outputContents.Add(string.Format("\t{0}   : q<={1};", i, machineCode[i]));
            }

            formattedContents = string.Join("\n", outputContents);

            //formattedContents += string.Format("\n\t[{0}..255]  :   0;", machineCode.Count()); //fileend

            File.WriteAllText(fileName, _head + formattedContents + _tail);
        }

        private string _head =
            @"module instruction_rom_mock (
	address,
	clock,
	q);

	input	[7:0]  address;
	input	  clock;
	output reg	[7:0]  q;

    always @ (*) begin
	case (address)

";      
        private string _tail =
@"
endcase
end
endmodule
";

    }
}