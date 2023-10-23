using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoronParser.Model
{

    public class CompraConcluida
    {
        public SolicitudCotizacion SolicitudCotizacion{ get; set; }
        public DateTime FechaPublicacion { get; set; }
        public DateTime FechaCierre { get; set; }
        public string Estado { get; set; }
        public TipoDeCompra TipoDeCompra { get; set; }
        public List<OrdenDeCompra> OrdenesDeCompra { get; set; }
    
        public CompraConcluida(SolicitudCotizacion solicitudCotizacion, DateTime fechaPublicacion, DateTime fechaCierre, string estado, TipoDeCompra tipoDeCompra, List<OrdenDeCompra> ordenesDeCompra)
        {
            SolicitudCotizacion = solicitudCotizacion;
            FechaPublicacion = fechaPublicacion;
            FechaCierre = fechaCierre;
            Estado = estado;
            TipoDeCompra = tipoDeCompra;
            OrdenesDeCompra = ordenesDeCompra;
        }
    }
}
