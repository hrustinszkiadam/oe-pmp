namespace L06;

class Book(string title, string author, int year, int pages)
{
    private string title = title;
    private string author = author;
    private int year = year;
    private int pages = pages;

    public string AllData()
    {
        return $"{author}: {title}, {year} ({pages} pages)";
    }
}
