using System;

namespace TDD.Legacy
{
    public interface IPerson
    {
        DateTime Hired { get; set; }
        bool IsManager { get; set; }
        string Name { get; set; }
        string Surname { get; set; }
    }
}