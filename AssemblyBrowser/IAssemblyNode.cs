using System;
using System.Collections.Generic;
using System.Text;

namespace AssemblyBrowser
{
    public interface IAssemblyNode
    {
        public string Name { get; set; }
        public List<IAssemblyNode> Nodes { get; }
    }
}
