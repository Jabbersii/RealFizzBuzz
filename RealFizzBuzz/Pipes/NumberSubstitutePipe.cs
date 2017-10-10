using System;
using System.Collections.Generic;
using System.Text;

namespace RealFizzBuzz.Pipes
{
    public class NumberSubstitutePipe : IPipe
    {
        private readonly int target;
        private readonly string substitute;

        public NumberSubstitutePipe(int target, string substitute)
        {
            this.target = target;
            this.substitute = substitute;
        }

        public bool Check(int number) => number % this.target == 0;

        public string Process(int number) => this.substitute;
    }
}
