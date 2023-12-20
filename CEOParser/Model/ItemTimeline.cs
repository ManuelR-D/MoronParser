using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CEOParser.Model
{
    public class ItemTimeline
    {
        [JsonPropertyName("avisos")]
        public List<Aviso> Avisos { get; set; }

        [JsonPropertyName("fecha_desde")]
        public DateOnly FechaDesde { get; set; }

        [JsonPropertyName("fecha_hasta")]
        public DateOnly FechaHasta { get; set; }
    }
}
