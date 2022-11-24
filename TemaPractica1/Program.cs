
static void GetLimits(out int lim1, out int lim2)
{
    while (true)
    {
        bool isInt1 = false, isInt2 = false;
        Console.WriteLine("Limita interval 1: ");
        isInt1 = Int32.TryParse(Console.ReadLine(), out lim1);
        Console.WriteLine("Limita interval 2: ");
        isInt2 = Int32.TryParse(Console.ReadLine(), out lim2);

        if (isInt1 && isInt2)
            break;
        else Console.WriteLine("Input incorect! Incearca din nou.");
    }

    if (lim2 < lim1)
        (lim1, lim2) = (lim2, lim1);
}

int lim1, lim2, randNum;
var rand = new Random();

GetLimits(out lim1, out lim2);
randNum = rand.Next(lim1, lim2 + 1);

Console.WriteLine("Ghiceste numarul din interval.");

while (true)
{
    //bool nIsValid = false;
    int n;
    if (Int32.TryParse(Console.ReadLine(), out n))
    {
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
    else Console.WriteLine("Input incorect! Incearca din nou.");
}