using System;

namespace C_sharp_VJEZBE
{

    /*
    Napisati program koji upisuje dva cjelobrojna broja i ispisuje rezultat dijeljenja ta dva 
    broja. Rezultat treba ispisati u sljedećim formatima (Currency, Integer, Scientific, 
    Fixed-point, General, Number, Hexadecimal).
    Prilikom upisa nekog podatka sa tipkovnice, podatak se učitava kao tip string, a ako 
    nam treba tip int moramo ga pretvoriti uz pomoć ugrađenih metoda.
    Pripaziti da se obrade sve iznimke
    */
    class Zadatak_1
    {
        static void Main1(string[] args)
        {
            try
            {
                int a = Convert.ToInt32(Console.ReadLine());
                int b = Convert.ToInt32(Console.ReadLine());

                if (b == 0) // Divide by zero Exception
                {
                    throw new DivideByZeroException();
                }

                double res = (double)a / b;

                Console.WriteLine(res.ToString("C"));
                Console.WriteLine((int)res);
                Console.WriteLine(res.ToString("E5"));
                Console.WriteLine(res.ToString("F"));
                Console.WriteLine(res.ToString("G"));
                Console.WriteLine(res.ToString("N"));
                Console.WriteLine(((int)res).ToString("X"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
        }
    }
}
