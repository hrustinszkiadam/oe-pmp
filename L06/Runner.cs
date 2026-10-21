namespace L06;

class Runner(string name, int number, double speed)
{
    private string name = name;
    private int number = number;
    private double speed = speed;
    private double distance = 0;

    public void RefreshDistance(int seconds)
    {
        distance += speed * seconds;
    }

    public void Show()
    {
        Console.SetCursorPosition((int)distance, number);
        Console.Write(name[0]);
    }

    public double GetDistance()
    {
        return distance;
    }
}
