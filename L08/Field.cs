using System;

namespace L08;

public class Field(int gridSize)
{
  int gridSize = gridSize;

  public int Size { get => gridSize; }
  public int TargetX { get => gridSize - 1; }
  public int TargetY { get => gridSize - 1; }
  
  public int RenderSize { get => gridSize + 2; }

  public bool AllowedPosition(int x, int y)
  {
    return x >= 0 && x <= TargetX && y >= 0 && y <= TargetY;
  }

  public void Show()
  {
    for (int i = 0; i < RenderSize; i++)
    {
      Console.WriteLine();
    }
    int cursorLeft = Console.CursorLeft;
    int cursorTop = Console.CursorTop - RenderSize;
    Console.SetCursorPosition(cursorLeft, cursorTop);

    for (int y = 0; y < RenderSize; y++)
    {
      for (int x = 0; x < RenderSize; x++)
      {
        if (x == 0 || x == RenderSize - 1)
        {
          Console.Write("|");
        } else if (y == 0 || y == RenderSize - 1)
        {
          Console.Write(" — ");
        } else
        {
          Console.Write("   ");
        }
      }
      Console.WriteLine();
    }

    Console.SetCursorPosition(cursorLeft, cursorTop);
  }
}
