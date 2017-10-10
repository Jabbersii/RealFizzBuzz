using RealFizzBuzz.Pipes;
using RealFizzBuzz.Tests.Pipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace RealFizzBuzz.Tests
{
    public class RunnerTests
    {
        [Fact]
        public void No_pipes_supplied_throws_exception()
        {
            Assert.Throws<ArgumentException>(() => new Runner(Enumerable.Empty<int>(), new List<IPipe>()));
        }

        [Theory]
        [MemberData(nameof(TestPipes))]
        public void Pipes_are_evaluated_in_correct_order(IList<IPipe> pipes, string expected)
        {
            var runner = new Runner(Enumerable.Range(1, 1), pipes);
            foreach (var item in runner.Run())
            {
                Assert.Equal(expected, item);
            }
        }

        public static IEnumerable<object[]> TestPipes = new[]
        {
            new object[] 
            {
                new List<IPipe>() { new TruePipe(), new FalsePipe() },
                "true"
            },
            new object[]
            {
                new List<IPipe>() { new FalsePipe(), new NumberSubstitutePipe(1, "NUMBER") },
                "NUMBER"
            },
            new object[]
            {
                new List<IPipe>() { new TruePipe(), new NumberSubstitutePipe(1, "NUMBER") },
                "true"
            },
            new object[]
            {
                new List<IPipe>() { new NumberSubstitutePipe(1, "ONE"), new TruePipe() },
                "ONE"
            }
        };
    }
}
