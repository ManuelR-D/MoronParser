using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoronParser.Querier
{
    public interface IHttpQuerier
    {
        HtmlDocument GetDocument(Uri url);
    }
}
