using BlazorRedux;

namespace DevCruise.Blazor.Client.Shared.Components
{
    public class NavMenuBase : ReduxComponent<MyStateBase, IAction>
    {
        protected bool CollapseNavMenu { get; set; } = true;

        protected void ToggleNavMenu()
        {
            CollapseNavMenu = !CollapseNavMenu;
        }
    }
}
