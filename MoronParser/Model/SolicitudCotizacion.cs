using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoronParser.Model
{
    public struct SolicitudCotizacion
    {
        public string NumeroSolicitudCotizacion { get; set; }
        public int PedidoSuministro { get; set; }
        public string DependenciaSolicitante { get; set; }
        public List<Item> Items { get; set; }
        public string PlazoEntrega { get; set; }
        public string MantenimientoOferta { get; set; }
        public string CondicionesDePago { get; set; }
        public string LugarEntrega { get; set; }
        public string Observaciones { get; set; }
    }
}
