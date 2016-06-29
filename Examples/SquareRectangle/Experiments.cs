using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace SquareRectangle
{
    public class Experiments
    {
        [Fact]
        public void TestName()
        {
            var x = new Rectangle(5,10);
            Square sqr = x;
            Rectangle rect = x;

            sqr.Obwod().Should().Be(rect.Obwod());
        }
    }



    public class Clojure
    {
        public IEnumerable<int> Run(int i)
        {
            return  Enumerable.Range(0, i).Where(n=> n%2 == 0);
        }
    }




}
