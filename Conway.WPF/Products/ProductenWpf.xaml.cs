using Conway.Core.Model;
using Conway.WPF.Verbinding;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Conway.WPF.Products
{
    /// <summary>
    /// Interaction logic for Producten.xaml
    /// </summary>
    public partial class ProductenWpf : Window
    {
        private ObservableCollection<Product> _Producten;

        public ProductenWpf()
        {
            InitializeComponent();
            _Producten = new ObservableCollection<Product>();
            GetProduct();
        }

        private async void GetProduct()
        {
            var producten = await Context.Product_Manager.GetProducten();
            foreach (var item in producten)
            {
                _Producten.Add(item);
            }
            data_Product.ItemsSource = _Producten;
        }
    }
}
