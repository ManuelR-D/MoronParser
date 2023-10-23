using MoronParser.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoronParser.Parser.Extension
{
    public struct LineaCompraConcluida
    {
        public DateTime FechaPublicacion { get; set; }
        public DateTime FechaCierre { get; set; }
        public string Estado { get; set; }
        public TipoDeCompra TipoDeCompra { get; set; }
        public Uri SolicitudCotizacionUrl { get; set; }
        public Uri OrdenDeCompraUrl { get; set; }
    }
}
