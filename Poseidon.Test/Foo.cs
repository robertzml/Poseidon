using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Test
{
    public class Foo
    {
        private int a = 1;

        public int Sum(int b)
        {
            return a + b;
        }

        public void Set(int s)
        {
            a = s;
        }

        public int Get()
        {
            return a;
        }
    }
}
