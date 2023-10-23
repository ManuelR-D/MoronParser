using HtmlAgilityPack;
using MoronParser.Model;
using MoronParser.Parser;
using MoronParser.Parser.Extension;
using System.Runtime.CompilerServices;
using System.Text;
using Xunit.Sdk;

namespace MoronParserTest.Parser
{
    [TestClass]
    public class HtmlParserSolicitudCotizacionTest
    {
        [TestMethod]
        public void TestParse()
        {
            SolicitudCotizacion expected = new SolicitudCotizacion()
            {
                NumeroSolicitudCotizacion = "2007- 0001-1",
                PedidoSuministro = 83,
                DependenciaSolicitante = "Departamento Mantenimiento  Vial.",
                Items = new List<Item>()
                {
                    new Item()
                    {
                        Id = 1,
                        Cantidad = 370.000f,
                        UnidadDeMedida = "TONELADA",
                        DescripcionArticulo = "ARENA - GRANULOMETRIA SILICEA FINA TIPO CONSTRUCCION - PRESENTACION A GRANEL"
                    },
                    new Item()
                    {
                        Id = 2,
                        Cantidad = 700.000f,
                        UnidadDeMedida = "TONELADA",
                        DescripcionArticulo = "PIEDRA PARTIDA - DIAMETRO DE 6 A 12 - PRESENTACION A GRANEL"
                    },
                    new Item()
                    {
                        Id = 3,
                        Cantidad = 800.000f,
                        UnidadDeMedida = "TONELADA",
                        DescripcionArticulo = "ARENA - GRANULOMETRIA GRANITICA DE 0/6 - LAVADA - PRESENTACION A GRANEL"
                    },
                    new Item()
                    {
                        Id = 4,
                        Cantidad = 60.000f,
                        UnidadDeMedida = "TONELADA",
                        DescripcionArticulo = "CEMENTO PORTLAND - TIPO COMPUESTO - PRESENTACION A GRANEL"
                    },
                    new Item()
                    {
                        Id = 5,
                        Cantidad = 90.000f,
                        UnidadDeMedida = "TONELADA",
                        DescripcionArticulo = "PIEDRA PARTIDA - DIAMETRO 10 A 30 - PRESENTACION A GRANEL"
                    },
                    new Item()
                    {
                        Id = 6,
                        Cantidad = 130.000f,
                        UnidadDeMedida = "TONELADA",
                        DescripcionArticulo = "PIEDRA PARTIDA - DIAMETRO 6 A 20 - PRESENTACION A GRANEL"
                    },
                    new Item()
                    {
                        Id = 7,
                        Cantidad = 2.000f,
                        UnidadDeMedida = "TAMBOR",
                        DescripcionArticulo = "ACELERANTE DE FRAGÜE - CLASE ADITIVO DE ENDURECIMIENTO Y PLASTIFICANTE - PRESENTACION TAMBOR x 220 KG - TIPO SIKACRETE C"
                    },
                    new Item()
                    {
                        Id = 8,
                        Cantidad = 1100.000f,
                        UnidadDeMedida = "BOLSA",
                        DescripcionArticulo = "CAL - PRESENTACION BOLSA x 25 KG - USO CONSTRUCCION - HIDRAULICA HIDRATADA / COMUN - TIPO VICAT"
                    },
                },
                PlazoEntrega = "1 Día. Parciales",
                MantenimientoOferta = "2 Meses.",
                CondicionesDePago = "10 Días.",
                LugarEntrega = "Secretaría de Obras y Servicios Públicos Mazza entre Río Gallardo y Santa Maria 2300   Moron.",
                Observaciones = "MATERIALES VARIOS PARA REPARACION DE DISTINTAS CALLES DEL PARTIDO."
            };
            string fileName = "SolicitudCotizacionTable.html";
            string filePath = Path.Combine("../../../Resources", fileName);

            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.Load(filePath, Encoding.Latin1);

            HtmlParserSolicitudCotizacion htmlParserCompraConcluida = new HtmlParserSolicitudCotizacion();
            var solicitudCotizacion = htmlParserCompraConcluida.Parse(htmlDocument);

            AssertAreSolicitudCotizacionEqual(expected, solicitudCotizacion);
        }

        private static bool AssertAreSolicitudCotizacionEqual(SolicitudCotizacion expected, SolicitudCotizacion actual)
        {
            Assert.AreEqual(expected.DependenciaSolicitante, actual.DependenciaSolicitante);
            Assert.AreEqual(expected.NumeroSolicitudCotizacion, actual.NumeroSolicitudCotizacion);
            Assert.AreEqual(expected.Observaciones, actual.Observaciones);
            Assert.AreEqual(expected.LugarEntrega, actual.LugarEntrega);
            Assert.AreEqual(expected.CondicionesDePago, actual.CondicionesDePago);
            Assert.AreEqual(expected.MantenimientoOferta, actual.MantenimientoOferta);
            Assert.AreEqual(expected.PedidoSuministro, actual.PedidoSuministro);
            Assert.AreEqual(expected.Items.Count, actual.Items.Count);

            for (int i = 0; i < expected.Items.Count; i++)
            {
                Assert.AreEqual(expected.Items[i].Cantidad, actual.Items[i].Cantidad);
                Assert.AreEqual(expected.Items[i].DescripcionArticulo, actual.Items[i].DescripcionArticulo);
                Assert.AreEqual(expected.Items[i].Id, actual.Items[i].Id);
                Assert.AreEqual(expected.Items[i].UnidadDeMedida, actual.Items[i].UnidadDeMedida);
            }

            return true;
        }
    }
}