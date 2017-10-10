using RealFizzBuzz.Pipes;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RealFizzBuzz.Tests.Pipes
{
    public class ContainsPipeTests
    {
        [Theory]
        [MemberData(nameof(CheckTestsData))]
        public void Contains_pipe_check_passes_correctly(int input, bool expected)
        {
            IPipe pipe = new ContainsPipe(3, string.Empty);

            Assert.Equal(expected, pipe.Check(input));
        }

        public static IEnumerable<object[]> CheckTestsData = new[]
        {
            new object[] { 3,   true  },
            new object[] { 2,   false },
            new object[] { 30,  true  },
            new object[] { 20,  false },
            new object[] { 32,  true  },
            new object[] { 300, true  },
            new object[] { 302, true  },
            new object[] { 200, false }
        };
    }
}
