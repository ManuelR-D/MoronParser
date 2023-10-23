using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoronParser.Model
{
    public struct Item
    {
        public int Id { get; set; }
        public float Cantidad { get; set; }
        public string UnidadDeMedida { get; set; }
        public string DescripcionArticulo { get; set; }
    }
}
