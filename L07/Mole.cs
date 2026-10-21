namespace L07;

public class Mole(int position = 0)
{
  private int position = position;

  public int Position { get => position; }

  public void TurnUp()
  {
    Console.SetCursorPosition(position, Console.CursorTop);
    Console.Write("🐳");
    Console.SetCursorPosition(0, Console.CursorTop + 1);
  }

  public void Hide(int minimum = 0, int maximum = 10)
  {
    position = new Random().Next(minimum, maximum + 1);
  }
}
