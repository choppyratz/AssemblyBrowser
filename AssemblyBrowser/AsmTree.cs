using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;
using System.Runtime.CompilerServices;

namespace AssemblyBrowser
{
    class AsmTree
    {
        private List<IAssemblyNode> Tree = new List<IAssemblyNode>();
        private Assembly _assembly;
        private IAssemblyNode TreeNode = null;

        public AsmTree(Assembly asm)
        {
            _assembly = asm;
        }

        public List<IAssemblyNode> CreateTree()
        {
            Type[] types = _assembly.GetTypes();
            foreach (var t in types)
            {
                NamespaceNode npNode = new NamespaceNode(t);
                if (Tree.IndexOf(npNode) >= 0)
                {
                    npNode = Tree[Tree.IndexOf(npNode)] as NamespaceNode;
                }
                else
                {
                    Tree.Add(npNode);
                }
                TreeNode = npNode;

                TypeNode tNode = new TypeNode(t);
                if (npNode.Nodes.IndexOf(tNode) >= 0)
                {
                    tNode = npNode.Nodes[npNode.Nodes.IndexOf(tNode)] as TypeNode;
                }
                else
                {
                    npNode.Nodes.Add(tNode);
                }

                MethodInfo[] methods = t.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.DeclaredOnly);

                List<MethodInfo> ext = GetExtensionMethods(methods);
                List<IAssemblyNode> tExt = new List<IAssemblyNode> { };
                foreach (var temp in ext)
                {
                    var extMethod = new MethodNode(temp);
                    extMethod.Name += " (extension method)";
                    tExt.Add(extMethod);
                    var tempList = methods.ToList();
                    tempList.Remove(temp);
                    methods = tempList.ToArray();
                }
                TypeNode tn = FindExtendedType(Tree, ext) as TypeNode;
                tn?.Nodes.AddRange(tExt);

                tNode.Nodes.AddRange(methods.Select(item => new MethodNode(item)).ToList());



                PropertyInfo[] properties = t.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.DeclaredOnly);
                tNode.Nodes.AddRange(properties.Select(item => new PropertyNode(item)).ToList());

                FieldInfo[] fields = t.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.DeclaredOnly);
                tNode.Nodes.AddRange(fields.Select(item => new FieldNode(item)).ToList());
            }
            return Tree;
        }
        public List<MethodInfo> GetExtensionMethods(MethodInfo[] methods)
        {

            var query = from method in methods
                        where method.IsDefined(typeof(ExtensionAttribute), false)
                        select method;
            return query.ToList();

        }

        public IAssemblyNode FindExtendedType(List<IAssemblyNode> tree, List<MethodInfo> extMethods)
        {
            if (extMethods.Count == 0)
            {
                return null;
            }

            foreach (var t in extMethods)
            {
                foreach (var nS in tree)
                {
                   
                    foreach (var tS in nS.Nodes)
                    {
                        if (new TypeNode(extMethods[0].GetParameters()[0].ParameterType).Name == tS.Name)
                        {
                            return tS;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
            return null;
        }
    }
}
