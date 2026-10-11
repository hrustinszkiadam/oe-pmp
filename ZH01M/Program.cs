namespace ZH01M;

class Program
{
    static void Main(string[] args)
    {
        // 1.
        string[] genresRaw = File.ReadAllLines("../../../assets/genre.txt")[0].Split(',');

        List<string> genres = new List<string>();

        foreach (string rawGenre in genresRaw)
        {
            genres.Add(rawGenre.Split('=')[0]);
        }

        // 2.
        List<string> Titles = new List<string>();
        List<string> Genres = new List<string>();
        List<string> Publishers = new List<string>();
        List<DateTime> ReleaseDates = new List<DateTime>();
        List<DateTime> OriginalReleaseDates = new List<DateTime>();

        string[] gameDataLines = File.ReadAllLines("../../../assets/games_dataset.csv");

        for (int i = 1; i < gameDataLines.Length; i++)
        {
            string[] parts = gameDataLines[i].Split(';');

            Titles.Add(parts[0]);
            Genres.Add(genres[int.Parse(parts[1])]);
            Publishers.Add(parts[2]);
            ReleaseDates.Add(DateTime.Parse(parts[3]));
            OriginalReleaseDates.Add(DateTime.Parse(parts[4]));
        }

        // 3.
        Console.Write("Adja meg egy kiadó nevét: ");
        string kiado = Console.ReadLine();
        int kiadoCount = 0;

        foreach (string publisher in Publishers)
        {
            if(publisher.Equals(kiado, StringComparison.CurrentCultureIgnoreCase))
            {
                kiadoCount++;
            }
        }

        Console.WriteLine("A megadott kiadó által piacra dobott játékok száma: " + kiadoCount);

        //4.
        Console.WriteLine("A megjelenés évében elérhetők voltak a platformon:");

        for (int i = 0; i < Titles.Count; i++)
        {
            if(ReleaseDates[i].Year == OriginalReleaseDates[i].Year)
            {
                Console.WriteLine($"\t{Titles[i]}, {Genres[i]} ({OriginalReleaseDates[i]:yyyy.MM.dd.})");
            }
        }

        //5.

        Console.WriteLine("Játékok száma műfajonként:");
        foreach (string genre in genres)
        {
            int genreCount = 0;

            foreach (string Genre in Genres)
            {
                if(Genre == genre)
                {
                    genreCount++;
                }
            }

            Console.WriteLine($"\t{genre}: {genreCount}");
        }


        Console.ReadLine();
    }
}
