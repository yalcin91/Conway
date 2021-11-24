using Conway.ASP.Net.Form.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conway.ASP.Net.Form.Models.Manager
{
    public class Product_Manager
    {
        Server_Product server_Product = new Server_Product();
        public  List<Product> GetProducten()
        {
            List<Product> products;
            products = server_Product.GetAllProducts();
            return  products;
        }

        public async void UpdateProduct(long id, Product product)
        {
            await server_Product.UpdateProduct(id, product);
        }

        public async void AddProduct(Product product)
        {
            await server_Product.AddProduct(product);
        }
    }
}
