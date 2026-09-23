namespace L03;

class Program
{
    static void Main(string[] args)
    {
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
}
