using Conway.Core.Exceptions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conway.Core.Model
{
    public abstract class IAssortiment
    {
        #region CTR
        public IAssortiment(long id, int @ref, string product, int ean, string fabrikant, string dif, double nielsen1, double nielsen2, double nielsen3, double nielsen4, string groupe, string color)
        {
            SetId(id);
            SetRef(@ref);
            SetProduct(product);
            SetEan(ean);
            SetFabrikant(fabrikant);
            SetDIF(dif);
            SetNielsen1(nielsen1);
            SetNielsen2(nielsen2);
            SetNielsen3(nielsen3);
            SetNielsen4(nielsen4);
            SetGroupe(groupe);
            SetColor(color);
        }
        #endregion
        #region Model
        private long Id;
        private int Ref { get; set; }
        private string Product { get; set; }
        private int Ean { get; set; }
        private string Fabrikant { get; set; }
        private string DIF { get; set; }
        private double Nielsen1 { get; set; }
        private double Nielsen2 { get; set; }
        private double Nielsen3 { get; set; }
        private double Nielsen4 { get; set; }
        private string Groupe { get; set; }
        private string Color { get; set; }
        #endregion

        #region Get Methods
        public long GetId()
        {
            return Id;
        }

        public int GetRef()
        {
            return Ref;
        }

        public string GetProduct()
        {
            return Product;
        }

        public int GetEan()
        {
            return Ean;
        }

        public string GetFabrikant()
        {
            return Fabrikant;
        }

        public string GetDIF()
        {
            return DIF;
        }

        public double GetNielsen1()
        {
            return Nielsen1;
        }

        public double GetNielsen2()
        {
            return Nielsen2;
        }

        public double GetNielsen3()
        {
            return Nielsen3;
        }

        public double GetNielsen4()
        {
            return Nielsen4;
        }

        public string GetGroupe()
        {
            return Groupe;
        }

        public string GetColor()
        {
            return Color;
        }
        #endregion

        #region Set Methods
        public void SetId(long id)
        {
            if (id <= 0) { throw new AssortimentException("Invalid id."); }
            Id = id;
        }

        public void SetRef(int @ref)
        {
            //if (@ref <= 0) { throw new AssortimentException("Invalid ref."); }
            Ref = @ref;
        }

        public void SetProduct(string product)
        {
            if (product.Trim().Length <= 1) { throw new AssortimentException("Invalid product."); }
            Product = product;
        }

        public void SetEan(int ean)
        {
            if (ean <= 0) { throw new AssortimentException("Invalid ean."); }
            Ean = ean;
        }

        public void SetFabrikant(string fabrikant)
        {
            if (fabrikant.Trim().Length <= 1) { throw new AssortimentException("Invalid fabrikant."); }
            Fabrikant = fabrikant;
        }

        public void SetDIF(string dif)
        {
            if (dif.Trim().Length >= 10) { throw new AssortimentException("Invalid dif."); }
            DIF = dif;
        }

        public void SetNielsen1(double nielsen1)
        {
            if (nielsen1 < 0) { throw new AssortimentException("Invalid nielsen1."); }
            Nielsen1 = nielsen1;
        }

        public void SetNielsen2(double nielsen2)
        {
            if (nielsen2 < 0) { throw new AssortimentException("Invalid nielsen2."); }
            Nielsen2 = nielsen2;
        }

        public void SetNielsen3(double nielsen3)
        {
            if (nielsen3 < 0) { throw new AssortimentException("Invalid nielsen3."); }
            Nielsen3 = nielsen3;
        }

        public void SetNielsen4(double nielsen4)
        {
            if (nielsen4 < 0) { throw new AssortimentException("Invalid nielsen4."); }
            Nielsen4 = nielsen4;
        }

        public virtual void SetGroupe(string groupe)
        {
            if (groupe.Trim() != "Cigarette") { throw new AssortimentException("Invalid groupe."); }
            Groupe = groupe;
        }

        public void SetColor(string color)
        {
            //if (color.Trim().Length < 0) { throw new AssortimentException("Invalid color."); }
            Color = color;
        }
        #endregion
    }
}
