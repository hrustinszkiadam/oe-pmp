using System;

namespace TheConsoleSlayer;

public enum DemonType { Zombieman, Imp, Mancubus }

public enum DemonStateType { Idle, Move, Attack }

public class Demon
{
  Position position;
  ConsoleSprite sprite;
  DemonType type;
  DemonStateType state;
  double fillingRatio;
  int health;
  bool alive;
  int sightRange;
  int attackRange;
  int speed;

  public Demon(int x, int y, DemonType type)
  {
    position = new Position(x, y);
    this.type = type;
    alive = true;
    state = DemonStateType.Idle;
    sprite = new ConsoleSprite(ConsoleColor.Black, ConsoleColor.White, 'o');
    SetInitialProperties();
  }

  public Position Position
  {
    get { return position; }
    set { position = value; }
  }

  public ConsoleSprite Sprite
  {
    get { return sprite; }
  }

  public DemonType Type
  {
    get { return type; }
  }

  public DemonStateType State
  {
    get { return state; }
    set { state = value; }
  }

  public double FillingRatio
  {
    get { return fillingRatio; }
  }

  public int Health
  {
    get { return health; }
    set
    {
      if (value < 0)
      {
        health = 0;
      }
      else
      {
        health = value;
      }
    }
  }

  public bool Alive
  {
    get { return alive; }
  }

  public int SightRange
  {
    get { return sightRange; }
  }

  public int AttackRange
  {
    get { return attackRange; }
  }

  public int Speed
  {
    get { return speed; }
  }

  private void SetInitialProperties()
  {
    switch (type)
    {
      case DemonType.Zombieman:
        sprite = new ConsoleSprite(ConsoleColor.Black, ConsoleColor.White, 'o');
        fillingRatio = 0.4;
        health = 20;
        speed = 70;
        sightRange = 3;
        attackRange = 1;
        break;
      case DemonType.Imp:
        sprite = new ConsoleSprite(ConsoleColor.Black, ConsoleColor.Red, 'o');
        fillingRatio = 0.4;
        health = 60;
        speed = 93;
        sightRange = 6;
        attackRange = 3;
        break;
      case DemonType.Mancubus:
        sprite = new ConsoleSprite(ConsoleColor.Black, ConsoleColor.Red, 'O');
        fillingRatio = 0.9;
        health = 600;
        speed = 70;
        sightRange = 9;
        attackRange = 6;
        break;
      default:
        throw new ArgumentException("Invalid demon type");
    }
  }

  public void UpdateState(Player player)
  {
    double distance = Position.Distance(position, player.Position);

    if (distance < attackRange)
    {
      state = DemonStateType.Attack;
    }
    else if (distance < sightRange)
    {
      state = DemonStateType.Move;
    }
    else
    {
      state = DemonStateType.Idle;
    }
  }

  public void TakeDamage(int damage)
  {
    Health = Health - damage;
    if (Health == 0)
    {
      alive = false;
    }
  }
}
