using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEOParser.Model
{
    public class Empresa
    {
        public string razonSocial;
        public string cuit;
        public IDictionary<string, string> directorio = new Dictionary<string, string>();

        public Empresa(string razonSocial, string cuit)
        {
            this.razonSocial = razonSocial;
            this.cuit = cuit;
        }
    }
}
