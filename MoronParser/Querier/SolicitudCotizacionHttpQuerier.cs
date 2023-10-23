using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoronParser.Querier
{
    public class SolicitudCotizacionHttpQuerier : IHttpQuerier
    {
        private IHttpQuerier _querier;

        public SolicitudCotizacionHttpQuerier()
        {
            _querier = new HtmlAgilityPackQuerier();
        }

        public SolicitudCotizacionHttpQuerier(IHttpQuerier querier)
        {
            _querier = querier;
        }

        public HtmlDocument GetDocument(Uri url)
        {
            var doc = _querier.GetDocument(url);
            var divContenido = doc.DocumentNode.Descendants("div")
                            .FirstOrDefault(d => d.GetAttributeValue("class", "") == "contenido");

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(divContenido.InnerHtml);
            return htmlDocument;
        }
    }
}
