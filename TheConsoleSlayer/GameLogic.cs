using System;

namespace TheConsoleSlayer;

public class GameLogic
{
  static Random RNG = new Random();

  Game game;

  public GameLogic(Game game)
  {
    this.game = game;
  }

  public void UpdateGameState(long elapsedTime)
  {
    UpdateDemons(elapsedTime);
    CleanUpGameItems();
    CleanUpDemons();
  }

  private void CleanUpGameItems()
  {
    List<GameItem> toRemove = new List<GameItem>();
    foreach (GameItem item in game.Items)
    {
      if (!item.Available)
      {
        toRemove.Add(item);
      }
    }

    foreach (GameItem item in toRemove)
    {
      game.Items.Remove(item);
    }
  }

  private void CleanUpDemons()
  {
    List<Demon> toRemove = new List<Demon>();
    foreach (Demon demon in game.Demons)
    {
      if (!demon.Alive)
      {
        toRemove.Add(demon);
      }
    }

    foreach (Demon demon in toRemove)
    {
      game.Demons.Remove(demon);
    }
  }

  private List<GameItem> GetGameItemsWithinDistance(Position position, double distance)
  {
    List<GameItem> result = new List<GameItem>();
    foreach (GameItem item in game.Items)
    {
      if (Position.Distance(item.Position, position) <= distance)
      {
        result.Add(item);
      }
    }
    return result;
  }

  private List<Demon> GetDemonsWithinDistance(Position position, double distance)
  {
    List<Demon> result = new List<Demon>();
    foreach (Demon demon in game.Demons)
    {
      if (Position.Distance(demon.Position, position) <= distance)
      {
        result.Add(demon);
      }
    }
    return result;
  }

  private double GetTotalFillingRatio(Position position)
  {
    double sum = 0;

    foreach (GameItem item in GetGameItemsWithinDistance(position, 0))
    {
      sum += item.FillingRatio;
    }

    foreach (Demon demon in GetDemonsWithinDistance(position, 0))
    {
      sum += demon.FillingRatio;
    }

    return sum;
  }

  public void Move(Player player, Position target)
  {
    if (GetTotalFillingRatio(target) + player.FillingRatio <= 1.0)
    {
      player.Position = target;
    }
  }

  public void Move(Demon demon, Position target, long elapsedTime)
  {
    double pMove = demon.Speed / 100.0 * (elapsedTime / 1000.0);

    if (RNG.NextDouble() < pMove)
    {
      if (GetTotalFillingRatio(target) + demon.FillingRatio <= 1.0)
      {
        demon.Position = target;
      }
    }
  }

  private void DemonMoveLogic(Demon demon, long elapsedTime)
  {
    int x = demon.Position.X + RNG.Next(-1, 2);
    int y = demon.Position.Y + RNG.Next(-1, 2);
    Position targetPosition = new Position(x, y);

    Move(demon, targetPosition, elapsedTime);
  }

  private void DemonAttackLogic(Demon demon, long elapsedTime)
  {
    double distance = Position.Distance(demon.Position, game.Player.Position);

    int min = 0;
    int max = 0;
    switch (demon.Type)
    {
      case DemonType.Zombieman:
        min = 3;
        max = 15;
        break;
      case DemonType.Imp:
        min = 3;
        max = 24;
        break;
      case DemonType.Mancubus:
        min = 8;
        max = 64;
        break;
      default:
        throw new ArgumentException("Invalid demon type");
    }

    double damage = 2 * RNG.Next(min, max + 1) / (1 + distance);
    damage = damage * (elapsedTime / 1000.0);

    if ((int)damage > 0)
    {
      game.Player.TakeDamage((int)damage);
      game.PlaySoundEffect(SoundEffectType.Pain);
    }
  }

  private void DemonIndirectInteractionLogic(Demon demon)
  {
    foreach (GameItem item in GetGameItemsWithinDistance(demon.Position, 0))
    {
      if (item.Type == ItemType.ToxicWaste)
      {
        demon.TakeDamage(5);
      }
    }
  }

  private void UpdateDemons(long elapsedTime)
  {
    foreach (Demon demon in game.Demons)
    {
      demon.UpdateState(game.Player);

      if (demon.State == DemonStateType.Move)
      {
        DemonMoveLogic(demon, elapsedTime);
      }
      else if (demon.State == DemonStateType.Attack)
      {
        DemonAttackLogic(demon, elapsedTime);
      }

      DemonIndirectInteractionLogic(demon);
    }
  }

  public void PlayerAttackLogic()
  {
    Player player = game.Player;

    if (player.Ammo > 0)
    {
      player.Shoot();
      game.PlaySoundEffect(SoundEffectType.Shotgun);

      foreach (Demon demon in GetDemonsWithinDistance(player.Position, player.SightRange))
      {
        double distance = Position.Distance(demon.Position, player.Position);
        int damage = 2 * RNG.Next(35, 106) / (1 + (int)distance);
        demon.TakeDamage(damage);

        if (!demon.Alive)
        {
          switch (demon.Type)
          {
            case DemonType.Zombieman:
              player.AddCombatPoints(1);
              break;
            case DemonType.Imp:
              player.AddCombatPoints(3);
              break;
            case DemonType.Mancubus:
              player.AddCombatPoints(10);
              break;
            default:
              throw new ArgumentException("Invalid demon type");
          }
        }
      }
    }
  }

  public void PlayerBFGAttackLogic()
  {
    Player player = game.Player;

    if (player.BFGCells > 0)
    {
      player.ShootBFG();
      game.PlaySoundEffect(SoundEffectType.BFG);

      foreach (Demon demon in GetDemonsWithinDistance(player.Position, player.SightRange))
      {
        demon.TakeDamage(RNG.Next(100, 801));

        if (!demon.Alive)
        {
          player.AddCombatPoints(1);
        }
      }
    }
  }

  public void PlayerDirectInteractionLogic()
  {
    foreach (GameItem item in GetGameItemsWithinDistance(game.Player.Position, 1))
    {
      if (item.Type == ItemType.Door)
      {
        item.Interact();
        game.PlaySoundEffect(SoundEffectType.Door);
      }
      else if (item.Type == ItemType.LevelExit)
      {
        item.Interact();
        game.LevelCompleted = true;
        game.Exited = true;
      }
    }
  }

  public void PlayerIndirectInteractionLogic()
  {
    Player player = game.Player;

    foreach (GameItem item in GetGameItemsWithinDistance(player.Position, 0))
    {
      switch (item.Type)
      {
        case ItemType.Ammo:
          item.Interact();
          player.PickUpAmmo(5);
          game.PlaySoundEffect(SoundEffectType.ItemPickup);
          break;
        case ItemType.Medikit:
          item.Interact();
          player.PickUpHealth(25);
          game.PlaySoundEffect(SoundEffectType.ItemPickup);
          break;
        case ItemType.BFGCell:
          if (player.BFGCells < player.MaxBFGCells)
          {
            item.Interact();
            player.PickUpBFGCell(1);
            game.PlaySoundEffect(SoundEffectType.ItemPickup);
          }
          break;
        case ItemType.ToxicWaste:
          item.Interact();
          player.TakeDamage(5);
          game.PlaySoundEffect(SoundEffectType.Pain);
          break;
        default:
          break;
      }
    }
  }
}
