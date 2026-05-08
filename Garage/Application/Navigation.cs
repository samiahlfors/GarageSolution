namespace Garage.Application;

public class Navigation(AppState appState)
{
    public View? CurrentView { get; set; }
    public View? PreviousView { get; set; }
    
    public void NavigateTo(View nextView, View? previousView = null)
    {
        PreviousView = previousView;
        previousView?.OnExit();
        
        CurrentView = nextView;
        CurrentView.Render();
        CurrentView.OnEnter();
    }

    public void GoBack()
    {
        if (PreviousView == null) return;
        
        NavigateTo(PreviousView);
        PreviousView = null;
    }
    
    public void Quit()
    {
        CurrentView?.OnExit();
        CurrentView = null;
    }
}