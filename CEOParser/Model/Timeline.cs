using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CEOParser.Model
{
    public class Timeline
    {
        [JsonPropertyName("indice")]
        public int Indice {  get; set; }
        
        [JsonPropertyName("items")]
        public List<ItemTimeline> Items {  get; set; }
        
        [JsonPropertyName("razon_social")]
        public string RazonSocial { get; set; }
        
        [JsonPropertyName("tipo")]
        public string Tipo { get; set; }

        [JsonPropertyName("total_avisos")]
        public int TotalAvisos { get; set; }
    }
}
