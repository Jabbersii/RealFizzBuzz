using RealFizzBuzz.Pipes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RealFizzBuzz
{
    class Program
    {
        static void Main(string[] args)
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

            var runner = new Runner(Enumerable.Range(1, 20), pipes);
            foreach (var item in runner.Run())
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
