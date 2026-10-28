using System;

namespace L08;

public class Game
{
  Field gameField;
  List<Buffalo> buffalos;

  public Game(int gridSize, int numberOfBuffalos)
  {
    gameField = new(gridSize);
    buffalos = new();

    for (int i = 0; i < numberOfBuffalos; i++)
    {
      buffalos.Add(new Buffalo(0, 0));
    }
  }

  public bool IsOver
  {
    get
    {
      int activeBuffalos = 0;
      foreach (Buffalo buffalo in buffalos)
      {
        if (buffalo.X == gameField.TargetX && buffalo.Y == gameField.TargetY)
        {
          return true;
        }
        if (buffalo.IsActive)
        {
          activeBuffalos++;
        }
      }

      if (activeBuffalos == 0)
      {
        return true;
      }

      return false;
    }
  }

  private void VisualizeElements()
  {
    gameField.Show();
    foreach (Buffalo buffalo in buffalos)
    {
      buffalo.Show();
    }

    // move below the field
    Console.SetCursorPosition(0, Console.CursorTop + gameField.RenderSize);
    Console.WriteLine();
  }

  private void Shoot()
  {
    int inputX, inputY;
    do
    {
      Console.Write($"Enter X coordinate to shoot (0-{gameField.TargetX}): ");
      inputX = int.Parse(Console.ReadLine() ?? "0");
      Console.Write($"Enter Y coordinate to shoot (0-{gameField.TargetY}): ");
      inputY = int.Parse(Console.ReadLine() ?? "0");
    } while (!gameField.AllowedPosition(inputX, inputY));

    foreach (Buffalo buffalo in buffalos)
    {
      if (buffalo.X == inputX && buffalo.Y == inputY)
      {
        buffalo.Deactivate();
      }
    }
  }

  public void Run()
  {
    while (!IsOver)
    {
      VisualizeElements();

      foreach (Buffalo buffalo in buffalos)
      {
        if (buffalo.IsActive)
        {
          buffalo.Move(gameField);
        }
      }

      Shoot();

      Console.Clear();
    }

    foreach (Buffalo buffalo in buffalos)
    {
      if (buffalo.X == gameField.TargetX && buffalo.Y == gameField.TargetY)
      {
        Console.WriteLine("A buffalo reached the target! Game over.");
        return;
      }
    }

    Console.WriteLine("All buffalos have been shot! You win!");
  }
}
