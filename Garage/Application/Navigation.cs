using Garage.Views;

namespace Garage.Application;

public class Navigation(AppState appState)
{
    public View? CurrentView { get; set; }
    public View? PreviousView { get; set; }
    
    public void NavigateTo(View nextView, View? previousView = null)
    {
        if (previousView != null)
        {
            PreviousView = previousView;
            previousView.OnExit();   
        }
        
        CurrentView = nextView;
        CurrentView.Render();
        CurrentView.OnEnter();
    }

    public void GoBackToMainMenu(AppState state)
    {
        NavigateTo(new MainMenuView(state, this));
    }
    
    public void GoBack()
    {
        NavigateTo(PreviousView);
        PreviousView = null;
    }
    
    public void Quit()
    {
        CurrentView?.OnExit();
        CurrentView = null;
    }
}