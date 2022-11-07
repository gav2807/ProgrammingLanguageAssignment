using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguageAssignment
{
    public class Circle : Shapes
    {
        public int radius;

        public Circle(int radius, int x, int y, Pen pen, SolidBrush brush) : base(x, y, pen, brush)
        {
            this.radius = radius;
        }


        /// <summary>
        /// This method draws a circle
        /// </summary>
        /// <param name="g"></param>
        public void Draw(Graphics g)
        {
            float xPosition = (x - (radius / 2)) + 2;
            float yPosition = (y - (radius / 2)) + 2;

            g.DrawEllipse(pen, xPosition, yPosition, radius, radius);
            g.FillEllipse(brush, xPosition, yPosition, radius, radius);
        }
    }
}
