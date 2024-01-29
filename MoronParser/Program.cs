using HtmlAgilityPack;
using MoronParser.Model;
using MoronParser.Parser;
using MoronParser.Parser.Extension;
using MoronParser.Querier;
using Newtonsoft.Json;
using System.Formats.Asn1;
using System;
using System.Reflection.Metadata;
using System.Text.Json;
using CsvHelper;
using System.Globalization;
using System.Xml.Schema;

namespace MoronParser
{
    internal class Program
    {
        static int Main(string[] args)
        {
            IList<CompraConcluida> compras = new List<CompraConcluida>();
            for (int i = 2007; i < 2024; i++)
            {
                ReadFromFS(compras, i);
            }

            // Write compras to a single .json file
            string jsonString = JsonConvert.SerializeObject(compras);
            File.WriteAllText("C:\\CompraConcluida\\compras.json", jsonString);

            return 0;
        }

        private static void ReadFromFS(IList<CompraConcluida> compras, int i)
        {
            if (Directory.Exists($"C:\\CompraConcluida\\{i}"))
            {
                string[] files = Directory.GetFiles($"C:\\CompraConcluida\\{i}");
                foreach (string file in files)
                {
                    var contents = File.ReadAllText(file, System.Text.Encoding.UTF8);
                    CompraConcluida? compra = JsonConvert.DeserializeObject<CompraConcluida>(contents);
                    if (compra != null)
                    {
                        compras.Add(compra);
                    }
                    else
                    {
                        Console.WriteLine("Error al deserializar: " + file);
                    }
                }
            }
        }

        // Rest of the code...
    }
}