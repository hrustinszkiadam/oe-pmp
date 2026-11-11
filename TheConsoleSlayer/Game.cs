using System;
using System.Diagnostics;

namespace TheConsoleSlayer;

public enum SoundEffectType { BFG, Door, ItemPickup, Pain, PlayerDeath, Shotgun }

public class Game
{
  Player player;
  bool exited;
  bool levelCompleted;
  List<GameItem> items;
  List<Demon> demons;

  ConsoleRenderer renderer;
  GameLogic logic;

  Stopwatch stopwatchLogic;
  Stopwatch stopwatchRenderer;

  dynamic? MusicPlayer;
  dynamic? SfxPlayer;

  Process? musicProcess;
  Process? sfxProcess;

  public Game()
  {
    player = new Player(0, 0);
    exited = false;
    levelCompleted = false;
    items = new List<GameItem>();
    demons = new List<Demon>();

    renderer = new ConsoleRenderer(this);
    logic = new GameLogic(this);

    stopwatchLogic = new Stopwatch();
    stopwatchRenderer = new Stopwatch();

    if (OperatingSystem.IsWindows())
    {
      Type? mediaPlayerType = Type.GetTypeFromProgID("WMPlayer.OCX");
      if (mediaPlayerType != null)
      {
        MusicPlayer = Activator.CreateInstance(mediaPlayerType);
        SfxPlayer = Activator.CreateInstance(mediaPlayerType);
      }
    }
  }

  public Player Player
  {
    get { return player; }
  }

  public bool Exited
  {
    get { return exited; }
    set { exited = value; }
  }

  public bool LevelCompleted
  {
    get { return levelCompleted; }
    set { levelCompleted = value; }
  }

  public List<GameItem> Items
  {
    get { return items; }
  }

  public List<Demon> Demons
  {
    get { return demons; }
  }

  public void LoadMapFromPlainText(string path)
  {
    string[] lines = File.ReadAllLines(path);

    string[] size = lines[0].Split(',');
    int rows = int.Parse(size[0]);
    int columns = int.Parse(size[1]);

    for (int y = 0; y < rows; y++)
    {
      string line = lines[y + 1];

      for (int x = 0; x < columns; x++)
      {
        switch (line[x])
        {
          case 'A':
            items.Add(new GameItem(x, y, ItemType.Ammo));
            break;
          case 'B':
            items.Add(new GameItem(x, y, ItemType.BFGCell));
            break;
          case 'D':
            items.Add(new GameItem(x, y, ItemType.Door));
            break;
          case 'E':
            items.Add(new GameItem(x, y, ItemType.LevelExit));
            break;
          case 'M':
            items.Add(new GameItem(x, y, ItemType.Medikit));
            break;
          case 'T':
            items.Add(new GameItem(x, y, ItemType.ToxicWaste));
            break;
          case 'W':
            items.Add(new GameItem(x, y, ItemType.Wall));
            break;
          case 'z':
            demons.Add(new Demon(x, y, DemonType.Zombieman));
            break;
          case 'i':
            demons.Add(new Demon(x, y, DemonType.Imp));
            break;
          case 'm':
            demons.Add(new Demon(x, y, DemonType.Mancubus));
            break;
          case 'p':
            player = new Player(x, y);
            break;
          default:
            break;
        }
      }
    }
  }

  public void PlaySoundEffect(SoundEffectType effectType)
  {
    string path = "../../../assets/sounds/";
    switch (effectType)
    {
      case SoundEffectType.BFG:
        path += "bfg.mp3";
        break;
      case SoundEffectType.Door:
        path += "door.mp3";
        break;
      case SoundEffectType.ItemPickup:
        path += "item_pickup.mp3";
        break;
      case SoundEffectType.Pain:
        path += "pain.mp3";
        break;
      case SoundEffectType.PlayerDeath:
        path += "player_death.mp3";
        break;
      case SoundEffectType.Shotgun:
        path += "shotgun.mp3";
        break;
      default:
        return;
    }

    if (SfxPlayer != null)
    {
      SfxPlayer.URL = path;
      SfxPlayer.controls.play();
    }
    else if (OperatingSystem.IsMacOS())
    {
      StopPlayer(sfxProcess);
      sfxProcess = Process.Start("afplay", path);
    }
  }

  public void PlayMusic(string path)
  {
    if (MusicPlayer != null)
    {
      MusicPlayer.URL = path;
      MusicPlayer.controls.play();
    }
    else if (OperatingSystem.IsMacOS())
    {
      StopPlayer(musicProcess);
      musicProcess = Process.Start("afplay", path);
    }
  }

  private void StopPlayer(Process? soundPlayer)
  {
    if (soundPlayer != null && !soundPlayer.HasExited)
    {
      soundPlayer.Kill();
    }
  }

  private void UserAction()
  {
    if (Console.KeyAvailable)
    {
      ConsoleKeyInfo pressed = Console.ReadKey(true);
      switch (pressed.Key)
      {
        case ConsoleKey.Escape:
          Exited = true;
          break;
        case ConsoleKey.UpArrow:
          logic.Move(player, Position.Add(player.Position, new Position(0, -1)));
          break;
        case ConsoleKey.DownArrow:
          logic.Move(player, Position.Add(player.Position, new Position(0, 1)));
          break;
        case ConsoleKey.LeftArrow:
          logic.Move(player, Position.Add(player.Position, new Position(-1, 0)));
          break;
        case ConsoleKey.RightArrow:
          logic.Move(player, Position.Add(player.Position, new Position(1, 0)));
          break;
        case ConsoleKey.D:
          logic.PlayerDirectInteractionLogic();
          break;
        case ConsoleKey.A:
          logic.PlayerAttackLogic();
          break;
        case ConsoleKey.S:
          logic.PlayerBFGAttackLogic();
          break;
        default:
          break;
      }

      logic.PlayerIndirectInteractionLogic();
    }
  }

  public void Run()
  {
    PlayMusic("../../../assets/sounds/doom_music.mp3");

    stopwatchLogic.Start();
    stopwatchRenderer.Start();

    while (!Exited && player.Alive)
    {
      if (stopwatchLogic.ElapsedMilliseconds > 500)
      {
        logic.UpdateGameState(stopwatchLogic.ElapsedMilliseconds);
        stopwatchLogic.Restart();
      }
      if (stopwatchRenderer.ElapsedMilliseconds > 25)
      {
        renderer.RenderGame();
        stopwatchRenderer.Restart();
      }

      UserAction();

      Thread.Sleep(25);
    }

    Console.ResetColor();
    Console.Clear();

    if (!player.Alive)
    {
      PlaySoundEffect(SoundEffectType.PlayerDeath);
      Console.WriteLine("You died.");
    }
    else if (levelCompleted)
    {
      PlayMusic("../../../assets/sounds/level_complete.mp3");
      Console.WriteLine("Level completed!");
    }

    Console.WriteLine("Press Enter to quit.");
    Console.ReadLine();

    StopPlayer(musicProcess);
    StopPlayer(sfxProcess);
  }
}
