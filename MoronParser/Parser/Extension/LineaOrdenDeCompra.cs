using MoronParser.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoronParser.Parser.Extension
{
    // Orden de compra como se la presenta en la pagina del municipio, sin seguir sus referencias.
    public struct LineaOrdenDeCompra
    {
        public int NumeroOrdenDeCompra { get; set; }
        public DateOnly FechaOrdenDeCompra { get; set; }
        public long ImporteOrdenDeCompra { get; set; }
        public Empresa Empresa { get; set; }
        public Uri DetalleOrdenDeCompraUrl { get; set; }
    }
}
