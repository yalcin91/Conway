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
    public class Server_PMI_Cigarette
    {
        public async Task<List<PMI_Cigarette>> GetAllPMI_Cigarette()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync(AppSettings.ApiUrl + "api/PMI_Cigarette_");
            return JsonConvert.DeserializeObject<List<PMI_Cigarette>>(response);
        }
    }
}
