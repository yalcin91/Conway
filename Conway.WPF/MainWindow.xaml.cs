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
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
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

        private List<Label> _lbl_Prix;
        private List<Label> _lbl_Grids;
        private List<Border> _clm;

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
            _lbl_Grids = new List<Label>();
            _lbl_Prix = new List<Label>();
            _clm = new List<Border>();
            LabelsInLijst();
            LabelsPrixInLijst();
            GridsInList();
            GetProduct();
            GetBAT_Cigarette();
            ProductenWpf.Closing += ProductenWpf_Closing;
            AssortimentWpf.Closing += AssortimentWpf_Closing;
            Closing += MainWindow_Closing;

            ProductenWpf.Update += Vernieuwen;

            data_Product.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(DgSupp_PreviewMouseLeftButtonDown);
            data_Product.PreviewMouseLeftButtonUp += new MouseButtonEventHandler(DgSupp_PreviewMouseLeftButtonUp);
            data_Product.PreviewKeyDown += new KeyEventHandler(DgSupp_KeyPress);
            data_Product.PreviewKeyUp += new KeyEventHandler(DgSupp_KeyPress);
            Clear();
            StartIni();
        }

        #region Mijn Event Methode
        public void Vernieuwen(object sender, RoutedEventArgs e)
        {
            GetProduct();
        }
        #endregion

        #region Get all Products
        private async void GetProduct()
        {
            long id = 1;
            var producten = await Context.Product_Manager.GetProducten();
            _Producten = new ObservableCollection<Product>();
            foreach (var item in producten)
            {
                item.Id = id;
                _Producten.Add(item);
                id++;
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
        private List<int> _Activatie = new List<int>();
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
            if (MessageBox.Show("Als u doorgaat word alles verwijderd!!", "Maak uw keuze", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
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
                string activatie = "";
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
                                            if (_Producten[i].Eancode == ean) { fabrikant = _Producten[i].Fabrikant; activatie = _Producten[i].Activatie; hoogte = _Producten[i].Hoogte; breedte = _Producten[i].Breedte; inhoud = _Producten[i].Inhoud; }
                                        }
                                        string exampleTrimmed = String.Concat(fabrikant.Where(c => !Char.IsWhiteSpace(c)));
                                        double prix2 = double.Parse(prix, System.Globalization.CultureInfo.InvariantCulture);
                                        var data = new Product(id, description, activatie, fabrikant, hoogte, breedte, 0, inhoud, ean, prix2);
                                        CheckFabrikantAantal(fabrikant);
                                        CheckAantalNietActief(activatie);
                                        var money = prix;
                                        ToMachine(id, description, money, fabrikant);
                                        _Fabrikant.Add(fabrikant);
                                        index = data.Id.ToString();
                                        int indexx = int.Parse(index);
                                        _Ini.Insert((indexx - 1), data);
                                        Breedte_Berekenen_Verminderen(id);
                                        id++;
                                        ean = 0;
                                        description = "";
                                        activatie = "";
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
            else return;
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

        private void CheckAantalNietActief(string activatie)
        {
            if (activatie == "Niet Actief") { _Activatie.Add(1); lbl_NietActief.Content = _Activatie.Count(); }
        }

        private void CheckAantalNietActiefVerminderen(string activatie)
        {
            if (activatie == "Niet Actief") { _Activatie.Remove(1); lbl_NietActief.Content = _Activatie.Count(); }
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
                _Activatie = new List<int>();

                _BAT.Clear();
                _ITB.Clear();
                _JTI.Clear();
                _PMI.Clear();
                _Activatie.Clear();

                lbl_BAT.Content = _BAT.Count();
                lbl_ITB.Content = _ITB.Count();
                lbl_JTI.Content = _JTI.Count();
                lbl_PMI.Content = _PMI.Count();
                lbl_NietActief.Content = _Activatie.Count();

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

                foreach (var elementen in _lbl_Grids)
                {
                    elementen.Content = "";
                }

                foreach (var elementen in _lbl_Prix)
                {
                    elementen.Content = "";
                }
            }
        }

        private void ToMachine(long i, string description, string prix, string fabrikant)
        {
            for (int k = 0; k < 90; k++)
            {
                if (i == k+1) { _lbl_Grids[k].Content = description; _lbl_Prix[k].Content = "\u20AC" + prix; }
            }
        }

        #region Drop change in machine
        private void lbl_1_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_1.Content = changedProduct.Naam; lbl_1_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 1); }
        private void lbl_2_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_2.Content = changedProduct.Naam; lbl_2_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 2); }
        private void lbl_3_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_3.Content = changedProduct.Naam; lbl_3_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 3); }
        private void lbl_4_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_4.Content = changedProduct.Naam; lbl_4_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 4); }
        private void lbl_5_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_5.Content = changedProduct.Naam; lbl_5_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 5); }

        private void lbl_6_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_6.Content = changedProduct.Naam; lbl_6_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 6); }
        private void lbl_7_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_7.Content = changedProduct.Naam; lbl_7_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 7); }
        private void lbl_8_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_8.Content = changedProduct.Naam; lbl_8_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 8); }
        private void lbl_9_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_9.Content = changedProduct.Naam; lbl_9_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 9); }
        private void lbl_10_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_10.Content = changedProduct.Naam; lbl_10_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 10); }

        private void lbl_11_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_11.Content = changedProduct.Naam; lbl_11_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 11); }
        private void lbl_12_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_12.Content = changedProduct.Naam; lbl_12_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 12); }
        private void lbl_13_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_13.Content = changedProduct.Naam; lbl_13_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 13); }
        private void lbl_14_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_14.Content = changedProduct.Naam; lbl_14_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 14); }
        private void lbl_15_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_15.Content = changedProduct.Naam; lbl_15_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 15); }

        private void lbl_16_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_16.Content = changedProduct.Naam; lbl_16_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 16); }
        private void lbl_17_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_17.Content = changedProduct.Naam; lbl_17_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 17); }
        private void lbl_18_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_18.Content = changedProduct.Naam; lbl_18_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 18); }
        private void lbl_19_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_19.Content = changedProduct.Naam; lbl_19_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 19); }
        private void lbl_20_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_20.Content = changedProduct.Naam; lbl_20_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 20); }

        private void lbl_21_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_21.Content = changedProduct.Naam; lbl_21_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 21); }
        private void lbl_22_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_22.Content = changedProduct.Naam; lbl_22_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 22); }
        private void lbl_23_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_23.Content = changedProduct.Naam; lbl_23_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 23); }
        private void lbl_24_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_24.Content = changedProduct.Naam; lbl_24_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 24); }
        private void lbl_25_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_25.Content = changedProduct.Naam; lbl_25_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 25); }

        private void lbl_26_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_26.Content = changedProduct.Naam; lbl_26_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 26); }
        private void lbl_27_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_27.Content = changedProduct.Naam; lbl_27_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 27); }
        private void lbl_28_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_28.Content = changedProduct.Naam; lbl_28_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 28); }
        private void lbl_29_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_29.Content = changedProduct.Naam; lbl_29_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 29); }
        private void lbl_30_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_30.Content = changedProduct.Naam; lbl_30_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 30); }

        private void lbl_31_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_31.Content = changedProduct.Naam; lbl_31_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 31); }
        private void lbl_32_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_32.Content = changedProduct.Naam; lbl_32_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 32); }
        private void lbl_33_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_33.Content = changedProduct.Naam; lbl_33_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 33); }
        private void lbl_34_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_34.Content = changedProduct.Naam; lbl_34_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 34); }
        private void lbl_35_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_35.Content = changedProduct.Naam; lbl_35_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 35); }

        private void lbl_36_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_36.Content = changedProduct.Naam; lbl_36_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 36); }
        private void lbl_37_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_37.Content = changedProduct.Naam; lbl_37_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 37); }
        private void lbl_38_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_38.Content = changedProduct.Naam; lbl_38_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 38); }
        private void lbl_39_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_39.Content = changedProduct.Naam; lbl_39_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 39); }
        private void lbl_40_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_40.Content = changedProduct.Naam; lbl_40_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 40); }

        private void lbl_41_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_41.Content = changedProduct.Naam; lbl_41_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 41); }
        private void lbl_42_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_42.Content = changedProduct.Naam; lbl_42_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 42); }
        private void lbl_43_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_43.Content = changedProduct.Naam; lbl_43_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 43); }
        private void lbl_44_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_44.Content = changedProduct.Naam; lbl_44_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 44); }
        private void lbl_45_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_45.Content = changedProduct.Naam; lbl_45_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 45); }

        private void lbl_46_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_46.Content = changedProduct.Naam; lbl_46_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 46); }
        private void lbl_47_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_47.Content = changedProduct.Naam; lbl_47_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 47); }
        private void lbl_48_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_48.Content = changedProduct.Naam; lbl_48_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 48); }
        private void lbl_49_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_49.Content = changedProduct.Naam; lbl_49_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 49); }
        private void lbl_50_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_50.Content = changedProduct.Naam; lbl_50_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 50); }

        private void lbl_51_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_51.Content = changedProduct.Naam; lbl_51_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 51); }
        private void lbl_52_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_52.Content = changedProduct.Naam; lbl_52_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 52); }
        private void lbl_53_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_53.Content = changedProduct.Naam; lbl_53_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 53); }
        private void lbl_54_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_54.Content = changedProduct.Naam; lbl_54_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 54); }
        private void lbl_55_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_55.Content = changedProduct.Naam; lbl_55_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 55); }

        private void lbl_56_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_56.Content = changedProduct.Naam; lbl_56_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 56); }
        private void lbl_57_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_57.Content = changedProduct.Naam; lbl_57_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 57); }
        private void lbl_58_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_58.Content = changedProduct.Naam; lbl_58_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 58); }
        private void lbl_59_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_59.Content = changedProduct.Naam; lbl_59_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 59); }
        private void lbl_60_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_60.Content = changedProduct.Naam; lbl_60_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 60); }

        private void lbl_61_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_61.Content = changedProduct.Naam; lbl_61_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 61); }
        private void lbl_62_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_62.Content = changedProduct.Naam; lbl_62_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 62); }
        private void lbl_63_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_63.Content = changedProduct.Naam; lbl_63_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 63); }
        private void lbl_64_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_64.Content = changedProduct.Naam; lbl_64_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 64); }
        private void lbl_65_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_65.Content = changedProduct.Naam; lbl_65_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 65); }

        private void lbl_66_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_66.Content = changedProduct.Naam; lbl_66_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 66); }
        private void lbl_67_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_67.Content = changedProduct.Naam; lbl_67_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 67); }
        private void lbl_68_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_68.Content = changedProduct.Naam; lbl_68_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 68); }
        private void lbl_69_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_69.Content = changedProduct.Naam; lbl_69_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 69); }
        private void lbl_70_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_70.Content = changedProduct.Naam; lbl_70_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 70); }

        private void lbl_71_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_71.Content = changedProduct.Naam; lbl_71_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 71); }
        private void lbl_72_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_72.Content = changedProduct.Naam; lbl_72_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 72); }
        private void lbl_73_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_73.Content = changedProduct.Naam; lbl_73_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 73); }
        private void lbl_74_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_74.Content = changedProduct.Naam; lbl_74_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 74); }
        private void lbl_75_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_75.Content = changedProduct.Naam; lbl_75_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 75); }

        private void lbl_76_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_76.Content = changedProduct.Naam; lbl_76_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 76); }
        private void lbl_77_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_77.Content = changedProduct.Naam; lbl_77_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 77); }
        private void lbl_78_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_78.Content = changedProduct.Naam; lbl_78_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 78); }
        private void lbl_79_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_79.Content = changedProduct.Naam; lbl_79_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 79); }
        private void lbl_80_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_80.Content = changedProduct.Naam; lbl_80_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 80); }

        private void lbl_81_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_81.Content = changedProduct.Naam; lbl_81_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 81); }
        private void lbl_82_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_82.Content = changedProduct.Naam; lbl_82_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 82); }
        private void lbl_83_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_83.Content = changedProduct.Naam; lbl_83_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 83); }
        private void lbl_84_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_84.Content = changedProduct.Naam; lbl_84_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 84); }
        private void lbl_85_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_85.Content = changedProduct.Naam; lbl_85_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 85); }

        private void lbl_86_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_86.Content = changedProduct.Naam; lbl_86_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 86); }
        private void lbl_87_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_87.Content = changedProduct.Naam; lbl_87_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 87); }
        private void lbl_88_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_88.Content = changedProduct.Naam; lbl_88_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 88); }
        private void lbl_89_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_89.Content = changedProduct.Naam; lbl_89_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 89); }
        private void lbl_90_Drop(object sender, DragEventArgs e) { Product changedProduct = _Producten[rowIndex]; lbl_90.Content = changedProduct.Naam; lbl_90_Prix.Content = "\u20AC" + changedProduct.Prijs; HerstelIni(changedProduct, 90); }
        #endregion

        private void HerstelIni(Product product, int id)
        {

            Product p = new Product(id, product.Naam, product.Activatie, product.Fabrikant, product.Hoogte, product.Breedte, product.Diepte, product.Inhoud, product.Eancode, product.Prijs);
            var v = _Ini.Where(x => x.Id == id).FirstOrDefault();
            if (p != null)
            {
                if (p.Naam != "dismounted")
                {
                    Breedte_Berekenen_Optellen(p.Id);
                    CheckFabrikantAantal_Verminderen(v.Fabrikant);
                    CheckAantalNietActiefVerminderen(v.Activatie);
                    _Ini.Remove(v);
                    p.Breedte = p.Breedte + 8.5;
                    _Ini.Insert((id - 1), p);
                    data_Ini.ItemsSource = _Ini;
                    Breedte_Berekenen_Verminderen(p.Id);
                    CheckFabrikantAantal(product.Fabrikant);
                    CheckAantalNietActief(product.Activatie);
                    if (ClearCodeCheck == 1) { clearColor(); ClearCodeCheck = 0; }
                    return;
                }

                if (v.Naam == "dismounted")
                {
                    CheckFabrikantAantal_Verminderen(v.Fabrikant);
                    CheckAantalNietActiefVerminderen(v.Activatie);
                    _Ini.Remove(v);
                    _Ini.Insert((id - 1), p);
                    data_Ini.ItemsSource = _Ini;
                    CheckFabrikantAantal(product.Fabrikant);
                    CheckAantalNietActief(product.Activatie);
                    if (ClearCodeCheck == 1) { clearColor(); ClearCodeCheck = 0; }
                    return;
                }

                if (p.Naam == "dismounted")
                {
                    Breedte_Berekenen_Optellen(v.Id);
                    CheckFabrikantAantal_Verminderen(v.Fabrikant);
                    CheckAantalNietActiefVerminderen(v.Activatie);
                    _Ini.Remove(v);
                    _Ini.Insert((id - 1), p);
                    data_Ini.ItemsSource = _Ini;
                    CheckFabrikantAantal(product.Fabrikant);
                    CheckAantalNietActief(product.Activatie);
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
            rowIndex = (b - 1);
            data_Product.IsReadOnly = false;
        }
        private void DgSupp_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            data_Product.CancelEdit();
            data_Product.BeginEdit();
        }
        #endregion

        private void DgSupp_KeyPress(object sender, KeyEventArgs e)
        {
            data_Product.IsReadOnly = true;
        }

        #region Maak grids leeg
        private void lbl_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ClearCodeCheck == 1) { clearColor(); ClearCodeCheck = 0; }
            FrameworkElement s = sender as FrameworkElement;
            string name = s.Name;
            Product product = new Product(1, "dismounted", "", "", 0, 0, 0, 0, 0, 0);
            for (int i = 0; i < 90; i++)
            {
                var naam = _lbl_Grids[i].Name.ToString();
                if (name.ToString() == naam)
                {
                    product.Id = i + 1;
                    HerstelIni(product, i+1);
                    _lbl_Grids[i].Content = "dismounted";
                    _lbl_Prix[i].Content = "0";
                }
            }

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
                        for (int i = 0; i < 90; i++)
                        {
                            if (m == i) _clm[i].Background = new System.Windows.Media.SolidColorBrush(Colors.Aqua);
                        }
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
                        for (int i = 0; i < 90; i++)
                        {
                            if (m == i) _clm[i].Background = new System.Windows.Media.SolidColorBrush(Colors.Orange);
                        }
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
                        for (int i = 0; i < 90; i++)
                        {
                            if (m == i) _clm[i].Background = new System.Windows.Media.SolidColorBrush(Colors.SaddleBrown);
                        }
                    }
                }
                ClearCodeCheck = 1;
            }
            else { clearColor(); ClearCodeCheck = 0; }
        }

        private void btn_Activatie_Click(object sender, RoutedEventArgs e)
        {
            if (ClearCodeCheck == 0)
            {
                clearColor();
                for (int m = 0; m < _Ini.Count; m++)
                {
                    if (_Ini[m].Activatie == "Niet Actief")
                    {
                        for (int i = 0; i < 90; i++)
                        {
                            if (m == i) _clm[i].Background = new System.Windows.Media.SolidColorBrush(Colors.Red);
                        }
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

        #region Steek alle Labels Grids in een lijst
        private void LabelsInLijst()
        {
            _lbl_Grids.Add(lbl_1); _lbl_Grids.Add(lbl_2); _lbl_Grids.Add(lbl_3); _lbl_Grids.Add(lbl_4); _lbl_Grids.Add(lbl_5);
            _lbl_Grids.Add(lbl_6); _lbl_Grids.Add(lbl_7); _lbl_Grids.Add(lbl_8); _lbl_Grids.Add(lbl_9); _lbl_Grids.Add(lbl_10);
            _lbl_Grids.Add(lbl_11); _lbl_Grids.Add(lbl_12); _lbl_Grids.Add(lbl_13); _lbl_Grids.Add(lbl_14); _lbl_Grids.Add(lbl_15);
            _lbl_Grids.Add(lbl_16); _lbl_Grids.Add(lbl_17); _lbl_Grids.Add(lbl_18); _lbl_Grids.Add(lbl_19); _lbl_Grids.Add(lbl_20);

            _lbl_Grids.Add(lbl_21); _lbl_Grids.Add(lbl_22); _lbl_Grids.Add(lbl_23); _lbl_Grids.Add(lbl_24); _lbl_Grids.Add(lbl_25);
            _lbl_Grids.Add(lbl_26); _lbl_Grids.Add(lbl_27); _lbl_Grids.Add(lbl_28); _lbl_Grids.Add(lbl_29); _lbl_Grids.Add(lbl_30);
            _lbl_Grids.Add(lbl_31); _lbl_Grids.Add(lbl_32); _lbl_Grids.Add(lbl_33); _lbl_Grids.Add(lbl_34); _lbl_Grids.Add(lbl_35);
            _lbl_Grids.Add(lbl_36); _lbl_Grids.Add(lbl_37); _lbl_Grids.Add(lbl_38); _lbl_Grids.Add(lbl_39); _lbl_Grids.Add(lbl_40);

            _lbl_Grids.Add(lbl_41); _lbl_Grids.Add(lbl_42); _lbl_Grids.Add(lbl_43); _lbl_Grids.Add(lbl_44); _lbl_Grids.Add(lbl_45);
            _lbl_Grids.Add(lbl_46); _lbl_Grids.Add(lbl_47); _lbl_Grids.Add(lbl_48); _lbl_Grids.Add(lbl_49); _lbl_Grids.Add(lbl_50);
            _lbl_Grids.Add(lbl_51); _lbl_Grids.Add(lbl_52); _lbl_Grids.Add(lbl_53); _lbl_Grids.Add(lbl_54); _lbl_Grids.Add(lbl_55);
            _lbl_Grids.Add(lbl_56); _lbl_Grids.Add(lbl_57); _lbl_Grids.Add(lbl_58); _lbl_Grids.Add(lbl_59); _lbl_Grids.Add(lbl_60);

            _lbl_Grids.Add(lbl_61); _lbl_Grids.Add(lbl_62); _lbl_Grids.Add(lbl_63); _lbl_Grids.Add(lbl_64); _lbl_Grids.Add(lbl_65);
            _lbl_Grids.Add(lbl_66); _lbl_Grids.Add(lbl_67); _lbl_Grids.Add(lbl_68); _lbl_Grids.Add(lbl_69); _lbl_Grids.Add(lbl_70);
            _lbl_Grids.Add(lbl_71); _lbl_Grids.Add(lbl_72); _lbl_Grids.Add(lbl_73); _lbl_Grids.Add(lbl_74); _lbl_Grids.Add(lbl_75);
            _lbl_Grids.Add(lbl_76); _lbl_Grids.Add(lbl_77); _lbl_Grids.Add(lbl_78); _lbl_Grids.Add(lbl_79); _lbl_Grids.Add(lbl_80);

            _lbl_Grids.Add(lbl_81); _lbl_Grids.Add(lbl_82); _lbl_Grids.Add(lbl_83); _lbl_Grids.Add(lbl_84); _lbl_Grids.Add(lbl_85);
            _lbl_Grids.Add(lbl_86); _lbl_Grids.Add(lbl_87); _lbl_Grids.Add(lbl_88); _lbl_Grids.Add(lbl_89); _lbl_Grids.Add(lbl_90);
        }

        private void LabelsPrixInLijst()
        {
            _lbl_Prix.Add(lbl_1_Prix); _lbl_Prix.Add(lbl_2_Prix); _lbl_Prix.Add(lbl_3_Prix); _lbl_Prix.Add(lbl_4_Prix); _lbl_Prix.Add(lbl_5_Prix);
            _lbl_Prix.Add(lbl_6_Prix); _lbl_Prix.Add(lbl_7_Prix); _lbl_Prix.Add(lbl_8_Prix); _lbl_Prix.Add(lbl_9_Prix); _lbl_Prix.Add(lbl_10_Prix);
            _lbl_Prix.Add(lbl_11_Prix); _lbl_Prix.Add(lbl_12_Prix); _lbl_Prix.Add(lbl_13_Prix); _lbl_Prix.Add(lbl_14_Prix); _lbl_Prix.Add(lbl_15_Prix);
            _lbl_Prix.Add(lbl_16_Prix); _lbl_Prix.Add(lbl_17_Prix); _lbl_Prix.Add(lbl_18_Prix); _lbl_Prix.Add(lbl_19_Prix); _lbl_Prix.Add(lbl_20_Prix);

            _lbl_Prix.Add(lbl_21_Prix); _lbl_Prix.Add(lbl_22_Prix); _lbl_Prix.Add(lbl_23_Prix); _lbl_Prix.Add(lbl_24_Prix); _lbl_Prix.Add(lbl_25_Prix);
            _lbl_Prix.Add(lbl_26_Prix); _lbl_Prix.Add(lbl_27_Prix); _lbl_Prix.Add(lbl_28_Prix); _lbl_Prix.Add(lbl_29_Prix); _lbl_Prix.Add(lbl_30_Prix);
            _lbl_Prix.Add(lbl_31_Prix); _lbl_Prix.Add(lbl_32_Prix); _lbl_Prix.Add(lbl_33_Prix); _lbl_Prix.Add(lbl_34_Prix); _lbl_Prix.Add(lbl_35_Prix);
            _lbl_Prix.Add(lbl_36_Prix); _lbl_Prix.Add(lbl_37_Prix); _lbl_Prix.Add(lbl_38_Prix); _lbl_Prix.Add(lbl_39_Prix); _lbl_Prix.Add(lbl_40_Prix);

            _lbl_Prix.Add(lbl_41_Prix); _lbl_Prix.Add(lbl_42_Prix); _lbl_Prix.Add(lbl_43_Prix); _lbl_Prix.Add(lbl_44_Prix); _lbl_Prix.Add(lbl_45_Prix);
            _lbl_Prix.Add(lbl_46_Prix); _lbl_Prix.Add(lbl_47_Prix); _lbl_Prix.Add(lbl_48_Prix); _lbl_Prix.Add(lbl_49_Prix); _lbl_Prix.Add(lbl_50_Prix);
            _lbl_Prix.Add(lbl_51_Prix); _lbl_Prix.Add(lbl_52_Prix); _lbl_Prix.Add(lbl_53_Prix); _lbl_Prix.Add(lbl_54_Prix); _lbl_Prix.Add(lbl_55_Prix);
            _lbl_Prix.Add(lbl_56_Prix); _lbl_Prix.Add(lbl_57_Prix); _lbl_Prix.Add(lbl_58_Prix); _lbl_Prix.Add(lbl_59_Prix); _lbl_Prix.Add(lbl_60_Prix);

            _lbl_Prix.Add(lbl_61_Prix); _lbl_Prix.Add(lbl_62_Prix); _lbl_Prix.Add(lbl_63_Prix); _lbl_Prix.Add(lbl_64_Prix); _lbl_Prix.Add(lbl_65_Prix);
            _lbl_Prix.Add(lbl_66_Prix); _lbl_Prix.Add(lbl_67_Prix); _lbl_Prix.Add(lbl_68_Prix); _lbl_Prix.Add(lbl_69_Prix); _lbl_Prix.Add(lbl_70_Prix);
            _lbl_Prix.Add(lbl_71_Prix); _lbl_Prix.Add(lbl_72_Prix); _lbl_Prix.Add(lbl_73_Prix); _lbl_Prix.Add(lbl_74_Prix); _lbl_Prix.Add(lbl_75_Prix);
            _lbl_Prix.Add(lbl_76_Prix); _lbl_Prix.Add(lbl_77_Prix); _lbl_Prix.Add(lbl_78_Prix); _lbl_Prix.Add(lbl_79_Prix); _lbl_Prix.Add(lbl_80_Prix);

            _lbl_Prix.Add(lbl_81_Prix); _lbl_Prix.Add(lbl_82_Prix); _lbl_Prix.Add(lbl_83_Prix); _lbl_Prix.Add(lbl_84_Prix); _lbl_Prix.Add(lbl_85_Prix);
            _lbl_Prix.Add(lbl_86_Prix); _lbl_Prix.Add(lbl_87_Prix); _lbl_Prix.Add(lbl_88_Prix); _lbl_Prix.Add(lbl_89_Prix); _lbl_Prix.Add(lbl_90_Prix);
        }

        private void GridsInList()
        {
            _clm.Add(clm_1); _clm.Add(clm_2); _clm.Add(clm_3); _clm.Add(clm_4); _clm.Add(clm_5);
            _clm.Add(clm_6); _clm.Add(clm_7); _clm.Add(clm_8); _clm.Add(clm_9); _clm.Add(clm_10);
            _clm.Add(clm_11); _clm.Add(clm_12); _clm.Add(clm_13); _clm.Add(clm_14); _clm.Add(clm_15);
            _clm.Add(clm_16); _clm.Add(clm_17); _clm.Add(clm_18); _clm.Add(clm_19); _clm.Add(clm_20);

            _clm.Add(clm_21); _clm.Add(clm_22); _clm.Add(clm_23); _clm.Add(clm_24); _clm.Add(clm_25);
            _clm.Add(clm_26); _clm.Add(clm_27); _clm.Add(clm_28); _clm.Add(clm_29); _clm.Add(clm_30);
            _clm.Add(clm_31); _clm.Add(clm_32); _clm.Add(clm_33); _clm.Add(clm_34); _clm.Add(clm_35);
            _clm.Add(clm_36); _clm.Add(clm_37); _clm.Add(clm_38); _clm.Add(clm_39); _clm.Add(clm_40);

            _clm.Add(clm_41); _clm.Add(clm_42); _clm.Add(clm_43); _clm.Add(clm_44); _clm.Add(clm_45);
            _clm.Add(clm_46); _clm.Add(clm_47); _clm.Add(clm_48); _clm.Add(clm_49); _clm.Add(clm_50);
            _clm.Add(clm_51); _clm.Add(clm_52); _clm.Add(clm_53); _clm.Add(clm_54); _clm.Add(clm_55);
            _clm.Add(clm_56); _clm.Add(clm_57); _clm.Add(clm_58); _clm.Add(clm_59); _clm.Add(clm_60);

            _clm.Add(clm_61); _clm.Add(clm_62); _clm.Add(clm_63); _clm.Add(clm_64); _clm.Add(clm_65);
            _clm.Add(clm_66); _clm.Add(clm_67); _clm.Add(clm_68); _clm.Add(clm_69); _clm.Add(clm_70);
            _clm.Add(clm_71); _clm.Add(clm_72); _clm.Add(clm_73); _clm.Add(clm_74); _clm.Add(clm_75);
            _clm.Add(clm_76); _clm.Add(clm_77); _clm.Add(clm_78); _clm.Add(clm_79); _clm.Add(clm_80);

            _clm.Add(clm_81); _clm.Add(clm_82); _clm.Add(clm_83); _clm.Add(clm_84); _clm.Add(clm_85);
            _clm.Add(clm_86); _clm.Add(clm_87); _clm.Add(clm_88); _clm.Add(clm_89); _clm.Add(clm_90);
        }
        #endregion

        #region TitelBar regelen
        private void PackIconForkAwesome_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void PackIconForkAwesome_MouseLeftButtonUp_Maximize(object sender, MouseButtonEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
            }
            else WindowState = WindowState.Maximized;
        }

        private void PackIconForkAwesome_MouseLeftButtonUp_Minimize(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        #endregion

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MaxHeight = SystemParameters.MaximumWindowTrackHeight;
            MaxWidth = SystemParameters.MaximumWindowTrackWidth;
        }
    }
}