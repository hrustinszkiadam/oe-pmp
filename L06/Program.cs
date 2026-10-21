using System.Globalization;

namespace L06;

class Program
{
    static void Main(string[] args)
    {
        string filePathStart = "../../../";

        // 1. feladat
        PrintTaskHeader(1);

        Book b = new("The Hobbit - or There and Back Again", "J.R.R. Tolkien", 1937, 312);
        Console.WriteLine(b.AllData());

        // 2. feladat
        PrintTaskHeader(2);
        WaitForEnter();
        Console.Clear();

        Rectangle[] rectangles =
        {
            new(10, 4, ConsoleColor.Red),
            new(0, 5, ConsoleColor.Green),
            new(6, 3, ConsoleColor.Blue),
            new(4, 6, ConsoleColor.Yellow),
        };

        int x = 0;
        foreach (Rectangle rectangle in rectangles)
        {
            if (rectangle.IsValid())
            {
                rectangle.Draw(x, 1);
                x += 12;
            }
        }

        Console.SetCursorPosition(0, 8);
        WaitForEnter();

        // 3. feladat
        Console.Clear();
        Runner first = new("Bolt", 1, 2.5);
        Runner second = new("Lewis", 2, 2.0);
        int goal = 100;

        while (first.GetDistance() < goal && second.GetDistance() < goal)
        {
            first.RefreshDistance(1);
            second.RefreshDistance(1);

            Console.Clear();
            first.Show();
            second.Show();

            Thread.Sleep(200);
        }

        Console.SetCursorPosition(0, 4);
        WaitForEnter();
        Console.Clear();

        // 4. feladat
        PrintTaskHeader(4);

        CaesarCipher cipher = new(3);
        string encoded = cipher.Encode("Hello, World!");
        Console.WriteLine($"Kódolt: {encoded}");
        Console.WriteLine($"Visszafejtett: {cipher.Decode(encoded)}");

        // 5. feladat
        PrintTaskHeader(5);

        List<Person> people = new();
        string[] nhanesLines = File.ReadAllLines(filePathStart + "assets/NHANES_1999-2018.csv");

        for (int i = 1; i < nhanesLines.Length; i++)
        {
            string[] parts = nhanesLines[i].Split(",");
            people.Add(new Person(
                int.Parse(parts[0]),
                parts[1],
                int.Parse(parts[2].Split(".")[0]),
                int.Parse(parts[3].Split(".")[0]),
                double.Parse(parts[4], CultureInfo.InvariantCulture),
                double.Parse(parts[5], CultureInfo.InvariantCulture)));
        }

        List<string> surveys = new();
        foreach (Person person in people)
        {
            if (!surveys.Contains(person.GetSurvey()))
            {
                surveys.Add(person.GetSurvey());
            }
        }

        // 5.1 és 5.2: nők és férfiak átlagos BMI-je, illetve az 5.6 feletti vércukorszint aránya felmérésenként
        foreach (string survey in surveys)
        {
            double maleBmiSum = 0, femaleBmiSum = 0;
            int maleCount = 0, femaleCount = 0;
            int highGlucoseCount = 0, surveyCount = 0;

            foreach (Person person in people)
            {
                if (person.GetSurvey() != survey)
                {
                    continue;
                }

                surveyCount++;
                if (person.GetGender() == 1)
                {
                    maleBmiSum += person.GetBmi();
                    maleCount++;
                }
                else if (person.GetGender() == 2)
                {
                    femaleBmiSum += person.GetBmi();
                    femaleCount++;
                }

                if (person.GetGlucose() > 5.6)
                {
                    highGlucoseCount++;
                }
            }

            Console.WriteLine($"{survey}:");
            Console.WriteLine($"\tNők átlagos BMI-je: {femaleBmiSum / femaleCount:F2}");
            Console.WriteLine($"\tFérfiak átlagos BMI-je: {maleBmiSum / maleCount:F2}");
            Console.WriteLine($"\t5.6-nál magasabb vércukorszint aránya: {(double)highGlucoseCount / surveyCount * 100:F2}%");
        }

        // 5.3: egy maximális BMI-vel rendelkező alany vércukorszintje
        Person maxBmiPerson = people[0];
        foreach (Person person in people)
        {
            if (person.GetBmi() > maxBmiPerson.GetBmi())
            {
                maxBmiPerson = person;
            }
        }
        Console.WriteLine($"\nA maximális BMI-vel ({maxBmiPerson.GetBmi()}) rendelkező alany (SEQN {maxBmiPerson.GetSeqn()}) vércukorszintje: {maxBmiPerson.GetGlucose()}");

        // 5.4: túlsúlyos (BMI >= 30.0) személyek átlagos életkora
        int overweightAgeSum = 0, overweightCount = 0;
        foreach (Person person in people)
        {
            if (person.GetBmi() >= 30.0)
            {
                overweightAgeSum += person.GetAge();
                overweightCount++;
            }
        }
        Console.WriteLine($"A túlsúlyos (BMI >= 30.0) személyek átlagos életkora: {(double)overweightAgeSum / overweightCount:F2}");

        Console.WriteLine();
        WaitForEnter();
    }

    static void PrintTaskHeader(uint taskNumber)
    {
        Console.WriteLine($"\n--- {taskNumber}. feladat ---\n");
    }

    static void WaitForEnter()
    {
        Console.WriteLine("Nyomd meg az Enter-t a folytatáshoz...");
        Console.ReadLine();
    }
}
