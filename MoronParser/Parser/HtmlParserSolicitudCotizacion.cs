using HtmlAgilityPack;
using MoronParser.Model;
using MoronParser.Parser.Abstraction;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MoronParser.Parser
{
    public class HtmlParserSolicitudCotizacion : IHtmlParser<SolicitudCotizacion>
    {
        public SolicitudCotizacion Parse(HtmlDocument document)
        {
            var h3 = document.DocumentNode.Descendants("h3").ToList()[0];
            string numeroSolicitudCotizacion = h3.InnerText.Substring(h3.InnerText.Length - 13).Trim();
            var tdValues = document.DocumentNode.Descendants("td")
                .Select(td => td.InnerText.Trim())
                .ToList();

            List<Item> items = new List<Item>();
            for (int i = 0; i + 3 < tdValues.Count; i += 4)
            {
                items.Add(new Item()
                {
                    Id = int.Parse(tdValues[i]),
                    Cantidad = float.Parse(tdValues[i + 1]),
                    UnidadDeMedida = tdValues[i + 2],
                    DescripcionArticulo = tdValues[i + 3]
                });
            }

            var result = new SolicitudCotizacion();
            result.Items = items;

            result = this.ParseHeader(document, result);
            result = this.ParseFooter(document, result);
            result.NumeroSolicitudCotizacion = numeroSolicitudCotizacion;
            return result;
        }

        private SolicitudCotizacion ParseFooter(HtmlDocument document, SolicitudCotizacion result)
        {
            var table = document.DocumentNode.Descendants("table")
                .ToList();

            var sibling = table[0].NextSibling;

            while (sibling != null && (sibling.InnerText == "" || sibling.InnerText == "\n"))
                sibling = sibling.NextSibling;

            sibling = sibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling;
            string plazoEntrega = sibling.InnerText;
            
            sibling = sibling.NextSibling.NextSibling;
            while (sibling != null && (sibling.InnerText == "" || sibling.InnerText == "\n"))
                sibling = sibling.NextSibling;
            string mantenimientoOferta = sibling.NextSibling.NextSibling.InnerText;
            
            sibling = sibling.NextSibling.NextSibling.NextSibling;
            while (sibling != null && (sibling.InnerText == "" || sibling.InnerText == "\n"))
                sibling = sibling.NextSibling;
            string condicionesPago = sibling.NextSibling.NextSibling.InnerText;

            sibling = sibling.NextSibling.NextSibling.NextSibling;
            while (sibling != null && (sibling.InnerText == "" || sibling.InnerText == "\n"))
                sibling = sibling.NextSibling;
            string lugarEntrega = sibling.NextSibling.NextSibling.InnerText;

            sibling = sibling.NextSibling.NextSibling.NextSibling;
            while (sibling != null && (sibling.InnerText == "" || sibling.InnerText == "\n"))
                sibling = sibling.NextSibling;
            string observaciones = sibling.NextSibling.NextSibling.InnerText;

            result.PlazoEntrega = plazoEntrega.Trim();
            result.LugarEntrega = lugarEntrega.Trim();
            result.CondicionesDePago = condicionesPago.Trim();
            result.Observaciones = observaciones.Trim();
            result.MantenimientoOferta = mantenimientoOferta.Trim();
            return result;
        }
        private SolicitudCotizacion ParseHeader(HtmlDocument document, SolicitudCotizacion result)
        {
            var table = document.DocumentNode.Descendants("b")
                .ToList();

            var sibling = table[0].NextSibling;

            while (sibling != null && (sibling.InnerText == "" || sibling.InnerText == "\n"))
                sibling = sibling.NextSibling;

            sibling = sibling.NextSibling.NextSibling.NextSibling.NextSibling;
            int pedidoDeSuministro = int.Parse(sibling.InnerText.Substring(0,sibling.InnerText.Length-1));

            while (sibling != null && (sibling.InnerText == "" || sibling.InnerText == "\n"))
                sibling = sibling.NextSibling;

            sibling = sibling.NextSibling.NextSibling.NextSibling.NextSibling;

            string dependenciaSolicitante = sibling.InnerText;

            result.DependenciaSolicitante = dependenciaSolicitante.Trim();
            result.PedidoSuministro = pedidoDeSuministro;
            return result;
        }
    }
}
