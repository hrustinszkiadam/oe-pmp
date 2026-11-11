using System;

namespace TheConsoleSlayer;

public class ConsoleRenderer
{
  Game game;

  public ConsoleRenderer(Game game)
  {
    this.game = game;
  }

  private void RenderSingleSprite(Position position, ConsoleSprite sprite)
  {
    if (position.X >= 0 && position.X < Console.WindowWidth &&
        position.Y >= 0 && position.Y < Console.WindowHeight)
    {
      Console.SetCursorPosition(position.X, position.Y);
      Console.BackgroundColor = sprite.Background;
      Console.ForegroundColor = sprite.Foreground;
      Console.Write(sprite.Glyph);
    }
  }

  private void RenderHUD()
  {
    Player player = game.Player;
    string hud = $" HP: {player.Health}/{player.MaxHealth} | Ammo: {player.Ammo}/{player.MaxAmmo} | BFG: {player.BFGCells}/{player.MaxBFGCells} | CP: {player.CombatPoints} ";

    Console.SetCursorPosition(0, Console.WindowHeight - 1);
    Console.BackgroundColor = ConsoleColor.DarkRed;
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write(hud);
  }

  public void RenderGame()
  {
    Console.CursorVisible = false;
    Console.ResetColor();
    Console.Clear();

    Player player = game.Player;

    foreach (GameItem item in game.Items)
    {
      if (Position.Distance(item.Position, player.Position) <= player.SightRange)
      {
        RenderSingleSprite(item.Position, item.Sprite);
      }
    }

    foreach (Demon demon in game.Demons)
    {
      if (Position.Distance(demon.Position, player.Position) <= player.SightRange)
      {
        RenderSingleSprite(demon.Position, demon.Sprite);
      }
    }

    RenderSingleSprite(player.Position, player.Sprite);

    RenderHUD();
  }
}
