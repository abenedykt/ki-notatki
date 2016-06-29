using System.Linq;
using FluentAssertions;
using PizzaCore;
using Xunit;

namespace PizzaTests
{
    public class PizzaTests
    {
        private const string EaterName = "Jan";
        private const string Eater2Name = "Marek";
        private readonly Pizza _pizza;
        private readonly Eater _eater;
        private readonly Eater _eater2;

        public PizzaTests()
        {
            _pizza = new Pizza(40);
            _eater = new Eater(EaterName);
            _eater2 = new Eater(Eater2Name);
        }

        [Fact]
        public void When_eater_add_order_it_should_be_included_in_pizza()
        {
            _pizza.OrderSlice(_eater, 3);

            _pizza.OrderedSlices.Should().Be(3);
        }

        [Fact]
        public void When_eater_add_another_order_it_is_added_to_pizza()
        {
            _pizza.OrderSlice(_eater, 2);
            _pizza.OrderSlice(_eater, 4);

            _pizza.OrderedSlices.Should().Be(4);
        }

        [Fact]
        public void Pizza_is_valid_when_has_8_slices_ordered()
        {

            var eater1 = new Eater("");
            var eater2 = new Eater("");
            var eater3 = new Eater("");

            _pizza.OrderSlice(eater1, 4);
            _pizza.OrderSlice(eater2, 2);
            _pizza.OrderSlice(eater3, 2);

            _pizza.IsValid().Should().BeTrue();
        }

        [Fact]
        public void Pizza_is_not_valid_when_does_not_have_exacy_8()
        {
            _pizza.OrderSlice(_eater, 4);

            _pizza.IsValid().Should().BeFalse();
        }

        [Fact]
        public void Cannot_create_bill_when_pizza_is_not_valid()
        {
            _pizza.OrderSlice(_eater, 3);

            Assert.Throws<CannotSplitInvalidPizza>(() => _pizza.SplitBill().ToList());
        }

        [Fact]
        public void When_pizza_is_valid_then_should_return_bill_positions()
        {
            _pizza.OrderSlice(_eater, 3);
            _pizza.OrderSlice(_eater2, 5);

            var result = _pizza.SplitBill().ToList();
            result[0].Name.Should().Be(EaterName);
            result[0].Value.Should().Be(15);

            result[1].Value.Should().Be(25);
            result[1].Name.Should().Be(Eater2Name);
        }
    }

}

