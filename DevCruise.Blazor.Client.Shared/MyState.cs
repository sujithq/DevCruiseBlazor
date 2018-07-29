using System;
using System.Collections.Generic;
using BlazorRedux;
using DevCruise.Blazor.Shared;

namespace DevCruise.Blazor.Client.Shared
{
    public class MyState
    {
        public MyState()
        {
            Basket = new List<BasketItem>();
            Checkout = new CheckoutState();
        }
        public string Location { get; set; }
        public List<BasketItem> Basket { get; set; }
        public bool CollapseNavMenu { get; set; }
        public CheckoutState Checkout { get; set; }
    }

    public static class Reducers
    {
        public static MyState RootReducer(MyState state, IAction action)
        {
            if (state == null)
                throw new ArgumentNullException(nameof(state));

            return new MyState
            {
                Location = Location.Reducer(state.Location, action),
                Basket = BasketReducer(state.Basket, action),
                CollapseNavMenu = CollapseNavMenuReducer(state.CollapseNavMenu, action),
                Checkout = CheckoutReducer(state.Checkout, action)
            };
        }

        private static List<BasketItem> BasketReducer(List<BasketItem> basket, IAction action)
        {
            switch (action)
            {
                case Actions.ClearBasketAction _:
                    basket.Clear();
                    return basket;
                case Actions.AddBasketItemAction a:
                    basket.Add(a.Value);
                    return basket;
                case Actions.RemoveBasketItemAction a:
                    basket.Remove(a.Value);
                    return basket;
                case Actions.UpdateBasketItemSizeAction a:

                    var indexs = basket.IndexOf(a.Value);

                    basket[indexs].Size = a.Size;

                    return basket;

                case Actions.UpdateBasketItemQuantityAction a:

                    var indexq = basket.IndexOf(a.Value);

                    basket[indexq].Quantity = a.Quantity;

                    return basket;
                default:
                    return basket;
            }
        }

        private static bool CollapseNavMenuReducer(bool collapseNavMenu, IAction action)
        {
            switch (action)
            {
                case Actions.ToggleNavMenuAction _:
                    collapseNavMenu = !collapseNavMenu;
                    return collapseNavMenu;

                default:
                    return collapseNavMenu;
            }
        }

        private static CheckoutState CheckoutReducer(CheckoutState checkout, IAction action)
        {
            switch (action)
            {
                case Actions.PlaceOrderAction a:
                    return a.Value;

                default:
                    return checkout;
            }

        }
    }
}
