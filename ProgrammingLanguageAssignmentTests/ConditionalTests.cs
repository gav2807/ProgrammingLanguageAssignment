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
    public class ConditionalTests
    {
        [TestMethod()]
        public void ConditionalTest()
        {
            int value = 10;
            int variable = 5;
            string operatorValue = ">";
            bool If = true;

            Conditional conditional = new Conditional();
            conditional.set(If, variable, value, operatorValue);

            Assert.IsFalse(conditional.checkIfLogic());

        }
    }
}