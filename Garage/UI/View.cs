namespace Garage;

public abstract class View
{
    public abstract string Title { get; }
    public abstract View? Render();

    public virtual void RenderHeader()
    {
        Console.Clear();
        Console.WriteLine($"-- {Title} --");
    }
}