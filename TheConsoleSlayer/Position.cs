using System;

namespace TheConsoleSlayer;

public class Position
{
  int x;
  int y;

  public Position(int x, int y)
  {
    this.x = x;
    this.y = y;
  }

  public int X
  {
    get { return x; }
    set { x = value; }
  }

  public int Y
  {
    get { return y; }
    set { y = value; }
  }

  public static Position Add(Position p_1, Position p_2)
  {
    return new Position(p_1.X + p_2.X, p_1.Y + p_2.Y);
  }

  public static double Distance(Position p_1, Position p_2)
  {
    int dx = p_1.X - p_2.X;
    int dy = p_1.Y - p_2.Y;
    return Math.Sqrt(dx * dx + dy * dy);
  }
}
