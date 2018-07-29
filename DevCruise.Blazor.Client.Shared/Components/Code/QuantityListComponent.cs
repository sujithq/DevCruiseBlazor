using System;
using DevCruise.Blazor.Shared;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;
//using BlazorRedux;

namespace DevCruise.Blazor.Client.Shared.Components.Code
{
    public class QuantityListComponent:BaseListComponent
    {
        [Parameter] protected Action<int> ParentCallback { get; set; }
        [Parameter] protected Action<BasketItem, int> ParentItemCallback { get; set; }

        protected void QuantityChanged(UIChangeEventArgs args)
        {
            ParentCallback?.Invoke(int.Parse(args.Value.ToString()));
        }

        protected void QuantityItemChanged(UIChangeEventArgs args)
        {
            ParentItemCallback?.Invoke(Item,int.Parse(args.Value.ToString()));
        }
    }


}
