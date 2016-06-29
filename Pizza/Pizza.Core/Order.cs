using System.Collections.Generic;
using System.Linq;

namespace PizzaCore
{
    public class Order
    {
        private readonly List<IOrderItem> _items;

        public Order()
        {
            _items = new List<IOrderItem>();
        }

        public void Add(IOrderItem orderItem)
        {
            _items.Add(orderItem);
        }

        public bool IsValid()
        {
            return _items.All(i => i.IsValid());
        }

        // do zap³aty -> arek 30, marek 20, jarek 15
        public IList<IBillItem> SplitBill()
        {
            var bill = new List<IBillItem>();
            foreach (var orderItem in _items)
            {
                bill.AddRange(orderItem.SplitBill());
            }

            return bill.GroupBy(i=>i.Name).Select(cs=> new BillItem
            {
                Name = cs.First().Name,
                Value = cs.Sum(c=>c.Value)
            }).Cast<IBillItem>().ToList();
        }
    }

    public class BillItem : IBillItem
    {
        public double Value { get; set; }
        public string Name { get; set; }
    }

    public interface IBillItem
    {
        double Value { get; set; }
        string Name { get; set; }
    }
}