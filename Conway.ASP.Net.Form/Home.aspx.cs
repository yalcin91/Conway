using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Forms;

using Conway.ASP.Net.Form.Models.Model;
using Conway.ASP.Net.Form.Models.Verbinding;

using Microsoft.AspNetCore.Http;

namespace Conway.ASP.Net.Form
{
    public partial class Home : System.Web.UI.Page
    {
        private ObservableCollection<Product> _Producten;
        private ObservableCollection<BAT_Cigarette> _BAT_Cigaretten;
        private ObservableCollection<BAT_Tabac> _BAT_Tabac;
        private ObservableCollection<ITB_Cigarette> _ITB_Cigaretten;
        private ObservableCollection<ITB_Tabac> _ITB_Tabac;
        private ObservableCollection<JTI_Cigarette> _JTI_Cigaretten;
        private ObservableCollection<JTI_Tabac> _JTI_Tabac;
        private ObservableCollection<PMI_Cigarette> _PMI_Cigaretten;
        private ObservableCollection<Product> _Ini;


        protected void Page_Load(object sender, EventArgs e)
        {
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
            return;
        }

        #region Get all Products
        private  void GetProduct()
        {
            long id = 1;
            var producten =  Contexto.Product_Manager.GetProducten();
            _Producten = new ObservableCollection<Product>();
            foreach (var item in producten)
            {
                item.Id = id;
                _Producten.Add(item);
                id++;
            }
            //gvCustomers.DataSource = _Producten;
            //gvCustomers.DataBind();
            data_Product.DataSource = _Producten;
            data_Product.DataBind();
            data_Product.UseAccessibleHeader = true;
            data_Product.HeaderRow.TableSection = TableRowSection.TableHeader;
            //cb_Producten.ItemsSource = _Producten;
        }
        #endregion

        #region Get All Assortiment
        private  void GetBAT_Cigarette()
        {
            _BAT_Cigaretten = new ObservableCollection<BAT_Cigarette>();
            var bAT_Cigarette =  Contexto.BAT_Cigarette_Manager.GetBAT_Cigarette();
            foreach (var item in bAT_Cigarette)
            {
                _BAT_Cigaretten.Add(item);
            }
            data_Assortiment.DataSource = _BAT_Cigaretten;
            data_Assortiment.DataBind();
            data_Assortiment.UseAccessibleHeader = true;
            data_Assortiment.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        private  void GetBAT_Tabac()
        {
            _BAT_Tabac = new ObservableCollection<BAT_Tabac>();
            var bAT_Tabac =  Contexto.BAT_Tabac_Manager.GetBAT_Tabac();
            foreach (var item in bAT_Tabac)
            {
                _BAT_Tabac.Add(item);
            }
            data_Assortiment.DataSource = _BAT_Tabac;
            data_Assortiment.DataBind();
            data_Assortiment.UseAccessibleHeader = true;
            data_Assortiment.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        private  void GetITB_Cigarette()
        {
            _ITB_Cigaretten = new ObservableCollection<ITB_Cigarette>();
            var itb_Cigarette =  Contexto.ITB_Cigarette_Manager.GetITB_Cigarette();
            foreach (var item in itb_Cigarette)
            {
                _ITB_Cigaretten.Add(item);
            }
            data_Assortiment.DataSource = _ITB_Cigaretten;
            data_Assortiment.DataBind();
            data_Assortiment.UseAccessibleHeader = true;
            data_Assortiment.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        private void GetITB_Tabac()
        {
            _ITB_Tabac = new ObservableCollection<ITB_Tabac>();
            var itb_Tabac = Contexto.ITB_Tabac_Manager.GetITB_Tabac();
            foreach (var item in itb_Tabac)
            {
                _ITB_Tabac.Add(item);
            }
            data_Assortiment.DataSource = _ITB_Tabac;
            data_Assortiment.DataBind();
            data_Assortiment.UseAccessibleHeader = true;
            data_Assortiment.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        private  void GetJTI_Cigarette()
        {
            _JTI_Cigaretten = new ObservableCollection<JTI_Cigarette>();
            var jti_Cigarette =  Contexto.JTI_Cigarette_Manager.GetJTI_Cigarette();
            foreach (var item in jti_Cigarette)
            {
                _JTI_Cigaretten.Add(item);
            }
            data_Assortiment.DataSource = _JTI_Cigaretten;
            data_Assortiment.DataBind();
            data_Assortiment.UseAccessibleHeader = true;
            data_Assortiment.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        private  void GetJTI_Tabac()
        {
            _JTI_Tabac = new ObservableCollection<JTI_Tabac>();
            var jti_Tabac =  Contexto.JTI_Tabac_Manager.GetJTI_Tabac();
            foreach (var item in jti_Tabac)
            {
                _JTI_Tabac.Add(item);
            }
            data_Assortiment.DataSource = _JTI_Tabac;
            data_Assortiment.DataBind();
            data_Assortiment.UseAccessibleHeader = true;
            data_Assortiment.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        private  void GetPMI_Cigarette()
        {
            _PMI_Cigaretten = new ObservableCollection<PMI_Cigarette>();
            var pmi_Cigarette =  Contexto.PMI_Cigarette_Manager.GetPMI_Cigarette();
            foreach (var item in pmi_Cigarette)
            {
                _PMI_Cigaretten.Add(item);
            }
            data_Assortiment.DataSource = _PMI_Cigaretten;
            data_Assortiment.DataBind();
            data_Assortiment.UseAccessibleHeader = true;
            data_Assortiment.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        #endregion

        protected void Btn_Import_Click(object sender, EventArgs e)
        {
            if (System.Windows.MessageBox.Show("Als u doorgaat word alles verwijderd!!", "Maak uw keuze", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                //Clear();
                //StartIni();

                //OpenFileDialog ofd = new OpenFileDialog();
                //ofd.DefaultExt = ".ini";
                //ofd.Filter = "Ini Document (.ini)|*.ini";
                string path = null;
                path = Server.MapPath(btn_import.FileName);
                if (btn_import.FileName.ToString() == "") { return; }
                string filenam = btn_import.FileName.ToString();
                path = path + filenam;
                btn_import.PostedFile.SaveAs(path);

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
                        string[] array = volledigString.Split(' ', (char)StringSplitOptions.RemoveEmptyEntries);
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
                                        _Ini.Insert((indexx - 1), data);
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
                        reader.Close();
                    }
                }
                data_Ini.DataSource = _Producten;
                data_Ini.DataBind();
                data_Ini.UseAccessibleHeader = true;
                data_Ini.HeaderRow.TableSection = TableRowSection.TableHeader;
                //else { Clear(); StartIni(); }
            }
            else return;
        }


        #region Clik Fabrikanten
        protected void BAT_C_Click(object sender, EventArgs e)
        {
            GetBAT_Cigarette();
        }

        protected void BAT_T_Click(object sender, EventArgs e)
        {
            GetBAT_Tabac();
        }

        protected void ITB_C_Click(object sender, EventArgs e)
        {
            GetITB_Cigarette();
        }

        protected void ITB_T_Click(object sender, EventArgs e)
        {
            GetITB_Tabac();
        }

        protected void JTI_C_Click(object sender, EventArgs e)
        {
            GetJTI_Cigarette();
        }

        protected void JTI_T_Click(object sender, EventArgs e)
        {
            GetJTI_Tabac();
        }

        protected void PMI_C_Click(object sender, EventArgs e)
        {
            GetPMI_Cigarette();
        }
        #endregion
    }
}