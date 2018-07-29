using BlazorRedux;

namespace DevCruise.Blazor.Client.Shared.Components.Code
{
    public class NavMenu : ReduxComponent<MyState, IAction>
    {
        protected bool CollapseNavMenu { get; set; } = true;

        protected void ToggleNavMenu()
        {
            CollapseNavMenu = !CollapseNavMenu;
        }
    }
}
