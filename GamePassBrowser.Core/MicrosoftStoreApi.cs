using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using GamePassBrowser.Core.Json.Model;
using GamePassBrowser.Core.MVVM.Model;

namespace GamePassBrowser.Core
{
    internal static class MicrosoftStoreApi
    {
        private static readonly HttpClient LifeTimeHttpClient = new();

        private const string GetDesktopCatalogUrl =
            "https://catalog.gamepass.com/sigls/v2?id=fdd9e2a7-0fee-49f6-ad69-4354098401ff&language=en-us&market=US";

        private const string GetProductsUri =
            "https://catalog.gamepass.com/products?market=US&language=en-US&hydration=MobileDetailsForConsole";

        public static async Task<GamePassCatalog> GetDesktopGamesCatalog(CancellationToken token)
        {
            HttpResponseMessage response = await LifeTimeHttpClient.GetAsync(GetDesktopCatalogUrl, token);
            if (!response.IsSuccessStatusCode)
                return null;

            string responseBody = await response.Content.ReadAsStringAsync(token);
            return JsonSerializer.Deserialize<GamePassCatalog>(responseBody);
        }

        public static async Task<DesktopGame[]> GetDesktopGames(string[] productIDs, CancellationToken token)
        {
            GamePassLookupResult lookupResult = await GetProducts(productIDs, token);
            return ConvertProductsToDesktopGames(lookupResult);
        }

        public static async Task<DesktopGame[]> GetAllDesktopGames(CancellationToken token)
        {
            GamePassCatalog desktopCatalogUrl = await GetDesktopGamesCatalog(token);
            GamePassLookupResult lookupResult = await GetProducts(desktopCatalogUrl.ProductIDs, token);
            return ConvertProductsToDesktopGames(lookupResult);
        }

        private static DesktopGame[] ConvertProductsToDesktopGames(GamePassLookupResult lookupResult)
        {
            return lookupResult.Products
                .Select(x => new DesktopGame(x.Value))
                .ToArray();
        }

        private static async Task<GamePassLookupResult> GetProducts(string[] productIDs, CancellationToken token)
        {
            HttpRequestMessage postMessage = new(HttpMethod.Post, GetProductsUri)
            {
                Content = CreateProductRequestBody(productIDs)
            };

            HttpResponseMessage response = await LifeTimeHttpClient.SendAsync(postMessage, token);
            if (!response.IsSuccessStatusCode)
                return null;

            string responseBody = await response.Content.ReadAsStringAsync(token);

            return JsonSerializer.Deserialize<GamePassLookupResult>(responseBody);
        }

        private static StringContent CreateProductRequestBody(string[] productIDs)
        {
            string body = "{\"Products\": [ ";
            foreach (string id in productIDs)
            {
                body += $"\"{id}\", ";
            }

            body += "]}";

            return new StringContent(body);
        }
    }
}