using System;

namespace TDD.Legacy
{
    public class ExpenseFactory
    {
        public IExpenseCalculator GetFor(ITravel travel)
        {
            if (travel.Person.IsManager)
            {
                return new ManagerCalculator(travel);
            }
            if (WorksOverAYear(travel))
            {
                return new OldEmplyeeCalculator(travel);
            }

            return new NullCalculator();
        }

        private static bool WorksOverAYear(ITravel travel)
        {
            return DateTime.Now.Subtract(travel.Person.Hired).TotalDays >= 365;
        }
    }
}