using Conway.Core.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conway.Core.Manager
{
    public class JTI_Tabac_Manager
    {
        Server_JTI_Tabac server_JTI_Tabac = new Server_JTI_Tabac();
        public async Task<List<JTI_Tabac>> GetJTI_Tabac()
        {
            Task<List<JTI_Tabac>> jti_Tabac;
            jti_Tabac = server_JTI_Tabac.GetAllJTI_Tabac();
            return await jti_Tabac;
        }
    }
}
