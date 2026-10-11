namespace GestionBanque
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<CompteBancaire> listeComptes = new List<CompteBancaire>();
            bool continuer = true;

            while (continuer)
            {
                Console.WriteLine("\n=================================");
                Console.WriteLine("    Bank Account Management System    ");
                Console.WriteLine("=================================");
                Console.WriteLine("1. Create Savings Account (Compte Epargne)");
                Console.WriteLine("2. Create Current Account (Compte Courant)");
                Console.WriteLine("3. Deposit Money (Deposer)");
                Console.WriteLine("4. Withdraw Money (Retirer)");
                Console.WriteLine("5. Apply Interest to Savings Accounts (Calculer Interets)");
                Console.WriteLine("6. Display All Accounts (Afficher Tout)");
                Console.WriteLine("7. Exit (Quitter)");
                Console.Write("\nChoose an option (1-7): ");

                string choix = Console.ReadLine();

                switch (choix)
                {
                    case "1":
                        CreerCompteEpargne(listeComptes);
                        break;
                    case "2":
                        CreerCompteCourant(listeComptes);
                        break;
                    case "3":
                        EfectuerDepot(listeComptes);
                        break;
                    case "4":
                        EffectuerRetrait(listeComptes);
                        break;
                    case "5":
                        AppliquerInterets(listeComptes);
                        break;
                    case "6":
                        AfficherTousLesComptes(listeComptes);
                        break;
                    case "7":
                        continuer = false;
                        Console.WriteLine("\nThank you for using the Banking System. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("\nInvalid choice! Please enter a number from 1 to 7.");
                        break;
                }
            }
        }

        // --- Helper Methods ---

        static void CreerCompteEpargne(List<CompteBancaire> liste)
        {
            Console.WriteLine("\n--- Create New Savings Account ---");
            Console.Write("Account Holder Name: ");
            string nom = Console.ReadLine();

            Console.Write("Initial Balance: ");
            double solde = Convert.ToDouble(Console.ReadLine());


            CompteEpargne ce = new CompteEpargne(solde, nom);
            liste.Add(ce);

            Console.WriteLine("\nSavings account created successfully!");
            ce.Afficherinformations();
        }

        static void CreerCompteCourant(List<CompteBancaire> liste)
        {
            Console.WriteLine("\n--- Create New Current Account ---");
            Console.Write("Account Holder Name: ");
            string nom = Console.ReadLine();

            Console.Write("Initial Balance: ");
            double solde = Convert.ToDouble(Console.ReadLine());

            Console.Write("Overdraft Limit (Découvert): ");
            double decouvert = Convert.ToDouble(Console.ReadLine());

            CompteCourant cc = new CompteCourant(solde, nom);
            liste.Add(cc);

            Console.WriteLine("\nCurrent account created successfully!");
            cc.Afficherinformations();
        }

        static CompteBancaire ChercherCompte(List<CompteBancaire> liste)
        {
            if (liste.Count == 0) return null;

            Console.Write("Enter Account Number (e.g., CPT0001): ");
            string numero = Console.ReadLine().Trim();

            foreach (var c in liste)
            {
                if (c.Numero.Equals(numero, StringComparison.OrdinalIgnoreCase))
                    return c;
            }
            return null;
        }

        static void EfectuerDepot(List<CompteBancaire> liste)
        {
            Console.WriteLine("\n--- Deposit Money ---");
            CompteBancaire c = ChercherCompte(liste);

            if (c == null)
            {
                Console.WriteLine("Account not found or no accounts available!");
                return;
            }

            Console.Write("Amount to deposit: ");
            double montant = Convert.ToDouble(Console.ReadLine());

            if (c.Deposer(montant))
                Console.WriteLine("Deposit successful!");
            else
                Console.WriteLine("Transaction failed! Invalid amount.");

            c.Afficherinformations();
        }

        static void EffectuerRetrait(List<CompteBancaire> liste)
        {
            Console.WriteLine("\n--- Withdraw Money ---");
            CompteBancaire c = ChercherCompte(liste);

            if (c == null)
            {
                Console.WriteLine("Account not found or no accounts available!");
                return;
            }

            Console.Write("Amount to withdraw: ");
            double montant = Convert.ToDouble(Console.ReadLine());

            if (c.Retirer(montant))
                Console.WriteLine("Withdrawal successful!");
            else
                Console.WriteLine("Transaction failed! Insufficient funds or exceeds overdraft limit.");

            c.Afficherinformations();
        }

        static void AppliquerInterets(List<CompteBancaire> liste)
        {
            Console.WriteLine("\n--- Apply Interest to Savings Accounts ---");
            bool trouve = false;

            foreach (var c in liste)
            {
                if (c is CompteEpargne ce)
                {
                    ce.Calculer();
                    Console.WriteLine($"Interest applied for account {ce.Numero}. New balance: {ce.Solde}");
                    trouve = true;
                }
            }

            if (!trouve)
                Console.WriteLine("No savings accounts registered in the system currently.");
        }

        static void AfficherTousLesComptes(List<CompteBancaire> liste)
        {
            Console.WriteLine("\n=== List of All Registered Accounts ===");
            if (liste.Count == 0)
            {
                Console.WriteLine("No accounts registered yet.");
                return;
            }

            foreach (var c in liste)
            {
                c.Afficherinformations();
            }

        }
    }
}
