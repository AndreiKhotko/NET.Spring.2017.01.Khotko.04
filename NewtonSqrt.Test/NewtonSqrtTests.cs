using System;
using NUnit.Framework;
using NewtonSqrt;

namespace NewtonSqrt.Test
{
    [TestFixture]
    public class NewtonSqrtTests
    {
        [TestCase(81, 2, 0.001)]
        [TestCase(125.505, 3, 0.01)]
        [TestCase(200, 5, 0.001)]
        [TestCase(625, 4, 1)]
        public void RootN_PositiveXAnyN_PositiveResult(double x, int n, double precition)
        {
            double expected = Math.Pow(x, (double)1 / n);
            double actual = NewtonSqrt.RootN(x, n, precition);

            Assert.That(expected, Is.EqualTo(actual).Within(precition));
        }

        [TestCase(-81, 1, 0.001)]
        [TestCase(-81, 3, 0.00001)]
        [TestCase(-81, 5, 0.0001)]
        public void RootN_NegativeXOddN_PositiveResult(double x, int n, double precition)
        {
            double expected = -Math.Pow(-x, (double)1 / n);
            double actual = NewtonSqrt.RootN(x, n, precition);

            Assert.That(expected, Is.EqualTo(actual).Within(precition));
        }

        [TestCase(-81, 2, 0.001)]
        [TestCase(-125.505, 4, 0.01)]
        [TestCase(-200, 6, 0.0001)]
        public void RootN_NegativeXEvenN_ThrowsArgumentException(double x, int n, double precition)
        {
            Assert.Throws<ArgumentException>(() => NewtonSqrt.RootN(x, n, precition));
        }

        [TestCase(81, 2, 2)]
        [TestCase(81, 2, -1)]
        public void RootN_PrecitionIsNotBetweenZeroAndOne_ThrowsArgumentException(double x, int n, double precition)
        {
            Assert.Throws<ArgumentException>(() => NewtonSqrt.RootN(x, n, precition));
        }
    }
}
