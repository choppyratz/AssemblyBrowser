using System;
using System.Collections.Generic;
using System.Text;

namespace AssemblyBrowser
{
    public class NamespaceNode : IAssemblyNode
    {
        public string Name { get; set; }
        public List<IAssemblyNode> Nodes { get; }

        internal NamespaceNode(Type type)
        {
            Name = type.Namespace;
            Nodes = new List<IAssemblyNode>();
        }

        public override bool Equals(object obj)
        {
            return (obj as NamespaceNode).Name == this.Name;
        }
    }
}
