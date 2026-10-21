namespace L07;

class Program
{
    static void Main(string[] args)
    {
        //WhackAMole();
        //ListFlights();
        ExamResults();

        Console.ReadLine();
    }

    public static void ExamResults()
    {
        Console.Write("Number of exam results: ");
        int n;
        while (!int.TryParse(Console.ReadLine(), out n) || n < 1)
        {
            Console.Write("Please enter a positive integer: ");
        }

        int[] limits = { 0, 50, 62, 74, 86 };
        List<ExamResult> results = new(n);
        for (int i = 0; i < n; i++)
        {
            Console.Write($"{i + 1}. result (Neptun code and points, e.g. ABC123 75; empty for random): ");
            string input = Console.ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(input))
            {
                results.Add(new ExamResult());
                continue;
            }

            string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            try
            {
                results.Add(new ExamResult(parts[0], int.Parse(parts[1])));
            }
            catch (Exception e)
            {
                Console.WriteLine($"Invalid input ({e.Message}), try again.");
                i--;
            }
        }

        Console.WriteLine("\nPassed:");
        foreach (ExamResult result in results)
        {
            if (result.Passed)
            {
                Console.WriteLine(result.NeptunCode);
            }
        }

        double sum = 0;
        ExamResult best = results[0];
        foreach (ExamResult result in results)
        {
            sum += result.Points;
            if (result.Points > best.Points)
            {
                best = result;
            }
        }

        Console.WriteLine($"\nAverage points: {sum / results.Count:F2}");
        Console.WriteLine($"Highest points: {best.NeptunCode} ({best.Points})");
    }

    public static void ListFlights()
    {
        GroundControl.AddFlight(new Flight("AA123", "New York", new DateTime(2023, 10, 1, 10, 0, 0), 15));
        GroundControl.AddFlight(new Flight("BB456", "Los Angeles", new DateTime(2023, 10, 1, 12, 0, 0)));
        GroundControl.AddFlight(new Flight("CC789", "Chicago", new DateTime(2023, 10, 1, 14, 0, 0), 30));

        GroundControl.DisplayFlightData();
        GroundControl.AverageDelay();
    }

    public static void WhackAMole()
    {
        Mole mole = new();

        int guess, attempts = 0;

        do 
        {
            Console.Clear();
            mole.Hide(1, 25);

            Console.Write("Guess the position of the mole (1-25): ");
            guess = int.TryParse(Console.ReadLine(), out guess) ? guess : 0;
            attempts++;
            
            Console.Clear();
            mole.TurnUp();
            if (guess != mole.Position)
            {
                Console.WriteLine("Miss! Try again.");
            }

            Thread.Sleep(1500);
        } while (guess != mole.Position);

        Console.WriteLine($"Congratulations! You found the mole in {attempts} attempts.");
    }
}
