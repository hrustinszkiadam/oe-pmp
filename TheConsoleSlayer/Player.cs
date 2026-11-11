using System;

namespace TheConsoleSlayer;

public class Player
{
  Position position;
  ConsoleSprite sprite;
  double fillingRatio;
  int health;
  int ammo;
  int bfgCells;
  bool alive;
  int combatPoints;
  int sightRange;

  public Player(int x, int y)
  {
    position = new Position(x, y);
    sprite = new ConsoleSprite(ConsoleColor.Black, ConsoleColor.Green, 'O');
    fillingRatio = 0.4;
    health = 100;
    ammo = 5;
    bfgCells = 0;
    alive = true;
    combatPoints = 0;
    sightRange = 8;
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

  public double FillingRatio
  {
    get { return fillingRatio; }
  }

  public bool Alive
  {
    get { return alive; }
  }

  public int CombatPoints
  {
    get { return combatPoints; }
  }

  public int SightRange
  {
    get { return sightRange; }
  }

  public int MaxHealth
  {
    get { return 100 + combatPoints / 10; }
  }

  public int MaxAmmo
  {
    get { return 10 + combatPoints / 50; }
  }

  public int MaxBFGCells
  {
    get { return 3; }
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
      else if (value > MaxHealth)
      {
        health = MaxHealth;
      }
      else
      {
        health = value;
      }
    }
  }

  public int Ammo
  {
    get { return ammo; }
    set
    {
      if (value < 0)
      {
        ammo = 0;
      }
      else if (value > MaxAmmo)
      {
        ammo = MaxAmmo;
      }
      else
      {
        ammo = value;
      }
    }
  }

  public int BFGCells
  {
    get { return bfgCells; }
    set
    {
      if (value < 0)
      {
        bfgCells = 0;
      }
      else if (value > MaxBFGCells)
      {
        bfgCells = MaxBFGCells;
      }
      else
      {
        bfgCells = value;
      }
    }
  }

  public void Shoot()
  {
    Ammo = Ammo - 1;
  }

  public void ShootBFG()
  {
    BFGCells = BFGCells - 1;
  }

  public void AddCombatPoints(int points)
  {
    combatPoints += points;
  }

  public void TakeDamage(int damage)
  {
    Health = Health - damage;
    if (Health == 0)
    {
      alive = false;
    }
  }

  public void PickUpAmmo(int amount)
  {
    Ammo = Ammo + amount;
  }

  public void PickUpHealth(int amount)
  {
    Health = Health + amount;
  }

  public void PickUpBFGCell(int amount)
  {
    BFGCells = BFGCells + amount;
  }
}
