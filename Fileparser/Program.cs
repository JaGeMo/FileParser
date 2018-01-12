using System;
using System.Collections.Generic;

namespace Fileparser
{
    class Program
    {
        static void Main(string[] args)
        {
            // AppLog

            List<string> rawStringList = new List<string>();
            var readInput = new ReadInput();
            readInput.FillRawStringList(Environment.GetEnvironmentVariable("inputFile"), ref rawStringList);
            
            var parseInput = new CleanseRawInput();
            parseInput.CleanseRawList(ref rawStringList);

            var generateJson = new JSONParser();
            generateJson.ReplaceAtStrings(ref rawStringList);

            List<LoggingJSON> jsonObjectList = new List<LoggingJSON>();
            generateJson.GenerateJSON(ref rawStringList, ref jsonObjectList);

            List<string> finalListPriorToOutput = new List<string>();
            generateJson.GenerateFinaStringListPriorToOutput(ref jsonObjectList, ref finalListPriorToOutput);

            // AccessLog
            List<string> rawAccessLog = new List<string>();
            List<string> cleansedLog = new List<string>();
            readInput.FillRawAccessLog(Environment.GetEnvironmentVariable("inputLog"), ref rawAccessLog);

            AccessLog accessLog = new AccessLog();
            accessLog.CleanseAccessLog(ref rawAccessLog, ref cleansedLog);

            Console.WriteLine("press a button .. ");
            string line = Console.ReadLine();

            // Both
            WriteOutput output = new WriteOutput();
            output.WriteToFile(ref finalListPriorToOutput, ref cleansedLog);



        }
    }
}
