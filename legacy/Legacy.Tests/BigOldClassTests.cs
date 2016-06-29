using System;
using System.Collections.Generic;
using FluentAssertions;
using NSubstitute;
using TDD.Legacy;
using Xunit;

namespace Legacy.Tests
{
    public class BigOldClassTests
    {
        private readonly BigOldClass _sut;

        public BigOldClassTests()
        {
            _sut = new BigOldClass();
        }

        [Fact]
        public void When_manager_has_no_costs_then_should_accept_it()
        {
            var travel = Substitute.For<ITravel>();
            travel.Person.IsManager.Returns(true);
            travel.Expenses.Returns(new List<IExpense>());

            var result = _sut.CanAcceptTravelExpenses(travel);

            result.Should().BeTrue();
        }

        [Fact]
        public void When_manager_has_costs_lower_than_5000_then_should_accept_it()
        {
            var travel = Substitute.For<ITravel>();
            travel.Person.IsManager.Returns(true);
            travel.Expenses.Returns(new List<IExpense>
            {
                new Expense { Value = 500}
            });

            var result = _sut.CanAcceptTravelExpenses(travel);

            result.Should().BeTrue();
        }

        [Fact]
        public void When_manager_has_costs_above_5000_should_not_accept_it()
        {
            var travel = Substitute.For<ITravel>();
            travel.Person.IsManager.Returns(true);
            travel.Expenses.Returns(new List<IExpense>
            {
                new Expense { Value = 5000},
                new Expense { Value = 500}
            });

            var result = _sut.CanAcceptTravelExpenses(travel);

            result.Should().BeFalse();
        }

        [Fact]
        public void When_normal_person_has_no_cost_then_it_should_accept_it()
        {
            var travel = Substitute.For<ITravel>();
            travel.Person.IsManager.Returns(false);
            travel.Expenses.Returns(new List<IExpense>());

            var result = _sut.CanAcceptTravelExpenses(travel);

            result.Should().BeTrue();
        }

        [Fact]
        public void When_person_works_less_than_year_cannot_accept_expenses()
        {
            var travel = Substitute.For<ITravel>();
            travel.Person.IsManager.Returns(false);
            travel.Person.Hired.Returns(DateTime.Now.AddDays(-364));
            travel.Expenses.Returns(new List<IExpense>());

            var result = _sut.CanAcceptTravelExpenses(travel);

            result.Should().BeFalse();
        }

        [Fact]
        public void When_person_works_over_a_year_and_expenses_under_1k_should_accept_costs()
        {
            var travel = Substitute.For<ITravel>();
            travel.Person.IsManager.Returns(false);
            travel.Person.Hired.Returns(DateTime.Now.AddYears(-2));
            travel.Expenses.Returns(new List<IExpense>
            {
                new Expense
                {
                    Value = 600
                }
            });

            var result = _sut.CanAcceptTravelExpenses(travel);

            result.Should().BeTrue();
        }

        [Fact]
        public void When_person_works_over_a_year_and_has_expenses_over_1000_should_not_accept()
        {
            var travel = Substitute.For<ITravel>();
            travel.Person.IsManager.Returns(false);
            travel.Person.Hired.Returns(DateTime.Now.AddYears(-2));
            travel.Expenses.Returns(new List<IExpense>
            {
                new Expense
                {
                    Value = 600
                },
                 new Expense {
                    Value = 600
                }

            });

            var result = _sut.CanAcceptTravelExpenses(travel);

            result.Should().BeFalse();
        }

        [Fact]
        public void When_person_has_expenses_over_1k_but_600_is_for_transport_then_should_accept_it()
        {
            var travel = Substitute.For<ITravel>();
            travel.Person.IsManager.Returns(false);
            travel.Person.Hired.Returns(DateTime.Now.AddYears(-2));
            travel.Expenses.Returns(new List<IExpense>
            {
                new Expense
                {
                    Value = 600,
                    Transport = true
                },
                 new Expense {
                    Value = 600
                }

            });

            var result = _sut.CanAcceptTravelExpenses(travel);

            result.Should().BeTrue();
        }

    }
}
