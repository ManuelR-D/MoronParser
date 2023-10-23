using HtmlAgilityPack;
using MoronParser.Model;
using MoronParser.Parser;
using MoronParser.Parser.Extension;
using Xunit.Sdk;

namespace MoronParserTest.Parser
{
    [TestClass]
    public class HtmlParserCompraConcluidaTest
    {
        [TestMethod]
        public void TestParse()
        {
            string fileName = "CompraConcluidaTable.html";
            string filePath = Path.Combine("../../../Resources", fileName);

            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.Load(filePath);

            HtmlParserCompraConcluida htmlParserCompraConcluida = new HtmlParserCompraConcluida();
            LineaCompraConcluida compra = htmlParserCompraConcluida.Parse(htmlDocument);

            Assert.IsNotNull(compra);
            Assert.AreEqual(compra.FechaPublicacion, DateTime.Parse("02/01/2007 02:21:38 PM"));
            Assert.AreEqual(compra.FechaCierre, DateTime.MinValue);
            Assert.AreEqual(compra.Estado, "Orden de compra emitida");
            Assert.AreEqual(compra.TipoDeCompra, TipoDeCompra.LPUB);
        }
    }
}