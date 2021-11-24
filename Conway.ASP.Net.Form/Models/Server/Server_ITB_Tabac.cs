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
    public class Server_ITB_Tabac
    {
        public  List<ITB_Tabac> GetAllITB_Tabac()
        {
            var httpClient = new HttpClient();
            var response =  httpClient.GetStringAsync(AppSettings.ApiUrl + "api/ITB_Tabac_").Result;
            return JsonConvert.DeserializeObject<List<ITB_Tabac>>(response);
        }
    }
}
