using System.Threading;
using Xunit;

namespace ClassLibrary1
{
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public override string ToString()
        {
            return $"{Name} {Surname}".Trim();
        }
    }

    public class PersonTest
    {
        [Fact]
        public void PersonNameSurnameTest()
        {
            var p = new Person
            {
                Surname = "Benedykt"
            };
            var result = p.ToString();

            Assert.Equal(result, "Benedykt");



        }
    }
}
