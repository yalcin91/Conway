using Conway.Core.Model;
using Conway.WPF.Verbinding;

using Microsoft.Win32;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Conway.WPF.Products
{
    /// <summary>
    /// Interaction logic for Producten.xaml
    /// </summary>
    public partial class ProductenWpf : Window
    {
        private ObservableCollection<Product> _Producten;
        private ObservableCollection<Product> _Portal;
        private List<long> _eanCodes;

        public ProductenWpf()
        {
            InitializeComponent();
            _Producten = new ObservableCollection<Product>();
            _Portal = new ObservableCollection<Product>();
            _eanCodes = new List<long>();
            GetProduct();
        }

        private async void GetProduct()
        {
            var producten = await Context.Product_Manager.GetProducten();
            _Producten = new ObservableCollection<Product>();
            foreach (var item in producten)
            {
                _Producten.Add(item);
                _eanCodes.Add(item.Eancode);
            }
            data_Product.ItemsSource = _Producten;
        }

        private void btn_Import_Click(object sender, RoutedEventArgs e)
        {
            Clear();

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.DefaultExt = ".txt";
            ofd.Filter = "(.txt)|*.txt";
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
            string prix = "";
            string fabrikant = "";
            double hoogte = 0;
            double breedte = 0;
            double diepte = 0;
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
                    string[] array = volledigString.Split("\t", StringSplitOptions.RemoveEmptyEntries);
                    for (int k = 0; k < array.Length; k++)
                    {
                        array[k].Replace(" ", "");
                        _VolledigString.Add(array[k]);
                    }

                    for (int j = 0; j < _VolledigString.Count; j++)
                    {
                        if (_VolledigString[j] == "ID ")
                        {
                            for (int d = 0; d <= j; d++)
                            {
                                _VolledigString.RemoveAt(0);
                            }
                        }
                    }
                    for (int i = 0; i < _VolledigString.Count; i++)
                    {
                        description = _VolledigString[i];
                        i++;
                        fabrikant = _VolledigString[i];
                        i++;
                        hoogte = double.Parse(_VolledigString[i]);
                        i++;
                        breedte = double.Parse(_VolledigString[i]);
                        i++;
                        diepte = double.Parse(_VolledigString[i]);
                        i++;
                        inhoud = int.Parse(_VolledigString[i]);
                        i++;
                        ean = long.Parse(_VolledigString[i]);
                        i++;
                        prix = _VolledigString[i];
                        prix = prix.Remove(prix.Length - 2);
                        double prix2 = double.Parse(prix);
                        var data = new Product(id, description, activatie, fabrikant, hoogte, breedte, diepte, inhoud, ean, prix2);
                        _Portal.Add(data);
                        data_Portal.ItemsSource = _Portal;
                        id++;
                        ean = 0;
                        description = "";
                        activatie = "";
                        prix = "";
                        fabrikant = "";
                        breedte = 0;
                        hoogte = 0;
                        diepte = 0;
                        inhoud = 0;
                        i = i+2;
                    }
                    reader.Close();
                }
            }
        }

        private void Clear()
        {
            _Portal = new ObservableCollection<Product>();
        }

        public EventHandler<RoutedEventArgs> Update;
        private async void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            pb_Updating.Maximum = _Producten.Count;
            pb_Updating.Visibility = Visibility.Visible;
            foreach (var v in _Portal)
            {
                if (_eanCodes.Contains(v.Eancode))
                {
                    var d = _Producten.Where(x => x.Eancode == v.Eancode).FirstOrDefault();
                    v.Id = d.Id;
                    v.Activatie = d.Activatie;
                    Context.Product_Manager.UpdateProduct(v.Id, v);
                    await Task.Delay(1);
                    pb_Updating.Value += 1;
                }
                /*foreach (var k in _Portal)
                {
                    if (v.Eancode == k.Eancode)
                    {
                        k.Id = v.Id;
                        k.Activatie = v.Activatie;
                        Context.Product_Manager.UpdateProduct(k.Id, k);
                    }
                }*/
            }
            GetProduct();
            Update?.Invoke(this, e);
            pb_Updating.Value = 0;
        }

        #region Import Excel to datagried
        /*private void btn_Import_Click(object sender, RoutedEventArgs e)
{
OpenFileDialog ofd = new OpenFileDialog();
ofd.DefaultExt = ".xlsx";
ofd.Filter = "(.xlsx)|*.xlsx";
string path = null;
if (ofd.ShowDialog() == true)
{
//string sFileName = ofd.FileName;
path = ofd.FileName;
Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
DataSet ds = new DataSet();
Microsoft.Office.Interop.Excel.Workbook wb = excel.Workbooks.Open(path);
foreach (Microsoft.Office.Interop.Excel.Worksheet ws in wb.Worksheets)
{
System.Data.DataTable td = new System.Data.DataTable();
td = formofDataTable(ws);
ds.Tables.Add(td);//This will give the DataTable from Excel file in Dataset
}
data_Portal.ItemsSource = ds.Tables[0].DefaultView;
wb.Close();
}
}
public System.Data.DataTable formofDataTable(Microsoft.Office.Interop.Excel.Worksheet ws)
{
System.Data.DataTable dt = new System.Data.DataTable();
string worksheetName = ws.Name;
dt.TableName = worksheetName;
Microsoft.Office.Interop.Excel.Range xlRange = ws.UsedRange;
object[,] valueArray = (object[,])xlRange.get_Value(XlRangeValueDataType.xlRangeValueDefault);
for (int k = 1; k <= valueArray.GetLength(1); k++)
{
dt.Columns.Add((string)valueArray[1, k]);  //add columns to the data table.
}
object[] singleDValue = new object[valueArray.GetLength(1)]; //value array first row contains column names. so loop starts from 2 instead of 1
for (int i = 2; i <= valueArray.GetLength(0); i++)
{
for (int j = 0; j < valueArray.GetLength(1); j++)
{
if (valueArray[i, j + 1] != null)
{
singleDValue[j] = valueArray[i, j + 1].ToString();
}
else
{
singleDValue[j] = valueArray[i, j + 1];
}
}
dt.LoadDataRow(singleDValue, System.Data.LoadOption.PreserveChanges);
}

return dt;
}*/
        #endregion
    }
}
