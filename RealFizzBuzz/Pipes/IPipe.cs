using System;
using System.Collections.Generic;
using System.Text;

namespace RealFizzBuzz.Pipes
{
    public interface IPipe
    {
        bool Check(int number);

        string Process(int number);
    }
}
