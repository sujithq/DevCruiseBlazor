using BlazorRedux;

namespace DevCruise.Blazor.Client.Shared.Components.Code
{
    public class NavMenu : ReduxComponent<MyStateBase, IAction>
    {
        protected bool CollapseNavMenu { get; set; } = true;

        protected void ToggleNavMenu()
        {
            CollapseNavMenu = !CollapseNavMenu;
        }
    }
}
