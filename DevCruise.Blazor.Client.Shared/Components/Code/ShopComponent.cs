using System.Net.Http;
using System.Threading.Tasks;
using BlazorRedux;
using DevCruise.Blazor.Shared;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;

namespace DevCruise.Blazor.Client.Shared.Components.Code
{
    public class ShopComponent : ReduxComponent<MyStateBase,IAction>
    {
        [Parameter]
        protected string Source { get; set; }
        [Parameter]
        protected string Description { get; set; }

        protected string ImageSource => $"images/{Source}.jpg";

        protected string ApiSource => $"{State.ApiRoot}/api/product/{Source}";

        [Inject]
        private HttpClient Http { get; set; }

        protected Product[] Products { get; set; }

        protected override async Task OnInitAsync()
        {
            Products = await Http.GetJsonAsync<Product[]>(ApiSource);
        }
    }
}
