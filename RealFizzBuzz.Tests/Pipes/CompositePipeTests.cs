using System;
using System.Collections.Generic;
using System.Text;
using RealFizzBuzz.Pipes;
using Xunit;
using System.Linq;

namespace RealFizzBuzz.Tests.Pipes
{
    public class CompositePipeTests
    {
        [Fact]
        public void No_pipes_ctor_throws_exception()
        {
            Assert.Throws<ArgumentException>(() => new CompositePipe());
        }

        [Fact]
        public void True_only_pipes_returns_true_on_check()
        {
            var pipe = new CompositePipe(new TruePipe(), new TruePipe(), new TruePipe());

            for (int i = 0; i < 20; i++)
            {
                Assert.True(pipe.Check(i));
            }
        }

        [Fact]
        public void False_only_pipes_returns_false_on_check()
        {
            var pipe = new CompositePipe(new FalsePipe(), new FalsePipe(), new FalsePipe());

            for (int i = 0; i < 20; i++)
            {
                Assert.False(pipe.Check(i));
            }
        }

        [Fact]
        public void False_and_true_pipes_returns_false_on_check()
        {
            var pipe = new CompositePipe(new TruePipe(), new FalsePipe(), new TruePipe());

            for (int i = 0; i < 20; i++)
            {
                Assert.False(pipe.Check(i));
            }
        }

        [Theory]
        [MemberData(nameof(ConcatPipes))]
        public void Pipe_returns_concatenation_of_composed_pipes(IPipe[] pipes, string expected)
        {
            var pipe = new CompositePipe(pipes);
            Assert.Equal(expected, pipe.Process(0));
        }

        public static IEnumerable<object[]> ConcatPipes => new[]
        {
            new object[]{ new IPipe[] { new TruePipe(), new FalsePipe() }, "truefalse" },
            new object[]{ new IPipe[] { new FalsePipe(), new TruePipe() }, "falsetrue" },
            new object[]{ new IPipe[] { new FalsePipe(), new FalsePipe() }, "falsefalse" },
            new object[]{ new IPipe[] { new TruePipe(), new TruePipe() }, "truetrue" }
        };
    }
}
