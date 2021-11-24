using Conway.ASP.Net.MVC.Models;
using Conway.ASP.Net.MVC.Verbinding;
using Conway.Core.Model;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Conway.ASP.Net.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private ProductenWpf ProductenWpf;
        //private AssortimentWpf AssortimentWpf;
        private List<Product> _Producten;
        private List<BAT_Cigarette> _BAT_Cigaretten;
        private List<BAT_Tabac> _BAT_Tabac;
        private List<ITB_Cigarette> _ITB_Cigaretten;
        private List<ITB_Tabac> _ITB_Tabac;
        private List<JTI_Cigarette> _JTI_Cigaretten;
        private List<JTI_Tabac> _JTI_Tabac;
        private List<PMI_Cigarette> _PMI_Cigaretten;
        private List<Product> _Ini;
        //ProductModel productModel = new ProductModel();

        private IHostingEnvironment Environment;

        public HomeController(ILogger<HomeController> logger, IHostingEnvironment hostingEnvironment)
        {
            _logger = logger;
            if (_Producten == null) { _Producten = new List<Product>(); }
            if (_BAT_Cigaretten == null) { _BAT_Cigaretten = new List<BAT_Cigarette>(); }
            if (_BAT_Tabac == null) { _BAT_Tabac = new List<BAT_Tabac>(); }
            if (_ITB_Cigaretten == null) { _ITB_Cigaretten = new List<ITB_Cigarette>(); }
            if (_ITB_Tabac == null) { _ITB_Tabac = new List<ITB_Tabac>(); }
            if (_JTI_Cigaretten == null) { _JTI_Cigaretten = new List<JTI_Cigarette>(); }
            if (_JTI_Tabac == null) { _JTI_Tabac = new List<JTI_Tabac>(); }
            if (_PMI_Cigaretten == null) { _PMI_Cigaretten = new List<PMI_Cigarette>(); }
            if (_Ini == null) { _Ini = new List<Product>(); }
            //_Producten = new List<Product>();
            //_BAT_Cigaretten = new List<BAT_Cigarette>();
            //_BAT_Tabac = new List<BAT_Tabac>();
            //_ITB_Cigaretten = new List<ITB_Cigarette>();
            //_ITB_Tabac = new List<ITB_Tabac>();
            //_JTI_Cigaretten = new List<JTI_Cigarette>();
            //_JTI_Tabac = new List<JTI_Tabac>();
            //_PMI_Cigaretten = new List<PMI_Cigarette>();
            //_Ini = new List<Product>();
            Environment = hostingEnvironment;
        }
        
        public async Task<ActionResult> Index(string button, ProductModel productModel1)
        {
            //ProductModel productModel = new ProductModel();
            //Product product = new Product();
            //product = (List<Product>)TempData["product"];
            dynamic mymodel = new ExpandoObject();
            mymodel.Product = await GetProduct();
            //_Ini.Add(product);
            //if (_Ini == null) { _Ini = new List<Product>(); }
            //if (productModel == null ) { productModel = new ProductModel(); }
            if (productModel1 == null) { productModel1 = new ProductModel(); }
            var v = productModel1.GetProducts();
            mymodel.Ini =  v;

            if (button == null)
            {
                mymodel.naamFabrikant = await GetBAT_Cigarette();
            }
            if (button == "BAT_C")
            {
                mymodel.naamFabrikant = await GetBAT_Cigarette();
            }
            if (button == "BAT_T")
            {
                mymodel.naamFabrikant = await GetBAT_Tabac();
            }
            if (button == "ITB_C")
            {
                mymodel.naamFabrikant = await GetITB_Cigarette();
            }
            if (button == "ITB_T")
            {
                mymodel.naamFabrikant = await GetITB_Tabac();
            }
            if (button == "JTI_C")
            {
                mymodel.naamFabrikant = await GetJTI_Cigarette();
            }
            if (button == "JTI_T")
            {
                mymodel.naamFabrikant = await GetJTI_Tabac();
            }
            if (button == "PMI_C")
            {
                mymodel.naamFabrikant = await GetPMI_Cigarette();
            }

            return View(mymodel);
        }


        public async Task<ActionResult> Test(/*IFormFile file*/ProductModel productModel1)
        {
            //var v = productModel.GetProducts();
            //productModel = new ProductModel();
            var v = productModel1.GetProducts();
            //_Ini = new List<Product>();
            //List<Product> product = new List<Product>();

            /*string wwwPath = this.Environment.WebRootPath;
            string contentPath = this.Environment.ContentRootPath;
            string path = Path.Combine(this.Environment.WebRootPath, "Uploads");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }*/
            var test = "D:\\Users\\Yalcin\\Desktop\\HBO5\\Werkpleksimulatie\\Pitch 29-10-2021)\\Delhaize XXL96 Meubel 1.ini";
            /*List<string> uploadedFiles = new List<string>();

            string fileName = Path.GetFileName(file.FileName);
            using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            {
                file.CopyTo(stream);
                uploadedFiles.Add(fileName);
                ViewBag.Message += string.Format("<b>{0}</b> uploaded.<br />", fileName);
            }*/

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
            if (test != null)
            {
                using (StreamReader reader = new StreamReader(test))
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
                                    //CheckFabrikantAantal(fabrikant);
                                    //CheckAantalNietActief(activatie);
                                    var money = prix;
                                    //ToMachine(id, description, money, fabrikant);
                                    //_Fabrikant.Add(fabrikant);
                                    index = data.Id.ToString();
                                    int indexx = int.Parse(index);
                                    v.Insert((indexx - 1), data);
                                    //Breedte_Berekenen_Verminderen(id);
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
                    //data_Ini.ItemsSource = _Ini;
                    //product = _Ini;
                    //TempData["_Ini"] = new ;
                    //TempData["product"] = product;
                    //product = _Ini;
                    reader.Close();
                }
            }
            productModel1.SetProducts(v);
            return RedirectToAction("Index", v);
        }


        #region Don't know
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        #endregion

        private void StartIni()
        {
            for (int i = 1; i < 91; i++)
            {
                Product product = new Product();
                product.SetNaam("dismounted");
                product.Id = i;
                _Ini.Add(product);
            }
            //data_Ini.ItemsSource = _Ini;
        }


        /*private void Clear()
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
        }*/

        private async Task<List<Product>> GetProduct()
        {
            long id = 1;
            var producten = await Context.Product_Manager.GetProducten();
            _Producten = new List<Product>();
            foreach (var item in producten)
            {
                item.Id = id;
                _Producten.Add(item);
                id++;
            }
            return _Producten;
            //data_Product.ItemsSource = _Producten;
            //cb_Producten.ItemsSource = _Producten;
        }

        #region Get All Assortiment
        private async Task<List<BAT_Cigarette>> GetBAT_Cigarette()
        {
            _BAT_Cigaretten = new List<BAT_Cigarette>();
            var bAT_Cigarette = await Context.BAT_Cigarette_Manager.GetBAT_Cigarette();
            foreach (var item in bAT_Cigarette)
            {
                _BAT_Cigaretten.Add(item);
            }
            return _BAT_Cigaretten;
            //data_Assortiment.ItemsSource = _BAT_Cigaretten;
        }
        private async Task<List<BAT_Tabac>> GetBAT_Tabac()
        {
            _BAT_Tabac = new List<BAT_Tabac>();
            var bAT_Tabac = await Context.BAT_Tabac_Manager.GetBAT_Tabac();
            foreach (var item in bAT_Tabac)
            {
                _BAT_Tabac.Add(item);
            }
            return _BAT_Tabac;
            //data_Assortiment.ItemsSource = _BAT_Tabac;
        }

        private async Task<List<ITB_Cigarette>> GetITB_Cigarette()
        {
            _ITB_Cigaretten = new List<ITB_Cigarette>();
            var itb_Cigarette = await Context.ITB_Cigarette_Manager.GetITB_Cigarette();
            foreach (var item in itb_Cigarette)
            {
                _ITB_Cigaretten.Add(item);
            }
            return _ITB_Cigaretten;
            //data_Assortiment.ItemsSource = _ITB_Cigaretten;
        }
        private async Task<List<ITB_Tabac>> GetITB_Tabac()
        {
            _ITB_Tabac = new List<ITB_Tabac>();
            var itb_Tabac = await Context.ITB_Tabac_Manager.GetITB_Tabac();
            foreach (var item in itb_Tabac)
            {
                _ITB_Tabac.Add(item);
            }
            return _ITB_Tabac;
            //data_Assortiment.ItemsSource = _ITB_Tabac;
        }

        private async Task<List<JTI_Cigarette>> GetJTI_Cigarette()
        {
            _JTI_Cigaretten = new List<JTI_Cigarette>();
            var jti_Cigarette = await Context.JTI_Cigarette_Manager.GetJTI_Cigarette();
            foreach (var item in jti_Cigarette)
            {
                _JTI_Cigaretten.Add(item);
            }
            return _JTI_Cigaretten;
            //data_Assortiment.ItemsSource = _JTI_Cigaretten;
        }
        private async Task<List<JTI_Tabac>> GetJTI_Tabac()
        {
            _JTI_Tabac = new List<JTI_Tabac>();
            var jti_Tabac = await Context.JTI_Tabac_Manager.GetJTI_Tabac();
            foreach (var item in jti_Tabac)
            {
                _JTI_Tabac.Add(item);
            }
            return _JTI_Tabac;
            //data_Assortiment.ItemsSource = _JTI_Tabac;
        }

        private async Task<List<PMI_Cigarette>> GetPMI_Cigarette()
        {
            _PMI_Cigaretten = new List<PMI_Cigarette>();
            var pmi_Cigarette = await Context.PMI_Cigarette_Manager.GetPMI_Cigarette();
            foreach (var item in pmi_Cigarette)
            {
                _PMI_Cigaretten.Add(item);
            }
            return _PMI_Cigaretten;
            //data_Assortiment.ItemsSource = _PMI_Cigaretten;
        }
        #endregion
    }
}
