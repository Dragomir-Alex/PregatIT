using System;

namespace TemaPractica1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lim1, lim2, randNum;
            var rand = new Random();

            Console.WriteLine("Limita interval 1: ");
            lim1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Limita interval 2: ");
            lim2 = Convert.ToInt32(Console.ReadLine());

            if (lim2 < lim1)
                (lim1, lim2) = (lim2, lim1);
            randNum = rand.Next(lim1, lim2 + 1);

            Console.WriteLine("Ghiceste numarul din interval.");

            while (true)
            {
                int n = Convert.ToInt32(Console.ReadLine());
                if (n == randNum)
                {
                    Console.WriteLine("Valoarea {0} este cea corecta!", n);
                    break;
                }
                else if (n > randNum)
                {
                    Console.WriteLine("Valoarea {0} este prea mare.", n);
                }
                else
                {
                    Console.WriteLine("Valoarea {0} este prea mica.", n);
                }
            }
        }
    }
}