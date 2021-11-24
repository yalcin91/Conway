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
    public class Server_BAT_Tabac
    {
        public  List<BAT_Tabac> GetAllBAT_Tabac()
        {
            var httpClient = new HttpClient();
            var response =  httpClient.GetStringAsync(AppSettings.ApiUrl + "api/BAT_Tabac_").Result;
            return JsonConvert.DeserializeObject<List<BAT_Tabac>>(response);
        }
    }
}
