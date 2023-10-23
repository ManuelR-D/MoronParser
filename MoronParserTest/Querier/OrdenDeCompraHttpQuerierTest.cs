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
    public class OrdenDeCompraHttpQuerierTest
    {
        [TestMethod]
        public void TestDocument()
        {
            Mock<IHttpQuerier> mockQuerier = new Mock<IHttpQuerier>();
            string fileName = "FullPageOrdenDeCompra.html";
            string filePath = Path.Combine("../../../Resources", fileName);
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.Load(filePath);

            mockQuerier.Setup(querier => querier.GetDocument(It.IsAny<Uri>()))
                .Returns(htmlDocument);

            OrdenDeCompraHttpQuerier test = new OrdenDeCompraHttpQuerier(mockQuerier.Object);
            var x = test.GetDocument(new Uri("http://fakeurl.com"));

            HtmlParserOrdenDeCompra parser = new HtmlParserOrdenDeCompra();
            var result = parser.Parse(x);

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
        }
    }
}
