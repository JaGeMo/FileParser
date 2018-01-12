using System;
using System.Collections.Generic;
using System.Text;

namespace Fileparser
{
    class CleanseRawInput
    {
        public void CleanseRawList(ref List<string> rawStringList)
        {
            rawStringList.RemoveAll(x => !x.Contains("{"));
            rawStringList.RemoveAll(x => !x.Contains("begin request"));
            rawStringList.RemoveAll(x => x.Contains("\"none\""));
        }
    }
}
