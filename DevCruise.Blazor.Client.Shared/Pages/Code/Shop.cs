using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorRedux;
using Microsoft.AspNetCore.Blazor.Components;

namespace DevCruise.Blazor.Client.Shared.Pages.Code
{
    public class Shop:BlazorComponent
    {
        [Parameter]
        protected string Source { get; set; }

        [Parameter]
        protected string Description { get; set; }

    }
}
