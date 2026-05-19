using Garage.UI.Views;

namespace Garage.Application;

public class Navigation
{
    private Stack<View> History { get; } = new();
    public View? CurrentView => History.Count > 0 ? History.Peek() : null;
    
    public void NavigateTo(View nextView)
    {
        // Call OnExit on current view
        if (History.Count > 0) History.Peek().OnExit();
        
        // Push next view into history
        History.Push(nextView);
        
        // Render next view
        nextView.Render();
        nextView.OnEnter();
    }

    public void GoBackToMainMenu(AppState state)
    {
        History.Clear();
        NavigateTo(new MainMenuView(state, this));
    }
    
    public void GoBack()
    {
        History.Pop();
        
        var nextView = History.Peek();
        nextView.Render();
        nextView.OnEnter();
    }
    
    public void Quit()
    {
        History.Clear();
    }
}