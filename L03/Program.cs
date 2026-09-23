namespace L03;

class Program
{
    static void Main(string[] args)
    {

        string[] pakli = FirstTask();
        Console.WriteLine(string.Join(", ", pakli));
        CleanUp();

        SecondTask(pakli);
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

    static string[] FirstTask()
    {
        PrintTaskHeader(1);
        string[] szinek = [
            "Kőr", "Káró", "Treff", "Pikk"
        ];

        string[] ertekek = [
            "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jumbó", "Dáma", "Király", "Ász"
        ];

        string[] pakli = new string[szinek.Length * ertekek.Length];
        int j = 0;
        for (int i = 0; i < pakli.Length; i++)
        {
            pakli[i] = $"{szinek[j]} {ertekek[i % ertekek.Length]}";
            if((i+1) % ertekek.Length == 0) {
                j++;
            }
        }
        return pakli;
    }

    static void SecondTask(string[] pakli)
    {
        PrintTaskHeader(2);
        Console.WriteLine("A pakli keverése...");
        Random rnd = new();
        for (int i = 0; i < pakli.Length - 1; i++)
        {
            int randomIndex = rnd.Next(pakli.Length);
            (pakli[i], pakli[randomIndex]) = (pakli[randomIndex], pakli[i]);
        }
        Console.WriteLine(string.Join(", ", pakli));
    }
}
