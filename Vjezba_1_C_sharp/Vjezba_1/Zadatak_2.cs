using System;

namespace C_sharp_VJEZBE
{
    /*
    Napisati program koji sadrži dvije varijable, jednu tipa int, a drugu tipa long u koju će
    biti zapisana najveća moguća vrijednost za tip long. 
    Varijablu tipa long treba pridružiti varijabli tipa int, s tim da se obradi iznimka ako dođe do preljeva (overflow).
    Pomoć: vidjeti “checked” u MSDN
     */
    class Zadatak_2
    {
        static void Main2(string[] args)
        {
            try
            {
                int a = 100;
                long b = long.MaxValue;

                Console.WriteLine(checked(a + b));
            }
            catch (OverflowException e)
            {
                // Overflow
                Console.WriteLine(e.Message);
            }
        }
    }
}
