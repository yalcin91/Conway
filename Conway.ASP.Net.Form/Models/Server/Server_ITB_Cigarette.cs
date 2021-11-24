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
    public class Server_ITB_Cigarette
    {
        public  List<ITB_Cigarette> GetAllITB_Cigarette()
        {
            var httpClient = new HttpClient();
            var response =  httpClient.GetStringAsync(AppSettings.ApiUrl + "api/ITB_Cigarette_").Result;
            return JsonConvert.DeserializeObject<List<ITB_Cigarette>>(response);
        }
    }
}
