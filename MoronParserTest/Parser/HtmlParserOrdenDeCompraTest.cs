using HtmlAgilityPack;
using MoronParser.Parser;
using MoronParser.Parser.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoronParserTest.Parser
{
    [TestClass]
    public class HtmlParserOrdenDeCompraTest
    {
        [TestMethod]
        public void TestParser()
        {
            LineaOrdenDeCompra expected1 = new LineaOrdenDeCompra()
            {
                NumeroOrdenDeCompra = 705,
                FechaOrdenDeCompra = DateOnly.Parse("16/03/2007"),
                ImporteOrdenDeCompra = 56980,
                Empresa = new MoronParser.Model.Empresa()
                {
                    RazonSocial = "CERAMICA SANTA MARTA S.R.L.",
                    NombreFantasia = "CERAMICA SANTA MARTA S.R.L.",
                    FechaDeAlta = DateOnly.Parse("07/08/2003"),
                    TipoDeProveedor = "General",
                    Cuit = "30-66241997-0"
                }
            };
            LineaOrdenDeCompra expected2 = new LineaOrdenDeCompra()
            {
                NumeroOrdenDeCompra = 704,
                FechaOrdenDeCompra = DateOnly.Parse("16/03/2007"),
                ImporteOrdenDeCompra = 124471,
                Empresa = new MoronParser.Model.Empresa()
                {
                    RazonSocial = "FERDOM S.R.L.",
                    NombreFantasia = "FERDOM S.R.L.",
                    FechaDeAlta = DateOnly.Parse("24/05/2006"),
                    TipoDeProveedor = "General",
                    Cuit = "30-70343456-4"
                }
            };
            string fileName = "OrdenDeCompraTable.html";
            string filePath = Path.Combine("../../../Resources", fileName);

            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.Load(filePath, Encoding.UTF8);

            HtmlParserOrdenDeCompra oc = new HtmlParserOrdenDeCompra();
            IList<LineaOrdenDeCompra> result = oc.Parse(htmlDocument);

            var frame1 = result[0];
            var frame2 = result[1];

            AreOCFramesEqual(expected1, frame1);
            AreOCFramesEqual(expected2, frame2);
        }

        private static bool AreOCFramesEqual(LineaOrdenDeCompra expected, LineaOrdenDeCompra actual)
        {
            Assert.AreEqual(expected.NumeroOrdenDeCompra, actual.NumeroOrdenDeCompra);
            Assert.AreEqual(expected.FechaOrdenDeCompra, actual.FechaOrdenDeCompra);
            Assert.AreEqual(expected.ImporteOrdenDeCompra, actual.ImporteOrdenDeCompra);
            Assert.AreEqual(expected.Empresa.RazonSocial, actual.Empresa.RazonSocial);
            Assert.AreEqual(expected.Empresa.NombreFantasia, actual.Empresa.NombreFantasia);
            Assert.AreEqual(expected.Empresa.Cuit, actual.Empresa.Cuit);
            Assert.AreEqual(expected.Empresa.FechaDeAlta, actual.Empresa.FechaDeAlta);
            Assert.AreEqual(expected.Empresa.TipoDeProveedor, actual.Empresa.TipoDeProveedor);
            return true;
        }
    }
}
