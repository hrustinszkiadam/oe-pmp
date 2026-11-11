using System;

namespace TheConsoleSlayer;

public enum ItemType { Ammo, BFGCell, Door, LevelExit, Medikit, ToxicWaste, Wall }

public class GameItem
{
  Position position;
  ConsoleSprite sprite;
  ItemType type;
  double fillingRatio;
  bool available;

  public GameItem(int x, int y, ItemType type)
  {
    position = new Position(x, y);
    this.type = type;
    available = true;
    sprite = new ConsoleSprite(ConsoleColor.Black, ConsoleColor.White, ' ');
    SetInitialProperties();
  }

  public Position Position
  {
    get { return position; }
  }

  public ConsoleSprite Sprite
  {
    get { return sprite; }
  }

  public ItemType Type
  {
    get { return type; }
  }

  public double FillingRatio
  {
    get { return fillingRatio; }
  }

  public bool Available
  {
    get { return available; }
  }

  private void SetInitialProperties()
  {
    switch (type)
    {
      case ItemType.Ammo:
        sprite = new ConsoleSprite(ConsoleColor.Red, ConsoleColor.Yellow, 'A');
        fillingRatio = 0.0;
        break;
      case ItemType.BFGCell:
        sprite = new ConsoleSprite(ConsoleColor.Green, ConsoleColor.White, 'B');
        fillingRatio = 0.0;
        break;
      case ItemType.Door:
        sprite = new ConsoleSprite(ConsoleColor.Gray, ConsoleColor.Yellow, '/');
        fillingRatio = 1.0;
        break;
      case ItemType.LevelExit:
        sprite = new ConsoleSprite(ConsoleColor.Blue, ConsoleColor.White, 'E');
        fillingRatio = 1.0;
        break;
      case ItemType.Medikit:
        sprite = new ConsoleSprite(ConsoleColor.Gray, ConsoleColor.Red, '+');
        fillingRatio = 0.0;
        break;
      case ItemType.ToxicWaste:
        sprite = new ConsoleSprite(ConsoleColor.DarkGreen, ConsoleColor.Green, ':');
        fillingRatio = 0.0;
        break;
      case ItemType.Wall:
        sprite = new ConsoleSprite(ConsoleColor.Gray, ConsoleColor.Gray, ' ');
        fillingRatio = 1.0;
        break;
      default:
        throw new ArgumentException("Invalid item type");
    }
  }

  public void Interact()
  {
    if (type == ItemType.Ammo || type == ItemType.BFGCell || type == ItemType.Medikit)
    {
      available = false;
    }
    else if (type == ItemType.Door)
    {
      if (fillingRatio == 1.0)
      {
        fillingRatio = 0.0;
        sprite = new ConsoleSprite(ConsoleColor.Gray, ConsoleColor.Red, '/');
      }
      else
      {
        fillingRatio = 1.0;
        sprite = new ConsoleSprite(ConsoleColor.Gray, ConsoleColor.Yellow, '/');
      }
    }
  }
}
