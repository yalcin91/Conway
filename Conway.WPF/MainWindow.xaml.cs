using Conway.Core.Model;
using Conway.WPF.Assortiment;
using Conway.WPF.Products;
using Conway.WPF.Verbinding;

using Microsoft.Win32;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
        private List<Product> _Products;
        private ObservableCollection<Product> _Producten;
        private ObservableCollection<BAT_Cigarette> _BAT_Cigaretten;
        private ObservableCollection<BAT_Tabac> _BAT_Tabac;
        private ObservableCollection<ITB_Cigarette> _ITB_Cigaretten;
        private ObservableCollection<ITB_Tabac> _ITB_Tabac;
        private ObservableCollection<JTI_Cigarette> _JTI_Cigaretten;
        private ObservableCollection<JTI_Tabac> _JTI_Tabac;
        private ObservableCollection<PMI_Cigarette> _PMI_Cigaretten;
        private ObservableCollection<ModelIni> _Ini;

        public MainWindow()
        {
            InitializeComponent();
            ProductenWpf = new ProductenWpf();
            AssortimentWpf = new AssortimentWpf();
            _Products = new List<Product>();
            _Producten = new ObservableCollection<Product>();
            _BAT_Cigaretten = new ObservableCollection<BAT_Cigarette>();
            _BAT_Tabac = new ObservableCollection<BAT_Tabac>();
            _ITB_Cigaretten = new ObservableCollection<ITB_Cigarette>();
            _ITB_Tabac = new ObservableCollection<ITB_Tabac>();
            _JTI_Cigaretten = new ObservableCollection<JTI_Cigarette>();
            _JTI_Tabac = new ObservableCollection<JTI_Tabac>();
            _PMI_Cigaretten = new ObservableCollection<PMI_Cigarette>();
            _Ini = new ObservableCollection<ModelIni>();
            GetProduct();
            GetBAT_Cigarette();
            ProductenWpf.Closing += ProductenWpf_Closing;
            AssortimentWpf.Closing += AssortimentWpf_Closing;
            Closing += MainWindow_Closing;
        }

        #region Get all Products
        private async void GetProduct()
        {
            var producten = await Context.Product_Manager.GetProducten();
            foreach (var item in producten)
            {
                _Producten.Add(item);
            }
            data_Product.ItemsSource = _Producten;
            _Products = producten;
        }
        #endregion

        #region Get All Assortiment
        private async void GetBAT_Cigarette()
        {
            _BAT_Cigaretten = new ObservableCollection<BAT_Cigarette>();
            var bAT_Cigarette = await Context.BAT_Cigarette_Manager.GetBAT_Cigarette();
            foreach (var item in bAT_Cigarette)
            {
                _BAT_Cigaretten.Add(item);
            }
            data_Assortiment.ItemsSource = _BAT_Cigaretten;
        }
        private async void GetBAT_Tabac()
        {
            _BAT_Tabac = new ObservableCollection<BAT_Tabac>();
            var bAT_Tabac = await Context.BAT_Tabac_Manager.GetBAT_Tabac();
            foreach (var item in bAT_Tabac)
            {
                _BAT_Tabac.Add(item);
            }
            data_Assortiment.ItemsSource = _BAT_Tabac;
        }

        private async void GetITB_Cigarette()
        {
            _ITB_Cigaretten = new ObservableCollection<ITB_Cigarette>();
            var itb_Cigarette = await Context.ITB_Cigarette_Manager.GetITB_Cigarette();
            foreach (var item in itb_Cigarette)
            {
                _ITB_Cigaretten.Add(item);
            }
            data_Assortiment.ItemsSource = _ITB_Cigaretten;
        }
        private async void GetITB_Tabac()
        {
            _ITB_Tabac = new ObservableCollection<ITB_Tabac>();
            var itb_Tabac = await Context.ITB_Tabac_Manager.GetITB_Tabac();
            foreach (var item in itb_Tabac)
            {
                _ITB_Tabac.Add(item);
            }
            data_Assortiment.ItemsSource = _ITB_Tabac;
        }

        private async void GetJTI_Cigarette()
        {
            _JTI_Cigaretten = new ObservableCollection<JTI_Cigarette>();
            var jti_Cigarette = await Context.JTI_Cigarette_Manager.GetJTI_Cigarette();
            foreach (var item in jti_Cigarette)
            {
                _JTI_Cigaretten.Add(item);
            }
            data_Assortiment.ItemsSource = _JTI_Cigaretten;
        }
        private async void GetJTI_Tabac()
        {
            _JTI_Tabac = new ObservableCollection<JTI_Tabac>();
            var jti_Tabac = await Context.JTI_Tabac_Manager.GetJTI_Tabac();
            foreach (var item in jti_Tabac)
            {
                _JTI_Tabac.Add(item);
            }
            data_Assortiment.ItemsSource = _JTI_Tabac;
        }

        private async void GetPMI_Cigarette()
        {
            _PMI_Cigaretten = new ObservableCollection<PMI_Cigarette>();
            var pmi_Cigarette = await Context.PMI_Cigarette_Manager.GetPMI_Cigarette();
            foreach (var item in pmi_Cigarette)
            {
                _PMI_Cigaretten.Add(item);
            }
            data_Assortiment.ItemsSource = _PMI_Cigaretten;
        }
        #endregion

        #region Closing
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
        #endregion

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


        private List<string> _Fabrikant = new List<string>();
        private List<int> _BAT = new List<int>();
        private List<int> _ITB = new List<int>();
        private List<int> _JTI = new List<int>();
        private List<int> _PMI = new List<int>();
        private double Breedte_Links = 645;
        private double Breedte_Rechts_Boven = 645;
        private double Breedte_Rechts_Beneden = 645;
        private double Breedte_Midden_Boven = 1306;
        private double Breedte_Midden_Midden = 1306;
        private double Breedte_Midden_Beneden = 1306;
        private void btn_Import_Click(object sender, RoutedEventArgs e)
        {
            Clear();

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
            string fabrikant = "";
            double hoogte = 0;
            double breedte = 0;
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
                                for (int i = 0; i < _Products.Count; i++)
                                {
                                    if(_Products[i].Eancode == long.Parse(ean)) { fabrikant = _Products[i].Fabrikant; hoogte = _Products[i].Hoogte; breedte = _Products[i].Breedte; }
                                }
                                string exampleTrimmed = String.Concat(fabrikant.Where(c => !Char.IsWhiteSpace(c)));
                                var data = new ModelIni { Id = id, Ean = ean, Description = description, Qt = qt, Prix = prix, Fabricant = fabrikant, Hoogte = hoogte, Breedte = breedte };
                                CheckFabrikantAantal(fabrikant);
                                ToMachine(id, description, prix, fabrikant);
                                _Fabrikant.Add(fabrikant);
                                _Ini.Add(data);
                                Breedte_Berekenen(id);
                                id++;
                                ean = "";
                                 description = "";
                                 qt = "";
                                 prix = "";
                                 fabrikant = "";
                                breedte = 0;
                                hoogte = 0;
                            }
                        }
                        min++;
                    }
                }
                data_Ini.ItemsSource = _Ini;
                lbl_BAT.Content = _BAT.Count();
                lbl_ITB.Content = _ITB.Count();
                lbl_JTI.Content = _JTI.Count();
                lbl_PMI.Content = _PMI.Count();
            }
        }

        private void Breedte_Berekenen(long id)
        {
            var product = _Ini.Where(x => x.Id == id).FirstOrDefault();
            if (product != null)
            {
                if (id >= 81 && id <= 90)
                {
                    Breedte_Links = Breedte_Links - product.Breedte;
                    lbl_Breedte_Links.Content = Breedte_Links.ToString();
                    if (Breedte_Links < 0)
                    {
                        lbl_Breedte_Links.Background = new System.Windows.Media.SolidColorBrush(Colors.Red);
                    }
                }

                if (id >= 11 && id <= 20)
                {
                    Breedte_Rechts_Boven = Breedte_Rechts_Boven - product.Breedte;
                    lbl_Breedte_Rechts_Boven.Content = Breedte_Rechts_Boven.ToString();
                    if (Breedte_Rechts_Boven < 0)
                    {
                        lbl_Breedte_Rechts_Boven.Background = new System.Windows.Media.SolidColorBrush(Colors.Red);
                    }
                }

                if (id >= 1 && id <= 10)
                {
                    Breedte_Rechts_Beneden = Breedte_Rechts_Beneden - product.Breedte;
                    lbl_Breedte_Rechts_Beneden.Content = Breedte_Rechts_Beneden.ToString();
                    if (Breedte_Rechts_Beneden < 0)
                    {
                        lbl_Breedte_Rechts_Beneden.Background = new System.Windows.Media.SolidColorBrush(Colors.Red);
                    }
                }

                if (id >= 61 && id <= 80)
                {
                    Breedte_Midden_Boven = Breedte_Midden_Boven - product.Breedte;
                    lbl_Breedte_Midden_Boven.Content = Breedte_Midden_Boven.ToString();
                    if (Breedte_Midden_Boven < 0)
                    {
                        lbl_Breedte_Midden_Boven.Background = new System.Windows.Media.SolidColorBrush(Colors.Red);
                    }
                }

                if (id >= 41 && id <= 60)
                {
                    Breedte_Midden_Midden = Breedte_Midden_Midden - product.Breedte;
                    lbl_Breedte_Midden_Midden.Content = Breedte_Midden_Midden.ToString();
                    if (Breedte_Midden_Midden < 0)
                    {
                        lbl_Breedte_Midden_Midden.Background = new System.Windows.Media.SolidColorBrush(Colors.Red);
                    }
                }

                if (id >= 21 && id <= 40)
                {
                    Breedte_Midden_Beneden = Breedte_Midden_Beneden - product.Breedte;
                    lbl_Breedte_Midden_Beneden.Content = Breedte_Midden_Beneden.ToString();
                    if (Breedte_Midden_Beneden < 0)
                    {
                        lbl_Breedte_Midden_Beneden.Background = new System.Windows.Media.SolidColorBrush(Colors.Red);
                    }
                }
            }
        }

        private void CheckFabrikantAantal(string fabrikant)
        {
            if(fabrikant == "BAT") { _BAT.Add(1); }
            if(fabrikant == "ITB") { _ITB.Add(1); }
            if(fabrikant == "JTI") { _JTI.Add(1); }
            if(fabrikant == "PMI") { _PMI.Add(1); }
        }

        private class ModelIni
        {
            public int Id { get; set; }
            public string Ean { get; set; }
            public string Description { get; set; }
            public string Qt { get; set; }
            public string Prix { get; set; }
            public string Fabricant { get; set; }
            public double Hoogte { get; set; }
            public double Breedte { get; set; }
        }

        #region Fabrikant code
        private int ClearCodeCheck = 0;
        private void btn_BAT_C(object sender, RoutedEventArgs e)
        {
            GetBAT_Cigarette();
            if (ClearCodeCheck == 0)
            {
                clearColor();
                ChangeColor("BAT");
                ClearCodeCheck = 1;
            }
            else { clearColor(); ClearCodeCheck = 0; }
        }
        private void btn_BAT_T(object sender, RoutedEventArgs e)
        {
            GetBAT_Tabac();
            if (ClearCodeCheck == 0)
            {
                clearColor();
                ChangeColor("BAT");
                ClearCodeCheck = 1;
            }
            else { clearColor(); ClearCodeCheck = 0; }
        }

        private void btn_ITB_C(object sender, RoutedEventArgs e)
        {
            GetITB_Cigarette();
            if (ClearCodeCheck == 0)
            {
                clearColor();
                ChangeColor("ITB");
                ClearCodeCheck = 1;
            }
            else { clearColor(); ClearCodeCheck = 0; }
        }
        private void btn_ITB_T(object sender, RoutedEventArgs e)
        {
            GetITB_Tabac();
            if (ClearCodeCheck == 0)
            {
                clearColor();
                ChangeColor("ITB");
                ClearCodeCheck = 1;
            }
            else { clearColor(); ClearCodeCheck = 0; }
        }

        private void btn_JTI_C(object sender, RoutedEventArgs e)
        {
            GetJTI_Cigarette();
            if (ClearCodeCheck == 0)
            {
                clearColor();
                ChangeColor("JTI");
                ClearCodeCheck = 1;
            }
            else { clearColor(); ClearCodeCheck = 0; }
        }
        private void btn_JTI_T(object sender, RoutedEventArgs e)
        {
            GetJTI_Tabac();
            if (ClearCodeCheck == 0)
            {
                clearColor();
                ChangeColor("JTI");
                ClearCodeCheck = 1;
            }
            else { clearColor(); ClearCodeCheck = 0; }
        }

        private void btn_PMI_C(object sender, RoutedEventArgs e)
        {
            GetPMI_Cigarette();
            if (ClearCodeCheck == 0)
            {
                clearColor();
                ChangeColor("PMI");
                ClearCodeCheck = 1;
            }
            else { clearColor(); ClearCodeCheck = 0; }
        }
        private void clearColor()
        {
            clm_1.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_2.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_3.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_4.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_5.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_6.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_7.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_8.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_9.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_10.Background = new System.Windows.Media.SolidColorBrush(Colors.White);

            clm_11.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_12.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_13.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_14.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_15.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_16.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_17.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_18.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_19.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_20.Background = new System.Windows.Media.SolidColorBrush(Colors.White);

            clm_21.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_22.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_23.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_24.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_25.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_26.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_27.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_28.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_29.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_30.Background = new System.Windows.Media.SolidColorBrush(Colors.White);

            clm_31.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_32.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_33.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_34.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_35.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_36.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_37.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_38.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_39.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_40.Background = new System.Windows.Media.SolidColorBrush(Colors.White);

            clm_41.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_42.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_43.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_44.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_45.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_46.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_47.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_48.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_49.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_50.Background = new System.Windows.Media.SolidColorBrush(Colors.White);

            clm_51.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_52.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_53.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_54.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_55.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_56.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_57.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_58.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_59.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_60.Background = new System.Windows.Media.SolidColorBrush(Colors.White);

            clm_61.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_62.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_63.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_64.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_65.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_66.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_67.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_68.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_69.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_70.Background = new System.Windows.Media.SolidColorBrush(Colors.White);

            clm_71.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_72.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_73.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_74.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_75.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_76.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_77.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_78.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_79.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_80.Background = new System.Windows.Media.SolidColorBrush(Colors.White);

            clm_81.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_82.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_83.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_84.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_85.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_86.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_87.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_88.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_89.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
            clm_90.Background = new System.Windows.Media.SolidColorBrush(Colors.White);
        }
        #endregion

        private void ChangeColor(string fabrikant)
        {
            for (int m = 0; m < _Ini.Count; m++)
            {
                if (_Ini[m].Fabricant == fabrikant)
                {
                    if (m == 0) clm_1.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 1) clm_2.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 2) clm_3.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 3) clm_4.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 4) clm_5.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 5) clm_6.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 6) clm_7.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 7) clm_8.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 8) clm_9.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 9) clm_10.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);

                    if (m == 10) clm_11.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 11) clm_12.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 12) clm_13.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 13) clm_14.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 14) clm_15.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 15) clm_16.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 16) clm_17.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 17) clm_18.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 18) clm_19.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 19) clm_20.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);

                    if (m == 20) clm_21.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 21) clm_22.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 22) clm_23.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 23) clm_24.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 24) clm_25.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 25) clm_26.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 26) clm_27.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 27) clm_28.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 28) clm_29.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 29) clm_30.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);

                    if (m == 30) clm_31.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 31) clm_32.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 32) clm_33.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 33) clm_34.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 34) clm_35.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 35) clm_36.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 36) clm_37.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 37) clm_38.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 38) clm_39.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 39) clm_40.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);

                    if (m == 40) clm_41.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 41) clm_42.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 42) clm_43.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 43) clm_44.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 44) clm_45.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 45) clm_46.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 46) clm_47.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 47) clm_48.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 48) clm_49.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 49) clm_50.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);

                    if (m == 50) clm_51.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 51) clm_52.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 52) clm_53.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 53) clm_54.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 54) clm_55.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 55) clm_56.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 56) clm_57.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 57) clm_58.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 58) clm_59.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 59) clm_60.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);

                    if (m == 60) clm_61.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 61) clm_62.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 62) clm_63.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 63) clm_64.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 64) clm_65.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 65) clm_66.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 66) clm_67.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 67) clm_68.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 68) clm_69.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 69) clm_70.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);

                    if (m == 70) clm_71.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 71) clm_72.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 72) clm_73.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 73) clm_74.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 74) clm_75.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 75) clm_76.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 76) clm_77.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 77) clm_78.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 78) clm_79.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 79) clm_80.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);

                    if (m == 80) clm_81.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 81) clm_82.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 82) clm_83.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 83) clm_84.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 84) clm_85.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 85) clm_86.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 86) clm_87.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 87) clm_88.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 88) clm_89.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                    if (m == 89) clm_90.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                }
            }
                   
            /*string message = "";
            int m = 1;
            for (int i = 0; i < data_Ini.Items.Count; i++)
            {
                message = "";
                for (int j = 0; j < data_Ini.Columns.Count; j++)
                {
                    DataGridCell cell = GetCell(i, j);
                    if (cell != null)
                    {
                        TextBlock tb = cell.Content as TextBlock;
                        message += tb.Text;
                    }
                    //TextBlock tb = cell.Content as TextBlock;
                    //message += tb.Text + " ";
                }
                if (message.Length > 3)
                {
                    var result = message.Substring(message.Length - 3);
                    string exampleTrimmed = String.Concat(result.Where(c => !Char.IsWhiteSpace(c)));
                    if (exampleTrimmed == fabrikant)
                    {
                        if (m == 1) clm_1.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 2) clm_2.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 3) clm_3.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 4) clm_4.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 5) clm_5.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 6) clm_6.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 7) clm_7.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 8) clm_8.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 9) clm_9.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 10) clm_10.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);

                        if (m == 11) clm_11.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 12) clm_12.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 13) clm_13.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 14) clm_14.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 15) clm_15.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 16) clm_16.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 17) clm_17.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 18) clm_18.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 19) clm_19.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 20) clm_20.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);

                        if (m == 21) clm_21.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 22) clm_22.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 23) clm_23.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 24) clm_24.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 25) clm_25.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 26) clm_26.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 27) clm_27.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 28) clm_28.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 29) clm_29.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 30) clm_30.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);

                        if (m == 31) clm_31.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 32) clm_32.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 33) clm_33.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 34) clm_34.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 35) clm_35.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 36) clm_36.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 37) clm_37.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 38) clm_38.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 39) clm_39.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 40) clm_40.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);

                        if (m == 41) clm_41.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 42) clm_42.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 43) clm_43.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 44) clm_44.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 45) clm_45.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 46) clm_46.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 47) clm_47.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 48) clm_48.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 49) clm_49.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 50) clm_50.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);

                        if (m == 51) clm_51.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 52) clm_52.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 53) clm_53.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 54) clm_54.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 55) clm_55.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 56) clm_56.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 57) clm_57.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 58) clm_58.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 59) clm_59.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 60) clm_60.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);

                        if (m == 61) clm_61.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 62) clm_62.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 63) clm_63.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 64) clm_64.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 65) clm_65.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 66) clm_66.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 67) clm_67.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 68) clm_68.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 69) clm_69.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 70) clm_70.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);

                        if (m == 71) clm_71.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 72) clm_72.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 73) clm_73.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 74) clm_74.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 75) clm_75.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 76) clm_76.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 77) clm_77.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 78) clm_78.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 79) clm_79.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 80) clm_80.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);

                        if (m == 81) clm_81.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 82) clm_82.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 83) clm_83.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 84) clm_84.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 85) clm_85.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 86) clm_86.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 87) clm_87.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 88) clm_88.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 89) clm_89.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                        if (m == 90) clm_90.Background = new System.Windows.Media.SolidColorBrush(Colors.LightYellow);
                   /* };
                }
                //MessageBox.Show(message);
                m++;
            }  */  
        }

        #region Voor Get DataGrid
        public DataGridCell GetCell(int row, int column)
        {
            DataGridRow rowData = GetRow(row);
            if (rowData != null)
            {
                DataGridCellsPresenter cellPresenter = GetVisualChild<DataGridCellsPresenter>(rowData);
                if (cellPresenter == null)
                {
                    return null;
                }
                    DataGridCell cell = (DataGridCell)cellPresenter.ItemContainerGenerator.ContainerFromIndex(column);
                if (cell == null)
                {
                    data_Ini.ScrollIntoView(rowData, data_Ini.Columns[column]);
                    cell = (DataGridCell)cellPresenter.ItemContainerGenerator.ContainerFromIndex(column);
                }
                return cell;
            }
            return null;
        }

        public DataGridRow GetRow(int index)
        {
            DataGridRow row = (DataGridRow)data_Ini.ItemContainerGenerator.ContainerFromIndex(index);
            if (row == null)
            {
                data_Ini.UpdateLayout();
                data_Ini.ScrollIntoView(data_Ini.Items[index]);
                row = (DataGridRow)data_Ini.ItemContainerGenerator.ContainerFromIndex(index);
            }
            return row;
        }

        public static T GetVisualChild<T>(Visual parent) where T : Visual
        {
            T child = default(T);
            int numVisuals = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < numVisuals; i++)
            {
                Visual v = (Visual)VisualTreeHelper.GetChild(parent, i);
                child = v as T;
                if (child == null)
                {
                    child = GetVisualChild<T>(v);
                }
                if (child != null)
                {
                    break;
                }
            }
            return child;
        }
        #endregion

        private void Clear()
        {
            if (data_Ini != null)
            {
                _Ini = new ObservableCollection<ModelIni>();
                _Fabrikant = new List<string>();
                _BAT = new List<int>();
                _ITB = new List<int>();
                _JTI = new List<int>();
                _PMI = new List<int>();

                _BAT.Clear();
                _ITB.Clear();
                _JTI.Clear();
                _PMI.Clear();

                Breedte_Links = 645;
                Breedte_Rechts_Boven = 645;
                Breedte_Rechts_Beneden = 645;
                Breedte_Midden_Boven = 1306;
                Breedte_Midden_Midden = 1306;
                Breedte_Midden_Beneden = 1306;

                lbl_Breedte_Links.Content = 645;
                lbl_Breedte_Rechts_Boven.Content = 645;
                lbl_Breedte_Rechts_Beneden.Content = 645;
                lbl_Breedte_Midden_Boven.Content = 1306;
                lbl_Breedte_Midden_Midden.Content = 1306;
                lbl_Breedte_Midden_Beneden.Content = 1306;

                lbl_Breedte_Links.Background = new System.Windows.Media.SolidColorBrush(Colors.Green);
                lbl_Breedte_Rechts_Boven.Background = new System.Windows.Media.SolidColorBrush(Colors.Green);
                lbl_Breedte_Rechts_Beneden.Background = new System.Windows.Media.SolidColorBrush(Colors.Green);
                lbl_Breedte_Midden_Boven.Background = new System.Windows.Media.SolidColorBrush(Colors.Green);
                lbl_Breedte_Midden_Midden.Background = new System.Windows.Media.SolidColorBrush(Colors.Green);
                lbl_Breedte_Midden_Beneden.Background = new System.Windows.Media.SolidColorBrush(Colors.Green);

                lbl_1.Content = ""; lbl_1_Prix.Content = ""; lbl_2.Content = ""; lbl_2_Prix.Content = ""; lbl_3.Content = ""; lbl_3_Prix.Content = "";
                lbl_4.Content = ""; lbl_4_Prix.Content = ""; lbl_5.Content = ""; lbl_5_Prix.Content = ""; lbl_6.Content = ""; lbl_6_Prix.Content = ""; lbl_7.Content = "";
                lbl_7_Prix.Content = ""; lbl_8.Content = ""; lbl_8_Prix.Content = ""; lbl_9.Content = ""; lbl_9_Prix.Content = ""; lbl_10.Content = ""; lbl_10_Prix.Content = "";

                lbl_11.Content = ""; lbl_11_Prix.Content = ""; lbl_12.Content = ""; lbl_12_Prix.Content = ""; lbl_13.Content = ""; lbl_13_Prix.Content = "";
                lbl_14.Content = ""; lbl_14_Prix.Content = ""; lbl_15.Content = ""; lbl_15_Prix.Content = ""; lbl_16.Content = ""; lbl_16_Prix.Content = ""; lbl_17.Content = "";
                lbl_17_Prix.Content = ""; lbl_18.Content = ""; lbl_18_Prix.Content = ""; lbl_19.Content = ""; lbl_19_Prix.Content = ""; lbl_20.Content = ""; lbl_20_Prix.Content = "";

                lbl_21.Content = ""; lbl_21_Prix.Content = ""; lbl_22.Content = ""; lbl_22_Prix.Content = ""; lbl_23.Content = ""; lbl_23_Prix.Content = "";
                lbl_24.Content = ""; lbl_24_Prix.Content = ""; lbl_25.Content = ""; lbl_25_Prix.Content = ""; lbl_26.Content = ""; lbl_26_Prix.Content = ""; lbl_27.Content = "";
                lbl_27_Prix.Content = ""; lbl_28.Content = ""; lbl_28_Prix.Content = ""; lbl_29.Content = ""; lbl_29_Prix.Content = ""; lbl_30.Content = ""; lbl_30_Prix.Content = "";

                lbl_31.Content = ""; lbl_31_Prix.Content = ""; lbl_32.Content = ""; lbl_32_Prix.Content = ""; lbl_33.Content = ""; lbl_33_Prix.Content = "";
                lbl_34.Content = ""; lbl_34_Prix.Content = ""; lbl_35.Content = ""; lbl_35_Prix.Content = ""; lbl_36.Content = ""; lbl_36_Prix.Content = ""; lbl_37.Content = "";
                lbl_37_Prix.Content = ""; lbl_38.Content = ""; lbl_38_Prix.Content = ""; lbl_39.Content = ""; lbl_39_Prix.Content = ""; lbl_40.Content = ""; lbl_40_Prix.Content = "";

                lbl_41.Content = ""; lbl_41_Prix.Content = ""; lbl_42.Content = ""; lbl_42_Prix.Content = ""; lbl_43.Content = ""; lbl_43_Prix.Content = "";
                lbl_44.Content = ""; lbl_44_Prix.Content = ""; lbl_45.Content = ""; lbl_45_Prix.Content = ""; lbl_46.Content = ""; lbl_46_Prix.Content = ""; lbl_47.Content = "";
                lbl_47_Prix.Content = ""; lbl_48.Content = ""; lbl_48_Prix.Content = ""; lbl_49.Content = ""; lbl_49_Prix.Content = ""; lbl_50.Content = ""; lbl_50_Prix.Content = "";

                lbl_51.Content = ""; lbl_51_Prix.Content = ""; lbl_52.Content = ""; lbl_52_Prix.Content = ""; lbl_53.Content = ""; lbl_53_Prix.Content = "";
                lbl_54.Content = ""; lbl_54_Prix.Content = ""; lbl_55.Content = ""; lbl_55_Prix.Content = ""; lbl_56.Content = ""; lbl_56_Prix.Content = ""; lbl_57.Content = "";
                lbl_57_Prix.Content = ""; lbl_58.Content = ""; lbl_58_Prix.Content = ""; lbl_59.Content = ""; lbl_59_Prix.Content = ""; lbl_60.Content = ""; lbl_60_Prix.Content = "";

                lbl_61.Content = ""; lbl_61_Prix.Content = ""; lbl_62.Content = ""; lbl_62_Prix.Content = ""; lbl_63.Content = ""; lbl_63_Prix.Content = "";
                lbl_64.Content = ""; lbl_64_Prix.Content = ""; lbl_65.Content = ""; lbl_65_Prix.Content = ""; lbl_66.Content = ""; lbl_66_Prix.Content = ""; lbl_67.Content = "";
                lbl_67_Prix.Content = ""; lbl_68.Content = ""; lbl_68_Prix.Content = ""; lbl_69.Content = ""; lbl_69_Prix.Content = ""; lbl_70.Content = ""; lbl_70_Prix.Content = "";

                lbl_71.Content = ""; lbl_71_Prix.Content = ""; lbl_72.Content = ""; lbl_72_Prix.Content = ""; lbl_73.Content = ""; lbl_73_Prix.Content = "";
                lbl_74.Content = ""; lbl_74_Prix.Content = ""; lbl_75.Content = ""; lbl_75_Prix.Content = ""; lbl_76.Content = ""; lbl_76_Prix.Content = ""; lbl_77.Content = "";
                lbl_77_Prix.Content = ""; lbl_78.Content = ""; lbl_78_Prix.Content = ""; lbl_79.Content = ""; lbl_79_Prix.Content = ""; lbl_80.Content = ""; lbl_80_Prix.Content = "";

                lbl_81.Content = ""; lbl_81_Prix.Content = ""; lbl_82.Content = ""; lbl_82_Prix.Content = ""; lbl_83.Content = ""; lbl_83_Prix.Content = "";
                lbl_84.Content = ""; lbl_84_Prix.Content = ""; lbl_85.Content = ""; lbl_85_Prix.Content = ""; lbl_86.Content = ""; lbl_86_Prix.Content = ""; lbl_87.Content = "";
                lbl_87_Prix.Content = ""; lbl_88.Content = ""; lbl_88_Prix.Content = ""; lbl_89.Content = ""; lbl_89_Prix.Content = ""; lbl_90.Content = ""; lbl_90_Prix.Content = "";
            }
        }

        private void ToMachine(int i, string description, string prix, string fabrikant)
        {
            if (i == 1) { lbl_1.Content = description; lbl_1_Prix.Content = prix; }
            if (i == 2) { lbl_2.Content = description; lbl_2_Prix.Content = prix; }
            if (i == 3) { lbl_3.Content = description; lbl_3_Prix.Content = prix; }
            if (i == 4) { lbl_4.Content = description; lbl_4_Prix.Content = prix; }
            if (i == 5) { lbl_5.Content = description; lbl_5_Prix.Content = prix; }
            if (i == 6) { lbl_6.Content = description; lbl_6_Prix.Content = prix; }
            if (i == 7) { lbl_7.Content = description; lbl_7_Prix.Content = prix; }
            if (i == 8) { lbl_8.Content = description; lbl_8_Prix.Content = prix; }
            if (i == 9) { lbl_9.Content = description; lbl_9_Prix.Content = prix; }
            if (i == 10) { lbl_10.Content = description; lbl_10_Prix.Content = prix; }

            if (i == 11) { lbl_11.Content = description; lbl_11_Prix.Content = prix; }
            if (i == 12) { lbl_12.Content = description; lbl_12_Prix.Content = prix; }
            if (i == 13) { lbl_13.Content = description; lbl_13_Prix.Content = prix; }
            if (i == 14) { lbl_14.Content = description; lbl_14_Prix.Content = prix; }
            if (i == 15) { lbl_15.Content = description; lbl_15_Prix.Content = prix; }
            if (i == 16) { lbl_16.Content = description; lbl_16_Prix.Content = prix; }
            if (i == 17) { lbl_17.Content = description; lbl_17_Prix.Content = prix; }
            if (i == 18) { lbl_18.Content = description; lbl_18_Prix.Content = prix; }
            if (i == 19) { lbl_19.Content = description; lbl_19_Prix.Content = prix; }
            if (i == 20) { lbl_20.Content = description; lbl_20_Prix.Content = prix; }

            if (i == 21) { lbl_21.Content = description; lbl_21_Prix.Content = prix; }
            if (i == 22) { lbl_22.Content = description; lbl_22_Prix.Content = prix; }
            if (i == 23) { lbl_23.Content = description; lbl_23_Prix.Content = prix; }
            if (i == 24) { lbl_24.Content = description; lbl_24_Prix.Content = prix; }
            if (i == 25) { lbl_25.Content = description; lbl_25_Prix.Content = prix; }
            if (i == 26) { lbl_26.Content = description; lbl_26_Prix.Content = prix; }
            if (i == 27) { lbl_27.Content = description; lbl_27_Prix.Content = prix; }
            if (i == 28) { lbl_28.Content = description; lbl_28_Prix.Content = prix; }
            if (i == 29) { lbl_29.Content = description; lbl_29_Prix.Content = prix; }
            if (i == 30) { lbl_30.Content = description; lbl_30_Prix.Content = prix; }

            if (i == 31) { lbl_31.Content = description; lbl_31_Prix.Content = prix; }
            if (i == 32) { lbl_32.Content = description; lbl_32_Prix.Content = prix; }
            if (i == 33) { lbl_33.Content = description; lbl_33_Prix.Content = prix; }
            if (i == 34) { lbl_34.Content = description; lbl_34_Prix.Content = prix; }
            if (i == 35) { lbl_35.Content = description; lbl_35_Prix.Content = prix; }
            if (i == 36) { lbl_36.Content = description; lbl_36_Prix.Content = prix; }
            if (i == 37) { lbl_37.Content = description; lbl_37_Prix.Content = prix; }
            if (i == 38) { lbl_38.Content = description; lbl_38_Prix.Content = prix; }
            if (i == 39) { lbl_39.Content = description; lbl_39_Prix.Content = prix; }
            if (i == 40) { lbl_40.Content = description; lbl_40_Prix.Content = prix; }

            if (i == 41) { lbl_41.Content = description; lbl_41_Prix.Content = prix; }
            if (i == 42) { lbl_42.Content = description; lbl_42_Prix.Content = prix; }
            if (i == 43) { lbl_43.Content = description; lbl_43_Prix.Content = prix; }
            if (i == 44) { lbl_44.Content = description; lbl_44_Prix.Content = prix; }
            if (i == 45) { lbl_45.Content = description; lbl_45_Prix.Content = prix; }
            if (i == 46) { lbl_46.Content = description; lbl_46_Prix.Content = prix; }
            if (i == 47) { lbl_47.Content = description; lbl_47_Prix.Content = prix; }
            if (i == 48) { lbl_48.Content = description; lbl_48_Prix.Content = prix; }
            if (i == 49) { lbl_49.Content = description; lbl_49_Prix.Content = prix; }
            if (i == 50) { lbl_50.Content = description; lbl_50_Prix.Content = prix; }

            if (i == 51) { lbl_51.Content = description; lbl_51_Prix.Content = prix; }
            if (i == 52) { lbl_52.Content = description; lbl_52_Prix.Content = prix; }
            if (i == 53) { lbl_53.Content = description; lbl_53_Prix.Content = prix; }
            if (i == 54) { lbl_54.Content = description; lbl_54_Prix.Content = prix; }
            if (i == 55) { lbl_55.Content = description; lbl_55_Prix.Content = prix; }
            if (i == 56) { lbl_56.Content = description; lbl_56_Prix.Content = prix; }
            if (i == 57) { lbl_57.Content = description; lbl_57_Prix.Content = prix; }
            if (i == 58) { lbl_58.Content = description; lbl_58_Prix.Content = prix; }
            if (i == 59) { lbl_59.Content = description; lbl_59_Prix.Content = prix; }
            if (i == 60) { lbl_60.Content = description; lbl_60_Prix.Content = prix; }

            if (i == 61) { lbl_61.Content = description; lbl_61_Prix.Content = prix; }
            if (i == 62) { lbl_62.Content = description; lbl_62_Prix.Content = prix; }
            if (i == 63) { lbl_63.Content = description; lbl_63_Prix.Content = prix; }
            if (i == 64) { lbl_64.Content = description; lbl_64_Prix.Content = prix; }
            if (i == 65) { lbl_65.Content = description; lbl_65_Prix.Content = prix; }
            if (i == 66) { lbl_66.Content = description; lbl_66_Prix.Content = prix; }
            if (i == 67) { lbl_67.Content = description; lbl_67_Prix.Content = prix; }
            if (i == 68) { lbl_68.Content = description; lbl_68_Prix.Content = prix; }
            if (i == 69) { lbl_69.Content = description; lbl_69_Prix.Content = prix; }
            if (i == 70) { lbl_70.Content = description; lbl_70_Prix.Content = prix; }

            if (i == 71) { lbl_71.Content = description; lbl_71_Prix.Content = prix; }
            if (i == 72) { lbl_72.Content = description; lbl_72_Prix.Content = prix; }
            if (i == 73) { lbl_73.Content = description; lbl_73_Prix.Content = prix; }
            if (i == 74) { lbl_74.Content = description; lbl_74_Prix.Content = prix; }
            if (i == 75) { lbl_75.Content = description; lbl_75_Prix.Content = prix; }
            if (i == 76) { lbl_76.Content = description; lbl_76_Prix.Content = prix; }
            if (i == 77) { lbl_77.Content = description; lbl_77_Prix.Content = prix; }
            if (i == 78) { lbl_78.Content = description; lbl_78_Prix.Content = prix; }
            if (i == 79) { lbl_79.Content = description; lbl_79_Prix.Content = prix; }
            if (i == 80) { lbl_80.Content = description; lbl_80_Prix.Content = prix; }

            if (i == 81) { lbl_81.Content = description; lbl_81_Prix.Content = prix; }
            if (i == 82) { lbl_82.Content = description; lbl_82_Prix.Content = prix; }
            if (i == 83) { lbl_83.Content = description; lbl_83_Prix.Content = prix; }
            if (i == 84) { lbl_84.Content = description; lbl_84_Prix.Content = prix; }
            if (i == 85) { lbl_85.Content = description; lbl_85_Prix.Content = prix; }
            if (i == 86) { lbl_86.Content = description; lbl_86_Prix.Content = prix; }
            if (i == 87) { lbl_87.Content = description; lbl_87_Prix.Content = prix; }
            if (i == 88) { lbl_88.Content = description; lbl_88_Prix.Content = prix; }
            if (i == 89) { lbl_89.Content = description; lbl_89_Prix.Content = prix; }
            if (i == 90) { lbl_90.Content = description; lbl_90_Prix.Content = prix; }
        }
    }
}
