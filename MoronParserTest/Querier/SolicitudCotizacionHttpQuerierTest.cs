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
    public class SolicitudCotizacionHttpQuerierTest
    {
        [TestMethod]
        public void TestQuerier()
        {
            Mock<IHttpQuerier> mockQuerier = new Mock<IHttpQuerier>();
            string fileName = "FullPageSolicitudCotizacion.html";
            string filePath = Path.Combine("../../../Resources", fileName);
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.Load(filePath);

            mockQuerier.Setup(querier => querier.GetDocument(It.IsAny<Uri>()))
                .Returns(htmlDocument);

            SolicitudCotizacionHttpQuerier test = new SolicitudCotizacionHttpQuerier(mockQuerier.Object);
            var x = test.GetDocument(new Uri("http://fakeurl.com"));

            HtmlParserSolicitudCotizacion parser = new HtmlParserSolicitudCotizacion();
            var result = parser.Parse(x);

            Assert.IsNotNull(result);
            Assert.AreEqual(8, result.Items.Count);
        }
    }
}
