using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Fileparser
{
    class AccessLog
    {
        public void CleanseAccessLog(ref List<string> rawAccessLog, ref List<string> cleansedLog)
        {
            rawAccessLog.RemoveAll(x => !x.Contains("Generic EServiceClinet"));

            Regex r1 = new Regex(@"\/dataservice(.*?\s)");
            Regex r2 = new Regex(@"HTTP/1.1(.*)""");

            cleansedLog.Add("time;url;code");
            foreach (string tmpString in rawAccessLog)
            {
                cleansedLog.Add(tmpString.Substring((tmpString.IndexOf(":") + 1), 8) + ";" + r1.Match(tmpString).ToString() + ";" + r2.Match(tmpString).ToString().Substring(10, 3));
            }
        }
    }
}
