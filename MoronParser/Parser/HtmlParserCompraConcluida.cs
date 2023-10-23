using HtmlAgilityPack;
using MoronParser.Model;
using MoronParser.Parser.Abstraction;
using MoronParser.Parser.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoronParser.Parser
{
    public class HtmlParserCompraConcluida : IHtmlParser<LineaCompraConcluida>
    {
        private const string Host = "https://apps.moron.gob.ar/ext/rafam_portal/compras/";

        public LineaCompraConcluida Parse(HtmlDocument document)
        {
            var tdValues = document.DocumentNode.Descendants("td")
                .Select(td => td.InnerText.Trim())
                .ToList();

            var aValues = document.DocumentNode.Descendants("a")
                .Where (a => a.Attributes.Contains("href"))
                .Select (a => a.Attributes["href"].Value)
                .ToList();

            DateTime fechaPublicacion = DateTime.Parse(tdValues[1]);
            DateTime fechaCierre = tdValues[2] == "" ? DateTime.MinValue : DateTime.Parse(tdValues[2]); 
            string estado = tdValues[3];
            TipoDeCompra tipoDeCompra = (TipoDeCompra)Enum.Parse(typeof(TipoDeCompra), tdValues[4]);
            string urlSolCotizDetalles = Host + aValues[0].Replace("&amp;", "&");
            string urlResumenOC = Host + aValues[1].Replace("&amp;","&");

            return new LineaCompraConcluida()
            {
                Estado = estado,
                FechaCierre = fechaCierre,
                FechaPublicacion = fechaPublicacion,
                OrdenDeCompraUrl = new Uri(urlResumenOC),
                SolicitudCotizacionUrl = new Uri(urlSolCotizDetalles),
                TipoDeCompra = tipoDeCompra
            };
        }
    }
}
