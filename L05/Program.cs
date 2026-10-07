using System.Globalization;

namespace L05;

class Program
{
    static void Main(string[] args)
    {
        string filePathStart = "../../../";

        // 1. feladat
        PrintTaskHeader(1);

        string[] colorLines = File.ReadAllLines(filePathStart + "assets/colorem_ipsum.txt");

        foreach (string line in colorLines)
        {
            string[] parts = line.Split("#");
            Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), parts[0]);
            Console.WriteLine(parts[1]);
            Console.ResetColor();
        }

        // 2. feladat
        PrintTaskHeader(2);

        DateTime currentLotteryDate = DateTime.Now;
        Random randomLottery = new();
        EnsureOutputDirectoryExists();
        StreamWriter lotteryWriter = new(filePathStart + "output/lottery.txt", false);

        while (true)
        {
            Console.Write($"On {currentLotteryDate:yyyy. MM. dd.} numbers where: ");
            lotteryWriter.Write($"{currentLotteryDate:yyyy-MM-dd};");

            int[] lotteryNumbers = new int[5];
            for (int i = 0; i < 5; i++)
            {
                int number = randomLottery.Next(1, 91);
                while (lotteryNumbers.Contains(number))
                {
                    number = randomLottery.Next(1, 91);
                }
                lotteryNumbers[i] = number;

                Console.Write($"{lotteryNumbers[i]} ");
                lotteryWriter.Write($"{lotteryNumbers[i]}" + (i < 4 ? "," : ""));
            }

            Console.WriteLine();
            lotteryWriter.WriteLine();

            Console.Write("Another week? [y/n]: ");
            string userInput = Console.ReadLine();

            if (userInput != null && userInput.Equals("n", StringComparison.CurrentCultureIgnoreCase)) 
            {
                break;
            }

            currentLotteryDate = currentLotteryDate.AddDays(7);
        }
        lotteryWriter.Close();

        // 3. feladat
        PrintTaskHeader(3);

        string[] antLines = File.ReadAllLines(filePathStart + "assets/ant_instructions.txt");

        string[] start = antLines[0].Split(" ");
        int antX = int.Parse(start[0]);
        int antY = int.Parse(start[1]);
        int antDirection = int.Parse(start[2]);

        Console.WriteLine($"Kezdőpozíció: ({antX}, {antY}), irány: {antDirection}°");

        for (int i = 1; i < antLines.Length; i++)
        {
            string[] parts = antLines[i].Split(" ");
            int value = int.Parse(parts[1]);

            if (parts[0] == "go")
            {
                switch (antDirection)
                {
                    case 0: antX += value; break;
                    case 90: antY += value; break;
                    case 180: antX -= value; break;
                    case 270: antY -= value; break;
                }
            }
            else if (parts[0] == "left")
            {
                antDirection = (antDirection + value) % 360;
            }
            else if (parts[0] == "right")
            {
                antDirection = (antDirection - value + 360) % 360;
            }

            Console.WriteLine($"{antLines[i],-10} -> pozíció: ({antX}, {antY}), irány: {antDirection}°");
        }

        // 4. feladat
        PrintTaskHeader(4);

        List<int> SEQN = new();
        List<string> SURVEY = new();
        List<int> RIAGENDR = new();
        List<int> RIDAGEYR = new();
        List<double> BMXBMI = new();
        List<double> LBDGLUSI = new();

        string[] nhanesLines = File.ReadAllLines(filePathStart + "assets/NHANES_1999-2018.csv");

        for (int i = 1; i < nhanesLines.Length; i++)
        {
            string[] parts = nhanesLines[i].Split(",");
            SEQN.Add(int.Parse(parts[0]));
            SURVEY.Add(parts[1]);
            RIAGENDR.Add(int.Parse(parts[2].Split(".")[0]));
            RIDAGEYR.Add(int.Parse(parts[3].Split(".")[0]));
            BMXBMI.Add(double.Parse(parts[4], CultureInfo.InvariantCulture));
            LBDGLUSI.Add(double.Parse(parts[5], CultureInfo.InvariantCulture));
        }

        List<string> surveys = new();
        for (int i = 0; i < SURVEY.Count; i++)
        {
            if (!surveys.Contains(SURVEY[i]))
            {
                surveys.Add(SURVEY[i]);
            }
        }

        // 4.1 és 4.2: nők és férfiak átlagos BMI-je, illetve az 5.6 feletti vércukorszint aránya felmérésenként
        foreach (string survey in surveys)
        {
            double maleBmiSum = 0, femaleBmiSum = 0;
            int maleCount = 0, femaleCount = 0;
            int highGlucoseCount = 0, surveyCount = 0;

            for (int i = 0; i < SEQN.Count; i++)
            {
                if (SURVEY[i] != survey)
                {
                    continue;
                }

                surveyCount++;
                if (RIAGENDR[i] == 1)
                {
                    maleBmiSum += BMXBMI[i];
                    maleCount++;
                }
                else if (RIAGENDR[i] == 2)
                {
                    femaleBmiSum += BMXBMI[i];
                    femaleCount++;
                }

                if (LBDGLUSI[i] > 5.6)
                {
                    highGlucoseCount++;
                }
            }

            Console.WriteLine($"{survey}:");
            Console.WriteLine($"\tNők átlagos BMI-je: {femaleBmiSum / femaleCount:F2}");
            Console.WriteLine($"\tFérfiak átlagos BMI-je: {maleBmiSum / maleCount:F2}");
            Console.WriteLine($"\t5.6-nál magasabb vércukorszint aránya: {(double)highGlucoseCount / surveyCount * 100:F2}%");
        }

        // 4.3: egy maximális BMI-vel rendelkező alany vércukorszintje
        int maxBmiIndex = 0;
        for (int i = 1; i < BMXBMI.Count; i++)
        {
            if (BMXBMI[i] > BMXBMI[maxBmiIndex])
            {
                maxBmiIndex = i;
            }
        }
        Console.WriteLine($"\nA maximális BMI-vel ({BMXBMI[maxBmiIndex]}) rendelkező alany (SEQN {SEQN[maxBmiIndex]}) vércukorszintje: {LBDGLUSI[maxBmiIndex]}");

        // 4.4: túlsúlyos (BMI >= 30.0) személyek átlagos életkora
        int overweightAgeSum = 0, overweightCount = 0;
        for (int i = 0; i < BMXBMI.Count; i++)
        {
            if (BMXBMI[i] >= 30.0)
            {
                overweightAgeSum += RIDAGEYR[i];
                overweightCount++;
            }
        }
        Console.WriteLine($"A túlsúlyos (BMI >= 30.0) személyek átlagos életkora: {(double)overweightAgeSum / overweightCount:F2}");

        Console.WriteLine("\n\nNyomd meg az Enter-t a kilépéshez...");
        Console.ReadLine();
    }

    static void PrintTaskHeader(uint taskNumber)
    {
        Console.WriteLine($"\n--- {taskNumber}. feladat ---\n");
    }

    static void EnsureOutputDirectoryExists()
    {
        if (!Directory.Exists("../../../output"))
        {
            Directory.CreateDirectory("../../../output");
        }
    }
}
