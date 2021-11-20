using Conway.ASP.Net.MVC.Models;
using Conway.ASP.Net.MVC.Verbinding;
using Conway.Core.Model;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace Conway.ASP.Net.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private ProductenWpf ProductenWpf;
        //private AssortimentWpf AssortimentWpf;
        private ObservableCollection<Product> _Producten;
        private ObservableCollection<BAT_Cigarette> _BAT_Cigaretten;
        private ObservableCollection<BAT_Tabac> _BAT_Tabac;
        private ObservableCollection<ITB_Cigarette> _ITB_Cigaretten;
        private ObservableCollection<ITB_Tabac> _ITB_Tabac;
        private ObservableCollection<JTI_Cigarette> _JTI_Cigaretten;
        private ObservableCollection<JTI_Tabac> _JTI_Tabac;
        private ObservableCollection<PMI_Cigarette> _PMI_Cigaretten;
        private ObservableCollection<Product> _Ini;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _Producten = new ObservableCollection<Product>();
            _BAT_Cigaretten = new ObservableCollection<BAT_Cigarette>();
            _BAT_Tabac = new ObservableCollection<BAT_Tabac>();
            _ITB_Cigaretten = new ObservableCollection<ITB_Cigarette>();
            _ITB_Tabac = new ObservableCollection<ITB_Tabac>();
            _JTI_Cigaretten = new ObservableCollection<JTI_Cigarette>();
            _JTI_Tabac = new ObservableCollection<JTI_Tabac>();
            _PMI_Cigaretten = new ObservableCollection<PMI_Cigarette>();
            _Ini = new ObservableCollection<Product>();
        }

        public async Task<IActionResult> Index(string button)
        {

            dynamic mymodel = new ExpandoObject();
            mymodel.Product = await GetProduct();
            mymodel.naamFabrikant = await GetBAT_Cigarette();
            if (button == "BAT_C")
            {
                mymodel.naamFabrikant = await GetBAT_Cigarette();
            }
            if (button == "BAT_T")
            {
                mymodel.naamFabrikant = await GetBAT_Tabac();
            }

            return View(mymodel);
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

        private async Task<ObservableCollection<Product>> GetProduct()
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
            return _Producten;
            //data_Product.ItemsSource = _Producten;
            //cb_Producten.ItemsSource = _Producten;
        }

        #region Get All Assortiment
        private async Task<ObservableCollection<BAT_Cigarette>> GetBAT_Cigarette()
        {
            _BAT_Cigaretten = new ObservableCollection<BAT_Cigarette>();
            var bAT_Cigarette = await Context.BAT_Cigarette_Manager.GetBAT_Cigarette();
            foreach (var item in bAT_Cigarette)
            {
                _BAT_Cigaretten.Add(item);
            }
            return _BAT_Cigaretten;
            //data_Assortiment.ItemsSource = _BAT_Cigaretten;
        }
        private async Task<ObservableCollection<BAT_Tabac>> GetBAT_Tabac()
        {
            _BAT_Tabac = new ObservableCollection<BAT_Tabac>();
            var bAT_Tabac = await Context.BAT_Tabac_Manager.GetBAT_Tabac();
            foreach (var item in bAT_Tabac)
            {
                _BAT_Tabac.Add(item);
            }
            return _BAT_Tabac;
            //data_Assortiment.ItemsSource = _BAT_Tabac;
        }

        private async Task<ObservableCollection<ITB_Cigarette>> GetITB_Cigarette()
        {
            _ITB_Cigaretten = new ObservableCollection<ITB_Cigarette>();
            var itb_Cigarette = await Context.ITB_Cigarette_Manager.GetITB_Cigarette();
            foreach (var item in itb_Cigarette)
            {
                _ITB_Cigaretten.Add(item);
            }
            return _ITB_Cigaretten;
            //data_Assortiment.ItemsSource = _ITB_Cigaretten;
        }
        private async Task<ObservableCollection<ITB_Tabac>> GetITB_Tabac()
        {
            _ITB_Tabac = new ObservableCollection<ITB_Tabac>();
            var itb_Tabac = await Context.ITB_Tabac_Manager.GetITB_Tabac();
            foreach (var item in itb_Tabac)
            {
                _ITB_Tabac.Add(item);
            }
            return _ITB_Tabac;
            //data_Assortiment.ItemsSource = _ITB_Tabac;
        }

        private async Task<ObservableCollection<JTI_Cigarette>> GetJTI_Cigarette()
        {
            _JTI_Cigaretten = new ObservableCollection<JTI_Cigarette>();
            var jti_Cigarette = await Context.JTI_Cigarette_Manager.GetJTI_Cigarette();
            foreach (var item in jti_Cigarette)
            {
                _JTI_Cigaretten.Add(item);
            }
            return _JTI_Cigaretten;
            //data_Assortiment.ItemsSource = _JTI_Cigaretten;
        }
        private async Task<ObservableCollection<JTI_Tabac>> GetJTI_Tabac()
        {
            _JTI_Tabac = new ObservableCollection<JTI_Tabac>();
            var jti_Tabac = await Context.JTI_Tabac_Manager.GetJTI_Tabac();
            foreach (var item in jti_Tabac)
            {
                _JTI_Tabac.Add(item);
            }
            return _JTI_Tabac;
            //data_Assortiment.ItemsSource = _JTI_Tabac;
        }

        private async Task<ObservableCollection<PMI_Cigarette>> GetPMI_Cigarette()
        {
            _PMI_Cigaretten = new ObservableCollection<PMI_Cigarette>();
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
