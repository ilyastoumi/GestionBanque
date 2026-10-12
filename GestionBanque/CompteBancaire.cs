using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.JavaScript;
using System.Text;

namespace GestionBanque
{
   abstract class CompteBancaire
    {
        //chon
        private string _titulaire;
        private static int _compteur;
        private string _numero;
        private double _solde;
        //Properties
        public string Numero { get { return _numero; } }//just get
        public string Titulaire { get { return _titulaire; } set { if (string.IsNullOrWhiteSpace(value)) _titulaire = "Inconnu"; else _titulaire = value; } }
        public double Solde { get { return _solde; } protected set { _solde = value; } }
        //Constructeur
        public CompteBancaire(double soldeCO , string TitulaireCO)
            { 
            _compteur++;
            _numero = "CPT" + _compteur.ToString("D4");
            Titulaire = TitulaireCO;
            Solde = soldeCO < 0 ? 0: soldeCO;
    
            
            }
            //Methods
    public virtual bool Deposer(double montant)
        {
            if (montant <= 0)
                return false;
            else
               Solde = Solde + montant;
            return true;
        }
        public virtual bool Retirer(double montant)
        {
            if (montant > Solde || montant <=0) 
                return false;
            else
               Solde = Solde - montant;
            return true;
        }
        public void Afficherinformations(){ Console.WriteLine(Description()); }
        protected virtual string Description() { 
        return $"Numero: {Numero} , Titulaire: {Titulaire} , Sold: {Solde}";
        }
    }
}
