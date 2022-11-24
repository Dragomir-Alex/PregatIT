
static bool ReadLimit(out int limit, string message)
{
    Console.WriteLine(message);
    return Int32.TryParse(Console.ReadLine(), out limit);
}

static void GetLimits(out int lowerLimit, out int upperLimit)
{
    while (true)
    {
        bool isLowerLimitValid = false, isUpperLimitValid = false;
        isLowerLimitValid = ReadLimit(out lowerLimit, "Limita interval 1: ");
        isUpperLimitValid = ReadLimit(out upperLimit, "Limita interval 2: ");

        if (isLowerLimitValid && isUpperLimitValid)
            break;
        else Console.WriteLine("Input incorect! Incearca din nou.");
    }

    if (upperLimit < lowerLimit)
        (lowerLimit, upperLimit) = (upperLimit, lowerLimit); // Swap
}

int lowerLimit, upperLimit, randomNumber;
var random = new Random();

GetLimits(out lowerLimit, out upperLimit);
randomNumber = random.Next(lowerLimit, upperLimit + 1);

Console.WriteLine("Ghiceste numarul din interval.");

while (true)
{
    int readValue;
    if (Int32.TryParse(Console.ReadLine(), out readValue))
    {
        if (readValue == randomNumber)
        {
            Console.WriteLine("Valoarea {0} este cea corecta!", readValue);
            break;
        }
        else if (readValue > randomNumber)
        {
            Console.WriteLine("Valoarea {0} este prea mare.", readValue);
        }
        else
        {
            Console.WriteLine("Valoarea {0} este prea mica.", readValue);
        }
    }
    else Console.WriteLine("Input incorect! Incearca din nou.");
}