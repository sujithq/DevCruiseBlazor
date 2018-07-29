﻿using BlazorRedux;
using DevCruise.Blazor.Shared;

namespace DevCruise.Blazor.Client.Shared.Pages.Code
{
    public class BasketComponent : ReduxComponent<MyState, IAction>
    {
        public void RemoveBasketItem(BasketItem item)
        {
            Dispatch(new Actions.RemoveBasketItemAction(item));
        }

        public void SizeItemChanged(BasketItem item, string size)
        {
            Dispatch(new Actions.UpdateBasketItemSizeAction(item,size));
        }
        public void QuantityItemChanged(BasketItem item, int quantity)
        {
            Dispatch(new Actions.UpdateBasketItemQuantityAction(item,quantity));
        }


    }
}