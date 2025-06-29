using System;
using NUnit.Framework;

namespace CalculatorApp
{
    public class Calculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
    }

    [TestFixture]
    public class CalculatorTests
    {
        private Calculator _calculator;

        [SetUp]
        public void SetUp()
        {
            _calculator = new Calculator();
        }

        [TearDown]
        public void TearDown()
        {
            _calculator = null;
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Console.WriteLine();
            Console.WriteLine("|   a  |   b  | actual | expected |");
            Console.WriteLine("-------------------------------------");
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Console.WriteLine();
        }

        [Test]
        [TestCase(2, 3, 5)]
        [TestCase(0, 0, 0)]
        [TestCase(-2, -3, -5)]
        public void Add_WhenCalled_ReturnsExpectedResult(int a, int b, int expected)
        {
            var result = _calculator.Add(a, b);
            Console.WriteLine($"| {a,4} | {b,4} | {result,6} | {expected,8} |");
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [Ignore("Demo only - This test is ignored.")]
        public void IgnoredTest()
        {
            Assert.Fail("This should not run.");
        }
    }
}
