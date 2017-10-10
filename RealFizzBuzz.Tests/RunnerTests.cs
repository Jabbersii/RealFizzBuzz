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
        public void Runner_returns_correct_fizzbuzz_result()
        {
            var fizz = new NumberSubstitutePipe(3, "fizz");
            var buzz = new NumberSubstitutePipe(5, "buzz");
            var fizzbuzz = new CompositePipe(fizz, buzz);
            var defaultPipe = new DefaultNumberPipe();

            List<IPipe> pipes = new List<IPipe>()
            {
                fizzbuzz,
                fizz,
                buzz,
                defaultPipe
            };

            var runner = new Runner(Enumerable.Range(1, 15), pipes);
            IList<string> actual = runner.Run().ToList();
            IList<string> expected = FizzBuzz.ToList();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Runner_returns_correct_fizzbuzzlucky_result()
        {
            var lucky = new ContainsPipe(3, "lucky");
            var fizz = new NumberSubstitutePipe(3, "fizz");
            var buzz = new NumberSubstitutePipe(5, "buzz");
            var fizzbuzz = new CompositePipe(fizz, buzz);
            var defaultPipe = new DefaultNumberPipe();

            List<IPipe> pipes = new List<IPipe>()
            {
                lucky,
                fizzbuzz,
                fizz,
                buzz,
                defaultPipe
            };

            var runner = new Runner(Enumerable.Range(1, 15), pipes);
            IList<string> actual = runner.Run().ToList();
            IList<string> expected = FizzBuzzLucky.ToList();

            Assert.Equal(expected, actual);
        }

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

        public static IEnumerable<string> FizzBuzz = new string[]
        {
            "1", "2", "fizz", "4", "buzz", "fizz", "7", "8", "fizz", "buzz", "11", "fizz", "13", "14", "fizzbuzz"
        };

        public static IEnumerable<string> FizzBuzzLucky = new string[]
        {
            "1", "2", "lucky", "4", "buzz", "fizz", "7", "8", "fizz", "buzz", "11", "fizz", "lucky", "14", "fizzbuzz"
        };
    }
}
