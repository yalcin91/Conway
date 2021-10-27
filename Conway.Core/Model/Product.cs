using Conway.Core.Exceptions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conway.Core.Model
{
    public class Product
    {
        #region CTR
        public Product(){}
        public Product(long id, string naam, string activatie, string fabrikant, double hoogte, double breedte, double diepte, int inhoud, long eancode, double prijs)
        {
            Id = id;
            SetNaam(naam);
            SetActivatie(activatie);
            SetFabrikant(fabrikant);
            SetHoogte(hoogte);
            SetBreedte(breedte);
            SetDiepte(diepte);
            SetInhoud(inhoud);
            SetEAN(eancode);
            SetPrijs(prijs);
        }
        #endregion

        #region Model
        private long _Id;
        private string _Naam;
        private string _Activatie;
        private string _Fabrikant;
        private double _Hoogte;
        private double _Breedte;
        private double _Diepte;
        private int _Inhoud;
        private long _Eancode;
        private double _Prijs;
        #endregion

        #region Return Private's
        public long Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public string Naam
        {
            get { return _Naam; }
            set { _Naam = value; }
        }

        public string Activatie
        {
            get { return _Activatie; }
            set { _Activatie = value; }
        }

        public string Fabrikant
        {
            get { return _Fabrikant; }
            set { _Fabrikant = value; }
        }

        public double Hoogte
        {
            get { return _Hoogte; }
            set { _Hoogte = value; }
        }

        public double Breedte
        {
            get { return _Breedte; }
            set { _Breedte = value; }
        }

        public double Diepte
        {
            get { return _Diepte; }
            set { _Diepte = value; }
        }

        public int Inhoud
        {
            get { return _Inhoud; }
            set { _Inhoud = value; }
        }

        public long Eancode
        {
            get { return _Eancode; }
            set { _Eancode = value; }
        }

        public double Prijs
        {
            get { return _Prijs; }
            set { _Prijs = value; }
        }
        #endregion

        #region Get Methods
        public long GetId()
        {
            return Id;
        }
        public string GetNaam()
        {
            return Naam;
        }
        public string GetActivatie()
        {
            return Activatie;
        }
        public string GetFabrikant()
        {
            return Fabrikant;
        }
        public double GetHoogte()
        {
            return Hoogte;
        }
        public double GetBreedte()
        {
            return Breedte;
        }
        public double GetDiepte()
        {
            return Diepte;
        }
        public int GetInhoud()
        {
            return Inhoud;
        }
        public long GetEAN()
        {
            return Eancode;
        }
        public double GetPrijs()
        {
            return Prijs;
        }
        #endregion

        #region SetMethods
        public void SetNaam(string naam)
        {
            if (naam.Trim().Length <= 1) { throw new ProductException("Invalid naam."); }
            Naam = naam;
        }
        public void SetActivatie(string actief)
        {
            if (actief.Trim().Length <= 1) { actief ="Niet Actief"; }
            Activatie = actief;
        }
        public void SetFabrikant(string fabrikant)
        {
            if (fabrikant.Trim().Length < 0) { throw new ProductException("Invalid fabrikant."); }
            Fabrikant = fabrikant;
        }
        public void SetHoogte(double hoogte)
        {
            if (hoogte < 0) { throw new ProductException("Invalid hoogte."); }
            Hoogte = hoogte;
        }
        public void SetBreedte(double breedte)
        {
            if (breedte < 0) { throw new ProductException("Invalid breedte."); }
            Breedte = breedte;
        }
        public void SetDiepte(double diepte)
        {
            if (diepte < 0) { throw new ProductException("Invalid diepte."); }
            Diepte = diepte;
        }
        public void SetInhoud(int inhoud)
        {
            if (inhoud < 0) { throw new ProductException("Invalid inhoud."); }
            Inhoud = inhoud;
        }
        public void SetEAN(long ean)
        {
            if (ean < 0) { throw new ProductException("Invalid ean."); }
            Eancode = ean;
        }
        public void SetPrijs(double prijs)
        {
            if (prijs < 0) { throw new ProductException("Invalid prijs."); }
            Prijs = prijs;
        }
        #endregion
    }
}
