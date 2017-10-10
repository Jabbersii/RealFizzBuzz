using System;
using System.Collections.Generic;
using System.Text;

namespace RealFizzBuzz.Pipes
{
    public class ContainsPipe : IPipe
    {
        private readonly int target;
        private readonly string substitute;

        public ContainsPipe(int target, string substitute)
        {
            this.target = target;
            this.substitute = substitute;
        }

        public bool Check(int number)
        {
            while (number != 0)
            {
                if (number % 10 == target)
                {
                    return true;
                }
                else
                {
                    number = number / 10;
                }
            }

            return false;
        }

        public string Process(int number) => this.substitute;
    }
}
