using Microsoft.VisualStudio.TestTools.UnitTesting;
using AssemblyBrowser;
using System.Collections.Generic;

namespace AssemblyBrowserUnitTests
{
    [TestClass]
    public class UnitTest1
    {

        private List<IAssemblyNode> tree;
        [TestInitialize]
        public void SetUp()
        {
            var asmB = new AsmBrowser();
            tree = asmB.getInfo("AssemblyBrowserTestBuild.dll");
        }

        [TestMethod]
        public void TestNamespacesNames()
        {
            Assert.AreEqual(tree[0].Name, "AssemblyBrowserTestBuild");
        }

        [TestMethod]
        public void TestTypesNames()
        {
            Assert.AreEqual(tree[0].Nodes[0].Name, "Test");
        }

        [TestMethod]
        public void TestTypesContent()
        {
            Assert.AreEqual(tree[0].Nodes[0].Nodes[0].Name, "Int32 get_c()");
        }
    }
}
