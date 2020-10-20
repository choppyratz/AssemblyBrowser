using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace AssemblyBrowser
{
    public class FieldNode : IAssemblyNode
    {
        public string Name { get; set; }
        public List<IAssemblyNode> Nodes { get; }

        internal FieldNode(FieldInfo field)
        {
            Name = field.FieldType.Name + " " + field.Name;
            Nodes = null;
        }
    }
}
