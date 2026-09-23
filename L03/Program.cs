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

        EighthTask();
        CleanUp();

        NinthTask();
        CleanUp();

        TenthTask();
        CleanUp();

        EleventhTask();
        CleanUp();

        TwelfthTask();

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

    static void EighthTask()
    {
        PrintTaskHeader(8);

        Console.Write("Adj meg egy pozitív egész számot: ");
        int n = int.Parse(Console.ReadLine() ?? "0");

        if(n <= 0)
        {
            Console.WriteLine("A szám nem lehet nulla vagy negatív.");
            return;
        }

        List<int> numbers = [n];
        while(numbers[^1] != 1)
        {
            int k = numbers[^1];
            int next = k % 2 == 0 ? k / 2 : 3 * k + 1;
            numbers.Add(next);
        }

        Console.WriteLine(string.Join(", ", numbers));
    }

    static void NinthTask()
    {
        PrintTaskHeader(9);

        int[] x = [1, 2, 3, 4, 5, 6, 7, 8];
        Console.WriteLine($"Eredeti tömb: {string.Join(", ", x)}");

        // only iterate to the middle, otherwise the elements get swapped back
        for(int i = 0; i < x.Length / 2; i++)
        {
            int tmp = x[i];
            x[i] = x[x.Length - i - 1];
            x[x.Length - i - 1] = tmp;
        }

        Console.WriteLine($"Megfordított tömb: {string.Join(", ", x)}");
    }

    static void PrintMatrix(int[,] matrix)
    {
        for(int i = 0; i < matrix.GetLength(0); i++)
        {
            for(int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write($"{matrix[i, j],3}");
            }
            Console.WriteLine();
        }
    }

    static void TenthTask()
    {
        PrintTaskHeader(10);

        Console.Write("Hány elemű legyen a gyűjtemény? ");
        int count = int.Parse(Console.ReadLine() ?? "0");

        if(count <= 0)
        {
            Console.WriteLine("Az elemszám nem lehet nulla vagy negatív.");
            return;
        }

        Random rnd = new();
        int[] numbers = new int[count];
        for(int i = 0; i < count; i++)
        {
            numbers[i] = rnd.Next(1, 100);
        }

        // array
        Console.WriteLine("\n--- Tömb ---");
        Console.WriteLine($"Elemek: {string.Join(", ", numbers)}");

        int[] everySecond = new int[count / 2];
        for(int i = 0; i < everySecond.Length; i++)
        {
            everySecond[i] = numbers[i * 2 + 1];
        }
        Console.WriteLine($"Minden második elem: {string.Join(", ", everySecond)}");

        int[] reversed = new int[count];
        for(int i = 0; i < count; i++)
        {
            reversed[i] = numbers[count - i - 1];
        }
        Console.WriteLine($"Fordított sorrend: {string.Join(", ", reversed)}");

        int size = (int)Math.Ceiling(Math.Sqrt(count));
        int[,] matrix = new int[size, size];
        for(int i = 0; i < count; i++)
        {
            matrix[i / size, i % size] = numbers[i];
        }
        Console.WriteLine("Négyzetes mátrix:");
        PrintMatrix(matrix);

        // list
        Console.WriteLine("\n--- Lista ---");
        List<int> numberList = [];
        foreach(int number in numbers)
        {
            numberList.Add(number);
        }
        Console.WriteLine($"Elemek: {string.Join(", ", numberList)}");

        List<int> everySecondList = [];
        for(int i = 1; i < numberList.Count; i += 2)
        {
            everySecondList.Add(numberList[i]);
        }
        Console.WriteLine($"Minden második elem: {string.Join(", ", everySecondList)}");

        List<int> reversedList = [];
        for(int i = numberList.Count - 1; i >= 0; i--)
        {
            reversedList.Add(numberList[i]);
        }
        Console.WriteLine($"Fordított sorrend: {string.Join(", ", reversedList)}");

        int listSize = (int)Math.Ceiling(Math.Sqrt(numberList.Count));
        int[,] listMatrix = new int[listSize, listSize];
        for(int i = 0; i < numberList.Count; i++)
        {
            listMatrix[i / listSize, i % listSize] = numberList[i];
        }
        Console.WriteLine("Négyzetes mátrix:");
        PrintMatrix(listMatrix);
    }

    static void EleventhTask()
    {
        PrintTaskHeader(11);

        const int rows = 4;
        const int cols = 4;
        int[,] matrix = new int[rows, cols];
        for(int i = 0; i < rows; i++)
        {
            for(int j = 0; j < cols; j++)
            {
                matrix[i, j] = i * cols + j + 1;
            }
        }

        Console.WriteLine("Eredeti mátrix:");
        PrintMatrix(matrix);

        Console.Write("\nHányszor forgassuk el 90 fokkal (K)? ");
        int k = int.Parse(Console.ReadLine() ?? "0");

        int top = 0, bottom = rows - 1, left = 0, right = cols - 1;
        while(top <= bottom && left <= right)
        {
            // collect the positions of the current ring in clockwise order
            List<int> ringRows = [];
            List<int> ringCols = [];
            for(int j = left; j <= right; j++) { ringRows.Add(top); ringCols.Add(j); }
            for(int i = top + 1; i <= bottom; i++) { ringRows.Add(i); ringCols.Add(right); }
            if(top < bottom)
            {
                for(int j = right - 1; j >= left; j--) { ringRows.Add(bottom); ringCols.Add(j); }
            }
            if(left < right)
            {
                for(int i = bottom - 1; i > top; i--) { ringRows.Add(i); ringCols.Add(left); }
            }

            int ringLength = ringRows.Count;
            int[] values = new int[ringLength];
            for(int p = 0; p < ringLength; p++)
            {
                values[p] = matrix[ringRows[p], ringCols[p]];
            }

            // every element moves k steps forward along the ring
            for(int p = 0; p < ringLength; p++)
            {
                int source = ((p - k) % ringLength + ringLength) % ringLength;
                matrix[ringRows[p], ringCols[p]] = values[source];
            }

            top++;
            bottom--;
            left++;
            right--;
        }

        Console.WriteLine("\nElforgatott mátrix:");
        PrintMatrix(matrix);
    }

    static bool CanReachEnd(bool[,] maze, bool[,] visited, int row, int col)
    {
        int rows = maze.GetLength(0);
        int cols = maze.GetLength(1);

        if(row < 0 || row >= rows || col < 0 || col >= cols || !maze[row, col] || visited[row, col])
        {
            return false;
        }

        if(row == rows - 1 && col == cols - 1)
        {
            return true;
        }

        visited[row, col] = true;

        return CanReachEnd(maze, visited, row - 1, col)
            || CanReachEnd(maze, visited, row + 1, col)
            || CanReachEnd(maze, visited, row, col - 1)
            || CanReachEnd(maze, visited, row, col + 1);
    }

    static void TwelfthTask()
    {
        PrintTaskHeader(12);

        const int rows = 4;
        const int cols = 10;
        bool[,] maze = new bool[rows, cols];
        Random rnd = new();

        for(int i = 0; i < rows; i++)
        {
            for(int j = 0; j < cols; j++)
            {
                maze[i, j] = rnd.Next(10) < 7;
                Console.Write(maze[i, j] ? "T " : "F ");
            }
            Console.WriteLine();
        }

        Console.Write($"\nAdd meg a kezdő oszlopot (x, 0-{cols - 1}): ");
        int x = int.Parse(Console.ReadLine() ?? "0");
        Console.Write($"Add meg a kezdő sort (y, 0-{rows - 1}): ");
        int y = int.Parse(Console.ReadLine() ?? "0");

        bool[,] visited = new bool[rows, cols];
        if(CanReachEnd(maze, visited, y, x))
        {
            Console.WriteLine("\nA kezdőpontból el lehet jutni a jobb alsó sarokba.");
        }
        else
        {
            Console.WriteLine("\nA kezdőpontból nem lehet eljutni a jobb alsó sarokba.");
        }
    }
}
