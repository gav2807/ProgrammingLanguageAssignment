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
    public class LoopTests
    {
        [TestMethod()]
        public void LoopTest()
        {
            int value = 10;
            int variable = 5;
            string operatorValue = ">";
            bool loopValue = true;

            Loop loop = new Loop();
            loop.set(loopValue, variable, value, operatorValue);

            Assert.IsFalse(loop.checkLoopLogic());

        }
    }
}