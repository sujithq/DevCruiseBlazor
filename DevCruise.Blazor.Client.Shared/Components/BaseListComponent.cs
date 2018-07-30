//using BlazorRedux;

using DevCruise.Blazor.Shared;
using Microsoft.AspNetCore.Blazor.Components;

namespace DevCruise.Blazor.Client.Shared.Components
{
    public class BaseListComponent:BlazorComponent// ReduxComponent<MyState, IAction>
    {
        [Parameter]
        protected string Label { get; set; } = null;

        [Parameter]
        protected bool ShowLabel { get; set; } = false;

        [Parameter]
        protected PageEnum Page { get; set; } = PageEnum.Detail;

        [Parameter]
        protected BasketItem Item { get; set; } = null;

        [Parameter]
        protected string FormClass { get; set; } = "form-group row";


    }


}
