using HtmlAgilityPack;
using MoronParser.Model;
using MoronParser.Parser.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoronParser.Parser
{
    public class HtmlParserDetalleOrdenDeCompra : IHtmlTableParser<DetalleOC>
    {
        public IList<DetalleOC> Parse(HtmlDocument document)
        {
            List<DetalleOC> detalleOCs = new List<DetalleOC>();
            var tdValues = document.DocumentNode.Descendants("td")
                .Select(td => td.InnerText.Trim())
                .ToList();

            for (int i = 0; i + 5 < tdValues.Count; i+=6)
            {
                int renglon = int.Parse(tdValues[i]);
                int cantidad = int.Parse(tdValues[i+1]);
                string uom = tdValues[i+2];
                string descripcion = tdValues[i+3];
                long precioUnitario = long.Parse(tdValues[i+4].Replace(",",""));
                DetalleOC detalle = new DetalleOC()
                {
                    UnidadDeMedida = uom,
                    Descripcion = descripcion,
                    Cantidad = cantidad,
                    ImporteUnitario = precioUnitario,
                    Renglon = renglon
                };

                Console.WriteLine( $"{renglon}, {cantidad}, {uom}, {descripcion}, {precioUnitario}" );

                detalleOCs.Add(detalle);
            }

            return detalleOCs;
        }
    }
}
