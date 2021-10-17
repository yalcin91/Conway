using Conway.Core.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conway.Core.Manager
{
    public class BAT_Cigarette_Manager
    {
        Server_BAT_Cigarette server_BAT_Cigarette = new Server_BAT_Cigarette();
        public async Task<List<BAT_Cigarette>> GetBAT_Cigarette()
        {
            Task<List<BAT_Cigarette>> bat_Cigarette;
            bat_Cigarette = server_BAT_Cigarette.GetAllBAT_Cigarette();
            return await bat_Cigarette;
        }
    }
}
