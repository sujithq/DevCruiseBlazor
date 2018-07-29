using BlazorRedux;
using DevCruise.Blazor.Shared;

namespace DevCruise.Blazor.Client.Shared
{
    public class Actions
    {
        public class AddBasketItemAction : IAction
        {
            public AddBasketItemAction(BasketItem value)
            {
                Value = value;
            }

            public BasketItem Value { get; set; }
        }

        public class UpdateBasketItemSizeAction : IAction
        {
            public UpdateBasketItemSizeAction(BasketItem value, string size)
            {
                Value = value;
                Size = size;
            }

            public BasketItem Value { get; set; }
            public string Size { get; set; }
        }

        public class UpdateBasketItemQuantityAction : IAction
        {
            public UpdateBasketItemQuantityAction(BasketItem value, int quantity)
            {
                Value = value;
                Quantity = quantity;
            }

            public BasketItem Value { get; set; }
            public int Quantity { get; set; }
        }

        public class RemoveBasketItemAction : IAction
        {
            public RemoveBasketItemAction(BasketItem value)
            {
                Value = value;
            }

            public BasketItem Value { get; set; }
        }

        public class ClearBasketAction : IAction
        {
        }

        public class ToggleNavMenuAction : IAction
        {
        }

        public class PlaceOrderAction : IAction
        {
            public PlaceOrderAction(CheckoutState value)
            {
                Value = value;
            }

            public CheckoutState Value { get; set; }
        }
    }
}
