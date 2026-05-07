namespace Garage;

public abstract class View
{
    public abstract string Title { get; }
    public abstract void Run();

    public virtual void RenderHeader()
    {
        Console.Clear();
        Console.WriteLine($"-- {Title} --");
    }
}