namespace L01;

class Program
{
    static void Main(string[] args)
    {
        ElsoMasodik();
        AfterTask();

        Harmadik();

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
        Console.SetCursorPosition(0, 0);
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

        Console.WriteLine($"Szia, {name}!");
    }
}
