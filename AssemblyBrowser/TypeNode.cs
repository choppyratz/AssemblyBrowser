using System;
using System.Collections.Generic;
using System.Text;

namespace AssemblyBrowser
{
    public class TypeNode : IAssemblyNode
    {
        public string Name { get; set; }
        public List<IAssemblyNode> Nodes { get; }

        internal TypeNode(Type type)
        {
            Name = type.Name;
            Nodes = new List<IAssemblyNode>();
        }

        public override bool Equals(object obj)
        {
            return Name == obj.GetType().Name;
        }
    }
}
