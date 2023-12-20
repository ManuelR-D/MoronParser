using CEOParser.Model;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CEOParser.Parser
{
    public class TimelineParser
    {
        public List<Timeline> Parse(HtmlDocument doc)
        {

            HtmlNodeCollection scriptNode = doc.DocumentNode.SelectNodes("//script");
            foreach (var node in scriptNode)
            {
                if (node.InnerText.Length > 0)
                {
                    int initIdx = node.InnerText.IndexOf("const societies = ") + 18;
                    int endIdx = node.InnerText.IndexOf("}];");
                    if (endIdx <= 0)
                    {
                        continue;
                    }

                    string serializedData = node.InnerText.Substring(initIdx, endIdx - initIdx + 2);
                    var jsonSerializerOptions = new JsonSerializerOptions
                    {
                        Converters = { new DateOnlyJsonConverter() }
                    };

                    return JsonSerializer.Deserialize<List<Timeline>>(serializedData, jsonSerializerOptions);
                }
            }

            return new List<Timeline>();
        }
    }
}
