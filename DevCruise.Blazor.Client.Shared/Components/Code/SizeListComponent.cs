using System;
using DevCruise.Blazor.Shared;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;
//using BlazorRedux;

namespace DevCruise.Blazor.Client.Shared.Components.Code
{

    public class SizeListComponent:BaseListComponent
    {
        [Parameter] protected Action<string> ParentCallback { get; set; }
        [Parameter] protected Action<BasketItem, string> ParentItemCallback { get; set; }

        protected void SizeChanged(UIChangeEventArgs args)
        {
            ParentCallback?.Invoke(args.Value.ToString());
        }
        protected void SizeItemChanged(UIChangeEventArgs args)
        {
            ParentItemCallback?.Invoke(Item, args.Value.ToString());
        }
    }


}
