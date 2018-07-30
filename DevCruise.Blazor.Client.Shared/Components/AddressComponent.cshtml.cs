using DevCruise.Blazor.Shared;
using Microsoft.AspNetCore.Blazor.Components;

namespace DevCruise.Blazor.Client.Shared.Components
{
    public class AddressBase : BlazorComponent
    {
        [Parameter]
        protected bool IsBilling { get; set; }

        [Parameter]
        protected CheckoutModel Model { get; set; }

        protected AddressModel AddressModel { get; set; }
        protected string Label { get; set; }

        protected override void OnInit()
        {
            AddressModel = IsBilling ? Model.Billing : Model.Shipping;
            var prefix = IsBilling ? "Billing" : "Shipping";
            Label = $"{prefix} Address";
        }
    }
}
