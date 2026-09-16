namespace L02;

class Program
{
    static void Main(string[] args)
    {
        TaskOne();
        CleanUp();

        TaskTwo();
        CleanUp();

        TaskThree();
        CleanUp();

        TaskFour();
        CleanUp();

        TaskFive();
        CleanUp();

        TaskSix();
        CleanUp();

        TaskSeven();
        CleanUp();

        TaskEight();
        CleanUp();

        TaskNine();
        CleanUp();

        TaskTen();
        CleanUp();

        Console.WriteLine("\n\nNyomd meg az Enter-t a kilépéshez...");
        Console.ReadLine();
    }

    static void CleanUp()
    {
        Console.WriteLine("\n\nNyomd meg az Enter-t a következő feladat elindításához...");
        Console.ReadLine();
        Console.Clear();
    }

    static void PrintTaskHeader(int taskNumber)
    {
        Console.WriteLine($"--- {taskNumber}. feladat ---\n");
    }

    static void TaskOne()
    {
        PrintTaskHeader(1);
        Console.Write("Adj meg egy pozitív egész számot: ");
        int number = int.Parse(Console.ReadLine() ?? "0");

        if (number <= 0)
        {
            Console.WriteLine("A megadott szám nem pozitív egész szám.");
            return;
        }

        Console.Write($"A páros egész számok 0 és {number} között: ");
        for (int i = 0; i <= number; i += 2)
        {
            Console.Write(i);
            if (i < number - 1)
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine();
    }

    static void TaskTwo()
    {
        PrintTaskHeader(2);

        Console.Write("Adj meg egy jelszót: ");
        string password = Console.ReadLine() ?? "";

        string confirmPassword;
        int maxAttempts = 3;
        for (int attempt = 1; attempt <= maxAttempts; attempt++)
        {
            Console.Write("Erősítsd meg a jelszót: ");
            confirmPassword = Console.ReadLine() ?? "";

            if (password == confirmPassword)
            {
                Console.WriteLine("A jelszó megerősítése sikeres.");
                return;
            }
            else
            {
                Console.WriteLine($"A jelszó nem egyezik. Próbáld újra ({attempt}/{maxAttempts}).");
            }
        }
        Console.WriteLine("A jelszó megerősítése sikertelen. Túl sok hibás próbálkozás.");
    }

    static void TaskThree()
    {
        PrintTaskHeader(3);

        Console.Write("Adj meg egy pozitív egész számot 1 és 1000 között: ");
        int number = int.Parse(Console.ReadLine() ?? "0");

        if (number < 1 || number > 1000)
        {
            Console.WriteLine("A megadott szám nem a megadott tartományban van.");
            return;
        }

        Random random = new Random();
        int randomNumber;

        Console.Write("Generált véletlenszámok: ");
        do
        {
            randomNumber = random.Next(1, 1001);
            Console.Write($"{randomNumber}, ");
        } while (randomNumber != number);
        Console.WriteLine();
    }

    static void TaskFour()
    {
        PrintTaskHeader(4);

        Console.Write("Add meg a játékosok számát: ");
        int playerCount = int.Parse(Console.ReadLine() ?? "0");

        if (playerCount <= 0)
        {
            Console.WriteLine("Ennyi játékos nem lehet.");
            return;
        }

        Random random = new Random();
        int highestRollPlayer = -1;
        int highestRoll = 0;
        Console.WriteLine("Eldöntjük, ki kezdjen. A játékosok sorszáma 1-től indul.");
        for (int i = 1; i <= playerCount; i++)
        {
            Console.WriteLine($"Játékos {i} következik.");
            Console.Write("Nyomd meg az Enter-t a dobáshoz...");
            Console.ReadLine();
            
            Console.WriteLine($"Játékos {i} dob...");
            int roll = random.Next(1, 7);
            Console.WriteLine($"A dobott szám: {roll}");

            if (roll == 6)
            {
                Console.WriteLine($"Játékos {i} kezdhet!");
                return;
            } else if (roll > highestRoll)
            {
                highestRoll = roll;
                highestRollPlayer = i;
            }
        }
        
        Console.WriteLine($"A legtöbbet dobó játékos kezd: Játékos {highestRollPlayer} a {highestRoll} dobással.");

    }

    static void TaskFive()
    {
        PrintTaskHeader(5);

        Random random = new Random();
        int randomNumber = random.Next(1, 101);
        int guess, attempts = 0;

        Console.WriteLine("Gondoltam egy számra 1 és 100 között. Találd ki!");
        do
        {
            Console.Write("Tippelj: ");
            guess = int.Parse(Console.ReadLine() ?? "0");
            attempts++;

            if (guess < randomNumber)
            {
                Console.WriteLine("A gondolt szám nagyobb.");
            }
            else if (guess > randomNumber)
            {
                Console.WriteLine("A gondolt szám kisebb.");
            }
        } while (guess != randomNumber);
        Console.WriteLine($"Gratulálok! Eltaláltad a {randomNumber} számot {attempts} próbálkozásból.");
    }

    static void TaskSix()
    {
        PrintTaskHeader(6);

        Console.Write("Adj meg egy pozitív egész számot: ");
        int number = int.Parse(Console.ReadLine() ?? "0");
        if (number <= 0)
        {
            Console.WriteLine("A megadott szám nem pozitív egész szám.");
            return;
        }

        string pairity = (number % 2 == 0) ? "páros" : "páratlan";
        Console.WriteLine($"A(z) {number} szám {pairity}.");

        int numberOfDivisors = 0;
        for (int i = 1; i <= number/2; i++)
        {
            if (number % i == 0)
            {
                numberOfDivisors++;
            }
        }
        numberOfDivisors++; // include the number itself
        Console.WriteLine($"A(z) {number} számnak {numberOfDivisors} osztója van.");

        if (numberOfDivisors == 2)
        {
            Console.WriteLine($"A(z) {number} szám prímszám.");
        }
        else
        {
            Console.WriteLine($"A(z) {number} szám összetett szám.");
        }
    }

    static void TaskSeven()
    {
        PrintTaskHeader(7);

        Console.Write("Adj meg egy pozitív egész számot: ");
        int number = int.Parse(Console.ReadLine() ?? "0");
        if (number <= 0)
        {
            Console.WriteLine("A megadott szám nem pozitív egész szám.");
            return;
        }

        long factorial = 1;
        for (int i = 2; i <= number; i++)
        {
            factorial *= i;
        }

        Console.WriteLine($"A(z) {number} szám faktoriálisa: {factorial}");
    }

    static void TaskEight()
    {
        PrintTaskHeader(8);

        int tableSize = 9;
        Console.WriteLine("Szorzótábla:");
        for (int i = 1; i <= tableSize; i++)
        {
            if(i == 1)
            {
                Console.Write($"  |");
            }
            Console.Write($"\t{i}");
        }
        Console.WriteLine("\n----------------------------------------------------------------------------");
        for (int i = 1; i <= tableSize; i++)
        {
            Console.Write($"{i} |\t");
            for (int j = 1; j <= tableSize; j++)
            {
                Console.Write($"{i * j}\t");
            }
            Console.WriteLine();
        }
    }

    static void TaskNine()
    {
        PrintTaskHeader(9);

        Console.Write("Add meg az időtartamot másodpercben: ");
        int seconds = int.Parse(Console.ReadLine() ?? "0");

        if (seconds <= 0)
        {
            Console.WriteLine("A megadott időtartam nem pozitív egész szám.");
            return;
        }

        for (int remaining = seconds; remaining > 0; remaining--)
        {
            Console.Clear();
            PrintTaskHeader(9);
            Console.WriteLine($"Hátralévő idő: {remaining / 60:D2}:{remaining % 60:D2}");
            Thread.Sleep(1000);
        }

        Console.BackgroundColor = ConsoleColor.Red;
        Console.Clear();
        Console.WriteLine("Lejárt az idő!");
        Console.Beep();
        Console.ResetColor();
    }

    static void TaskTen()
    {
        PrintTaskHeader(10);

        Console.Write("Adj meg egy pozitív egész számot: ");
        uint number = uint.Parse(Console.ReadLine() ?? "0");
        if (number <= 0)
        {
            Console.WriteLine("A megadott szám nem pozitív egész szám.");
            return;
        }

        Console.WriteLine($"A(z) {number} szám bináris reprezentációja: {Convert.ToString(number, 2).PadLeft(32, '0')}");
    }
}
