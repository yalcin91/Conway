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
    public class Server_BAT_Tabac
    {
        public async Task<List<BAT_Tabac>> GetAllBAT_Tabac()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync(AppSettings.ApiUrl + "api/BAT_Tabac_");
            return JsonConvert.DeserializeObject<List<BAT_Tabac>>(response);
        }
    }
}
