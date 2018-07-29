using System;
using System.Linq;
using BlazorRedux;
using DevCruise.Blazor.Shared;
using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.AspNetCore.Blazor.Services;

namespace DevCruise.Blazor.Client.Shared.Components.Code
{
    public class CheckoutComponent : ReduxComponent<MyState, IAction>
    {
        [Inject]
        private IUriHelper UriHelper { get; set; }
        protected CheckoutModel Model { get; set; }

        protected bool HasErrrors
        {
            get
            {
                var modelErrs = Model.GetErrors(null);
                var shippingErrs = Model.Shipping.GetErrors(null);
                var billingErrs = Model.Billing.GetErrors(null);

                Console.WriteLine("Model Errors" + string.Join("|", modelErrs.Cast<string>()));
                Console.WriteLine("Shipping Errors" + string.Join("|", shippingErrs.Cast<string>()));
                Console.WriteLine("Billing Errors" + string.Join("|", billingErrs.Cast<string>()));

                var hasErrors = Model.HasErrors || Model.Shipping.HasErrors;

                if (Model.UseOtherBilling)
                {
                    hasErrors = hasErrors || Model.Billing.HasErrors;
                }
                return hasErrors;
            }
        }

        protected override void OnInit()
        {
            Model = new CheckoutModel(State.Checkout);
        }

        public void PlaceOrder()
        {
            Dispatch(new Actions.PlaceOrderAction(new CheckoutState
            {
                Email = Model.Email,
                Phone = Model.Phone,
                Shipping = new AddressState
                {
                    AddressLine = Model.Shipping.AddressLine,
                    City = Model.Shipping.City,
                    Country = Model.Shipping.Country,
                    ZipPostalCode = Model.Shipping.ZipPostalCode,
                    StateProvince = Model.Shipping.StateProvince
                },
                UseOtherBilling = Model.UseOtherBilling,
                Billing = new AddressState
                {
                    AddressLine = Model.Billing.AddressLine,
                    City = Model.Billing.City,
                    Country = Model.Billing.Country,
                    ZipPostalCode = Model.Billing.ZipPostalCode,
                    StateProvince = Model.Billing.StateProvince
                },
                CcName = Model.CcName,
                CcNumber = Model.CcNumber,
                Month = Model.Month,
                Year = Model.Year,
                CVC = Model.CVC
            }));

            Dispatch(new Actions.ClearBasketAction());
            UriHelper.NavigateTo("/checkout/success");
        }
    }
}
