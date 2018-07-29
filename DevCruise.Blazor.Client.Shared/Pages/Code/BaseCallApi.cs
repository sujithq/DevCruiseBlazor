using BlazorRedux;

namespace DevCruise.Blazor.Client.Shared.Pages.Code
{
    public abstract class BaseCallApi:ReduxComponent<MyState,IAction>
    {
        protected string RootApi { get; set; } = "";
    }
}
