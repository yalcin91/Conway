using Conway.Core.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conway.ASP.Net.MVC.Models
{
    public class ProductModel
    {
        private List<Product> _Ini = new List<Product>();

        public List<Product> Ini
        {
            get { return _Ini; }
            set { _Ini = value; }
        }

        public List<Product> GetProducts()
        {
            return Ini;
        }

        public void SetProducts(List<Product> products)
        {
            Ini = products;
        }
    }
}
