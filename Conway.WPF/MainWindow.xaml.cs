using Conway.WPF.Assortiment;
using Conway.WPF.Products;

using Microsoft.Win32;

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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

        private void btn_Import_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.DefaultExt = ".ini";
            ofd.Filter = "Ini Document (.ini)|*.ini";
            string path = "";
            if (ofd.ShowDialog() == true)
            {
                path = ofd.FileName;
            }

            string line;
            string volledigString = "";
            List<string> _VolledigString = new List<string>();
            int id = 1;
            string ean = "";
            string description = "";
            string qt = "";
            string prix = "";
            List<string> _Naam = new List<string>();
            using (StreamReader reader = new StreamReader(path))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    volledigString += " " + line;
                }
                reader.Close();
                string[] array = volledigString.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int k = 0; k < array.Length; k++)
                {
                    _VolledigString.Add(array[k]);
                }

                for (int j = 0; j < _VolledigString.Count; j++)
                {
                    int min = 0;
                    foreach (char m in _VolledigString[j])
                    {
                        if (m.ToString() == "=")
                        {
                            if (j <= 1056)
                            {
                                description = _VolledigString[j].Remove(0, (min + 1));
                                ean = _VolledigString[(j + 1)];

                                if (j <= 1055)
                                {
                                    qt = _VolledigString[(j + 6)];
                                }
                                if (j <= 1053)
                                {
                                    if (_VolledigString[j + 8].First() == '0') { prix = "\u20AC" + _VolledigString[(j + 8)].Remove(0, 1); }
                                    else { prix = "\u20AC" + _VolledigString[(j + 8)]; }
                                }
                                //test.Text = _VolledigString[900];
                                //data_Ini.Items.Add(description);
                                var data = new ModelIni { Id = id, Ean = ean, Description = description, Qt = qt, Prix = prix };
                                id++;
                                data_Ini.Items.Add(data);
                            }
                        }
                        min++;
                    }
                }
            }
        }

        public void ToMachine()
        {

        }

        public class ModelIni
        {
            public int Id { get; set; }
            public string Ean { get; set; }
            public string Description { get; set; }
            public string Qt { get; set; }
            public string Prix { get; set; }
            public string Fabricant { get; set; }
        }
    }
}
