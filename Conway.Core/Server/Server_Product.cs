using Conway.Core.Model;
using Conway.Core.Server;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Conway.Core.Manager
{
    public class Server_Product
    {
        public async Task<List<Product>> GetAllProducts()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync(AppSettings.ApiUrl + "api/Products_");
            return JsonConvert.DeserializeObject<List<Product>>(response);
        }

        public async Task UpdateProduct(long id, Product product)
        {
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(product);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync(AppSettings.ApiUrl + "api/Products_/" + id, content);
        }

        public async Task<bool> AddProduct(Product product)
        {
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(product);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accesToken", string.Empty));  ----=> dit is later als er een inlog pagina komt voor TOKEN voor wachtwoord.
            var response = await httpClient.PostAsync(AppSettings.ApiUrl + "api/Products_", content);
            if (!response.IsSuccessStatusCode) return false;
            return true;
        }
    }
}
