namespace L06;

class Rectangle(int width, int height, ConsoleColor color)
{
    private int width = width;
    private int height = height;
    private ConsoleColor color = color;

    private int Area()
    {
        return width * height;
    }

    public bool IsValid()
    {
        return Area() > 0;
    }

    public void Draw(int x, int y)
    {
        Console.BackgroundColor = color;
        for (int row = 0; row < height; row++)
        {
            Console.SetCursorPosition(x, y + row);
            Console.Write(new string(' ', width));
        }
        Console.ResetColor();
    }
}
