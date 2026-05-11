namespace Garage;

public abstract class View
{
    public abstract string Title { get; }
    public abstract void Render();

    public virtual void OnEnter() {}

    public virtual void OnExit()
    {
        Console.Clear();
    }

    public virtual void RenderHeader()
    {
        Console.Clear();
        Console.WriteLine($"-- {Title} --");
    }
}