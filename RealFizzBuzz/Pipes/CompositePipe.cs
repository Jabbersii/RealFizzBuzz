using System;
using System.Collections.Generic;
using System.Text;

namespace RealFizzBuzz.Pipes
{
    public class CompositePipe : IPipe
    {
        public CompositePipe(params IPipe[] pipes)
        {

        }

        public bool Check(int number)
        {
            throw new NotImplementedException();
        }

        public string Process(int number)
        {
            throw new NotImplementedException();
        }
    }
}
