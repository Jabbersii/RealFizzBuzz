using System;
using System.Collections.Generic;
using System.Text;

namespace RealFizzBuzz.Pipes
{
    public class DefaultNumberPipe : IPipe
    {
        public bool Check(int number) => true;

        public string Process(int number) => number.ToString();
    }
}
