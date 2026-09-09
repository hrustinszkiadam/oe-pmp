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

        Hatodik();
        AfterTask();

        HetedikNyolcadik();
        AfterTask();

        Kilencedik();
        AfterTask();

        Tizenegyedik();
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

        int age = DateTime.Now.Year - (int)birthYear;
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

        double bmi = (double)(mass / Math.Pow((double)height, 2));
        Console.WriteLine($"\nA BMI-d: {bmi:F2}");
    }

    static void Hatodik()
    {
        Console.WriteLine("Hatodik feladat\n");

        int? seconds = null;

        while (seconds == null || seconds < 0)
        {
            Console.Write("Adj meg egy időtartamot másodpercben: ");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int s))
            {
                seconds = s;
            }
            else
            {
                Console.WriteLine("Érvénytelen érték. Kérlek, próbáld újra.");
            }
        }

        TimeSpan timeSpan = TimeSpan.FromSeconds((int)seconds);
        Console.WriteLine($"\nAz időtartam formázva: {timeSpan.Minutes}:{String.Format("{0:D2}", timeSpan.Seconds)}");
    }

    static void HetedikNyolcadik()
    {
        Console.WriteLine("Hetedik és nyolcadik feladat\n");

        static string ReadPassword()
        {
            string password = "";
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(intercept: true);

                if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password[..^1];
                    Console.Write("\b \b");
                }
                else if (!char.IsControl(key.KeyChar))
                {
                    password += key.KeyChar;
                    Console.Write("*");
                }
            } while (key.Key != ConsoleKey.Enter);

            Console.WriteLine();
            return password;
        }

        Console.Write("Add meg a jelszavad: ");
        string password = ReadPassword();
        Console.Write("\nErősítsd meg a jelszavad: ");
        string passwordConfirm = ReadPassword();
    
        Console.WriteLine();
        if (password != passwordConfirm)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("A jelszavak nem egyeznek meg.");
            Console.ResetColor();
            return;
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Sikeres jelszó megerősítés!");
        Console.ResetColor();
    }

    static void Kilencedik()
    {
        Console.WriteLine("Kilencedik feladat\n");

        int? number1 = null;

        while (number1 == null)
        {
            Console.Write("Add meg az első számot: ");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int n))
            {
                number1 = n;
            }
            else
            {
                Console.WriteLine("Érvénytelen szám. Kérlek, próbáld újra.");
            }
        }

        int? number2 = null;

        while (number2 == null)
        {
            Console.Write("Add meg a második számot: ");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int n))
            {
                number2 = n;
            }
            else
            {
                Console.WriteLine("Érvénytelen szám. Kérlek, próbáld újra.");
            }
        }

        string operation = "";

        while (operation != "+" && operation != "-" && operation != "*" && operation != "/")
        {
            Console.Write("Add meg a műveletet (+, -, *, /): ");
            operation = Console.ReadLine() ?? "";

            if (operation != "+" && operation != "-" && operation != "*" && operation != "/")
            {
                Console.WriteLine("Érvénytelen művelet. Kérlek, próbáld újra.");
            }
        }

        double n1 = (double)number1;
        double n2 = (double)number2;

        double result = operation switch
        {
            "+" => n1 + n2,
            "-" => n1 - n2,
            "*" => n1 * n2,
            "/" => n2 != 0 ? (double)n1 / n2 : throw new DivideByZeroException("Nullával való osztás nem engedélyezett."),
            _ => throw new InvalidOperationException("Érvénytelen művelet.")
        };
        Console.WriteLine($"\n{number1} {operation} {number2} = {result}");
    }

    static void Tizenegyedik()
    {
        Console.WriteLine("Tizenegyedik feladat\n");

        int? number = null;

        while (number == null || number < 0 || number > 9)
        {
            Console.Write("Adj meg egy 0 és 9 közötti számot: ");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int n))
            {
                number = n;
            }
            else
            {
                Console.WriteLine("Érvénytelen szám. Kérlek, próbáld újra.");
            }
        }

        string[] hungarianNumbers = ["nulla", "egy", "kettő", "három", "négy", "öt", "hat", "hét", "nyolc", "kilenc"];
        Console.WriteLine($"\nAz általad megadptt szám: {hungarianNumbers[(int)number]}");
    }

    static void Tizenkettedik()
    {
        Console.WriteLine("Tizenkettedik feladat\n");

    }
}
