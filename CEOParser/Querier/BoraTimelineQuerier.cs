using HtmlAgilityPack;

namespace CEOParser.Querier
{
    /// <summary>
    /// Boletin Oficial de la Republica Argentina timeline querier
    /// This class creates queries to get data from https://timeline.boletinoficial.gob.ar/
    /// </summary>
    internal class BoraTimelineQuerier
    {
        public async Task<HtmlDocument> ObtenerSociedadPorRazonSocialOCuit(string razonSocialOCuit)
        {
            var url = "https://timeline.boletinoficial.gob.ar/";
            var httpClient = new HttpClient();

            var content = new FormUrlEncodedContent(new[]
            {
            // Add your key-value pairs here
            new KeyValuePair<string, string>("searchtext_type", "society"),
            new KeyValuePair<string, string>("searchtext_society", razonSocialOCuit),
            });

            return await GetPostResponse(url, httpClient, content);
        }

        private static async Task<HtmlDocument> GetPostResponse(string url, HttpClient httpClient, FormUrlEncodedContent content)
        {
            var response = await httpClient.PostAsync(url, content);
            var htmlDocument = new HtmlDocument();

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                htmlDocument.LoadHtml(responseContent);
            }

            return htmlDocument;
        }
    }
}
