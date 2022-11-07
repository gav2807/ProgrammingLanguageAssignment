using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguageAssignment
{
    public class Rectangle : Shapes
    {
        public int width, height;

        public Rectangle(int width, int height, int x, int y, Pen pen, SolidBrush brush) : base(x, y, pen, brush)
        {
            this.width = width;
            this.height = height;
        }


        /// <summary>
        /// This method draws a rectangle
        /// </summary>
        /// <param name="g"></param>
        public void Draw(Graphics g)
        {
            float xPosition = (x - (width / 2)) + 2;
            float yPosition = (y - (height / 2)) + 2;

            g.DrawRectangle(pen, xPosition, yPosition, width, height);
            g.FillRectangle(brush, xPosition, yPosition, width, height);
        }
    }
}
