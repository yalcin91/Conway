using Conway.ASP.Net.Form.Models.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conway.ASP.Net.Form.Models.Manager
{
    public class BAT_Cigarette_Manager
    {
        Server_BAT_Cigarette server_BAT_Cigarette = new Server_BAT_Cigarette();
        public  List<BAT_Cigarette> GetBAT_Cigarette()
        {
            List<BAT_Cigarette> bat_Cigarette;
            bat_Cigarette = server_BAT_Cigarette.GetAllBAT_Cigarette();
            return  bat_Cigarette;
        }
    }
}
