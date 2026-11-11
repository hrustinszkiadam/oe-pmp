namespace TheConsoleSlayer;

class Program
{
    static void Main(string[] args)
    {
        Game game = new Game();
        game.LoadMapFromPlainText("../../../assets/maps/demo_map.txt");
        // game.LoadMapFromPlainText("../../../assets/maps/pmp_arena.txt");
        game.Run();
    }
}
