using TemaPractica1;

static int generateRandomInt(int lowerLimit, int upperLimit)
{
    var random = new Random();
    return random.Next(lowerLimit, upperLimit + 1);
}

var integerInterval = new IntegerInterval();
integerInterval = IntegerIntervalReader.ReadInterval();

var randomNumber = generateRandomInt(integerInterval.LowerLimit, integerInterval.UpperLimit);

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