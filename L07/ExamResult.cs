namespace L07;

public enum ExamGrade
{
  Elegtelen,
  Elegseges,
  Kozepes,
  Jo,
  Jeles
}

public class ExamResult
{
  private const string NeptunChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

  private string neptunCode = "";
  private int points;

  public ExamResult(string neptunCode, int points)
  {
    NeptunCode = neptunCode;
    Points = points;
  }

  public ExamResult()
  {
    Random random = new();
    char[] code = new char[6];
    code[0] = NeptunChars[random.Next(26)];
    for (int i = 1; i < code.Length; i++)
    {
      code[i] = NeptunChars[random.Next(NeptunChars.Length)];
    }

    NeptunCode = new string(code);
    Points = random.Next(0, 101);
  }

  public string NeptunCode
  {
    get => neptunCode;
    set
    {
      if (string.IsNullOrWhiteSpace(value) || value.Length != 6 || !char.IsLetter(value[0]) || !value.All(char.IsLetterOrDigit))
      {
        throw new ArgumentException("Neptun code must be exactly 6 alphanumeric characters, starting with a letter.");
      }
      neptunCode = value.ToUpper();
    }
  }

  public int Points
  {
    get => points;
    set
    {
      if (value < 0 || value > 100)
      {
        throw new ArgumentOutOfRangeException(nameof(value), "Points must be between 0 and 100.");
      }
      points = value;
    }
  }

  public bool Passed { get => points >= 50; }

  public ExamGrade Grade(int[] limits)
  {
    if (limits.Length != 5)
    {
      throw new ArgumentException("Grade limits must contain exactly 5 elements.");
    }

    for (int i = limits.Length - 1; i >= 0; i--)
    {
      if (points >= limits[i])
      {
        return (ExamGrade)i;
      }
    }
    return ExamGrade.Elegtelen;
  }
}
