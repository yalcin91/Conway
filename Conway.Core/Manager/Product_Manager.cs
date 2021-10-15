using Conway.Core.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conway.Core.Manager
{
    public class Product_Manager
    {
        Server_Product server_Product = new Server_Product();
        public async Task<List<Product>> GetProducten()
        {
            Task<List<Product>> products;
            products = server_Product.GetAllProducts();
            return await products;
        }
    }
}
