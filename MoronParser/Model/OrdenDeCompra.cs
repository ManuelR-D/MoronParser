using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoronParser.Model
{
    public struct DetalleOC
    {
        public int Renglon { get; set; }
        public int Cantidad { get; set; }
        public string UnidadDeMedida { get; set; }
        public string Descripcion { get; set; }
        public long ImporteUnitario { get; set; }
        public long ImporteTotal { get => ImporteUnitario * Cantidad; }
    }
    public class OrdenDeCompra
    {
        public int NumeroOrdenDeCompra { get; set; }
        public DateOnly FechaOrdenDeCompra { get; set; }
        public long ImporteOrdenDeCompra { get; set; }
        public Empresa Empresa { get; set; }
        public IList<DetalleOC> DetalleOC { get; set; }

        public OrdenDeCompra(int numeroOrdenDeCompra, DateOnly fechaOrdenDeCompra, long importeOrdenDeCompra, Empresa empresa, IList<DetalleOC> detalleOC)
        {
            NumeroOrdenDeCompra = numeroOrdenDeCompra;
            FechaOrdenDeCompra = fechaOrdenDeCompra;
            ImporteOrdenDeCompra = importeOrdenDeCompra;
            Empresa = empresa;
            DetalleOC = detalleOC;
        }
    }
}
