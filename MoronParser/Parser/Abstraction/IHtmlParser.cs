using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoronParser.Parser.Abstraction
{
    internal interface IHtmlParser<T>
    {
        T Parse(HtmlDocument document);
    }
}
