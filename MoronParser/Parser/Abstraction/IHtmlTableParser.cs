using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoronParser.Parser.Abstraction
{
    internal interface IHtmlTableParser<T>
    {
        IList<T> Parse(HtmlDocument html);
    }
}
