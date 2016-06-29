using System;

namespace AnatomiaTestu
{
    class Program
    {
        static void Main()
        {
            RunTest(Test1);
        }

        private static void Test1()
        {
            var a = 10;
            var b = 20;
            var result = MyFunction(a, b);

            AreEqual("60", result);
        }

        private static string MyFunction(int a, int b)
        {
            return ((a + b) * 2).ToString();
        }


        private static void AreEqual(string expected, string result)
        {
            if (result != expected)
            {
                throw new Exception("Are not equal");
            }
        }

        private static void RunTest(Action action)
        {
            try
            {
                action();
                var oldColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Succeed");
                Console.ForegroundColor = oldColor;
            }
            catch (Exception)
            {
                var oldColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Fail");
                Console.ForegroundColor = oldColor;
            }
        }
    }
}
