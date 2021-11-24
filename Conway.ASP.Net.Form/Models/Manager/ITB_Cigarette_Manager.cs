using Conway.ASP.Net.Form.Models.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conway.ASP.Net.Form.Models.Manager
{
    public class ITB_Cigarette_Manager
    {
        Server_ITB_Cigarette server_ITB_Cigarette = new Server_ITB_Cigarette();
        public  List<ITB_Cigarette> GetITB_Cigarette()
        {
            List<ITB_Cigarette> itb_Cigarette;
            itb_Cigarette = server_ITB_Cigarette.GetAllITB_Cigarette();
            return  itb_Cigarette;
        }
    }
}
