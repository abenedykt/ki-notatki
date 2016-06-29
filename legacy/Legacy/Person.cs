using System;

namespace TDD.Legacy
{
    public class Person : IPerson
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool IsManager { get; set; }
        public DateTime Hired { get; set; }
    }
}
