namespace TDD.Legacy
{
    public class NullCalculator : IExpenseCalculator
    {
        public bool Calculate()
        {
            return false;
        }
    }
}