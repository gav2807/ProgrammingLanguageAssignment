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
    public class RectangleTests
    {
        [TestMethod()]
        public void RectangleTest()
        {
            int x = 10;
            int y = 10;
            int[] list = new int[] { 50, 50 };

            Pen pen = new Pen(Color.Black);
            SolidBrush brush = new SolidBrush(Color.Black);
            Rectangle rectangle = new Rectangle();
            rectangle.set(x, y, pen, brush, list);

            Assert.AreEqual(list[0], rectangle.width);
            Assert.AreEqual(list[1], rectangle.height);
        }

    }
}