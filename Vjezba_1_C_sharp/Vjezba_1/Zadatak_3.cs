using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C_sharp_VJEZBE
{
    /*
    Napisati program za bankare koji ima deklariran pobrojani tip podataka u kojem se
    nalaze vrste računa (Štednja , Tekući račun, Žiro račun). Unutar programa deklarirati 
    strukturu BankAccount koja će sadržavati tri varijable, broj računa, iznos na računu i 
    vrstu računa.
    Program treba deklarirati polje struktura BankAccount od 5 elemenata, te napraviti 
    izbornik koji će imati opcije - upisa novog računa, i ispis svih računa. Za ispis svih 
    računa koristiti “foreach” iteraciju.
    */

    public enum AccountType { Stednja, Tekuci, Ziro };

    public struct BankAccount
    {
        public int accNumber { get; set; }
        public double balance { get; set; }
        public AccountType accType { get; set; }

        public void printAccountData()
        {
            Console.WriteLine("Number: " + accNumber);
            Console.WriteLine("Balance: " + balance);
            Console.WriteLine("Type: " + accType);
        }

        public void generateRandomData()
        {
            Random random = new Random();

            accNumber = random.Next();
            balance = random.NextDouble();
            accType = (AccountType)random.Next(2);
        }
    }

    class Zadatak_3
    {
        static void Main(string[] args)
        {
            List<BankAccount> accounts = new List<BankAccount>();

            int i = 0;
            while (i < 5)
            {
                BankAccount tmp = new BankAccount();
                tmp.generateRandomData();
                accounts.Add(tmp);
                i++;
            }

            Console.WriteLine("Za unos novog racuna unesite 1, za ispis svih 2:");
            int select = Convert.ToInt32(Console.ReadLine());

            switch (select)
            {
                case 1:
                    Console.WriteLine("Unesite podatke: broj racuna, stanje i tip racuna:");
                    int num = Convert.ToInt32(Console.ReadLine());
                    double bal = Convert.ToDouble(Console.ReadLine());
                    string ty = Console.ReadLine();
                    accounts.Add(saveAccount(num, bal, ty);
                    
                    break;

                case 2:
                    foreach (BankAccount acc in accounts)
                    {
                        acc.printAccountData();
                    }
                    break;

                default:
                    break;
            }
        }

        private static BankAccount saveAccount(int accNum, double balance, string type)
        {
            BankAccount newAcc = new BankAccount();

            newAcc.accNumber = accNum;
            newAcc.balance = balance;
            newAcc.accType = type;

            return newAcc;
        }
    }
}
