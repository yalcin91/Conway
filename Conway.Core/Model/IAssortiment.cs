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
        public IAssortiment(long id, int @ref, string product, long eanCode, string fabrikant, string size, double nielsen1, double nielsen2, double nielsen3, double nielsen4, string groupe, string color)
        {
            SetId(id);
            SetRef(@ref);
            SetProduct(product);
            SetEan(eanCode);
            SetFabrikant(fabrikant);
            SetDIF(size);
            SetNielsen1(nielsen1);
            SetNielsen2(nielsen2);
            SetNielsen3(nielsen3);
            SetNielsen4(nielsen4);
            SetGroupe(groupe);
            SetColor(color);
        }
        #endregion
        #region Model
        private long _Id;
        private int _Ref;
        private string _Product;
        private long _EanCode;
        private string _Fabrikant;
        private string _Size;
        private double _Nielsen1;
        private double _Nielsen2;
        private double _Nielsen3;
        private double _Nielsen4;
        private string _Groupe;
        private string _Color;
        #endregion

        #region Return Private's
        public long Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public int Ref
        {
            get { return _Ref; }
            set { _Ref = value; }
        }

        public string Product
        {
            get { return _Product; }
            set { _Product = value; }
        }

        public long EanCode
        {
            get { return _EanCode; }
            set { _EanCode = value; }
        }

        public string Fabrikant
        {
            get { return _Fabrikant; }
            set { _Fabrikant = value; }
        }

        public string Size
        {
            get { return _Size; }
            set { _Size = value; }
        }

        public double Nielsen1
        {
            get { return _Nielsen1; }
            set { _Nielsen1 = value; }
        }

        public double Nielsen2
        {
            get { return _Nielsen2; }
            set { _Nielsen2 = value; }
        }

        public double Nielsen3
        {
            get { return _Nielsen3; }
            set { _Nielsen3 = value; }
        }

        public double Nielsen4
        {
            get { return _Nielsen4; }
            set { _Nielsen4 = value; }
        }

        public string Groupe
        {
            get { return _Groupe; }
            set { _Groupe = value; }
        }

        public string Color
        {
            get { return _Color; }
            set { _Color = value; }
        }
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

        public long GetEan()
        {
            return EanCode;
        }

        public string GetFabrikant()
        {
            return Fabrikant;
        }

        public string GetDIF()
        {
            return Size;
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

        public void SetEan(long eanCode)
        {
            if (eanCode <= 0) { throw new AssortimentException("Invalid ean."); }
            EanCode = eanCode;
        }

        public void SetFabrikant(string fabrikant)
        {
            if (fabrikant.Trim().Length <= 1) { throw new AssortimentException("Invalid fabrikant."); }
            Fabrikant = fabrikant;
        }

        public void SetDIF(string size)
        {
            if (size.Trim().Length >= 10) { throw new AssortimentException("Invalid dif."); }
            Size = size;
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
            //if (groupe.Trim() != "Cigarette") { throw new AssortimentException("Invalid groupe."); }
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
