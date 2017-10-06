using System;
using System.Collections.Generic;
using System.Text;
using RealFizzBuzz.Pipes;
using Xunit;

namespace RealFizzBuzz.Tests.Pipes
{
    public class NumberSubstitutePipeTests
    {
        [Theory]
        [MemberData(nameof(CheckTestData))]
        public void Number_substitute_check_passes_for_expected_numbers(int target, int input, bool expected)
        {
            IPipe pipe = new NumberSubstitutePipe(target, string.Empty);

            bool actual = pipe.Check(input);

            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> CheckTestData => new[]
            {
                new object[] { 3, 1, false },
                new object[] { 3, 2, false },
                new object[] { 3, 3, true  },
                new object[] { 3, 4, false },
                new object[] { 5, 1, false },
                new object[] { 5, 2, false },
                new object[] { 5, 3, false },
                new object[] { 5, 4, false },
                new object[] { 5, 5, true  }
            };
    }
}
