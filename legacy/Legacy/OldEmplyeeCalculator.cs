namespace TDD.Legacy
{
    public class OldEmplyeeCalculator : IExpenseCalculator
    {
        private readonly ITravel _travel;

        public OldEmplyeeCalculator(ITravel travel)
        {
            _travel = travel;

        }

        public bool Calculate()
        {
            var total = 0.0;
            // ReSharper disable once LoopCanBeConvertedToQuery
            foreach (var expense in _travel.Expenses)
            {
                if (!expense.Transport)
                {
                    total += expense.Value;
                }
            }
            return total <= 1000;
        }
    }
}