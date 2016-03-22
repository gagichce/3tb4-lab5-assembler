using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _3tb4_lab5_assembler
{
    public class MifExporter
    {

        public void Export(List<byte> machineCode, string fileName = "instruction_rom.mif")
        {
            string formattedContents = String.Empty;
            var outputContents = new List<string>();

            for (int i = 0; i < machineCode.Count(); i++)
            {
                outputContents.Add(string.Format("\t{0}   :   {1};", i, machineCode[i]));
            }

            formattedContents = string.Join("\n", outputContents);

            formattedContents += string.Format("\n\t[{0}..255]  :   0;", machineCode.Count()); //fileend

            File.WriteAllText(fileName, _head + formattedContents + _tail);
        }

        private string _head =
            @"-- Copyright (C) 1991-2013 Altera Corporation
-- Your use of Altera Corporation's design tools, logic functions 
-- and other software and tools, and its AMPP partner logic 
-- functions, and any output files from any of the foregoing 
-- (including device programming or simulation files), and any 
-- associated documentation or information are expressly subject 
-- to the terms and conditions of the Altera Program License 
-- Subscription Agreement, Altera MegaCore Function License 
-- Agreement, or other applicable license agreement, including, 
-- without limitation, that your use is for the sole purpose of 
-- programming logic devices manufactured by Altera and sold by 
-- Altera or its authorized distributors.  Please refer to the 
-- applicable agreement for further details.

-- Quartus II generated Memory Initialization File (.mif)
-- Generated with source code via gagichce

WIDTH=8;
DEPTH=256;

ADDRESS_RADIX=UNS;
DATA_RADIX=UNS;

CONTENT BEGIN
";

        private string _tail =
            @"
END;
";

    }
}