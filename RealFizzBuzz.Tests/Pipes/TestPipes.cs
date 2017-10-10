using RealFizzBuzz.Pipes;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealFizzBuzz.Tests.Pipes
{
    internal class TruePipe : IPipe
    {
        public bool Check(int number) => true;
        public string Process(int number) => "true";
    }

    internal class FalsePipe : IPipe
    {
        public bool Check(int number) => false;
        public string Process(int number) => "false";
    }
}
