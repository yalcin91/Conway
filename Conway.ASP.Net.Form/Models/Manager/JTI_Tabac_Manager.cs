using Conway.ASP.Net.Form.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conway.ASP.Net.Form.Models.Manager
{
    public class JTI_Tabac_Manager
    {
        Server_JTI_Tabac server_JTI_Tabac = new Server_JTI_Tabac();
        public List<JTI_Tabac> GetJTI_Tabac()
        {
            List<JTI_Tabac> jti_Tabac;
            jti_Tabac = server_JTI_Tabac.GetAllJTI_Tabac();
            return  jti_Tabac;
        }
    }
}
