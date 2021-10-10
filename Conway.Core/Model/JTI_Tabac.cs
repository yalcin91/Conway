using Conway.Core.Exceptions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conway.Core.Model
{
    public class JTI_Tabac : IAssortiment
    {
        public JTI_Tabac(long id, int @ref, string product, int ean, string fabrikant, string dif, double nielsen1, double nielsen2, double nielsen3, double nielsen4, string groupe, string color) : base(id, @ref, product, ean, fabrikant, dif, nielsen1, nielsen2, nielsen3, nielsen4, groupe, color)
        {
        }

        public override void SetGroupe(string groupe)
        {
            if (groupe.Trim() != "Tabac") { throw new AssortimentException("Invalid groupe."); }
        }
    }
}
