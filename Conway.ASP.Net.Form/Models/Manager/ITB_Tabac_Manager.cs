using Conway.ASP.Net.Form.Models.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conway.ASP.Net.Form.Models.Manager
{
    public class ITB_Tabac_Manager
    {
        Server_ITB_Tabac server_ITB_Tabac = new Server_ITB_Tabac();
        public  List<ITB_Tabac> GetITB_Tabac()
        {
            List<ITB_Tabac> itb_Tabac;
            itb_Tabac = server_ITB_Tabac.GetAllITB_Tabac();
            return  itb_Tabac;
        }
    }
}
