using Conway.Core.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conway.Core.Manager
{
    public class PMI_Cigarette_Manager
    {
        Server_PMI_Cigarette server_PMI_Cigarette = new Server_PMI_Cigarette();

        public async Task<List<PMI_Cigarette>> GetPMI_Cigarette()
        {
            Task<List<PMI_Cigarette>> pmi_Cigarette;
            pmi_Cigarette = server_PMI_Cigarette.GetAllPMI_Cigarette();
            return await pmi_Cigarette;
        }
    }
}
