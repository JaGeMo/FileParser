using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Fileparser
{
    class JSONParser
    {

        public void ReplaceAtStrings(ref List<string> cleansedList)
        {
            cleansedList = cleansedList.Select(x => x.Replace("@mt", "Message").Replace("@t", "TimeStamp").Replace(",\"0\":", ",\"vUserKey\":")).ToList<string>();
        }

        public void GenerateJSON(ref List<string> cleansedList, ref List<LoggingJSON> jsonObjectList)
        {
            foreach(string jsonString in cleansedList)
            {
                LoggingJSON loggingObj = JsonConvert.DeserializeObject<LoggingJSON>(jsonString);
                jsonObjectList.Add(loggingObj);
            }
        }      
        

        public void GenerateFinaStringListPriorToOutput(ref List<LoggingJSON> jsonObjectList, ref List<string> finalListPriorToOutput)
        {
            string baseUrl = Environment.GetEnvironmentVariable("baseUrl");
            foreach (LoggingJSON loggingObj in jsonObjectList)
            {
                finalListPriorToOutput.Add(loggingObj.TimeStamp.Substring(11,11) + ";" + baseUrl + loggingObj.RequestPath + ";" + loggingObj.vUserKey);
            }

            string outputFile = Environment.GetEnvironmentVariable("outputFile");
            if (File.Exists(outputFile)) File.Delete(outputFile);
            File.WriteAllLines(outputFile, finalListPriorToOutput);
        }
    }   

    public class LoggingJSON
    {
        public string TimeStamp { get; set; }
        public string Message { get; set; }
        public string Caller { get; set; }
        public string vUserKey { get; set; }
        public string SourceContext { get; set; }
        public string service { get; set; }
        public string ActionID  { get; set; }
        public string ActionName { get; set; }
        public string RequestID { get; set; }
        public string RequestPath { get; set; }
        
    }
}
