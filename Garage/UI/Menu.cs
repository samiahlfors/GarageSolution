namespace Garage;

public class Menu
{
    private string Title { get; }
    private List<string> Options { get; }
    
    public Menu(string title, List<string> options)
    {
        Title = title;
        Options = options;
    }

    public void Show()
    {
        Console.WriteLine(Title);
        foreach (var option in Options)
        {
            Console.WriteLine(option);
        }
    }
}