using System;
using System.Collections.Generic;
using System.Text;

namespace AssemblyBrowserTestBuild
{
    public class Test
    {
        private int a;
        public int b;

        public int c { get; set; }
        private int d { get; }

        public void Addition(int a, int b)
        {

        }

        private int Submission(int a, int b)
        {
            return 0;
        }
    }


    public class test2
    {
        public void test()
        {
            Test t = new Test();
        }
    }
}
