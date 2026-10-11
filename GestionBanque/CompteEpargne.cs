using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace GestionBanque
{
    internal class CompteEpargne : CompteBancaire
    {
        private double Taux { get; } = 3.5;
            public CompteEpargne(double soldeCO,string TitulaireCO) :base(soldeCO, TitulaireCO)
        {

        }
            public void Calculer()
        {
            Solde += Solde * Taux / 100;
        }

        protected override string Description()
        {
            return $"Numero: {Numero} , Titulaire: {Titulaire} , Sold: {Solde},Taux: {Taux}%";
        }
    }
}
