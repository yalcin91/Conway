using Conway.ASP.Net.Form.Models.Model;
using Conway.ASP.Net.Form.Models.Server;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Conway.ASP.Net.Form.Models.Manager
{
    public class Server_Product
    {
        public  List<Product> GetAllProducts()
        {
            var httpClient = new HttpClient();
            var response =  httpClient.GetStringAsync(AppSettings.ApiUrl + "api/Products_").Result;
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
