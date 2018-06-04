using Calculator.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Implementation
{
    public class NormalCalculator : ICalculator
    {
        public int sum(int a, int b)
        {
            return a + b;
        }
    }
}
