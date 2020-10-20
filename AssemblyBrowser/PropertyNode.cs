using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace AssemblyBrowser
{
    public class PropertyNode : IAssemblyNode
    {
        public string Name { get; set; }
        public List<IAssemblyNode> Nodes { get; }

        public PropertyNode(PropertyInfo property)
        {
            Name = property.PropertyType.Name + " " + property.Name;
            Nodes = null;
        }
    }
}
