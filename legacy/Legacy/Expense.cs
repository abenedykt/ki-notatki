namespace TDD.Legacy
{
    public class Expense : IExpense
    {
        public string DateTime { get; set; }
        public string Description { get; set; }
        public double Value { get; set; }
        public bool Transport { get; set; }
    }
}