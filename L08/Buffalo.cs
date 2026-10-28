using System;

namespace L08;

public class Buffalo(int x, int y)
{
  public int X { get; private set; } = x;
  public int Y { get; private set; } = y;
  public bool IsActive { get; private set; } = true;

  public void Move(Field field)
  {
    Random random = new();
    int dx, dy;

    do
    {
      dx = random.Next(0, 2);
      dy = random.Next(0, 2);
    } while (
      (dx == 0 && dy == 0) || !field.AllowedPosition(X + dx, Y + dy)
    );

    X += dx;
    Y += dy;
  }

  public void Deactivate()
  {
    IsActive = false;
  }

  public void Show()
  {
    if (IsActive) {
      Console.ForegroundColor = ConsoleColor.Green;
    } else {
      Console.ForegroundColor = ConsoleColor.Red;
    }

    int cursorLeft = Console.CursorLeft;
    int cursorTop = Console.CursorTop;

    // skip the 1 char wide left border, then land in the middle of the 3 char wide cell
    int column = 3 * X + 2;
    // skip the top border row
    int row = Y + 1;
    Console.SetCursorPosition(cursorLeft + column, cursorTop + row);
    Console.Write("B");
    Console.ResetColor();

    Console.SetCursorPosition(cursorLeft, cursorTop);
  }
}
