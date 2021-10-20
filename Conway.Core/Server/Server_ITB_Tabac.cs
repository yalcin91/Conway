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
    public class Server_ITB_Tabac
    {
        public async Task<List<ITB_Tabac>> GetAllITB_Tabac()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync(AppSettings.ApiUrl + "api/ITB_Tabac_");
            return JsonConvert.DeserializeObject<List<ITB_Tabac>>(response);
        }
    }
}
