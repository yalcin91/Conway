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
    public class Server_JTI_Cigarette
    {
        public async Task<List<JTI_Cigarette>> GetAllJTI_Cigarette()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync(AppSettings.ApiUrl + "api/JTI_Cigarette_");
            return JsonConvert.DeserializeObject<List<JTI_Cigarette>>(response);
        }
    }
}
