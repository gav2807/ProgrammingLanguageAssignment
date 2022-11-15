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
    public class TriangleTests
    {
        [TestMethod()]
        public void TriangleTest()
        {
            int x = 10;
            int y = 10;
            int[] list = new int[] { 50 };

            Pen pen = new Pen(Color.Black);
            SolidBrush brush = new SolidBrush(Color.Black);
            Triangle triangle = new Triangle();
            triangle.set(x, y, pen, brush, list);

            Assert.AreEqual(list[0], triangle.sides);
        }
    }
}