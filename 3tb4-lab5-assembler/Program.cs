using System;
using System.Collections.Generic;
using System.Linq;

namespace _3tb4_lab5_assembler
{
    class Program
    {
        public static List<string> errorList = new List<string>();
        static void Main(string[] args)
        {
            var assem = new Assembler(args[0]);

            assem.Assemble();

            var byteCode = assem.GetByteCodeProgram();

            if (errorList.Any())
            {
                Console.WriteLine("Program failed to assemble because of the following reasons:\n");
                errorList.ForEach(l =>
                {
                    Console.WriteLine("{0}\n", l);
                });
            }
            else
            {
                //export the bytes to the .mif file

                var exporter = new MifExporter();

                if (args.Length > 1)
                    exporter.Export(byteCode, args[1]);
                else
                    exporter.Export(byteCode);

                Console.WriteLine("Success.");
            }

            Console.WriteLine("Press any key to exit..");
            Console.ReadKey();
            return;
        }
    }
}
