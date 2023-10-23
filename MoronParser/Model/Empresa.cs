namespace MoronParser.Model
{
    public struct Empresa
    {
        public string RazonSocial { get; set; }
        public string NombreFantasia { get; set; }
        public DateOnly FechaDeAlta { get; set; }
        public string TipoDeProveedor { get; set; }
        public string Cuit { get; set; }

        public Empresa(string razonSocial, string nombreFantasia, DateOnly fechaDeAlta, string tipoDeProveedor, string cuit)
        {
            RazonSocial = razonSocial;
            NombreFantasia = nombreFantasia;
            FechaDeAlta = fechaDeAlta;
            TipoDeProveedor = tipoDeProveedor;
            Cuit = cuit;
        }
    }
}