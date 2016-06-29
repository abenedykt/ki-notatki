namespace TDD.Legacy
{
    public class BigOldClass
    {
        public bool CanAcceptTravelExpenses(ITravel travel)
        {
            var factory = new ExpenseFactory();
            var calculator = factory.GetFor(travel);
            return calculator.Calculate();
        }
    }
}
