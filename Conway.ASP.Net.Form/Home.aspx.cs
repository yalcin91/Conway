using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetProduct();
                LabelsInLijst();
            }
            LabelsInLijst();
            LabelsPrixInLijst();
        }

        #region Get all Products
        private ObservableCollection<Product> GetProduct()
        {
            long id = 1;
            var producten =  Contexto.Product_Manager.GetProducten();
            ObservableCollection<Product> _Producten = new ObservableCollection<Product>();
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
            data_Product.AlternatingRowStyle.BackColor = System.Drawing.Color.LightCyan;
            //cb_Producten.ItemsSource = _Producten;
            return _Producten;
        }
        #endregion

        #region Get All Assortiment
        private void GetBAT_Cigarette()
        {
            ObservableCollection<BAT_Cigarette> _BAT_Cigaretten = new ObservableCollection<BAT_Cigarette>();
            var bAT_Cigarette =  Contexto.BAT_Cigarette_Manager.GetBAT_Cigarette();
            foreach (var item in bAT_Cigarette)
            {
                _BAT_Cigaretten.Add(item);
            }
            data_Assortiment.DataSource = _BAT_Cigaretten;
            data_Assortiment.DataBind();
            data_Assortiment.UseAccessibleHeader = true;
            data_Assortiment.HeaderRow.TableSection = TableRowSection.TableHeader;
            data_Assortiment.AlternatingRowStyle.BackColor = System.Drawing.Color.LightGreen;
            data_Assortiment.Attributes.Add("onclick", "return false;");
        }
        private  void GetBAT_Tabac()
        {
            ObservableCollection<BAT_Tabac> _BAT_Tabac = new ObservableCollection<BAT_Tabac>();
            var bAT_Tabac =  Contexto.BAT_Tabac_Manager.GetBAT_Tabac();
            foreach (var item in bAT_Tabac)
            {
                _BAT_Tabac.Add(item);
            }
            data_Assortiment.DataSource = _BAT_Tabac;
            data_Assortiment.DataBind();
            data_Assortiment.UseAccessibleHeader = true;
            data_Assortiment.HeaderRow.TableSection = TableRowSection.TableHeader;
            data_Assortiment.AlternatingRowStyle.BackColor = System.Drawing.Color.LightGreen;
        }

        private  void GetITB_Cigarette()
        {
            ObservableCollection<ITB_Cigarette> _ITB_Cigaretten = new ObservableCollection<ITB_Cigarette>();
            var itb_Cigarette =  Contexto.ITB_Cigarette_Manager.GetITB_Cigarette();
            foreach (var item in itb_Cigarette)
            {
                _ITB_Cigaretten.Add(item);
            }
            data_Assortiment.DataSource = _ITB_Cigaretten;
            data_Assortiment.DataBind();
            data_Assortiment.UseAccessibleHeader = true;
            data_Assortiment.HeaderRow.TableSection = TableRowSection.TableHeader;
            data_Assortiment.AlternatingRowStyle.BackColor = System.Drawing.Color.LightGreen;
        }
        private void GetITB_Tabac()
        {
            ObservableCollection<ITB_Tabac> _ITB_Tabac = new ObservableCollection<ITB_Tabac>();
            var itb_Tabac = Contexto.ITB_Tabac_Manager.GetITB_Tabac();
            foreach (var item in itb_Tabac)
            {
                _ITB_Tabac.Add(item);
            }
            data_Assortiment.DataSource = _ITB_Tabac;
            data_Assortiment.DataBind();
            data_Assortiment.UseAccessibleHeader = true;
            data_Assortiment.HeaderRow.TableSection = TableRowSection.TableHeader;
            data_Assortiment.AlternatingRowStyle.BackColor = System.Drawing.Color.LightGreen;
        }

        private  void GetJTI_Cigarette()
        {
            ObservableCollection<JTI_Cigarette> _JTI_Cigaretten = new ObservableCollection<JTI_Cigarette>();
            var jti_Cigarette =  Contexto.JTI_Cigarette_Manager.GetJTI_Cigarette();
            foreach (var item in jti_Cigarette)
            {
                _JTI_Cigaretten.Add(item);
            }
            data_Assortiment.DataSource = _JTI_Cigaretten;
            data_Assortiment.DataBind();
            data_Assortiment.UseAccessibleHeader = true;
            data_Assortiment.HeaderRow.TableSection = TableRowSection.TableHeader;
            data_Assortiment.AlternatingRowStyle.BackColor = System.Drawing.Color.LightGreen;
        }
        private  void GetJTI_Tabac()
        {
            ObservableCollection<JTI_Tabac> _JTI_Tabac = new ObservableCollection<JTI_Tabac>();
            var jti_Tabac =  Contexto.JTI_Tabac_Manager.GetJTI_Tabac();
            foreach (var item in jti_Tabac)
            {
                _JTI_Tabac.Add(item);
            }
            data_Assortiment.DataSource = _JTI_Tabac;
            data_Assortiment.DataBind();
            data_Assortiment.UseAccessibleHeader = true;
            data_Assortiment.HeaderRow.TableSection = TableRowSection.TableHeader;
            data_Assortiment.AlternatingRowStyle.BackColor = System.Drawing.Color.LightGreen;
        }

        private  void GetPMI_Cigarette()
        {
            ObservableCollection<PMI_Cigarette> _PMI_Cigaretten = new ObservableCollection<PMI_Cigarette>();
            var pmi_Cigarette =  Contexto.PMI_Cigarette_Manager.GetPMI_Cigarette();
            foreach (var item in pmi_Cigarette)
            {
                _PMI_Cigaretten.Add(item);
            }
            data_Assortiment.DataSource = _PMI_Cigaretten;
            data_Assortiment.DataBind();
            data_Assortiment.UseAccessibleHeader = true;
            data_Assortiment.HeaderRow.TableSection = TableRowSection.TableHeader;
            data_Assortiment.AlternatingRowStyle.BackColor = System.Drawing.Color.LightGreen;
        }
        #endregion

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

        private List<System.Web.UI.WebControls.Label> _lbl_Grids = new List<System.Web.UI.WebControls.Label>();
        private List<System.Web.UI.WebControls.Label> _lbl_Prix = new List<System.Web.UI.WebControls.Label>();
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

        protected void Btn_Import_Click(object sender, EventArgs e)
        {
            if (System.Windows.MessageBox.Show("Als u doorgaat word alles verwijderd!!", "Maak uw keuze", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                //Clear();
                //StartIni();

                ObservableCollection<Product> _Ini = new ObservableCollection<Product>();
                var _Producten = GetProduct();

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
                                        CheckFabrikantAantal(fabrikant);
                                        //CheckAantalNietActief(activatie);
                                        var money = prix;
                                        ToMachine(id, description, money, fabrikant);
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
                data_Ini.DataSource = _Ini;
                data_Ini.DataBind();
                data_Ini.UseAccessibleHeader = true;
                data_Ini.HeaderRow.TableSection = TableRowSection.TableHeader;
                data_Ini.AlternatingRowStyle.BackColor = System.Drawing.Color.LightGoldenrodYellow;

                //else { Clear(); StartIni(); }
            }
            else return;
        }

        private void CheckFabrikantAantal(string fabrikant)
        {
            if (fabrikant == "BAT") { _BAT.Add(1); lbl_BAT.Text = _BAT.Count().ToString(); }
            if (fabrikant == "ITB") { _ITB.Add(1); lbl_ITB.Text = _ITB.Count().ToString(); }
            if (fabrikant == "JTI") { _JTI.Add(1); lbl_JTI.Text = _JTI.Count().ToString(); }
            if (fabrikant == "PMI") { _PMI.Add(1); lbl_PMI.Text = _PMI.Count().ToString(); }
        }

        private void ToMachine(long i, string description, string prix, string fabrikant)
        {
            for (int k = 0; k < 90; k++)
            {
                if (i == k + 1) { _lbl_Grids[k].Text = description; _lbl_Prix[k].Text = "\u20AC" + prix; }
            }
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
            //_clm.Add(clm_1); _clm.Add(clm_2); _clm.Add(clm_3); _clm.Add(clm_4); _clm.Add(clm_5);
            //_clm.Add(clm_6); _clm.Add(clm_7); _clm.Add(clm_8); _clm.Add(clm_9); _clm.Add(clm_10);
            //_clm.Add(clm_11); _clm.Add(clm_12); _clm.Add(clm_13); _clm.Add(clm_14); _clm.Add(clm_15);
            //_clm.Add(clm_16); _clm.Add(clm_17); _clm.Add(clm_18); _clm.Add(clm_19); _clm.Add(clm_20);

            //_clm.Add(clm_21); _clm.Add(clm_22); _clm.Add(clm_23); _clm.Add(clm_24); _clm.Add(clm_25);
            //_clm.Add(clm_26); _clm.Add(clm_27); _clm.Add(clm_28); _clm.Add(clm_29); _clm.Add(clm_30);
            //_clm.Add(clm_31); _clm.Add(clm_32); _clm.Add(clm_33); _clm.Add(clm_34); _clm.Add(clm_35);
            //_clm.Add(clm_36); _clm.Add(clm_37); _clm.Add(clm_38); _clm.Add(clm_39); _clm.Add(clm_40);

            //_clm.Add(clm_41); _clm.Add(clm_42); _clm.Add(clm_43); _clm.Add(clm_44); _clm.Add(clm_45);
            //_clm.Add(clm_46); _clm.Add(clm_47); _clm.Add(clm_48); _clm.Add(clm_49); _clm.Add(clm_50);
            //_clm.Add(clm_51); _clm.Add(clm_52); _clm.Add(clm_53); _clm.Add(clm_54); _clm.Add(clm_55);
            //_clm.Add(clm_56); _clm.Add(clm_57); _clm.Add(clm_58); _clm.Add(clm_59); _clm.Add(clm_60);

            //_clm.Add(clm_61); _clm.Add(clm_62); _clm.Add(clm_63); _clm.Add(clm_64); _clm.Add(clm_65);
            //_clm.Add(clm_66); _clm.Add(clm_67); _clm.Add(clm_68); _clm.Add(clm_69); _clm.Add(clm_70);
            //_clm.Add(clm_71); _clm.Add(clm_72); _clm.Add(clm_73); _clm.Add(clm_74); _clm.Add(clm_75);
            //_clm.Add(clm_76); _clm.Add(clm_77); _clm.Add(clm_78); _clm.Add(clm_79); _clm.Add(clm_80);

            //_clm.Add(clm_81); _clm.Add(clm_82); _clm.Add(clm_83); _clm.Add(clm_84); _clm.Add(clm_85);
            //_clm.Add(clm_86); _clm.Add(clm_87); _clm.Add(clm_88); _clm.Add(clm_89); _clm.Add(clm_90);
        }
        #endregion
    }
}