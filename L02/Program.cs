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
}
