using System.Linq;

namespace TDD.Legacy
{
    public class ManagerCalculator : IExpenseCalculator
    {
        private readonly ITravel _travel;

        public ManagerCalculator(ITravel travel)
        {
            _travel = travel;
        }

        public bool Calculate()
        {
            var total = _travel.Expenses.Sum(expense => expense.Value);

            return total <= 5000;
        }
    }
}