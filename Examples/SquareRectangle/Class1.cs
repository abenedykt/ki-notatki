namespace SquareRectangle
{
    public class Rectangle : Square
    {
        public double B { get; }

        public Rectangle(double a, double b) : base(a)
        {
            B = b;
        }

        public new double Obwod()
        {
            return (A+B)*2;
        }
    
    }

    public class Square
    {
        public double A { get; }

        public Square(double a)
        {
            A = a;
        }

        public double Obwod()
        {
            return 4*A;
        }

        public double Pole()
        {
            return A*A;
        }
    }
}
