using BlazorRedux;

namespace DevCruise.Blazor.Client.Shared.Pages.Code
{
    public abstract class BaseCallApi:ReduxComponent<MyStateBase,IAction>
    {
        protected string RootApi { get; set; } = "";
    }
}
