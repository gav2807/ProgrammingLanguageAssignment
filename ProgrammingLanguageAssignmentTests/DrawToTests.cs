using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProgrammingLanguageAssignment;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguageAssignment.Tests
{
    [TestClass()]
    public class DrawToTests
    {
        [TestMethod()]
        public void DrawToTest()
        {
            int x = 10;
            int y = 10;
            int[] list = new int[] { 50, 50 };

            Pen pen = new Pen(Color.Black);
            SolidBrush brush = new SolidBrush(Color.Black);
            DrawTo drawTo = new DrawTo();
            drawTo.set(x, y, pen, brush, list);

            Assert.AreEqual(list[0], drawTo.start);
            Assert.AreEqual(list[1], drawTo.end);
        }
    }
}