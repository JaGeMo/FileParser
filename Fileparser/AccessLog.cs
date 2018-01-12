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

            string pat1 = @"/dataservice(.*) HTTP/1.1";
            string pat2 = @"HTTP/1.1(.*)""";
            Regex r1 = new Regex(pat1, RegexOptions.IgnoreCase);
            Regex r2 = new Regex(pat2, RegexOptions.IgnoreCase);


            cleansedLog.Add("time;code;url");
            foreach (string tmpString in rawAccessLog)
            {
                string tmpStra = r1.Match(tmpString).ToString();
                string tmpStrb = r2.Match(tmpString).ToString().Substring(10,3);

                cleansedLog.Add(tmpString.Substring((tmpString.IndexOf(":") + 1), 8) + ";" + r1.Match(tmpString).ToString() + ";" + r2.Match(tmpString).ToString().Substring(10, 3));
            }
        }
    }
}
