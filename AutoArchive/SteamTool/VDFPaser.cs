using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace SteamTool
{
    internal class VDFPaser
    {
        public static Dictionary<string, object> parseVdf(string filePath)
        {
            var result = new Dictionary<string, object>();
            var currentDict = result;
            var stack = new Stack<Dictionary<string, object>>();
            string content = File.ReadAllText(filePath);
            var matches = Regex.Matches(content, @"(?<key>""[^""]+"")\s*""(?<value>[^""]+)""|(?<blockstart>\{(?<blockname>[^\s}]+)\s*)(?<blockend>\})");
            foreach (Match match in matches)
            {
                if (match.Groups["blockstart"].Success)
                {
                    var newDict = new Dictionary<string, object>();
                    currentDict[match.Groups["blockname"].Value] = newDict;
                    stack.Push(currentDict);
                    currentDict = newDict;
                }
                else if (match.Groups["blockend"].Success)
                {
                    currentDict = stack.Count > 0 ? stack.Pop() : result;
                }
                else if (match.Groups["key"].Success && match.Groups["value"].Success)
                {
                    currentDict[match.Groups["key"].Value.Trim('"')] = match.Groups["value"].Value.Trim('"');
                }
            }
            return result;
        }
    }
}
