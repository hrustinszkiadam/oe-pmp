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

        ThirdTask();
        CleanUp();

        FifthTask();
        CleanUp();

        SixthTask();
        CleanUp();

        SeventhTask();
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

    static void ThirdTask()
    {
        PrintTaskHeader(3);

        List<string> words = [];
        
        while (true)
        {
            Console.Write("Adj meg egy szót (vagy írd be a 'STOP' parancsot a kilépéshez): ");
            string input = Console.ReadLine() ?? "";
            if (input.Equals("STOP", StringComparison.CurrentCultureIgnoreCase))
            {
                break;
            }
            if(!string.IsNullOrWhiteSpace(input))
            {
                words.Add(input);
            }
        }

        Console.Write("Adj meg egy keresőszót: ");
        string filter = Console.ReadLine() ?? "";

        if(string.IsNullOrWhiteSpace(filter))
        {
            Console.WriteLine("A keresőszó üres, nem lehet szűrni.");
            return;
        }

        for(int i = 0; i < words.Count; i++)
        {
            if(words[i].Contains(filter, StringComparison.CurrentCultureIgnoreCase))
            {
                Console.WriteLine($"A(z) '{filter}' szó megtalálható a(z) {i+1}. szóban: {words[i]}");
            }
        }
    }

    static void FifthTask()
    {
        PrintTaskHeader(5);

        List<string> names = [];
        List<int> ages = [];
        List<bool> experiences = [];
        
        while(true)
        {
            Console.Write("Add meg a neved: ");
            string name = Console.ReadLine() ?? "";

            if(string.IsNullOrWhiteSpace(name))
            {
                break;
            }

            Console.Write("Add meg az életkorod: ");
            int ageInput = int.Parse(Console.ReadLine() ?? "0");

            if(ageInput <= 0)
            {
                Console.WriteLine("Az életkor nem lehet nulla vagy negatív szám.");
                continue;
            }

            Console.Write("Van e programozási tapasztalatod? (igen/nem): ");
            string experienceInput = Console.ReadLine() ?? "";
            bool hasExperience = experienceInput.Equals("igen", StringComparison.CurrentCultureIgnoreCase);

            names.Add(name);
            ages.Add(ageInput);
            experiences.Add(hasExperience);
        }

        int totalAge = 0;
        foreach(int age in ages)
        {
            totalAge += age;
        }
        double averageAge = (double)totalAge / ages.Count;

        int maxAgeWithExperienceIndex = 0;
        int totalAgeWithoutExperience = 0;
        int countWithoutExperience = 0;

        for(int i = 0; i < ages.Count; i++)
        {
            if(ages[i] > ages[maxAgeWithExperienceIndex] && experiences[i])
            {
                maxAgeWithExperienceIndex = i;
            }

            if(!experiences[i])
            {
                totalAgeWithoutExperience += ages[i];
                countWithoutExperience++;
            }
        }

        double averageAgeWithoutExperience = countWithoutExperience > 0 ? (double)totalAgeWithoutExperience / countWithoutExperience : 0;

        Console.WriteLine($"\nA megadott életkorok átlaga: {averageAge:F2}");
        Console.WriteLine($"A megadott életkorok átlaga a tapasztalat nélküli személyekre: {averageAgeWithoutExperience:F2}");
        Console.WriteLine($"A legidősebb programozási tapasztalattal rendelkező személy: {names[maxAgeWithExperienceIndex]} ({ages[maxAgeWithExperienceIndex]} éves)");
    }

    static void SixthTask()
    {
        PrintTaskHeader(6);

        const int matrixSize = 3;
        int[,] matrix = new int[matrixSize, matrixSize];
        Random rnd = new();

        Console.WriteLine("A mátrix feltöltése véletlenszerű számokkal (0-9):");
        for(int i = 0; i < matrixSize; i++)
        {
            for(int j = 0; j < matrixSize; j++)
            {
                matrix[i, j] = rnd.Next(10);
                Console.Write($"{matrix[i, j]} ");
            }
            Console.WriteLine();
        }

        //transpose the matrix
        Console.WriteLine("\nA mátrix transzponálása:");
        int[,] transposedMatrix = new int[matrixSize, matrixSize];
        for(int i = 0; i < matrixSize; i++)
        {
            for(int j = 0; j < matrixSize; j++)
            {
                transposedMatrix[i,j] = matrix[j,i];
                Console.Write($"{transposedMatrix[i,j]} ");
            }
            Console.WriteLine();
        }
    }

    static void SeventhTask()
    {
        PrintTaskHeader(7);

        const int fishermenCount = 5;
        const int fishTypeCount = 4;
        int[,] catches = new int[fishermenCount, fishTypeCount];
        Random rnd = new();

        for(int i = 0; i < fishermenCount; i++)
        {
            for(int j = 0; j < fishTypeCount; j++)
            {
                catches[i, j] = rnd.Next(4);
            }
        }

        Console.Write("Horgász".PadRight(10));
        for(int j = 0; j < fishTypeCount; j++)
        {
            Console.Write($"{j + 1}. hal".PadLeft(8));
        }
        Console.WriteLine();

        for(int i = 0; i < fishermenCount; i++)
        {
            Console.Write($"{i + 1}.".PadRight(10));
            for(int j = 0; j < fishTypeCount; j++)
            {
                Console.Write($"{catches[i, j]}".PadLeft(8));
            }
            Console.WriteLine();
        }

        Console.WriteLine("\nFogások halfajtánként:");
        for(int j = 0; j < fishTypeCount; j++)
        {
            int typeTotal = 0;
            for(int i = 0; i < fishermenCount; i++)
            {
                typeTotal += catches[i, j];
            }
            Console.WriteLine($"{j + 1}. halfajta: {typeTotal} db");
        }

        int maxIndex = 0;
        int maxTotal = -1;
        bool hasZeroCatch = false;
        for(int i = 0; i < fishermenCount; i++)
        {
            int total = 0;
            for(int j = 0; j < fishTypeCount; j++)
            {
                total += catches[i, j];
            }

            if(total > maxTotal)
            {
                maxTotal = total;
                maxIndex = i;
            }

            if(total == 0)
            {
                hasZeroCatch = true;
            }
        }

        Console.WriteLine($"\nA legtöbb halat a(z) {maxIndex + 1}. horgász fogta: {maxTotal} db");
        Console.WriteLine(hasZeroCatch ? "Volt olyan horgász, aki egyetlen halat sem fogott." : "Minden horgász fogott legalább egy halat.");
    }
}
