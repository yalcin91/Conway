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
        private ObservableCollection<Product> _Producten;
        private ObservableCollection<BAT_Cigarette> _BAT_Cigaretten;
        private ObservableCollection<BAT_Tabac> _BAT_Tabac;
        private ObservableCollection<ITB_Cigarette> _ITB_Cigaretten;
        private ObservableCollection<ITB_Tabac> _ITB_Tabac;
        private ObservableCollection<JTI_Cigarette> _JTI_Cigaretten;
        private ObservableCollection<JTI_Tabac> _JTI_Tabac;
        private ObservableCollection<PMI_Cigarette> _PMI_Cigaretten;
        private ObservableCollection<Product> _Ini;

        public MainWindow()
        {
            InitializeComponent();
            ProductenWpf = new ProductenWpf();
            AssortimentWpf = new AssortimentWpf();
            _Producten = new ObservableCollection<Product>();
            _BAT_Cigaretten = new ObservableCollection<BAT_Cigarette>();
            _BAT_Tabac = new ObservableCollection<BAT_Tabac>();
            _ITB_Cigaretten = new ObservableCollection<ITB_Cigarette>();
            _ITB_Tabac = new ObservableCollection<ITB_Tabac>();
            _JTI_Cigaretten = new ObservableCollection<JTI_Cigarette>();
            _JTI_Tabac = new ObservableCollection<JTI_Tabac>();
            _PMI_Cigaretten = new ObservableCollection<PMI_Cigarette>();
            _Ini = new ObservableCollection<Product>();
            GetProduct();
            GetBAT_Cigarette();
            ProductenWpf.Closing += ProductenWpf_Closing;
            AssortimentWpf.Closing += AssortimentWpf_Closing;
            Closing += MainWindow_Closing;

            data_Product.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(DgSupp_PreviewMouseLeftButtonDown);
            data_Product.PreviewKeyDown += new KeyEventHandler(DgSupp_KeyPress);
            data_Product.PreviewKeyUp += new KeyEventHandler(DgSupp_KeyPress);
            Clear();
            StartIni();
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
            cb_Producten.ItemsSource = _Producten;
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

        private void btn_Export_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Ini Document (.ini)|*.ini";
            string path = null;
            if (saveFileDialog.ShowDialog() == true)
            {
                path = saveFileDialog.FileName;
            }
            // sort1=LUCKY_STRIKE_RED/50G 54039377 00000 1 1 0 14 0 011 0 0
            // [Global]
            // Date=20210323173036179
            // Propriétaire=DOCKX_YANNICK
            string sorts = "[sorts]";
            string sort = "sort";
            int sortnumber = 1;
            string gelijkaan = "=";
            string zero = "0000";
            int eerstenummer = 1;
            int tweedenummer = 1;
            int eertseConstZero = 0;
            int tweedeConstandZero = 0;
            int nulVoorPrijs = 0;
            int laatsteNulEen = 0;
            int laatsteNulTwee = 0;
            string space = " ";
            string gobal = "[Global]";
            string date = "Date=20210323173036179";
            string proprie = "Propriétaire=DOCKX_TOM";
            string dertienNullen = "0000000000000";

            if (path == null) { return; }
            using (TextWriter tw = new StreamWriter(path))
            {
                tw.WriteLine(sorts);
                for (int i = 0; i < _Ini.Count; i++)
                {
                    if (_Ini[i].Naam == "dismounted")
                    {
                        string prijs = _Ini[i].Prijs.ToString();
                        string newPrijs = prijs.Replace(",", ".");
                        string naam = _Ini[i].Naam;
                        string newNaam = naam.Replace(" ", "_");
                        tw.WriteLine(sort + sortnumber + gelijkaan + newNaam + space + dertienNullen + space + zero + space + eerstenummer + space + tweedenummer + space + eertseConstZero + space + 0 + space + tweedeConstandZero + space + nulVoorPrijs + newPrijs + space + laatsteNulEen + space + laatsteNulTwee);
                        sortnumber++;
                        eerstenummer++;
                        tweedenummer++;
                    }
                    else
                    {
                        string prijs = _Ini[i].Prijs.ToString();
                        string newPrijs = prijs.Replace(",", ".");
                        string naam = _Ini[i].Naam;
                        string newNaam = naam.Replace(" ", "_");
                        tw.WriteLine(sort + sortnumber + gelijkaan + newNaam + space + _Ini[i].Eancode + space + zero + space + eerstenummer + space + tweedenummer + space + eertseConstZero + space + 0 + space + tweedeConstandZero + space + nulVoorPrijs + newPrijs + space + laatsteNulEen + space + laatsteNulTwee);
                        sortnumber++;
                        eerstenummer++;
                        tweedenummer++;
                    }
                }
                tw.WriteLine(gobal);
                tw.WriteLine(date);
                tw.WriteLine(proprie);
                tw.Close();
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
            //StartIni();

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.DefaultExt = ".ini";
            ofd.Filter = "Ini Document (.ini)|*.ini";
            string path = null;
            if (ofd.ShowDialog() == true)
            {
                path = ofd.FileName;
            }

            string line;
            string volledigString = "";
            List<string> _VolledigString = new List<string>();
            long id = 1;
            long ean = 0;
            string description = "";
            string qt = "";
            string prix = "";
            string fabrikant = "";
            double hoogte = 0;
            double breedte = 0;
            string index = "";
            int inhoud = 0;
            List<string> _Naam = new List<string>();
            if (path != null)
            {
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
                                    ean = long.Parse(_VolledigString[(j + 1)]);
                                    //var money = "";
                                    if (j <= 1055)
                                    {
                                        qt = _VolledigString[(j + 6)];
                                    }
                                    if (j <= 1053)
                                    {
                                        //money = prix.ToString();
                                        if (_VolledigString[j + 8].First() == '0') { prix = _VolledigString[(j + 8)].Remove(0, 1); }
                                        else { prix = _VolledigString[(j + 8)]; }
                                    }
                                    for (int i = 0; i < _Producten.Count; i++)
                                    {
                                        if (_Producten[i].Eancode == ean) { fabrikant = _Producten[i].Fabrikant; hoogte = _Producten[i].Hoogte; breedte = _Producten[i].Breedte; inhoud = _Producten[i].Inhoud; }
                                    }
                                    string exampleTrimmed = String.Concat(fabrikant.Where(c => !Char.IsWhiteSpace(c)));
                                    double prix2 = double.Parse(prix, System.Globalization.CultureInfo.InvariantCulture);
                                    var data = new Product(id, description, fabrikant, hoogte, breedte, 0, inhoud, ean, prix2);
                                    CheckFabrikantAantal(fabrikant);
                                    var money = "\u20AC" + prix;
                                    ToMachine(id, description, money, fabrikant);
                                    _Fabrikant.Add(fabrikant);
                                    index = data.Id.ToString();
                                    int indexx = int.Parse(index);
                                    _Ini.Insert((indexx - 1), data);
                                    Breedte_Berekenen_Verminderen(id);
                                    id++;
                                    ean = 0;
                                    description = "";
                                    qt = "";
                                    prix = "";
                                    fabrikant = "";
                                    breedte = 0;
                                    hoogte = 0;
                                    inhoud = 0;
                                }
                            }
                            min++;
                        }
                    }
                    data_Ini.ItemsSource = _Ini;
                    reader.Close();
                }
            }
            else { Clear(); StartIni(); }
        }

        private void Breedte_Berekenen_Optellen(long id)
        {
            var product = _Ini.Where(x => x.Id == id).FirstOrDefault();
            if (product != null)
            {
                if (id >= 81 && id <= 90)
                {
                    Breedte_Links = Breedte_Links + product.Breedte;
                    lbl_Breedte_Links.Content = Breedte_Links.ToString();
                    if (Breedte_Links < 0)
                    {
                        lbl_Breedte_Links.Background = new System.Windows.Media.SolidColorBrush(Colors.Red);
                    }
                    else lbl_Breedte_Links.Background = new System.Windows.Media.SolidColorBrush(Colors.Green);
                }

                if (id >= 11 && id <= 20)
                {
                    Breedte_Rechts_Boven = Breedte_Rechts_Boven + product.Breedte;
                    lbl_Breedte_Rechts_Boven.Content = Breedte_Rechts_Boven.ToString();
                    if (Breedte_Rechts_Boven < 0)
                    {
                        lbl_Breedte_Rechts_Boven.Background = new System.Windows.Media.SolidColorBrush(Colors.Red);
                    }
                    else lbl_Breedte_Rechts_Boven.Background = new System.Windows.Media.SolidColorBrush(Colors.Green);
                }

                if (id >= 1 && id <= 10)
                {
                    Breedte_Rechts_Beneden = Breedte_Rechts_Beneden + product.Breedte;
                    lbl_Breedte_Rechts_Beneden.Content = Breedte_Rechts_Beneden.ToString();
                    if (Breedte_Rechts_Beneden < 0)
                    {
                        lbl_Breedte_Rechts_Beneden.Background = new System.Windows.Media.SolidColorBrush(Colors.Red);
                    }
                    else lbl_Breedte_Rechts_Beneden.Background = new System.Windows.Media.SolidColorBrush(Colors.Green);
                }

                if (id >= 61 && id <= 80)
                {
                    Breedte_Midden_Boven = Breedte_Midden_Boven + product.Breedte;
                    lbl_Breedte_Midden_Boven.Content = Breedte_Midden_Boven.ToString();
                    if (Breedte_Midden_Boven < 0)
                    {
                        lbl_Breedte_Midden_Boven.Background = new System.Windows.Media.SolidColorBrush(Colors.Red);
                    }
                    else lbl_Breedte_Midden_Boven.Background = new System.Windows.Media.SolidColorBrush(Colors.Green);
                }

                if (id >= 41 && id <= 60)
                {
                    Breedte_Midden_Midden = Breedte_Midden_Midden + product.Breedte;
                    lbl_Breedte_Midden_Midden.Content = Breedte_Midden_Midden.ToString();
                    if (Breedte_Midden_Midden < 0)
                    {
                        lbl_Breedte_Midden_Midden.Background = new System.Windows.Media.SolidColorBrush(Colors.Red);
                    }
                    else lbl_Breedte_Midden_Midden.Background = new System.Windows.Media.SolidColorBrush(Colors.Green);
                }

                if (id >= 21 && id <= 40)
                {
                    Breedte_Midden_Beneden = Breedte_Midden_Beneden + product.Breedte;
                    lbl_Breedte_Midden_Beneden.Content = Breedte_Midden_Beneden.ToString();
                    if (Breedte_Midden_Beneden < 0)
                    {
                        lbl_Breedte_Midden_Beneden.Background = new System.Windows.Media.SolidColorBrush(Colors.Red);
                    }
                    else lbl_Breedte_Midden_Beneden.Background = new System.Windows.Media.SolidColorBrush(Colors.Green);
                }
            }
        }

        private void Breedte_Berekenen_Verminderen(long id)
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
                    else lbl_Breedte_Links.Background = new System.Windows.Media.SolidColorBrush(Colors.Green);
                }

                if (id >= 11 && id <= 20)
                {
                    Breedte_Rechts_Boven = Breedte_Rechts_Boven - product.Breedte;
                    lbl_Breedte_Rechts_Boven.Content = Breedte_Rechts_Boven.ToString();
                    if (Breedte_Rechts_Boven < 0)
                    {
                        lbl_Breedte_Rechts_Boven.Background = new System.Windows.Media.SolidColorBrush(Colors.Red);
                    }
                    else lbl_Breedte_Rechts_Boven.Background = new System.Windows.Media.SolidColorBrush(Colors.Green);
                }

                if (id >= 1 && id <= 10)
                {
                    Breedte_Rechts_Beneden = Breedte_Rechts_Beneden - product.Breedte;
                    lbl_Breedte_Rechts_Beneden.Content = Breedte_Rechts_Beneden.ToString();
                    if (Breedte_Rechts_Beneden < 0)
                    {
                        lbl_Breedte_Rechts_Beneden.Background = new System.Windows.Media.SolidColorBrush(Colors.Red);
                    }
                    else lbl_Breedte_Rechts_Beneden.Background = new System.Windows.Media.SolidColorBrush(Colors.Green);
                }

                if (id >= 61 && id <= 80)
                {
                    Breedte_Midden_Boven = Breedte_Midden_Boven - product.Breedte;
                    lbl_Breedte_Midden_Boven.Content = Breedte_Midden_Boven.ToString();
                    if (Breedte_Midden_Boven < 0)
                    {
                        lbl_Breedte_Midden_Boven.Background = new System.Windows.Media.SolidColorBrush(Colors.Red);
                    }
                    else lbl_Breedte_Midden_Boven.Background = new System.Windows.Media.SolidColorBrush(Colors.Green);
                }

                if (id >= 41 && id <= 60)
                {
                    Breedte_Midden_Midden = Breedte_Midden_Midden - product.Breedte;
                    lbl_Breedte_Midden_Midden.Content = Breedte_Midden_Midden.ToString();
                    if (Breedte_Midden_Midden < 0)
                    {
                        lbl_Breedte_Midden_Midden.Background = new System.Windows.Media.SolidColorBrush(Colors.Red);
                    }
                    else lbl_Breedte_Midden_Midden.Background = new System.Windows.Media.SolidColorBrush(Colors.Green);
                }

                if (id >= 21 && id <= 40)
                {
                    Breedte_Midden_Beneden = Breedte_Midden_Beneden - product.Breedte;
                    lbl_Breedte_Midden_Beneden.Content = Breedte_Midden_Beneden.ToString();
                    if (Breedte_Midden_Beneden < 0)
                    {
                        lbl_Breedte_Midden_Beneden.Background = new System.Windows.Media.SolidColorBrush(Colors.Red);
                    }
                    else lbl_Breedte_Midden_Beneden.Background = new System.Windows.Media.SolidColorBrush(Colors.Green);
                }
            }
        }

        private void CheckFabrikantAantal(string fabrikant)
        {
            if (fabrikant == "BAT") { _BAT.Add(1); lbl_BAT.Content = _BAT.Count(); }
            if (fabrikant == "ITB") { _ITB.Add(1); lbl_ITB.Content = _ITB.Count(); }
            if (fabrikant == "JTI") { _JTI.Add(1); lbl_JTI.Content = _JTI.Count(); }
            if (fabrikant == "PMI") { _PMI.Add(1); lbl_PMI.Content = _PMI.Count(); }
        }

        private void CheckFabrikantAantal_Verminderen(string fabrikant)
        {
            if (fabrikant == "BAT") { _BAT.Remove(1); lbl_BAT.Content = _BAT.Count(); }
            if (fabrikant == "ITB") { _ITB.Remove(1); lbl_ITB.Content = _ITB.Count(); }
            if (fabrikant == "JTI") { _JTI.Remove(1); lbl_JTI.Content = _JTI.Count(); }
            if (fabrikant == "PMI") { _PMI.Remove(1); lbl_PMI.Content = _PMI.Count(); }
        }

        #region Fabrikant code kleur
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

        private void ChangeColor(string fabrikant)
        {
            for (int m = 0; m < _Ini.Count; m++)
            {
                if (_Ini[m].Fabrikant == fabrikant)
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

        private void Clear()
        {
            if (data_Ini != null)
            {
                _Ini = new ObservableCollection<Product>();
                _Fabrikant = new List<string>();
                _BAT = new List<int>();
                _ITB = new List<int>();
                _JTI = new List<int>();
                _PMI = new List<int>();

                _BAT.Clear();
                _ITB.Clear();
                _JTI.Clear();
                _PMI.Clear();

                lbl_BAT.Content = _BAT.Count();
                lbl_ITB.Content = _ITB.Count();
                lbl_JTI.Content = _JTI.Count();
                lbl_PMI.Content = _PMI.Count();

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

        private void ToMachine(long i, string description, string prix, string fabrikant)
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

        #region Drop change in machine
        private void lbl_1_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_1.Content = changedProduct.Naam; lbl_1_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 1); }
        private void lbl_2_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_2.Content = changedProduct.Naam; lbl_2_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 2); }
        private void lbl_3_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_3.Content = changedProduct.Naam; lbl_3_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 3); }
        private void lbl_4_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_4.Content = changedProduct.Naam; lbl_4_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 4); }
        private void lbl_5_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_5.Content = changedProduct.Naam; lbl_5_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 5); }

        private void lbl_6_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_6.Content = changedProduct.Naam; lbl_6_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 6); }
        private void lbl_7_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_7.Content = changedProduct.Naam; lbl_7_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 7); }
        private void lbl_8_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_8.Content = changedProduct.Naam; lbl_8_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 8); }
        private void lbl_9_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_9.Content = changedProduct.Naam; lbl_9_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 9); }
        private void lbl_10_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_10.Content = changedProduct.Naam; lbl_10_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 10); }

        private void lbl_11_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_11.Content = changedProduct.Naam; lbl_11_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 11); }
        private void lbl_12_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_12.Content = changedProduct.Naam; lbl_12_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 12); }
        private void lbl_13_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_13.Content = changedProduct.Naam; lbl_13_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 13); }
        private void lbl_14_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_14.Content = changedProduct.Naam; lbl_14_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 14); }
        private void lbl_15_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_15.Content = changedProduct.Naam; lbl_15_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 15); }

        private void lbl_16_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_16.Content = changedProduct.Naam; lbl_16_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 16); }
        private void lbl_17_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_17.Content = changedProduct.Naam; lbl_17_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 17); }
        private void lbl_18_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_18.Content = changedProduct.Naam; lbl_18_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 18); }
        private void lbl_19_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_19.Content = changedProduct.Naam; lbl_19_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 19); }
        private void lbl_20_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_20.Content = changedProduct.Naam; lbl_20_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 20); }

        private void lbl_21_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_21.Content = changedProduct.Naam; lbl_21_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 21); }
        private void lbl_22_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_22.Content = changedProduct.Naam; lbl_22_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 22); }
        private void lbl_23_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_23.Content = changedProduct.Naam; lbl_23_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 23); }
        private void lbl_24_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_24.Content = changedProduct.Naam; lbl_24_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 24); }
        private void lbl_25_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_25.Content = changedProduct.Naam; lbl_25_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 25); }

        private void lbl_26_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_26.Content = changedProduct.Naam; lbl_26_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 26); }
        private void lbl_27_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_27.Content = changedProduct.Naam; lbl_27_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 27); }
        private void lbl_28_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_28.Content = changedProduct.Naam; lbl_28_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 28); }
        private void lbl_29_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_29.Content = changedProduct.Naam; lbl_29_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 29); }
        private void lbl_30_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_30.Content = changedProduct.Naam; lbl_30_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 30); }

        private void lbl_31_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_31.Content = changedProduct.Naam; lbl_31_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 31); }
        private void lbl_32_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_32.Content = changedProduct.Naam; lbl_32_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 32); }
        private void lbl_33_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_33.Content = changedProduct.Naam; lbl_33_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 33); }
        private void lbl_34_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_34.Content = changedProduct.Naam; lbl_34_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 34); }
        private void lbl_35_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_35.Content = changedProduct.Naam; lbl_35_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 35); }

        private void lbl_36_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_36.Content = changedProduct.Naam; lbl_36_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 36); }
        private void lbl_37_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_37.Content = changedProduct.Naam; lbl_37_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 37); }
        private void lbl_38_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_38.Content = changedProduct.Naam; lbl_38_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 38); }
        private void lbl_39_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_39.Content = changedProduct.Naam; lbl_39_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 39); }
        private void lbl_40_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_40.Content = changedProduct.Naam; lbl_40_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 40); }

        private void lbl_41_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_41.Content = changedProduct.Naam; lbl_41_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 41); }
        private void lbl_42_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_42.Content = changedProduct.Naam; lbl_42_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 42); }
        private void lbl_43_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_43.Content = changedProduct.Naam; lbl_43_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 43); }
        private void lbl_44_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_44.Content = changedProduct.Naam; lbl_44_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 44); }
        private void lbl_45_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_45.Content = changedProduct.Naam; lbl_45_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 45); }

        private void lbl_46_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_46.Content = changedProduct.Naam; lbl_46_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 46); }
        private void lbl_47_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_47.Content = changedProduct.Naam; lbl_47_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 47); }
        private void lbl_48_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_48.Content = changedProduct.Naam; lbl_48_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 48); }
        private void lbl_49_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_49.Content = changedProduct.Naam; lbl_49_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 49); }
        private void lbl_50_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_50.Content = changedProduct.Naam; lbl_50_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 50); }

        private void lbl_51_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_51.Content = changedProduct.Naam; lbl_51_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 51); }
        private void lbl_52_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_52.Content = changedProduct.Naam; lbl_52_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 52); }
        private void lbl_53_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_53.Content = changedProduct.Naam; lbl_53_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 53); }
        private void lbl_54_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_54.Content = changedProduct.Naam; lbl_54_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 54); }
        private void lbl_55_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_55.Content = changedProduct.Naam; lbl_55_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 55); }

        private void lbl_56_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_56.Content = changedProduct.Naam; lbl_56_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 56); }
        private void lbl_57_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_57.Content = changedProduct.Naam; lbl_57_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 57); }
        private void lbl_58_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_58.Content = changedProduct.Naam; lbl_58_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 58); }
        private void lbl_59_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_59.Content = changedProduct.Naam; lbl_59_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 59); }
        private void lbl_60_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_60.Content = changedProduct.Naam; lbl_60_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 60); }

        private void lbl_61_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_61.Content = changedProduct.Naam; lbl_61_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 61); }
        private void lbl_62_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_62.Content = changedProduct.Naam; lbl_62_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 62); }
        private void lbl_63_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_63.Content = changedProduct.Naam; lbl_63_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 63); }
        private void lbl_64_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_64.Content = changedProduct.Naam; lbl_64_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 64); }
        private void lbl_65_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_65.Content = changedProduct.Naam; lbl_65_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 65); }

        private void lbl_66_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_66.Content = changedProduct.Naam; lbl_66_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 66); }
        private void lbl_67_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_67.Content = changedProduct.Naam; lbl_67_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 67); }
        private void lbl_68_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_68.Content = changedProduct.Naam; lbl_68_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 68); }
        private void lbl_69_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_69.Content = changedProduct.Naam; lbl_69_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 69); }
        private void lbl_70_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_70.Content = changedProduct.Naam; lbl_70_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 70); }

        private void lbl_71_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_71.Content = changedProduct.Naam; lbl_71_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 71); }
        private void lbl_72_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_72.Content = changedProduct.Naam; lbl_72_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 72); }
        private void lbl_73_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_73.Content = changedProduct.Naam; lbl_73_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 73); }
        private void lbl_74_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_74.Content = changedProduct.Naam; lbl_74_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 74); }
        private void lbl_75_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_75.Content = changedProduct.Naam; lbl_75_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 75); }

        private void lbl_76_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_76.Content = changedProduct.Naam; lbl_76_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 76); }
        private void lbl_77_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_77.Content = changedProduct.Naam; lbl_77_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 77); }
        private void lbl_78_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_78.Content = changedProduct.Naam; lbl_78_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 78); }
        private void lbl_79_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_79.Content = changedProduct.Naam; lbl_79_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 79); }
        private void lbl_80_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_80.Content = changedProduct.Naam; lbl_80_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 80); }

        private void lbl_81_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_81.Content = changedProduct.Naam; lbl_81_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 81); }
        private void lbl_82_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_82.Content = changedProduct.Naam; lbl_82_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 82); }
        private void lbl_83_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_83.Content = changedProduct.Naam; lbl_83_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 83); }
        private void lbl_84_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_84.Content = changedProduct.Naam; lbl_84_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 84); }
        private void lbl_85_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_85.Content = changedProduct.Naam; lbl_85_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 85); }

        private void lbl_86_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_86.Content = changedProduct.Naam; lbl_86_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 86); }
        private void lbl_87_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_87.Content = changedProduct.Naam; lbl_87_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 87); }
        private void lbl_88_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_88.Content = changedProduct.Naam; lbl_88_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 88); }
        private void lbl_89_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_89.Content = changedProduct.Naam; lbl_89_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 89); }
        private void lbl_90_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_90.Content = changedProduct.Naam; lbl_90_Prix.Content = changedProduct.Prijs; HerstelIni(changedProduct, 90); }
        #endregion

        private void HerstelIni(Product product, int id)
        {

            Product p = new Product(id, product.Naam, product.Fabrikant, product.Hoogte, product.Breedte, product.Diepte, product.Inhoud, product.Eancode, product.Prijs);
            var v = _Ini.Where(x => x.Id == id).FirstOrDefault();
            if (p != null)
            {
                if (p.Naam != "dismounted")
                {
                    Breedte_Berekenen_Optellen(p.Id);
                    CheckFabrikantAantal_Verminderen(v.Fabrikant);
                    _Ini.Remove(v);
                    p.Breedte = p.Breedte + 8.5;
                    _Ini.Insert((id - 1), p);
                    data_Ini.ItemsSource = _Ini;
                    Breedte_Berekenen_Verminderen(p.Id);
                    CheckFabrikantAantal(product.Fabrikant);
                    if (ClearCodeCheck == 1) { clearColor(); ClearCodeCheck = 0; }
                    return;
                }

                if (v.Naam == "dismounted")
                {
                    CheckFabrikantAantal_Verminderen(v.Fabrikant);
                    _Ini.Remove(v);
                    _Ini.Insert((id - 1), p);
                    data_Ini.ItemsSource = _Ini;
                    CheckFabrikantAantal(product.Fabrikant);
                    if (ClearCodeCheck == 1) { clearColor(); ClearCodeCheck = 0; }
                    return;
                }

                if (p.Naam == "dismounted")
                {
                    Breedte_Berekenen_Optellen(v.Id);
                    CheckFabrikantAantal_Verminderen(v.Fabrikant);
                    _Ini.Remove(v);
                    _Ini.Insert((id - 1), p);
                    data_Ini.ItemsSource = _Ini;
                    CheckFabrikantAantal(product.Fabrikant);
                    if (ClearCodeCheck == 1) { clearColor(); ClearCodeCheck = 0; }
                    return;
                }
            }
        }

        private void StartIni()
        {
            for (int i = 1; i < 91; i++)
            {
                Product product = new Product();
                product.SetNaam("dismounted");
                product.Id = i;
                _Ini.Add(product);
            }
            data_Ini.ItemsSource = _Ini;
        }

        #region Get row Index
        private int rowIndex = 0;
        private void DgSupp_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var b = 0;
            Product product = new Product();
            foreach (var item in data_Product.SelectedItems)
            {
                product = item as Product;
                b = (int)product.Id;
            }
            var currentRow = data_Product.SelectedItem;
            //var p = _Producten.Contains(currentRow);
            rowIndex = (b-1);
            data_Product.IsReadOnly = false;
        }
        #endregion

        private void DgSupp_KeyPress(object sender, KeyEventArgs e)
        {
            data_Product.IsReadOnly = true;
        }

        #region Maak grids leeg
        private void lbl_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            /*List<Label> obje = new List<Label>();   =>    Dit Zal later mijn update worden om codes te verkleinen zoals hieronder (alles zal in een loop zitten) !!!
            obje.Add(lbl_37);
            var v = obje[0];
            MessageBox.Show(v.Content.ToString()); return;*/
            if (ClearCodeCheck == 1) { clearColor(); ClearCodeCheck = 0; }
            FrameworkElement s = sender as FrameworkElement;
            string name = s.Name;
            Product product = new Product(1, "dismounted", "", 0, 0, 0, 0, 0, 0);
            if (name.ToString() == "lbl_1") { product.Id = 1; HerstelIni(product, 1); lbl_1.Content = "dismounted"; lbl_1_Prix.Content = "0"; }
            if (name.ToString() == "lbl_2") { product.Id = 2; HerstelIni(product, 2); lbl_2.Content = "dismounted"; lbl_2_Prix.Content = "0"; }
            if (name.ToString() == "lbl_3") { product.Id = 3; HerstelIni(product, 3); lbl_3.Content = "dismounted"; lbl_3_Prix.Content = "0"; }
            if (name.ToString() == "lbl_4") { product.Id = 4; HerstelIni(product, 4); lbl_4.Content = "dismounted"; lbl_4_Prix.Content = "0"; }
            if (name.ToString() == "lbl_5") { product.Id = 5; HerstelIni(product, 5); lbl_5.Content = "dismounted"; lbl_5_Prix.Content = "0"; }

            if (name.ToString() == "lbl_6") { product.Id = 6; HerstelIni(product, 6); lbl_6.Content = "dismounted"; lbl_6_Prix.Content = "0"; }
            if (name.ToString() == "lbl_7") { product.Id = 7; HerstelIni(product, 7); lbl_7.Content = "dismounted"; lbl_7_Prix.Content = "0"; }
            if (name.ToString() == "lbl_8") { product.Id = 8; HerstelIni(product, 8); lbl_8.Content = "dismounted"; lbl_8_Prix.Content = "0"; }
            if (name.ToString() == "lbl_9") { product.Id = 9; HerstelIni(product, 9); lbl_9.Content = "dismounted"; lbl_9_Prix.Content = "0"; }
            if (name.ToString() == "lbl_10") { product.Id = 10; HerstelIni(product, 10); lbl_10.Content = "dismounted"; lbl_10_Prix.Content = "0"; }

            if (name.ToString() == "lbl_11") { product.Id = 11; HerstelIni(product, 11); lbl_11.Content = "dismounted"; lbl_11_Prix.Content = "0"; }
            if (name.ToString() == "lbl_12") { product.Id = 12; HerstelIni(product, 12); lbl_12.Content = "dismounted"; lbl_12_Prix.Content = "0"; }
            if (name.ToString() == "lbl_13") { product.Id = 13; HerstelIni(product, 13); lbl_13.Content = "dismounted"; lbl_13_Prix.Content = "0"; }
            if (name.ToString() == "lbl_14") { product.Id = 14; HerstelIni(product, 14); lbl_14.Content = "dismounted"; lbl_14_Prix.Content = "0"; }
            if (name.ToString() == "lbl_15") { product.Id = 15; HerstelIni(product, 15); lbl_15.Content = "dismounted"; lbl_15_Prix.Content = "0"; }

            if (name.ToString() == "lbl_16") { product.Id = 16; HerstelIni(product, 16); lbl_16.Content = "dismounted"; lbl_16_Prix.Content = "0"; }
            if (name.ToString() == "lbl_17") { product.Id = 17; HerstelIni(product, 17); lbl_17.Content = "dismounted"; lbl_17_Prix.Content = "0"; }
            if (name.ToString() == "lbl_18") { product.Id = 18; HerstelIni(product, 18); lbl_18.Content = "dismounted"; lbl_18_Prix.Content = "0"; }
            if (name.ToString() == "lbl_19") { product.Id = 19; HerstelIni(product, 19); lbl_19.Content = "dismounted"; lbl_19_Prix.Content = "0"; }
            if (name.ToString() == "lbl_20") { product.Id = 20; HerstelIni(product, 20); lbl_20.Content = "dismounted"; lbl_20_Prix.Content = "0"; }

            if (name.ToString() == "lbl_21") { product.Id = 21; HerstelIni(product, 21); lbl_21.Content = "dismounted"; lbl_21_Prix.Content = "0"; }
            if (name.ToString() == "lbl_22") { product.Id = 22; HerstelIni(product, 22); lbl_22.Content = "dismounted"; lbl_22_Prix.Content = "0"; }
            if (name.ToString() == "lbl_23") { product.Id = 23; HerstelIni(product, 23); lbl_23.Content = "dismounted"; lbl_23_Prix.Content = "0"; }
            if (name.ToString() == "lbl_24") { product.Id = 24; HerstelIni(product, 24); lbl_24.Content = "dismounted"; lbl_24_Prix.Content = "0"; }
            if (name.ToString() == "lbl_25") { product.Id = 25; HerstelIni(product, 25); lbl_25.Content = "dismounted"; lbl_25_Prix.Content = "0"; }

            if (name.ToString() == "lbl_26") { product.Id = 26; HerstelIni(product, 26); lbl_26.Content = "dismounted"; lbl_26_Prix.Content = "0"; }
            if (name.ToString() == "lbl_27") { product.Id = 27; HerstelIni(product, 27); lbl_27.Content = "dismounted"; lbl_27_Prix.Content = "0"; }
            if (name.ToString() == "lbl_28") { product.Id = 28; HerstelIni(product, 28); lbl_28.Content = "dismounted"; lbl_28_Prix.Content = "0"; }
            if (name.ToString() == "lbl_29") { product.Id = 29; HerstelIni(product, 29); lbl_29.Content = "dismounted"; lbl_29_Prix.Content = "0"; }
            if (name.ToString() == "lbl_30") { product.Id = 30; HerstelIni(product, 30); lbl_30.Content = "dismounted"; lbl_30_Prix.Content = "0"; }

            if (name.ToString() == "lbl_31") { product.Id = 31; HerstelIni(product, 31); lbl_31.Content = "dismounted"; lbl_31_Prix.Content = "0"; }
            if (name.ToString() == "lbl_32") { product.Id = 32; HerstelIni(product, 32); lbl_32.Content = "dismounted"; lbl_32_Prix.Content = "0"; }
            if (name.ToString() == "lbl_33") { product.Id = 33; HerstelIni(product, 33); lbl_33.Content = "dismounted"; lbl_33_Prix.Content = "0"; }
            if (name.ToString() == "lbl_34") { product.Id = 34; HerstelIni(product, 34); lbl_34.Content = "dismounted"; lbl_34_Prix.Content = "0"; }
            if (name.ToString() == "lbl_35") { product.Id = 35; HerstelIni(product, 35); lbl_35.Content = "dismounted"; lbl_35_Prix.Content = "0"; }

            if (name.ToString() == "lbl_36") { product.Id = 36; HerstelIni(product, 36); lbl_36.Content = "dismounted"; lbl_36_Prix.Content = "0"; }
            if (name.ToString() == "lbl_37") { product.Id = 37; HerstelIni(product, 37); lbl_37.Content = "dismounted"; lbl_37_Prix.Content = "0"; }
            if (name.ToString() == "lbl_38") { product.Id = 38; HerstelIni(product, 38); lbl_38.Content = "dismounted"; lbl_38_Prix.Content = "0"; }
            if (name.ToString() == "lbl_39") { product.Id = 39; HerstelIni(product, 39); lbl_39.Content = "dismounted"; lbl_39_Prix.Content = "0"; }
            if (name.ToString() == "lbl_40") { product.Id = 40; HerstelIni(product, 40); lbl_40.Content = "dismounted"; lbl_40_Prix.Content = "0"; }

            if (name.ToString() == "lbl_41") { product.Id = 41; HerstelIni(product, 41); lbl_41.Content = "dismounted"; lbl_41_Prix.Content = "0"; }
            if (name.ToString() == "lbl_42") { product.Id = 42; HerstelIni(product, 42); lbl_42.Content = "dismounted"; lbl_42_Prix.Content = "0"; }
            if (name.ToString() == "lbl_43") { product.Id = 43; HerstelIni(product, 43); lbl_43.Content = "dismounted"; lbl_43_Prix.Content = "0"; }
            if (name.ToString() == "lbl_44") { product.Id = 44; HerstelIni(product, 44); lbl_44.Content = "dismounted"; lbl_44_Prix.Content = "0"; }
            if (name.ToString() == "lbl_45") { product.Id = 45; HerstelIni(product, 45); lbl_45.Content = "dismounted"; lbl_45_Prix.Content = "0"; }
        
            if (name.ToString() == "lbl_46") { product.Id = 46; HerstelIni(product, 46); lbl_46.Content = "dismounted"; lbl_46_Prix.Content = "0"; }
            if (name.ToString() == "lbl_47") { product.Id = 47; HerstelIni(product, 47); lbl_47.Content = "dismounted"; lbl_47_Prix.Content = "0"; }
            if (name.ToString() == "lbl_48") { product.Id = 48; HerstelIni(product, 48); lbl_48.Content = "dismounted"; lbl_48_Prix.Content = "0"; }
            if (name.ToString() == "lbl_49") { product.Id = 49; HerstelIni(product, 49); lbl_49.Content = "dismounted"; lbl_49_Prix.Content = "0"; }
            if (name.ToString() == "lbl_50") { product.Id = 50; HerstelIni(product, 50); lbl_50.Content = "dismounted"; lbl_50_Prix.Content = "0"; }

            if (name.ToString() == "lbl_51") { product.Id = 51; HerstelIni(product, 51); lbl_51.Content = "dismounted"; lbl_51_Prix.Content = "0"; }
            if (name.ToString() == "lbl_52") { product.Id = 52; HerstelIni(product, 52); lbl_52.Content = "dismounted"; lbl_52_Prix.Content = "0"; }
            if (name.ToString() == "lbl_53") { product.Id = 53; HerstelIni(product, 53); lbl_53.Content = "dismounted"; lbl_53_Prix.Content = "0"; }
            if (name.ToString() == "lbl_54") { product.Id = 54; HerstelIni(product, 54); lbl_54.Content = "dismounted"; lbl_54_Prix.Content = "0"; }
            if (name.ToString() == "lbl_55") { product.Id = 55; HerstelIni(product, 55); lbl_55.Content = "dismounted"; lbl_55_Prix.Content = "0"; }

            if (name.ToString() == "lbl_56") { product.Id = 56; HerstelIni(product, 56); lbl_56.Content = "dismounted"; lbl_56_Prix.Content = "0"; }
            if (name.ToString() == "lbl_57") { product.Id = 57; HerstelIni(product, 57); lbl_57.Content = "dismounted"; lbl_57_Prix.Content = "0"; }
            if (name.ToString() == "lbl_58") { product.Id = 58; HerstelIni(product, 58); lbl_58.Content = "dismounted"; lbl_58_Prix.Content = "0"; }
            if (name.ToString() == "lbl_59") { product.Id = 59; HerstelIni(product, 59); lbl_59.Content = "dismounted"; lbl_59_Prix.Content = "0"; }
            if (name.ToString() == "lbl_60") { product.Id = 60; HerstelIni(product, 60); lbl_60.Content = "dismounted"; lbl_60_Prix.Content = "0"; }

            if (name.ToString() == "lbl_61") { product.Id = 61; HerstelIni(product, 61); lbl_61.Content = "dismounted"; lbl_61_Prix.Content = "0"; }
            if (name.ToString() == "lbl_62") { product.Id = 62; HerstelIni(product, 62); lbl_62.Content = "dismounted"; lbl_62_Prix.Content = "0"; }
            if (name.ToString() == "lbl_63") { product.Id = 63; HerstelIni(product, 63); lbl_63.Content = "dismounted"; lbl_63_Prix.Content = "0"; }
            if (name.ToString() == "lbl_64") { product.Id = 64; HerstelIni(product, 64); lbl_64.Content = "dismounted"; lbl_64_Prix.Content = "0"; }
            if (name.ToString() == "lbl_65") { product.Id = 65; HerstelIni(product, 65); lbl_65.Content = "dismounted"; lbl_65_Prix.Content = "0"; }

            if (name.ToString() == "lbl_66") { product.Id = 66; HerstelIni(product, 66); lbl_66.Content = "dismounted"; lbl_66_Prix.Content = "0"; }
            if (name.ToString() == "lbl_67") { product.Id = 67; HerstelIni(product, 67); lbl_67.Content = "dismounted"; lbl_67_Prix.Content = "0"; }
            if (name.ToString() == "lbl_68") { product.Id = 68; HerstelIni(product, 68); lbl_68.Content = "dismounted"; lbl_68_Prix.Content = "0"; }
            if (name.ToString() == "lbl_69") { product.Id = 69; HerstelIni(product, 69); lbl_69.Content = "dismounted"; lbl_69_Prix.Content = "0"; }
            if (name.ToString() == "lbl_70") { product.Id = 70; HerstelIni(product, 70); lbl_70.Content = "dismounted"; lbl_70_Prix.Content = "0"; }

            if (name.ToString() == "lbl_71") { product.Id = 71; HerstelIni(product, 71); lbl_71.Content = "dismounted"; lbl_71_Prix.Content = "0"; }
            if (name.ToString() == "lbl_72") { product.Id = 72; HerstelIni(product, 72); lbl_72.Content = "dismounted"; lbl_72_Prix.Content = "0"; }
            if (name.ToString() == "lbl_73") { product.Id = 73; HerstelIni(product, 73); lbl_73.Content = "dismounted"; lbl_73_Prix.Content = "0"; }
            if (name.ToString() == "lbl_74") { product.Id = 74; HerstelIni(product, 74); lbl_74.Content = "dismounted"; lbl_74_Prix.Content = "0"; }
            if (name.ToString() == "lbl_75") { product.Id = 75; HerstelIni(product, 75); lbl_75.Content = "dismounted"; lbl_75_Prix.Content = "0"; }

            if (name.ToString() == "lbl_76") { product.Id = 76; HerstelIni(product, 76); lbl_76.Content = "dismounted"; lbl_76_Prix.Content = "0"; }
            if (name.ToString() == "lbl_77") { product.Id = 77; HerstelIni(product, 77); lbl_77.Content = "dismounted"; lbl_77_Prix.Content = "0"; }
            if (name.ToString() == "lbl_78") { product.Id = 78; HerstelIni(product, 78); lbl_78.Content = "dismounted"; lbl_78_Prix.Content = "0"; }
            if (name.ToString() == "lbl_79") { product.Id = 79; HerstelIni(product, 79); lbl_79.Content = "dismounted"; lbl_79_Prix.Content = "0"; }
            if (name.ToString() == "lbl_80") { product.Id = 80; HerstelIni(product, 80); lbl_80.Content = "dismounted"; lbl_80_Prix.Content = "0"; }

            if (name.ToString() == "lbl_81") { product.Id = 81; HerstelIni(product, 81); lbl_81.Content = "dismounted"; lbl_81_Prix.Content = "0"; }
            if (name.ToString() == "lbl_82") { product.Id = 82; HerstelIni(product, 82); lbl_82.Content = "dismounted"; lbl_82_Prix.Content = "0"; }
            if (name.ToString() == "lbl_83") { product.Id = 83; HerstelIni(product, 83); lbl_83.Content = "dismounted"; lbl_83_Prix.Content = "0"; }
            if (name.ToString() == "lbl_84") { product.Id = 84; HerstelIni(product, 84); lbl_84.Content = "dismounted"; lbl_84_Prix.Content = "0"; }
            if (name.ToString() == "lbl_85") { product.Id = 85; HerstelIni(product, 85); lbl_85.Content = "dismounted"; lbl_85_Prix.Content = "0"; }

            if (name.ToString() == "lbl_86") { product.Id = 86; HerstelIni(product, 86); lbl_86.Content = "dismounted"; lbl_86_Prix.Content = "0"; }
            if (name.ToString() == "lbl_87") { product.Id = 87; HerstelIni(product, 87); lbl_87.Content = "dismounted"; lbl_87_Prix.Content = "0"; }
            if (name.ToString() == "lbl_88") { product.Id = 88; HerstelIni(product, 88); lbl_88.Content = "dismounted"; lbl_88_Prix.Content = "0"; }
            if (name.ToString() == "lbl_89") { product.Id = 89; HerstelIni(product, 89); lbl_89.Content = "dismounted"; lbl_89_Prix.Content = "0"; }
            if (name.ToString() == "lbl_90") { product.Id = 90; HerstelIni(product, 90); lbl_90.Content = "dismounted"; lbl_90_Prix.Content = "0"; }

            lbl_BAT.Content = _BAT.Count();
            lbl_ITB.Content = _ITB.Count();
            lbl_JTI.Content = _JTI.Count();
            lbl_PMI.Content = _PMI.Count();
        }
        #endregion

        #region Kleuren voor aantal pakken
        private void btn_20_Inhoud_Click(object sender, RoutedEventArgs e)
        {
            if (ClearCodeCheck == 0)
            {
                clearColor();
                for (int m = 0; m < _Ini.Count; m++)
                {
                    if (_Ini[m].Inhoud == 20)
                    {
                        if (m == 0) clm_1.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 1) clm_2.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 2) clm_3.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 3) clm_4.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 4) clm_5.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 5) clm_6.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 6) clm_7.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 7) clm_8.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 8) clm_9.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 9) clm_10.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);

                        if (m == 10) clm_11.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 11) clm_12.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 12) clm_13.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 13) clm_14.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 14) clm_15.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 15) clm_16.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 16) clm_17.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 17) clm_18.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 18) clm_19.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 19) clm_20.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);

                        if (m == 20) clm_21.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 21) clm_22.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 22) clm_23.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 23) clm_24.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 24) clm_25.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 25) clm_26.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 26) clm_27.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 27) clm_28.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 28) clm_29.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 29) clm_30.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);

                        if (m == 30) clm_31.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 31) clm_32.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 32) clm_33.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 33) clm_34.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 34) clm_35.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 35) clm_36.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 36) clm_37.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 37) clm_38.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 38) clm_39.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 39) clm_40.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);

                        if (m == 40) clm_41.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 41) clm_42.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 42) clm_43.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 43) clm_44.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 44) clm_45.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 45) clm_46.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 46) clm_47.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 47) clm_48.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 48) clm_49.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 49) clm_50.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);

                        if (m == 50) clm_51.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 51) clm_52.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 52) clm_53.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 53) clm_54.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 54) clm_55.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 55) clm_56.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 56) clm_57.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 57) clm_58.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 58) clm_59.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 59) clm_60.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);

                        if (m == 60) clm_61.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 61) clm_62.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 62) clm_63.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 63) clm_64.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 64) clm_65.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 65) clm_66.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 66) clm_67.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 67) clm_68.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 68) clm_69.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 69) clm_70.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);

                        if (m == 70) clm_71.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 71) clm_72.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 72) clm_73.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 73) clm_74.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 74) clm_75.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 75) clm_76.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 76) clm_77.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 77) clm_78.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 78) clm_79.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 79) clm_80.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);

                        if (m == 80) clm_81.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 81) clm_82.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 82) clm_83.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 83) clm_84.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 84) clm_85.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 85) clm_86.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 86) clm_87.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 87) clm_88.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 88) clm_89.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        if (m == 89) clm_90.Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                    }
                }
                    ClearCodeCheck = 1;
            }
            else { clearColor(); ClearCodeCheck = 0; }
        }

        private void btn_21_46_Click(object sender, RoutedEventArgs e)
        {
            if (ClearCodeCheck == 0)
            {
                clearColor();
                for (int m = 0; m < _Ini.Count; m++)
                {
                    if (_Ini[m].Inhoud >= 21 && _Ini[m].Inhoud <= 46)
                    {
                        if (m == 0) clm_1.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 1) clm_2.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 2) clm_3.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 3) clm_4.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 4) clm_5.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 5) clm_6.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 6) clm_7.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 7) clm_8.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 8) clm_9.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 9) clm_10.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);

                        if (m == 10) clm_11.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 11) clm_12.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 12) clm_13.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 13) clm_14.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 14) clm_15.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 15) clm_16.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 16) clm_17.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 17) clm_18.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 18) clm_19.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 19) clm_20.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);

                        if (m == 20) clm_21.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 21) clm_22.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 22) clm_23.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 23) clm_24.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 24) clm_25.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 25) clm_26.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 26) clm_27.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 27) clm_28.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 28) clm_29.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 29) clm_30.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);

                        if (m == 30) clm_31.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 31) clm_32.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 32) clm_33.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 33) clm_34.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 34) clm_35.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 35) clm_36.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 36) clm_37.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 37) clm_38.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 38) clm_39.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 39) clm_40.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);

                        if (m == 40) clm_41.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 41) clm_42.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 42) clm_43.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 43) clm_44.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 44) clm_45.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 45) clm_46.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 46) clm_47.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 47) clm_48.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 48) clm_49.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 49) clm_50.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);

                        if (m == 50) clm_51.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 51) clm_52.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 52) clm_53.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 53) clm_54.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 54) clm_55.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 55) clm_56.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 56) clm_57.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 57) clm_58.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 58) clm_59.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 59) clm_60.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);

                        if (m == 60) clm_61.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 61) clm_62.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 62) clm_63.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 63) clm_64.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 64) clm_65.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 65) clm_66.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 66) clm_67.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 67) clm_68.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 68) clm_69.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 69) clm_70.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);

                        if (m == 70) clm_71.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 71) clm_72.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 72) clm_73.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 73) clm_74.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 74) clm_75.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 75) clm_76.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 76) clm_77.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 77) clm_78.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 78) clm_79.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 79) clm_80.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);

                        if (m == 80) clm_81.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 81) clm_82.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 82) clm_83.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 83) clm_84.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 84) clm_85.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 85) clm_86.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 86) clm_87.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 87) clm_88.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 88) clm_89.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        if (m == 89) clm_90.Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                    }
                }
                    ClearCodeCheck = 1;
            }
            else { clearColor(); ClearCodeCheck = 0; }
        }

        private void btn_47_60_Click(object sender, RoutedEventArgs e)
        {
            if (ClearCodeCheck == 0)
            {
                clearColor();
                for (int m = 0; m < _Ini.Count; m++)
                {
                    if (_Ini[m].Inhoud >= 47 && _Ini[m].Inhoud <= 60)
                    {
                        if (m == 0) clm_1.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 1) clm_2.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 2) clm_3.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 3) clm_4.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 4) clm_5.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 5) clm_6.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 6) clm_7.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 7) clm_8.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 8) clm_9.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 9) clm_10.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);

                        if (m == 10) clm_11.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 11) clm_12.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 12) clm_13.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 13) clm_14.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 14) clm_15.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 15) clm_16.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 16) clm_17.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 17) clm_18.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 18) clm_19.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 19) clm_20.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);

                        if (m == 20) clm_21.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 21) clm_22.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 22) clm_23.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 23) clm_24.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 24) clm_25.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 25) clm_26.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 26) clm_27.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 27) clm_28.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 28) clm_29.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 29) clm_30.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);

                        if (m == 30) clm_31.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 31) clm_32.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 32) clm_33.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 33) clm_34.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 34) clm_35.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 35) clm_36.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 36) clm_37.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 37) clm_38.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 38) clm_39.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 39) clm_40.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);

                        if (m == 40) clm_41.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 41) clm_42.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 42) clm_43.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 43) clm_44.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 44) clm_45.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 45) clm_46.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 46) clm_47.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 47) clm_48.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 48) clm_49.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 49) clm_50.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);

                        if (m == 50) clm_51.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 51) clm_52.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 52) clm_53.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 53) clm_54.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 54) clm_55.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 55) clm_56.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 56) clm_57.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 57) clm_58.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 58) clm_59.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 59) clm_60.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);

                        if (m == 60) clm_61.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 61) clm_62.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 62) clm_63.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 63) clm_64.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 64) clm_65.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 65) clm_66.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 66) clm_67.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 67) clm_68.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 68) clm_69.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 69) clm_70.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);

                        if (m == 70) clm_71.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 71) clm_72.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 72) clm_73.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 73) clm_74.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 74) clm_75.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 75) clm_76.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 76) clm_77.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 77) clm_78.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 78) clm_79.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 79) clm_80.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);

                        if (m == 80) clm_81.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 81) clm_82.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 82) clm_83.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 83) clm_84.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 84) clm_85.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 85) clm_86.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 86) clm_87.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 87) clm_88.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 88) clm_89.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        if (m == 89) clm_90.Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                    }
                }
                ClearCodeCheck = 1;
            }
            else { clearColor(); ClearCodeCheck = 0; }
        }
        #endregion

        private void cb_Producten_KeyUp(object sender, KeyEventArgs e)
        {
            var v = cb_Producten.SelectedItem;
            if (v == null) { return; }
            data_Product.ScrollIntoView(v);
        }
    }
}