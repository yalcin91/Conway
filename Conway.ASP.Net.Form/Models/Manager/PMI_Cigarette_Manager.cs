using Conway.ASP.Net.Form.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conway.ASP.Net.Form.Models.Manager
{
    public class PMI_Cigarette_Manager
    {
        Server_PMI_Cigarette server_PMI_Cigarette = new Server_PMI_Cigarette();

        public  List<PMI_Cigarette> GetPMI_Cigarette()
        {
            List<PMI_Cigarette> pmi_Cigarette;
            pmi_Cigarette = server_PMI_Cigarette.GetAllPMI_Cigarette();
            return  pmi_Cigarette;
        }
    }
}
