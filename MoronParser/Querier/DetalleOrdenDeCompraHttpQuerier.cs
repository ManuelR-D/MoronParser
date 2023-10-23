using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoronParser.Querier
{
    public class DetalleOrdenDeCompraHttpQuerier : IHttpQuerier
    {
        private IHttpQuerier _querier;
        public DetalleOrdenDeCompraHttpQuerier()
        {
            _querier = new HtmlAgilityPackQuerier();
        }

        public DetalleOrdenDeCompraHttpQuerier(IHttpQuerier querier)
        {
            _querier = querier;
        }

        public HtmlDocument GetDocument(Uri url)
        {
            var doc = _querier.GetDocument(url);
            var divBuscador = doc.GetElementbyId("lasClases");
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(divBuscador.InnerHtml);
            return htmlDocument;
        }
    }
}
