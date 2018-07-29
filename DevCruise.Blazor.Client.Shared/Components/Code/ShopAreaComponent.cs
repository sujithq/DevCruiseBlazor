using Microsoft.AspNetCore.Blazor.Components;

namespace DevCruise.Blazor.Client.Shared.Components.Code
{
    public class ShopAreaComponent : BlazorComponent
    {

        [Parameter]
        protected string Source { get; set; }

        [Parameter]
        protected string Description { get; set; }


        protected string ImageSource => $"images/{Source}.jpg";

        protected string ImageAltText => Description;

        protected string Title => Description;

        protected string HRef => Source;

        [Parameter]
        protected string ButtonClass { get; set; } = "btn btn-outline-dark rounded-0 mt-4";

        [Parameter]
        protected string CardBodyClass { get; set; } = "card-body";
    }
}
