using System;
using System.Collections.Generic;
using System.Text;

namespace GestionBanque
{
    internal class CompteCourant : CompteBancaire
    {
        public double DecouvertAutorise { get; } = 1000;
        public CompteCourant(double soldeCO, string TitulaireCO ):base(soldeCO, TitulaireCO)
        {
            
        }
       
        public override bool Retirer(double montant)
        {
            if (montant<=0 || montant > (Solde + DecouvertAutorise)) return false;
            else
                Solde = Solde - montant;
            return true;
        }
        protected override string Description()
        {
            return $"Numero: {Numero} , Titulaire: {Titulaire} , Sold: {Solde},DecouvertAutorise :{DecouvertAutorise}";
        }
    }
}
