using Conway.ASP.Net.Form.Models.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conway.ASP.Net.Form.Models.Manager
{
    public class BAT_Tabac_Manager
    {
        Server_BAT_Tabac server_BAT_Tabac = new Server_BAT_Tabac();
        public  List<BAT_Tabac> GetBAT_Tabac()
        {
            List<BAT_Tabac> bat_Tabac;
            bat_Tabac = server_BAT_Tabac.GetAllBAT_Tabac();
            return  bat_Tabac;
        }
    }
}
