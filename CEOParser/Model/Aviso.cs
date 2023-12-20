using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CEOParser.Model
{
    public class Aviso
    {
        [JsonPropertyName("accion")]
        public string Accion { get; set; }

        [JsonPropertyName("asuntos")]
        public List<string> Asuntos { get; set; }

        [JsonPropertyName("denominacion")]
        public string Denominacion { get; set; }

        [JsonPropertyName("denominacion_original")]
        public string DenominacionOriginal { get; set; }

        [JsonPropertyName("fecha_desde")]
        public DateOnly FechaDesde { get; set; }

        [JsonPropertyName("fecha_hasta")]
        public DateOnly FechaHasta { get; set; }

        [JsonPropertyName("fecha_publicado")]
        public DateOnly FechaPublicado { get; set; }

        [JsonPropertyName("id_aviso")]
        public string IdAviso { get; set; }

        [JsonPropertyName("id_rubro")]
        public int IdRubro { get; set; }

        [JsonPropertyName("nuevo")]
        public bool Nuevo { get; set; }

        [JsonPropertyName("rubro")]
        public string Rubro { get; set; }

        [JsonPropertyName("tags")]
        public Tags Tags { get; set; }
    }

    public class Tags
    {
        [JsonPropertyName("autoridad_designada")]
        public List<string> AutoridadDesignada { get; set; }

        [JsonPropertyName("cuit")]
        public List<string> Cuit { get; set; }

        [JsonPropertyName("direccion_sociedad")]
        public List<string> DireccionSociedad { get; set; }

        [JsonPropertyName("dni")]
        public List<string> Dni { get; set; }

        [JsonPropertyName("fecha_constitucion")]
        public List<string> FechaConstitucion { get; set; }

        [JsonPropertyName("firmante")]
        public List<string> Firmante { get; set; }

        [JsonPropertyName("integrante")]
        public List<string> Integrante { get; set; }

        [JsonPropertyName("integrante_renunciante")]
        public List<string> IntegranteRenunciante { get; set; }

        [JsonPropertyName("objeto_social")]
        public List<string> ObjetoSocial { get; set; }
    }
}
