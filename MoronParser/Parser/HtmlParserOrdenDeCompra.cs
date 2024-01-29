using HtmlAgilityPack;
using MoronParser.Model;
using MoronParser.Parser.Abstraction;
using MoronParser.Parser.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MoronParser.Parser
{
    public class HtmlParserOrdenDeCompra : IHtmlTableParser<LineaOrdenDeCompra>
    {
        private const string Host = "https://apps.moron.gob.ar/ext/rafam_portal/compras/";

        public IList<LineaOrdenDeCompra> Parse(HtmlDocument document)
        {
            var empresas = ParseEmpresas(document);
            List<LineaOrdenDeCompra> ordenesDeCompra = ParseOC(document, empresas);

            return ordenesDeCompra;
        }

        private static List<LineaOrdenDeCompra> ParseOC(HtmlDocument document, List<Empresa> empresas)
        {
            List<LineaOrdenDeCompra> compras = new List<LineaOrdenDeCompra>();
            var tdValues = document.DocumentNode.Descendants("td")
                .Select(td => td.InnerText.Trim())
                .ToList();

            var aValues = document.DocumentNode.Descendants("a")
                .Where(a => a.Attributes.Contains("href"))
                .Select(a => a.Attributes["href"].Value)
                .ToList();

            for (int i = 0, j = 0; i + 4 < tdValues.Count; i += 5, j++)
            {
                int numeroOC = int.Parse(tdValues[i]);
                DateOnly fechaOC = DateOnly.Parse(tdValues[i+1]);
                long importeOtorgado = long.Parse(tdValues[i+2].Replace(",", "").Replace(".", ""));
                string uri = Host + aValues[j].Trim().Replace("&amp;","&");

                //Console.WriteLine($"{numeroOC}, {fechaOC}, {importeOtorgado}, {uri}");

                compras.Add(new LineaOrdenDeCompra()
                {
                    Empresa = empresas[j],
                    FechaOrdenDeCompra = fechaOC,
                    ImporteOrdenDeCompra = importeOtorgado,
                    NumeroOrdenDeCompra = numeroOC,
                    DetalleOrdenDeCompraUrl = new Uri(uri)
                });
            }

            return compras;
        }

        private List<Empresa> ParseEmpresas(HtmlDocument document)
        {
            var jsValues = document.DocumentNode.Descendants("script")
                .Select(td => td.InnerText.Trim())
                .ToList();
            string realJavascript = "";
            foreach (var js in jsValues)
            {
                if (!js.StartsWith("/*"))
                {
                    realJavascript = js;
                }
            }

            List<Empresa> empresas = new List<Empresa>();
            string[] tooltips = realJavascript.Split(';');
            foreach (var tooltip in tooltips)
            {
                if (tooltip != "")
                {
                    string htmlTooltip = tooltip.Split(",")[1].Trim();
                    htmlTooltip = htmlTooltip.Substring(1, htmlTooltip.Length - 2);
                    HtmlDocument doc = new HtmlDocument();
                    doc.LoadHtml(htmlTooltip);

                    var labelNodes = doc.DocumentNode.Descendants("h2")
                        .ToList();
                    
                    string razonSocial = labelNodes[0].NextSibling.InnerHtml.Trim();
                    string nombreFantasia = labelNodes[1].NextSibling.InnerHtml.Trim();
                    DateOnly fechaAlta = DateOnly.Parse(labelNodes[2].NextSibling.InnerHtml);
                    string tipoProveedor = labelNodes[3].NextSibling.InnerHtml.Trim();
                    string cuit = labelNodes[4].NextSibling.InnerHtml.Trim();
                    Empresa empr = new Empresa(razonSocial, nombreFantasia, fechaAlta, tipoProveedor, cuit);
                    
                    empresas.Add(empr);
                }
            }

            return empresas;
        }
    }
}
