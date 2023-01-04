using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProgrammingLanguageAssignment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguageAssignment.Tests
{
    [TestClass()]
    public class VariableTests
    {
        [TestMethod()]
        public void VariableTest()
        {
            int value = 10;
            string name = "size";
            int index = 0;

            Variable variable = new Variable();
            variable.set(value, name, index);

            Assert.IsTrue(variable.getVariableValue().Contains(value));
            Assert.IsTrue(variable.getVariableName().Contains(name));

        }
    }
}