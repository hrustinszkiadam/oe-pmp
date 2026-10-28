namespace L08;

class Program
{
    static Random random = new();

    static void Main(string[] args)
    {
        #region Task 1
        Team team = CreateTeam(RandomPlayers(12));
        Console.WriteLine(team);
        #endregion

        #region Task 2
        Game game = new(10, 5);
        game.Run();
        #endregion

        Console.ReadLine();
    }

    static Team CreateTeam(Player[] available)
    {
        Team team = new();

        while (!team.IsFull)
        {
            Console.Clear();
            Console.WriteLine($"Team ({team.NumberOfPlayers}/5):");
            Console.WriteLine(team);

            Console.WriteLine("Available players:");
            for (int i = 0; i < available.Length; i++)
            {
                if (!team.IsIncluded(available[i]))
                {
                    Console.WriteLine($"{i + 1}. {available[i]}");
                }
            }

            Console.Write("\nChoose a player (empty to quit): ");
            string input = Console.ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(input))
            {
                break;
            }

            try
            {
                team.Include(available[int.Parse(input) - 1]);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Could not add player ({e.Message}). Press Enter to continue.");
                Console.ReadLine();
            }
        }

        Console.Clear();
        Console.WriteLine(team.IsFull ? "The team is complete" : "The team is incomplete");

        return team;
    }

    static Player[] RandomPlayers(int count)
    {
        string[] names = { "Bence", "Dávid", "Gergő", "Máté", "Levente", "Ádám", "Péter", "Balázs", "Tamás", "Zoltán", "Krisztián", "Norbert" };
        Position[] positions = Enum.GetValues<Position>();

        Player[] players = new Player[count];
        for (int i = 0; i < count; i++)
        {
            string name = names[random.Next(names.Length)];
            Position position = positions[random.Next(positions.Length)];
            players[i] = new Player(name, position);
        }
        return players;
    }
}
