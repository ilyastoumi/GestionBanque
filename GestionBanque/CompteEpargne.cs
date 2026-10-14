using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace GestionBanque
{
    internal class CompteEpargne : CompteBancaire
    {
        //chon
        private double _taux;
        //Properties 
        public double Taux { get { return _taux; } protected set { if (value >= 0 && value <= 10) _taux = value; else _taux = 1.5; } }
        //Constructeur
        public CompteEpargne(double soldeCO,string TitulaireCO,double TauxCO) :base(soldeCO, TitulaireCO)
        {
            Taux = TauxCO;
        }
        //Methods
        public void AppliquerInterets()
        {
            Solde += Solde * Taux / 100;
        }

        protected override string Description()
        {
            return base.Description() + $", Taux: {Taux}%";
        }
        public override bool Retirer(double montant)
        {
            if ( montant >10000)
                return false;
            
            return base.Retirer(montant);
        }
    }
}
