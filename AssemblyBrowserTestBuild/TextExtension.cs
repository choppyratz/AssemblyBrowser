using System;
using System.Collections.Generic;
using System.Text;

namespace AssemblyBrowserTestBuild
{
    public static class TextExtension
    {
        public static int Division(this Test t, int a, int b)
        {
            return a / b;
        }
    }
}
