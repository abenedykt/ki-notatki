namespace TDD.Legacy
{
    public interface IExpense
    {
        string DateTime { get; set; }
        string Description { get; set; }
        bool Transport { get; set; }
        double Value { get; set; }
    }
}