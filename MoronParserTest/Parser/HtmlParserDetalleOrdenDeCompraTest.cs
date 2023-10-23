using HtmlAgilityPack;
using MoronParser.Model;
using MoronParser.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoronParserTest.Parser
{
    [TestClass]
    public class HtmlParserDetalleOrdenDeCompraTest
    {
        [TestMethod]
        public void TestParser()
        {
            List<DetalleOC> expectedOCs = new List<DetalleOC>()
            {
                new DetalleOC()
                {
                     Renglon = 1,
                     Cantidad = 370,
                     UnidadDeMedida = "TONELADA",
                     Descripcion = "ARENA - GRANULOMETRIA SILICEA FINA TIPO CONSTRUCCION - PRESENTACION A GRANEL comun",
                     ImporteUnitario = 3346
                },
                new DetalleOC()
                {
                     Renglon = 2,
                     Cantidad = 700,
                     UnidadDeMedida = "TONELADA",
                     Descripcion = "PIEDRA PARTIDA - DIAMETRO DE 6 A 12 - PRESENTACION A GRANEL  OLAVARRIA",
                     ImporteUnitario = 6055
                },
                new DetalleOC()
                {
                     Renglon = 3,
                     Cantidad = 800,
                     UnidadDeMedida = "TONELADA",
                     Descripcion = "ARENA - GRANULOMETRIA GRANITICA DE 0/6 - LAVADA - PRESENTACION A GRANEL OLAVARRIA",
                     ImporteUnitario = 4248
                },
                new DetalleOC()
                {
                     Renglon = 4,
                     Cantidad = 60,
                     UnidadDeMedida = "TONELADA",
                     Descripcion = "CEMENTO PORTLAND - TIPO COMPUESTO - PRESENTACION A GRANEL- AVELLANEDA LOMA NEGRA / MINETTI",
                     ImporteUnitario = 30390
                },
                new DetalleOC()
                {
                     Renglon = 5,
                     Cantidad = 90,
                     UnidadDeMedida = "TONELADA",
                     Descripcion = "PIEDRA PARTIDA - DIAMETRO 10 A 30 - PRESENTACION A GRANEL  OLAVARRIA",
                     ImporteUnitario = 5629
                },
                new DetalleOC()
                {
                     Renglon = 6,
                     Cantidad = 130,
                     UnidadDeMedida = "TONELADA",
                     Descripcion = "PIEDRA PARTIDA - DIAMETRO 6 A 20 - PRESENTACION A GRANEL OLAVARRIA",
                     ImporteUnitario = 5629
                },
                new DetalleOC()
                {
                     Renglon = 8,
                     Cantidad = 1100,
                     UnidadDeMedida = "BOLSA",
                     Descripcion = "CAL - PRESENTACION BOLSA x 25 KG - USO CONSTRUCCION - HIDRAULICA HIDRATADA / COMUN - PUNTA  CAL// VICAT// SARMIENTO",
                     ImporteUnitario = 464
                },
            };
            string fileName = "DetalleOrdenDeCompraTable.html";
            string filePath = Path.Combine("../../../Resources", fileName);

            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.Load(filePath, Encoding.UTF8);

            HtmlParserDetalleOrdenDeCompra oc = new HtmlParserDetalleOrdenDeCompra();
            IList<DetalleOC> detallesOrdenesDeCompra = oc.Parse(htmlDocument);

            Assert.AreEqual(expectedOCs.Count, detallesOrdenesDeCompra.Count);
            for (int i = 0; i < detallesOrdenesDeCompra.Count; i++)
            {
                AssertAreDetalleOCEqual(expectedOCs[i], detallesOrdenesDeCompra[i]);
            }
        }

        private static bool AssertAreDetalleOCEqual(DetalleOC expected,  DetalleOC actual)
        {
            Assert.AreEqual(expected.Descripcion, actual.Descripcion);
            Assert.AreEqual(expected.ImporteUnitario, actual.ImporteUnitario);
            Assert.AreEqual(expected.ImporteTotal, actual.ImporteTotal);
            Assert.AreEqual(expected.Renglon, actual.Renglon);
            Assert.AreEqual(expected.UnidadDeMedida, actual.UnidadDeMedida);
            Assert.AreEqual(expected.Cantidad, actual.Cantidad);
            return true;
        }
    }
}
