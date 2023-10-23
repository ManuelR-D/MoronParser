using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoronParser.Querier
{
    public class OrdenDeCompraHttpQuerier : IHttpQuerier
    {
        private IHttpQuerier _querier;

        public OrdenDeCompraHttpQuerier()
        {
            _querier = new HtmlAgilityPackQuerier();
        }

        public OrdenDeCompraHttpQuerier(IHttpQuerier querier)
        {
            _querier = querier;
        }

        //https://apps.moron.gob.ar/ext/rafam_portal/compras/resumen.php?trimestre=1&rubro=-1&nro=%200001&anio=2007&llamado=1
        public HtmlDocument GetDocument(Uri url)
        {
            var doc = _querier.GetDocument(url);
            var divBuscador = doc.GetElementbyId("buscador");
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(divBuscador.InnerHtml);
            return htmlDocument;
        }
    }
}
