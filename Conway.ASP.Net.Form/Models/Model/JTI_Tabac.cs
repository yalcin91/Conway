

using Conway.ASP.Net.Form.Models.Exceptions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conway.ASP.Net.Form.Models.Model
{
    public class JTI_Tabac : IAssortiment
    {
        public JTI_Tabac(long id, int @ref, string product, long eanCode, string fabrikant, string size, double nielsen1, double nielsen2, double nielsen3, double nielsen4, string groupe, string color) : base(id, @ref, product, eanCode, fabrikant, size, nielsen1, nielsen2, nielsen3, nielsen4, groupe, color)
        {
        }

        public override void SetGroupe(string groupe)
        {
            if (groupe.Trim() != "Tabac") { throw new AssortimentException("Invalid groupe."); }
        }
    }
}
