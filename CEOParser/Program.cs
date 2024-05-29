using CEOParser.Model;
using CEOParser.Parser;
using CEOParser.Querier;
using HtmlAgilityPack;
using MoronParser.Model;
using System.Runtime.Serialization.Json;
using System.Text.Json;

namespace CEOParser
{
    internal class Program
    {
        private static string TARGET_FOLDER = "C:\\Empresas\\CUIT";
        private static string COMPRAS_FOLDER = "C:\\CompraConcluida";
        static void Main(string[] args)
        {
            Directory.CreateDirectory($"{TARGET_FOLDER}");
            List<CompraConcluida> compras = new List<CompraConcluida>();
            var jsonSerializerOptions = new JsonSerializerOptions
            {
                Converters = { new DateOnlyJsonConverter("yyyy-MM-dd") }
            };
            for (int i = 2007; i < 2008; i++)
            {
                string[] filenames = Directory.GetFiles($"{COMPRAS_FOLDER}\\{i}");

                foreach (string filename in filenames)
                {
                    string content = File.ReadAllText(filename);
                    try
                    {
                        CompraConcluida compra = JsonSerializer.Deserialize<CompraConcluida>(content, jsonSerializerOptions);
                        compras.Add(compra);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(filename);
                    }
                }
            }



            HashSet<string> cuits = new HashSet<string>();
            foreach (CompraConcluida c  in compras)
            {
                foreach (OrdenDeCompra o in c.OrdenesDeCompra)
                {
                    cuits.Add(o.Empresa.Cuit);
                }
            }

            Console.WriteLine($"Empresas: {cuits.Count}");
            int totalCount = 0;
            int fromCache = 0;
            foreach (string cuit in cuits)
            {
                totalCount++;
                string path = $"{TARGET_FOLDER}\\{cuit.Replace('\\', ' ').Replace('/',' ')}.json";
                if (File.Exists(path))
                {
                    fromCache++;
                    continue;
                }
                Console.WriteLine(cuit);
                var x = new BoraTimelineQuerier();
                Task<HtmlDocument> task = x.ObtenerSociedadPorRazonSocialOCuit(cuit);
                Task.WhenAll(task);

                HtmlDocument doc = task.Result;

                TimelineParser parser = new TimelineParser();
                List<Timeline> t = parser.Parse(doc);
                string serializedTimeLine = JsonSerializer.Serialize(t, jsonSerializerOptions);
                
                File.WriteAllText(path, serializedTimeLine, System.Text.Encoding.UTF8);
            }

            Console.WriteLine($"Se obtuvieron {fromCache}/{totalCount} de la cache");
        }
    }
}
