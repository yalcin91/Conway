using Conway.Core.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conway.Core.Manager
{
    public class BAT_Tabac_Manager
    {
        Server_BAT_Tabac server_BAT_Tabac = new Server_BAT_Tabac();
        public async Task<List<BAT_Tabac>> GetBAT_Tabac()
        {
            Task<List<BAT_Tabac>> bat_Tabac;
            bat_Tabac = server_BAT_Tabac.GetAllBAT_Tabac();
            return await bat_Tabac;
        }
    }
}
