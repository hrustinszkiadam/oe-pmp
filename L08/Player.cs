using System;

namespace L08;

public enum Position
{
  Goalkeeper,
  Defender,
  Winger,
  Forward
}

public class Player(string name, Position position)
{
  string name = name;
  Position position = position;

  public Position Position
  {
    get => position;
  }

  public string Name
  {
    get => name;
  }

  public override string ToString()
  {
    return $"{name} — {position}";
  }
}
