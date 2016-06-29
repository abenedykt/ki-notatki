using System.Collections.Generic;
using FluentAssertions;
using NSubstitute;
using PizzaCore;
using Xunit;

namespace PizzaTests
{

    public class OrderTests
    {
        private readonly IOrderItem _validItem;
        private readonly Order _order;

        public OrderTests()
        {
            _validItem = Substitute.For<IOrderItem>();
            _validItem.IsValid().Returns(true);
            _order = new Order();
        }

        [Fact]
        public void Order_should_contain_only_valid_pizzas_to_be_valid()
        {
            _order.Add(_validItem);
            _order.IsValid().Should().BeTrue();
        }

        [Fact]
        public void Order_should_not_be_valid_when_at_least_one_item_is_not_valid()
        {
            _order.Add(_validItem);
            IOrderItem invalidItem = new InvalidItem();
            _order.Add(invalidItem);
            _order.IsValid().Should().BeFalse();
        }

        [Fact]
        public void Payment_returns_a_list_of_costs_per_person()
        {
            _order.AddTestPizza(40)
                .WithOrder("Arek", 4)
                .WithOrder("Marek", 2)
                .WithOrder("Jarek", 2);
            _order.AddTestPizza(20)
                .WithOrder("Marek", 5)
                .WithOrder("Darek", 3);

            var result = _order.SplitBill();

            var arek = result[0];
            arek.Name.Should().Be("Arek");
            arek.Value.Should().Be(20);
            var marek = result[1];
            marek.Name.Should().Be("Marek");
            marek.Value.Should().Be(22.50);
            var jarek = result[2];
            jarek.Name.Should().Be("Jarek");
            jarek.Value.Should().Be(10);
            var darek = result[3];
            darek.Name.Should().Be("Darek");
            darek.Value.Should().Be(7.50);
        }

        private class InvalidItem : IOrderItem
        {
            public bool IsValid()
            {
                return false;
            }

            public List<IBillItem> SplitBill()
            {
                throw new System.NotImplementedException();
            }
        }
    }

    public static class OrderTestExtensions
    {
        public static Pizza AddTestPizza(this Order order,double price)
        {
            var pizza = new Pizza(price);
            order.Add(pizza);
            return pizza;
        }

        public static Pizza WithOrder(this Pizza pizza, string name, int slices)
        {
            var eater = new Eater(name);
            pizza.OrderSlice(eater,slices);

            return pizza;
        }
    }
}