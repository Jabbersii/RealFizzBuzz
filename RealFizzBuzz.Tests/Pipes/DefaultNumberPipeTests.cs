using RealFizzBuzz.Pipes;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RealFizzBuzz.Tests.Pipes
{
    public class DefaultNumberPipeTests
    {
        [Theory]
        [MemberData(nameof(TestData))]
        public void Number_pipe_returns_ToString_result_on_input(int input, string expected)
        {
            IPipe pipe = new DefaultNumberPipe();
            string actual = pipe.Process(input);

            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> TestData => new[]
        {
            new object[] { 1, "1" },
            new object[] { 3, "3" },
            new object[] { -1, "-1" },
            new object[] { 0, "0" }
        };
    }
}
