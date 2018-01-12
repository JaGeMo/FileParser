using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Fileparser
{
    class WriteOutput
    {
        public void WriteToFile(ref List<string> finalListPriorToOutput, ref List<string>cleansedLog)
        {
            string outputFile = Environment.GetEnvironmentVariable("outputFile");
            string outputLog = Environment.GetEnvironmentVariable("outputLog");
            if (File.Exists(outputFile)) File.Delete(outputFile);
            if (File.Exists(outputLog)) File.Delete(outputLog);

            File.WriteAllLines(outputFile, finalListPriorToOutput);
            File.WriteAllLines(outputLog, cleansedLog);
        }
    }
}
