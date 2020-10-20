using System;
using System.Collections.Generic;
using System.Reflection;

namespace AssemblyBrowser
{
    public class AsmBrowser
    {
        public List<IAssemblyNode> getInfo(string fName)
        {
            AsmTree asm = new AsmTree(Assembly.LoadFrom(fName));
            return asm.CreateTree();
        }
    }
}
