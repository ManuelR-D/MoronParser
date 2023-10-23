using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoronParser.Querier
{
    public class HtmlAgilityPackQuerier : IHttpQuerier
    {
        public HtmlDocument GetDocument(Uri url)
        {
            HtmlWeb htmlWeb = new HtmlWeb();
            return htmlWeb.Load(url);
        }
    }
}
