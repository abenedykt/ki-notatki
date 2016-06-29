using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaCore
{
    public class Pizza : IOrderItem
    {
        private readonly double _price;
        private readonly Dictionary<Eater, int> _orders;

        public Pizza(double price)
        {
            _price = price;
            _orders = new Dictionary<Eater, int>(8);
        }

        public void OrderSlice(Eater eater, int slices)
        {
            if (_orders.ContainsKey(eater))
            {
                _orders[eater] = slices;
            }
            else
            {
                _orders.Add(eater, slices);
            }
        }

        public int OrderedSlices => _orders.Sum(s => s.Value);

        public bool IsValid()
        {
            return OrderedSlices == 8;
        }

        public List<IBillItem> SplitBill()
        {
            if (!IsValid()) throw new CannotSplitInvalidPizza();

            var unitPrice = _price/8;
            return _orders.Select(order => new BillItem
            {
                Name = order.Key.Name,
                Value = order.Value*unitPrice
            }).Cast<IBillItem>().ToList();
        }
    }

    public class CannotSplitInvalidPizza : Exception
    {
    }

    public interface IBill
    {
        bool Succeed { get; }
        IEnumerable<IBillItem> Items { get; }
    }
}