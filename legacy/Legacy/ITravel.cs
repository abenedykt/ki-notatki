using System.Collections.Generic;

namespace TDD.Legacy
{
    public interface ITravel
    {
        List<IExpense> Expenses { get; set; }
        IPerson Person { get; set; }
    }
}