using RealFizzBuzz.Pipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RealFizzBuzz
{
    public class Runner
    {
        private readonly IEnumerable<int> source;
        private readonly IList<IPipe> pipes;

        public Runner(IEnumerable<int> source, IList<IPipe> pipes)
        {
            if (pipes.Count == 0)
            {
                throw new ArgumentException("Must supply at least 1 pipe", nameof(pipes));
            }

            this.source = source;
            this.pipes = pipes;
        }

        public IEnumerable<string> Run()
        {
            foreach (var item in source)
            {
                var pipe = pipes.First(p => p.Check(item));
                yield return pipe.Process(item);
            }
        }
    }
}
