using Conway.WPF.Assortiment;
using Conway.WPF.Products;

using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Conway.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ProductenWpf ProductenWpf;
        private AssortimentWpf AssortimentWpf;

        public MainWindow()
        {
            InitializeComponent();
            ProductenWpf = new ProductenWpf();
            AssortimentWpf = new AssortimentWpf();
            ProductenWpf.Closing += ProductenWpf_Closing;
            AssortimentWpf.Closing += AssortimentWpf_Closing;
            Closing += MainWindow_Closing;
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void ProductenWpf_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, (DispatcherOperationCallback)delegate (object o)
            {
                ((Window)sender).Hide();
                return null;
            }, null);
            e.Cancel = true;
        }

        private void AssortimentWpf_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, (DispatcherOperationCallback)delegate (object o)
            {
                ((Window)sender).Hide();
                return null;
            }, null);
            e.Cancel = true;
        }

        private void btn_Producten_Click(object sender, RoutedEventArgs e)
        {
            if (ProductenWpf != null) { ProductenWpf.Show(); }

        }

        private void btn_Assortiment_Click(object sender, RoutedEventArgs e)
        {
            if (AssortimentWpf != null) { AssortimentWpf.Show(); }
        }

        private void btn_Check_Click(object sender, RoutedEventArgs e)
        {
            if(txtb_Pass.Password == "tom007")
            {
                btn_Producten.IsEnabled = true;
                btn_Assortiment.IsEnabled = true;
                btn_Producten.Cursor = Cursors.Hand;
                btn_Assortiment.Cursor = Cursors.Hand;
            }
            else 
            {
                btn_Producten.IsEnabled = false;
                btn_Assortiment.IsEnabled = false;
                btn_Producten.Cursor = Cursors.Arrow;
                btn_Assortiment.Cursor = Cursors.Arrow;
            }
        }

        private void txtb_Pass_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtb_Pass.Password == "tom007")
            {
                btn_Producten.IsEnabled = true;
                btn_Assortiment.IsEnabled = true;
                btn_Producten.Cursor = Cursors.Hand;
                btn_Assortiment.Cursor = Cursors.Hand;
            }
            else
            {
                btn_Producten.IsEnabled = false;
                btn_Assortiment.IsEnabled = false;
                btn_Producten.Cursor = Cursors.Arrow;
                btn_Assortiment.Cursor = Cursors.Arrow;
            }
        }
    }
}
