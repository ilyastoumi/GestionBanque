using System;
using System.Collections.Generic;
using System.Text;

namespace GestionBanque
{
    internal class CompteCourant : CompteBancaire
    {
        //chon
        private double _decouvertAutorise;
        //Properties
        public double DecouvertAutorise { get { return _decouvertAutorise; } protected set { if (value < 0) _decouvertAutorise = 0; else _decouvertAutorise = value; } }
        //Constructeur
        public CompteCourant(double soldeCO, string TitulaireCO ,double DecouvertAutoriseCO) :base(soldeCO, TitulaireCO)
        {
            DecouvertAutorise = DecouvertAutoriseCO;
        }
        //Methods
        public override bool Retirer(double montant)
        {
            if (montant<=0 || montant > (Solde + DecouvertAutorise)) return false;
            else
                Solde = Solde - montant;
            return true;
        }
        protected override string Description()
        {
            return base.Description() +$", DecouvertAutorise :{DecouvertAutorise}";
        }
    }
}
