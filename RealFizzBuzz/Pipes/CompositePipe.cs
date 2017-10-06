using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RealFizzBuzz.Pipes
{
    public class CompositePipe : IPipe
    {
        private readonly IPipe[] pipes;

        public CompositePipe(params IPipe[] pipes)
        {
            if (pipes.Length == 0)
            {
                throw new ArgumentException("Must specify 1 or more pipes", nameof(pipes));
            }

            this.pipes = pipes;
        }

        public bool Check(int number)
        {
            return pipes.All(p => p.Check(number));
        }

        public string Process(int number)
        {
            return pipes.Select(p => p.Process(number)).Aggregate((s1, s2) => s1 + s2);
        }
    }
}
