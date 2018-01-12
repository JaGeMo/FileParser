using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Fileparser
{
    class ReadInput
    {
        public void FillRawStringList(string fileLocationName, ref List<string> rawStringList)
        {
            if (checkFileExists(fileLocationName))
            {
                string[] tempRawStringList = File.ReadAllLines(fileLocationName);

                foreach (string singleRawString in tempRawStringList)
                {
                    rawStringList.Add(singleRawString);
                }
            }
        }

        private bool checkFileExists(string path)
        {
            return File.Exists(path); 
        }

        public void FillRawAccessLog(string fileLocationName, ref List<string> rawAccessLog)
        {
            if (checkFileExists(fileLocationName))
            {
                string[] tempLog = File.ReadAllLines(fileLocationName);

                foreach (string singleRawString in tempLog)
                {
                    rawAccessLog.Add(singleRawString);
                }
            }
        }

    }
}
