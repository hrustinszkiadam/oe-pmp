using System;

namespace TheConsoleSlayer;

public class ConsoleSprite
{
  ConsoleColor background;
  ConsoleColor foreground;
  char glyph;

  public ConsoleSprite(ConsoleColor background, ConsoleColor foreground, char glyph)
  {
    this.background = background;
    this.foreground = foreground;
    this.glyph = glyph;
  }

  public ConsoleColor Background
  {
    get { return background; }
  }

  public ConsoleColor Foreground
  {
    get { return foreground; }
  }

  public char Glyph
  {
    get { return glyph; }
  }
}
