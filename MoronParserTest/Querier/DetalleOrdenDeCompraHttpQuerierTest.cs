using HtmlAgilityPack;
using Moq;
using MoronParser.Parser;
using MoronParser.Querier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoronParserTest.Querier
{
    [TestClass]
    public class DetalleOrdenDeCompraHttpQuerierTest
    {
        [TestMethod]
        public void TestDocument()
        {
            Mock<IHttpQuerier> mockQuerier = new Mock<IHttpQuerier>();
            string fileName = "FullPageDetalleOrdenDeCompra.html";
            string filePath = Path.Combine("../../../Resources", fileName);
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.Load(filePath);

            mockQuerier.Setup(querier => querier.GetDocument(It.IsAny<Uri>()))
                .Returns(htmlDocument);

            DetalleOrdenDeCompraHttpQuerier test = new DetalleOrdenDeCompraHttpQuerier(mockQuerier.Object);
            var x = test.GetDocument(new Uri("http://fakeurl.com"));

            HtmlParserDetalleOrdenDeCompra parser = new HtmlParserDetalleOrdenDeCompra();
            var result = parser.Parse(x);

            Assert.IsNotNull(result);
            Assert.AreEqual(7, result.Count);
        }
    }
}
