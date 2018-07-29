using System.Net.Http;
using System.Threading.Tasks;
using DevCruise.Blazor.Client.Shared.Pages.Code;
using DevCruise.Blazor.Shared;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.AspNetCore.Blazor.Services;

namespace DevCruise.Blazor.Client.Shared.Components.Code
{
    public class DetailComponent : BaseCallApi
    {
        [Parameter]
        private string Category { get; set; }

        [Parameter]
        private string Id { get; set; }

        protected Product Product { get; private set; }

        //private string Description { get; set; }

        [Inject]
        private IUriHelper UriHelper { get; set; }
        [Inject]
        private HttpClient Http { get; set; }

        protected override async Task OnInitAsync()
        {
            await RefreshType();
            //UriHelper.OnLocationChanged += OnLocationChanges;

        }

        //public override void Dispose()
        //{
        //    UriHelper.OnLocationChanged -= OnLocationChanges;
        //    base.Dispose();
        //}

        //private void OnLocationChanges(object sender, string location) => Task.Run(RefreshType);

        private async Task RefreshType()
        {
            //var uri = new Uri(UriHelper.GetAbsoluteUri());

            //Id = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(uri.Query).TryGetValue("id", out var id) ? id.First() : "";
            //Id = HttpUtility.UrlEncode(Id);

            Product = await Http.GetJsonAsync<Product>($"{State.ApiRoot}/api/product/{Category}/{Id}");
            //Description = HttpUtility.HtmlDecode(Product.Description);
        }

        protected void AddToBasket()
        {
            Dispatch(new Actions.AddBasketItemAction(new BasketItem { Title = Product.Title, Size = SelectedSize, Quantity = SelectedQuantity, Image = Product.Image, Price = Product.Price }));
        }

        private string SelectedSize { get; set; } = "XS";
        public void SizeChanged(string size)
        {
            SelectedSize = size;
        }
        private int SelectedQuantity { get; set; } = 1;
        public void QuantityChanged(int quantity)
        {
            SelectedQuantity = quantity;
        }
    }
}
