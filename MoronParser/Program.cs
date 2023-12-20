using HtmlAgilityPack;
using MoronParser.Model;
using MoronParser.Parser;
using MoronParser.Parser.Extension;
using MoronParser.Querier;
using Newtonsoft.Json;
using System.Reflection.Metadata;
using System.Text.Json;

namespace MoronParser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            for(int i = 2007; i < 2008; i++)
            {
                Console.WriteLine("Año: " + i);
                Uri uri = new Uri("https://apps.moron.gob.ar/ext/rafam_portal/compras/concluidas.php?trimestre=1&orden=A&crit=N&rubro=-1&anio=" + i);

                WriteYear(uri, i);
            }
        }

        static void WriteYear(Uri uri, int year)
        {
            HtmlWeb htmlWeb = new HtmlWeb();
            var doc = htmlWeb.Load(uri);
            var node = doc.GetElementbyId("lasClases");
            var doc2 = new HtmlDocument();
            doc2.LoadHtml(node.InnerHtml);
            Directory.CreateDirectory($"C:\\CompraConcluida\\{year}");

            var trValues = doc2.DocumentNode.Descendants("tr")
                .Select(td => td.InnerHtml)
                .ToList();

            HtmlParserCompraConcluida parser = new HtmlParserCompraConcluida();
            HtmlParserSolicitudCotizacion parserSolicitud = new HtmlParserSolicitudCotizacion();
            HtmlParserOrdenDeCompra parserOC = new HtmlParserOrdenDeCompra();
            HtmlParserDetalleOrdenDeCompra parserDOC = new HtmlParserDetalleOrdenDeCompra();
            SolicitudCotizacionHttpQuerier solicitudQuerier = new SolicitudCotizacionHttpQuerier();
            OrdenDeCompraHttpQuerier ocQuerier = new OrdenDeCompraHttpQuerier();
            DetalleOrdenDeCompraHttpQuerier detalleOcQuerier = new DetalleOrdenDeCompraHttpQuerier();
            List<CompraConcluida> compras = new List<CompraConcluida>();
            int totalCount = 0;
            int fromCache = 0;
            foreach (var tr in trValues)
            {
                HtmlDocument htmlDocument = new HtmlDocument();
                if (tr != null)
                {
                    htmlDocument.LoadHtml(tr);
                    try
                    {
                        totalCount += 1;
                        LineaCompraConcluida cc = parser.Parse(htmlDocument);

                        var htmlDocument2 = solicitudQuerier.GetDocument(cc.SolicitudCotizacionUrl);
                        SolicitudCotizacion cotizacion = parserSolicitud.Parse(htmlDocument2);
                        string pathToFile = $"C:\\CompraConcluida\\{year}\\{cotizacion.NumeroSolicitudCotizacion}.json";

                        if (File.Exists(pathToFile))
                        {
                            fromCache++;
                            Console.WriteLine(cotizacion.NumeroSolicitudCotizacion + " ya existe");
                            continue;
                        }

                        var htmlDocument3 = ocQuerier.GetDocument(cc.OrdenDeCompraUrl);

                        List<OrdenDeCompra> ordenDeCompras = new List<OrdenDeCompra>();
                        IList<LineaOrdenDeCompra> oc = parserOC.Parse(htmlDocument3);
                        foreach (var o in oc)
                        {
                            var htmlDocument4 = detalleOcQuerier.GetDocument(o.DetalleOrdenDeCompraUrl);

                            IList<DetalleOC> dOC = parserDOC.Parse(htmlDocument4);
                            OrdenDeCompra res = new OrdenDeCompra(o.NumeroOrdenDeCompra, o.FechaOrdenDeCompra, o.ImporteOrdenDeCompra, o.Empresa, dOC);
                            ordenDeCompras.Add(res);
                        }

                        CompraConcluida compra = new CompraConcluida(cotizacion, cc.FechaPublicacion, cc.FechaCierre, cc.Estado, cc.TipoDeCompra, ordenDeCompras);
                        string jsonString = JsonConvert.SerializeObject(compra);
                        File.WriteAllText(pathToFile, jsonString);
                        compras.Add(compra);
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }
                }
            }

            Console.WriteLine($"Se obtuvo de la cache {fromCache} de {totalCount}");
        }
    }
}