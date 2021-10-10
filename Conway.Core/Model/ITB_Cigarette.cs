using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conway.Core.Model
{
    public class ITB_Cigarette : IAssortiment
    {
        public ITB_Cigarette(long id, int @ref, string product, int ean, string fabrikant, string dif, double nielsen1, double nielsen2, double nielsen3, double nielsen4, string groupe, string color) : base(id, @ref, product, ean, fabrikant, dif, nielsen1, nielsen2, nielsen3, nielsen4, groupe, color)
        {
        }
    }
}
