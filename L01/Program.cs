namespace L01;

class Program
{
    static void Main(string[] args)
    {
        ElsoMasodik();
        AfterTask();

        Harmadik();
        AfterTask();

        Negyedik();
        AfterTask();

        Otodik();
        AfterTask();

        // Wait for input before closing
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadLine();
    }

    static void AfterTask()
    {
        Console.CursorVisible = true;
        Console.ResetColor();

        Console.WriteLine("\nPress any key to go to the next task...");
        Console.ReadLine();

        Console.Clear();
    }

    static void ElsoMasodik()
    {
        Console.WriteLine("Első és második feladat\n");
        #region Setup
        
        Console.WindowHeight = 40;
        Console.WindowWidth = 120;
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.CursorVisible = false;

        #endregion

        Console.WriteLine("Hello, World!");
    }

    static void Harmadik()
    {
        Console.WriteLine("Harmadik feladat\n");

        string? name = null;

        while (name == null || name == "")
        {
            Console.Write("Add meg a neved: ");
            name = Console.ReadLine();
        }

        Console.WriteLine($"\nSzia, {name}!");
    }

    static void Negyedik()
    {
        Console.WriteLine("Negyedik feladat\n");

        int? birthYear = null;

        while (birthYear == null)
        {
            Console.Write("Add meg a születési éved: ");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int year))
            {
                birthYear = year;
            }
            else
            {
                Console.WriteLine("Érvénytelen év. Kérlek, próbáld újra.");
            }
        }

        int age = DateTime.Now.Year - birthYear.Value;
        Console.WriteLine($"\nIdén {age} éves vagy.");
        Console.WriteLine($"Jövőre {age + 1} éves leszel.");
    }

    static void Otodik()
    {
        Console.WriteLine("Ötödik feladat\n");

        double? height = null;
        double? mass = null;

        while (height == null)
        {
            Console.Write("Add meg a magasságod (m): ");
            string? input = Console.ReadLine();

            if (double.TryParse(input, out double h))
            {
                height = h;
            }
            else
            {
                Console.WriteLine("Érvénytelen érték. Kérlek, próbáld újra.");
            }
        }

        while (mass == null)
        {
            Console.Write("Add meg a súlyod (kg): ");
            string? input = Console.ReadLine();

            if (double.TryParse(input, out double m))
            {
                mass = m;
            }
            else
            {
                Console.WriteLine("Érvénytelen érték. Kérlek, próbáld újra.");
            }
        }

        double bmi = (double)mass / (double)(height * height);
        Console.WriteLine($"\nA BMI-d: {bmi:F2}");
    }
}
