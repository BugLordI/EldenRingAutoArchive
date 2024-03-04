using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Gameloop.Vdf;
using Gameloop.Vdf.JsonConverter;
using Gameloop.Vdf.Linq;

namespace SteamTool
{
    internal class SteamFilePaser
    {
        public static Dictionary<string, object> parseACF(string filePath)
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

        public static List<LibraryFolder> parseVDF(string filePath)
        {
            VProperty volvo = VdfConvert.Deserialize(File.ReadAllText(filePath));
            Newtonsoft.Json.Linq.JProperty property = volvo.ToJson();
            List<LibraryFolder> folders = new List<LibraryFolder>();
            foreach (Newtonsoft.Json.Linq.JProperty item in property.Value)
            {
                folders.Add(item.Value.ToObject<LibraryFolder>());
            }
            return folders;
        }

    }
}
