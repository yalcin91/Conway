using Conway.ASP.Net.Form.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conway.ASP.Net.Form.Models.Manager
{
    public class JTI_Cigarette_Manager
    {
        Server_JTI_Cigarette server_JTI_Cigarette = new Server_JTI_Cigarette();
        public List<JTI_Cigarette> GetJTI_Cigarette()
        {
            List<JTI_Cigarette> jti_Cigarette;
            jti_Cigarette = server_JTI_Cigarette.GetAllJTI_Cigarette();
            return  jti_Cigarette;
        }
    }
}
