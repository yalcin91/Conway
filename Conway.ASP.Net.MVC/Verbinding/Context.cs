using Conway.Core.Manager;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conway.ASP.Net.MVC.Verbinding
{
    public class Context
    {
        public static BAT_Cigarette_Manager BAT_Cigarette_Manager { get; } = new BAT_Cigarette_Manager();
        public static BAT_Tabac_Manager BAT_Tabac_Manager { get; } = new BAT_Tabac_Manager();
        public static ITB_Cigarette_Manager ITB_Cigarette_Manager { get; } = new ITB_Cigarette_Manager();
        public static ITB_Tabac_Manager ITB_Tabac_Manager { get; } = new ITB_Tabac_Manager();
        public static JTI_Cigarette_Manager JTI_Cigarette_Manager { get; } = new JTI_Cigarette_Manager();
        public static JTI_Tabac_Manager JTI_Tabac_Manager { get; } = new JTI_Tabac_Manager();
        public static PMI_Cigarette_Manager PMI_Cigarette_Manager { get; } = new PMI_Cigarette_Manager();
        public static Product_Manager Product_Manager { get; } = new Product_Manager();
    }
}
