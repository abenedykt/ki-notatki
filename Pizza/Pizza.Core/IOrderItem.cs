using System.Collections.Generic;

namespace PizzaCore
{
    public interface IOrderItem
    {
        bool IsValid();
        List<IBillItem> SplitBill();
    }
}